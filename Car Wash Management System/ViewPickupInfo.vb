Imports System.IO
Imports System.Windows.Forms
Imports System.Threading.Tasks
Imports System.Text

Public Class ViewPickupInfo

    Inherits BaseForm
    Private ReadOnly _parentCustomerForm As Object

    Public Sub New(parentForm As Object)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        _parentCustomerForm = parentForm
    End Sub

    Private WithEvents DebounceTimer As New Timer()
    Private Const DEBOUNCE_DELAY_MS As Integer = 800 ' Wait 800ms after the last keypress

    ' The manually declared WebBrowser control
    Private WithEvents WebBrowserMap As New System.Windows.Forms.WebBrowser()

    ' Flag to ensure the HTML document is loaded before calling JavaScript
    Private IsDocumentLoaded As Boolean = False

    Private Sub ViewPickupInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CenterToScreen()
        TextBoxCarwashAddress.Text = "14.529822264353477, 121.08387548216851".Trim
        ' ***************************************************************
        ' Setup: Add the WebBrowserMap control to the Panel 
        ' ASSUMPTION: You have a Panel control on your form named 'ViewWebBrowserMapPanel'
        ' ***************************************************************

        Dim panelControl As Control = Me.Controls.Find("ViewWebBrowserMapPanel", True).FirstOrDefault()

        If panelControl IsNot Nothing AndAlso TypeOf panelControl Is Panel Then
            WebBrowserMap.Dock = DockStyle.Fill
            WebBrowserMap.ScriptErrorsSuppressed = True ' Hide script error dialogs
            DirectCast(panelControl, Panel).Controls.Add(WebBrowserMap)
            WebBrowserMap.BringToFront()
        Else
            ' Fallback if panel is not found.
            WebBrowserMap.Size = New Size(600, 400)
            WebBrowserMap.Location = New Point(10, 10)
            Me.Controls.Add(WebBrowserMap)
        End If

        ' Initialize the debounce timer
        DebounceTimer.Interval = DEBOUNCE_DELAY_MS
        DebounceTimer.Stop()

        ' Load the local HTML file
        Dim htmlPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MapAddressView.html")

        If File.Exists(htmlPath) Then
            WebBrowserMap.Navigate(htmlPath)
        Else
            MessageBox.Show($"Map file not found at: {htmlPath}. Please ensure MapAddressView.html is in the same directory as the executable.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub WebBrowserMap_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowserMap.DocumentCompleted
        If e.Url.LocalPath.EndsWith("MapAddressView.html", StringComparison.OrdinalIgnoreCase) Then
            IsDocumentLoaded = True
            ' Perform the initial map load using the current address text
            LoadMap()
        End If
    End Sub
    ''' <summary>
    ''' Calls the JavaScript function inside the WebBrowser control to update the map route.
    ''' </summary>
    Private Sub LoadMap()

        If Not IsDocumentLoaded OrElse WebBrowserMap.Document Is Nothing Then
            Exit Sub
        End If

        Dim pickupAddressText As String = ""
        Dim carwashAddressText As String = ""

        Try
            ' --- CRITICAL FIX: SWAPPING ADDRESS ROLES ---

            ' 1. Get the text for the Pickup Location (Source of the vehicle journey)
            ' This is assumed to be the textbox labeled "Pickup Address" on the form.
            Dim pickupBox As Control = Me.Controls.Find("TextBoxPickupAddress", True).FirstOrDefault()
            If pickupBox IsNot Nothing AndAlso TypeOf pickupBox Is TextBox Then
                pickupAddressText = DirectCast(pickupBox, TextBox).Text.Trim()
            End If

            ' 2. Get the text for the Carwash/Delivery Location (Destination of the vehicle journey)
            ' This is assumed to be the textbox labeled "Location" on the form.
            ' NOTE: If your "Location" textbox is named differently, update the line below.
            Dim carwashBox As Control = Me.Controls.Find("TextBoxCarwashAddress", True).FirstOrDefault()
            If carwashBox IsNot Nothing AndAlso TypeOf carwashBox Is TextBox Then
                carwashAddressText = DirectCast(carwashBox, TextBox).Text.Trim()
            End If

        Catch ex As Exception
            Console.WriteLine($"Error accessing address TextBoxes: {ex.Message}")
            Exit Sub
        End Try

        ' Ensure we have both addresses before attempting to draw a route
        If String.IsNullOrWhiteSpace(pickupAddressText) OrElse String.IsNullOrWhiteSpace(carwashAddressText) Then
            Console.WriteLine("One or both address fields are empty. Route cannot be calculated.")
            ' Still call the JS function with potentially empty strings to clear old markers/route
            WebBrowserMap.Document.InvokeScript("updateMapRoute", New Object() {pickupAddressText, carwashAddressText})
            Exit Sub
        End If

        ' Call the new JavaScript function updateMapRoute 
        ' CRITICAL: Order must be (Start Address, End Address)
        Try
            WebBrowserMap.Document.InvokeScript("updateMapRoute", New Object() {pickupAddressText, carwashAddressText})

        Catch ex As Exception
            Console.WriteLine($"Error invoking script: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Handles the TextBoxPickupAddress TextChanged event. 
    ''' </summary>
    Private Sub TextBoxPickupAddress_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPickupAddress.TextChanged
        ' Restart the timer on any keystroke in the Pickup box
        DebounceTimer.Stop()
        DebounceTimer.Start()
    End Sub
    ''' <summary>
    ''' Handles the TextBoxCarwashAddress TextChanged event. 
    ''' </summary>
    Private Sub TextBoxCarwashAddress_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCarwashAddress.TextChanged
        ' Restart the timer on any keystroke in the Carwash box
        DebounceTimer.Stop()
        DebounceTimer.Start()


    End Sub
    ''' <summary>
    ''' This fires when the timer expires (the user has stopped typing for the delay period).
    ''' </summary>
    Private Sub debounceTimer_Tick(sender As Object, e As EventArgs) Handles DebounceTimer.Tick
        DebounceTimer.Stop()
        ' Now that the user has stopped typing, load the map route
        LoadMap()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateAddress()
    End Sub

    Private Sub UpdateAddress()
        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Pickup Address Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub

        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
            LabelPickupID,
            TextBoxPickupAddress,
            errorHandler,
            pickupManagementDatabaseHelper
            )
        If success Then

            _parentCustomerForm.ViewPickupData()
        End If
    End Sub

    Private Sub ViewWebBrowserMapPanel_Paint(sender As Object, e As PaintEventArgs) Handles ViewWebBrowserMapPanel.Paint

    End Sub
End Class