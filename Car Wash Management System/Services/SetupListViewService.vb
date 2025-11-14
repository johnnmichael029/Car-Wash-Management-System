Public Class SetupListViewService
    Public Shared Sub SetupListViewForServices(listVIewServices As ListView, widthID As Integer, widthService As Integer, widthAddon As Integer, widthPrice As Integer)
        listVIewServices.View = View.Details
        listVIewServices.HeaderStyle = ColumnHeaderStyle.Nonclickable
        listVIewServices.Columns.Clear()
        listVIewServices.Columns.Add("ID", widthID, HorizontalAlignment.Left)
        listVIewServices.Columns.Add("Service", widthService, HorizontalAlignment.Left)
        listVIewServices.Columns.Add("Addon", widthAddon, HorizontalAlignment.Left)
        listVIewServices.Columns.Add("Price", widthPrice, HorizontalAlignment.Left)
        listVIewServices.GridLines = True
        listVIewServices.FullRowSelect = True
    End Sub
    Public Shared Sub SetupListViewForVehicles(listVIewVehicles As ListView, witdhID As Integer, widthPlateNumber As Integer, widthVehicleType As Integer)
        listVIewVehicles.View = View.Details
        listVIewVehicles.HeaderStyle = ColumnHeaderStyle.Nonclickable
        listVIewVehicles.Columns.Clear()
        listVIewVehicles.Columns.Add("ID", witdhID, HorizontalAlignment.Left) ' Hidden ID column
        listVIewVehicles.Columns.Add("Plate Number", widthPlateNumber, HorizontalAlignment.Left)
        listVIewVehicles.Columns.Add("Vehicle Type", widthVehicleType, HorizontalAlignment.Left)
        listVIewVehicles.GridLines = True
        listVIewVehicles.FullRowSelect = True
    End Sub
End Class
