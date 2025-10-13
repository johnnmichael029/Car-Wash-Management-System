Public Class VehicleService
    Public Property PlateNumber As String
    Public Property VehicleType As String

    ' --- FIX 1: Add a Parameterless Constructor to allow "New VehicleService() With {...}" ---
    Public Sub New()
        ' Parameterless constructor for object initialization
    End Sub

    ' --- Corrected Parameterized Constructor ---
    ' NOTE: I swapped the assignments below to match the intent (plateNum goes to PlateNumber property).
    Public Sub New(plateNum As String, vehicleType As String)
        Me.PlateNumber = plateNum       ' Corrected assignment
        Me.VehicleType = vehicleType    ' Corrected assignment
    End Sub

    ' Optional: Override ToString for easy debugging or displaying in simple ListBoxes
    Public Overrides Function ToString() As String
        Return $"Plate: {PlateNumber}, Type: {VehicleType}"
    End Function
End Class
