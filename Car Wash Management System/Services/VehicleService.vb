Public Class VehicleService
    Public Property PlateNumber As String
    Public Property VehicleType As String

    ' Constructor to easily create new vehicle objects
    ' NOTE: The form passes the arguments in the order (Vehicle Type, Plate Number).
    Public Sub New(plateNum As String, vehicleType As String)
        ' <<<< FIX 2: Swapping the assignment to match the data passed in. >>>>
        ' plateNum (Arg 1) contains the Vehicle Type from the form.
        ' vehicleType (Arg 2) contains the Plate Number from the form.
        Me.VehicleType = plateNum
        Me.PlateNumber = vehicleType
    End Sub

    ' Optional: Override ToString for easy debugging or displaying in simple ListBoxes
    Public Overrides Function ToString() As String
        Return $"Plate: {PlateNumber}, Type: {VehicleType}"
    End Function
End Class
