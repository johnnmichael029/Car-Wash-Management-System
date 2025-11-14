Public Class LoadService
    Public Shared Sub LoadServicesIntoListViewSalesForm(salesID As Integer, listViewServices As ListView)
        listViewServices.Items.Clear()
        AddSaleToListView.SaleServiceList.Clear()
        Dim serviceList As List(Of SalesService) = SalesDatabaseHelper.GetSalesServiceList(salesID)
        Dim listItemIDCounter As Integer = 1

        For Each service As SalesService In serviceList

            AddSaleToListView.SaleServiceList.Add(service)
            Dim lvi As New ListViewItem(listItemIDCounter.ToString())

            lvi.SubItems.Add(service.Service)
            lvi.SubItems.Add(service.Addon)
            lvi.SubItems.Add(service.ServicePrice.ToString("N2"))

            listViewServices.Items.Add(lvi)
            listItemIDCounter += 1
        Next
        AddSaleToListView.nextServiceID = listItemIDCounter
    End Sub

    Public Shared Sub LoadServicesIntoListViewAppointmentForm(AppointmentID As Integer, listViewServices As ListView)
        listViewServices.Items.Clear()
        AddSaleToListView.AppointmentServiceList.Clear()
        Dim serviceList As List(Of AppointmentService) = AppointmentManagementDatabaseHelper.GetSalesServiceList(AppointmentID)
        Dim listItemIDCounter As Integer = 1
        For Each service As AppointmentService In serviceList

            AddSaleToListView.AppointmentServiceList.Add(service)
            Dim lvi As New ListViewItem(listItemIDCounter.ToString())

            lvi.SubItems.Add(service.Service)
            lvi.SubItems.Add(service.Addon)
            lvi.SubItems.Add(service.ServicePrice.ToString("N2"))

            listViewServices.Items.Add(lvi)
            listItemIDCounter += 1

        Next
        AddSaleToListView.nextServiceID = listItemIDCounter
    End Sub
    Public Shared Sub LoadServicesIntoListViewContractForm(AppointmentID As Integer, listViewServices As ListView)
        listViewServices.Items.Clear()
        AddSaleToListView.ContractServiceList.Clear()
        Dim serviceList As List(Of ContractsService) = ContractsDatabaseHelper.GetSalesServiceList(AppointmentID)
        Dim listItemIDCounter As Integer = 1
        For Each service As ContractsService In serviceList

            AddSaleToListView.ContractServiceList.Add(service)
            Dim lvi As New ListViewItem(listItemIDCounter.ToString())

            lvi.SubItems.Add(service.Service)
            lvi.SubItems.Add(service.Addon)
            lvi.SubItems.Add(service.ServicePrice.ToString("N2"))

            listViewServices.Items.Add(lvi)
            listItemIDCounter += 1

        Next
        AddSaleToListView.nextServiceID = listItemIDCounter
    End Sub
    Public Shared Sub LoadVehiclesIntoListViewCustomerFOrm(customerID As Integer, listViewServices As ListView)
        ' 1. Clear the list view on the child form
        listViewServices.Items.Clear()
        ' 2. Clear the internal master list on THIS form
        AddVehicleToListView.VehicleList.Clear()

        Dim vehicles As List(Of VehicleService) = CustomerInformationDatabaseHelper.GetCustomerVehicles(customerID)
        Dim listItemIDCounter As Integer = 1
        For Each service As VehicleService In vehicles
            ' Add to the master list (Me.VehicleList)
            AddVehicleToListView.VehicleList.Add(service)

            ' Create ListView Item for the child form's ListView
            Dim lvi As New ListViewItem(listItemIDCounter.ToString())
            lvi.SubItems.Add(service.VehicleType)
            lvi.SubItems.Add(service.PlateNumber)

            listViewServices.Items.Add(lvi)
            listItemIDCounter += 1
        Next
        AddVehicleToListView.nextServiceID = listItemIDCounter
    End Sub
End Class
