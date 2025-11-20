Imports System.IO
Imports System.Windows.Forms
Imports System.Threading.Tasks

Public Class ViewPickupInfo

    ' CRITICAL FIX 1: Add WithEvents keyword to allow the Handles clause to work.
    ' This is the reference to the control used to display the HTML map
    Private WithEvents WebViewMap As New WebBrowser()

    ' CRITICAL FIX 2: Add WithEvents keyword for the Timer.
    ' Timer used for debouncing the address input (prevents too many API calls while typing)
    Private WithEvents debounceTimer As New Timer()

    ' The actual TextBox control reference found on the form
    Private addressTextBox As TextBox = Nothing


    ' --- SETUP AND INITIALIZATION ---
    Private Sub ViewPickupInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()

        ' 1. CRITICAL FIX: Suppress script errors that often pop up in WebBrowser controls
        WebViewMap.ScriptErrorsSuppressed = True

        ' 2. **CRITICAL FIX: Add and position the WebBrowser control**
        '    Assuming you want the map to fill a large area of the form.
        '    You might need to adjust the Location and Size/Dock property based on your designer layout.
        With WebViewMap
            .Dock = DockStyle.Fill ' Fill the entire parent container (the Form, in this case)
            .Visible = True
        End With

        ' **VERY IMPORTANT: Add the control to the Form's Controls collection**
        ' If you are using a Container (like a Panel or GroupBox) to hold the map, 
        ' replace 'Me.Controls' with 'YourPanelName.Controls'.
        Me.Controls.Add(WebViewMap)

        ' Ensure the WebViewMap is sent to the back, so other controls (like buttons/textboxes) are visible.
        WebViewMap.SendToBack()

        ' 3. Find the TextBoxPickupAddress control dynamically
        Dim textBoxControl As Control = Me.Controls.Find("TextBoxPickupAddress", True).FirstOrDefault()

        If textBoxControl IsNot Nothing AndAlso TypeOf textBoxControl Is TextBox Then
            ' 4. Store the casted reference
            addressTextBox = DirectCast(textBoxControl, TextBox)

            ' 5. Attach the event handler once. 
            AddHandler addressTextBox.TextChanged, AddressOf TextBoxPickupAddress_TextChanged

            ' 6. Setup the debounce timer (waits 1 second after typing stops to update the map)
            With debounceTimer
                .Interval = 1000 ' 1 second delay
                .Stop()
            End With

            ' 7. Perform the initial map update using the current text
            UpdateMapFromTextBox(addressTextBox.Text)

        Else
            Console.WriteLine("Error: TextBoxPickupAddress control not found on the form.")
        End If

        ' 8. This is where the MapAddressView.html is loaded into the WebViewMap
        Dim htmlPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MapAddressView.html")
        If File.Exists(htmlPath) Then
            WebViewMap.Navigate(htmlPath)
        Else
            ' Fallback if the file copy step was missed
            Console.WriteLine("Error: MapAddressView.html not found at execution path. Check project build settings.")
        End If
    End Sub


    ' --- DEBOUNCING AND EVENT HANDLERS ---

    ' Event handler for the TextBox (triggered on every key stroke)
    Private Sub TextBoxPickupAddress_TextChanged(sender As Object, e As EventArgs)
        ' Reset and start the timer when text changes
        debounceTimer.Stop()
        debounceTimer.Start()
    End Sub

    ' Event handler for the Timer (triggered 1 second after typing stops)
    Private Sub DebounceTimer_Tick(sender As Object, e As EventArgs) Handles debounceTimer.Tick
        ' Stop the timer immediately
        debounceTimer.Stop()

        ' Check if we have a valid reference to the address TextBox
        If addressTextBox IsNot Nothing Then
            UpdateMapFromTextBox(addressTextBox.Text)
        End If
    End Sub

    ' --- MAIN MAP UPDATE FUNCTION ---

    ''' <summary>
    ''' Calls the JavaScript function inside the WebBrowser control to update the map.
    ''' </summary>
    ''' <param name="address">The address text to be geocoded.</param>
    Private Sub UpdateMapFromTextBox(address As String)
        If WebViewMap.ReadyState = WebBrowserReadyState.Complete Then
            Try
                ' This is the critical line that calls the JavaScript function:
                ' "updateMapLocation" is the JS function name.
                ' The second argument is the address string (which must be a safe, quoted string).
                WebViewMap.Document.InvokeScript("updateMapLocation", New Object() {address})

                Console.WriteLine($"Map update requested for: {address}")
            Catch ex As Exception
                Console.WriteLine("Error invoking JavaScript: " & ex.Message)
            End Try
        Else
            ' If the map isn't loaded yet, try again after a short delay (or wait for the DocumentCompleted event)
            Console.WriteLine("Map not ready, deferring update.")
        End If
    End Sub

    ' Correct the argument type for the DocumentCompleted event.
    Private Sub WebViewMap_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebViewMap.DocumentCompleted
        ' Re-run the update logic when the map finishes loading to ensure the initial address is set.
        If addressTextBox IsNot Nothing Then
            UpdateMapFromTextBox(addressTextBox.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class