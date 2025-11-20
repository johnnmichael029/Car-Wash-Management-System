Public Class AddSaleToListView
    Public Shared nextServiceID As Integer = 1 ' Counter for unique service IDs
    Public Shared SaleServiceList As New List(Of SalesService)
    Public Shared AppointmentServiceList As New List(Of AppointmentService)
    Public Shared ContractServiceList As New List(Of ContractsService)
    Public Shared PickupServiceList As New List(Of PickupService)

    ' Method to add a service to the sale
    Public Shared Sub AddSaleService(comboBoxServices As ComboBox, comboBoxAddons As ComboBox, textBoxPrice As TextBox, listViewServices As ListView)
        If String.IsNullOrWhiteSpace(comboBoxServices.Text) Then
            MessageBox.Show("Please enter service.", "Missing Service Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 1. Get the current ID and prepare the next one
        Dim currentID As Integer = nextServiceID
        nextServiceID += 1 ' Increment the counter for the next line item

        Dim services As String = comboBoxServices.Text.Trim()
        Dim addons As String = comboBoxAddons.Text.Trim()

        ' Use TryParse for safer decimal conversion
        Dim price As Decimal
        If Not Decimal.TryParse(textBoxPrice.Text, price) Then
            MessageBox.Show("Invalid price value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 2. Create the new service, passing the current ID
        Dim newService As New SalesService(currentID, services, addons, price)

        SaleServiceList.Add(newService)

        ' 3. Add the ID as the FIRST column in the ListView
        Dim lvi As New ListViewItem(newService.ID.ToString()) ' ID is the main item text

        ' Add the rest of the columns as sub-items
        lvi.SubItems.Add(newService.Service)        ' Service
        lvi.SubItems.Add(newService.Addon)          ' Addon 
        lvi.SubItems.Add(newService.ServicePrice.ToString("N2")) ' Price
        listViewServices.Items.Add(lvi)

        comboBoxServices.SelectedIndex = -1
        comboBoxAddons.SelectedIndex = -1
        textBoxPrice.Text = "0.00"
    End Sub

    ' Method to remove the selected service from the sale
    Public Shared Sub RemoveSelectedService(listViewServices As ListView)
        If listViewServices.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a service from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedItem As ListViewItem = listViewServices.SelectedItems(0)

        ' Get the 0-based index of the selected item in the ListView
        Dim selectedIndex As Integer = selectedItem.Index

        ' 1. Check if the index is valid for our tracking list
        If selectedIndex >= 0 AndAlso selectedIndex < SaleServiceList.Count Then

            ' 2. Remove the service object from the internal list based on index
            SaleServiceList.RemoveAt(selectedIndex)

            ' 3. Remove the item from the visual ListView control
            ' (This step is technically optional since we clear and re-add below, but good practice)
            listViewServices.Items.Remove(selectedItem)

            ' 4. After removing, we must re-load and re-number the entire list
            ' This ensures the IDs (1, 2, 3...) remain sequential without gaps.

            ' Get the current list of remaining services
            ' Using ToList() creates a copy, so we can manipulate the original SaleServiceList safely below.
            Dim remainingServices As List(Of SalesService) = SaleServiceList.ToList()

            ' Clear the UI and internal list (before re-adding)
            listViewServices.Items.Clear()
            SaleServiceList.Clear() ' Clear the internal list so we can rebuild it with the same items

            ' Now, iterate through the remaining items and re-add them with new sequential IDs
            Dim listItemIDCounter As Integer = 1
            For Each service As SalesService In remainingServices
                SaleServiceList.Add(service) ' Re-add to the internal list

                ' Create the ListView item with the new sequential ID
                Dim lvi As New ListViewItem(listItemIDCounter.ToString())
                lvi.SubItems.Add(service.Service)
                lvi.SubItems.Add(service.Addon)
                lvi.SubItems.Add(service.ServicePrice.ToString("N2"))
                listViewServices.Items.Add(lvi)

                listItemIDCounter += 1
            Next

            ' 5. Update the global counter for new additions
            nextServiceID = listItemIDCounter

            MessageBox.Show($"Service (ID: {selectedItem.Text}) was removed successfully and the list was renumbered.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected service in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Methods for Contract Form
    Public Shared Sub AddSaleServiceInContractForm(comboBoxServices As ComboBox, comboBoxAddons As ComboBox, textBoxPrice As TextBox, listViewServices As ListView)
        If String.IsNullOrWhiteSpace(comboBoxServices.Text) Then
            MessageBox.Show("Please enter service.", "Missing Service Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim currentID As Integer = nextServiceID
        nextServiceID += 1

        Dim services As String = comboBoxServices.Text.Trim()
        Dim addons As String = comboBoxAddons.Text.Trim()
        Dim price As Decimal
        If Not Decimal.TryParse(textBoxPrice.Text, price) Then
            MessageBox.Show("Invalid price value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim newService As New ContractsService(currentID, services, addons, price)

        ContractServiceList.Add(newService)
        Dim lvi As New ListViewItem(newService.ID.ToString())

        lvi.SubItems.Add(newService.Service)
        lvi.SubItems.Add(newService.Addon)
        lvi.SubItems.Add(newService.ServicePrice.ToString("N2"))
        listViewServices.Items.Add(lvi)

        comboBoxServices.SelectedIndex = -1
        comboBoxAddons.SelectedIndex = -1
        textBoxPrice.Text = "0.00"
    End Sub

    ' Method to remove the selected service from the contract form
    Public Shared Sub RemoveSelectedServiceInContractForm(listViewServices As ListView)
        If listViewServices.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a service from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedItem As ListViewItem = listViewServices.SelectedItems(0)
        Dim selectedIndex As Integer = selectedItem.Index

        If selectedIndex >= 0 AndAlso selectedIndex < ContractServiceList.Count Then

            ContractServiceList.RemoveAt(selectedIndex)

            listViewServices.Items.Remove(selectedItem)
            Dim remainingServices As List(Of ContractsService) = ContractServiceList.ToList()
            listViewServices.Items.Clear()
            ContractServiceList.Clear()
            Dim listItemIDCounter As Integer = 1
            For Each service As ContractsService In remainingServices
                ContractServiceList.Add(service)
                Dim lvi As New ListViewItem(listItemIDCounter.ToString())
                lvi.SubItems.Add(service.Service)
                lvi.SubItems.Add(service.Addon)
                lvi.SubItems.Add(service.ServicePrice.ToString("N2"))
                listViewServices.Items.Add(lvi)

                listItemIDCounter += 1
            Next

            nextServiceID = listItemIDCounter

            MessageBox.Show($"Service (ID: {selectedItem.Text}) was removed successfully and the list was renumbered.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected service in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Methods for Appointment Form
    Public Shared Sub AddSaleServiceInAppointmentForm(comboBoxServices As ComboBox, comboBoxAddons As ComboBox, textBoxPrice As TextBox, listViewServices As ListView)
        If String.IsNullOrWhiteSpace(comboBoxServices.Text) Then
            MessageBox.Show("Please enter service.", "Missing Service Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim currentID As Integer = nextServiceID
        nextServiceID += 1

        Dim services As String = comboBoxServices.Text.Trim()
        Dim addons As String = comboBoxAddons.Text.Trim()
        Dim price As Decimal
        If Not Decimal.TryParse(textBoxPrice.Text, price) Then
            MessageBox.Show("Invalid price value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim newService As New AppointmentService(currentID, services, addons, price)

        AppointmentServiceList.Add(newService)
        Dim lvi As New ListViewItem(newService.ID.ToString())

        lvi.SubItems.Add(newService.Service)
        lvi.SubItems.Add(newService.Addon)
        lvi.SubItems.Add(newService.ServicePrice.ToString("N2"))
        listViewServices.Items.Add(lvi)

        comboBoxServices.SelectedIndex = -1
        comboBoxAddons.SelectedIndex = -1
        textBoxPrice.Text = "0.00"
    End Sub

    ' Method to remove the selected service from the appointment form
    Public Shared Sub RemoveSelectedServiceInAppointmentForm(listViewServices As ListView)
        If listViewServices.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a service from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedItem As ListViewItem = listViewServices.SelectedItems(0)
        Dim selectedIndex As Integer = selectedItem.Index

        If selectedIndex >= 0 AndAlso selectedIndex < AppointmentServiceList.Count Then

            AppointmentServiceList.RemoveAt(selectedIndex)

            listViewServices.Items.Remove(selectedItem)
            Dim remainingServices As List(Of AppointmentService) = AppointmentServiceList.ToList()
            listViewServices.Items.Clear()
            AppointmentServiceList.Clear()
            Dim listItemIDCounter As Integer = 1
            For Each service As AppointmentService In remainingServices
                AppointmentServiceList.Add(service)
                Dim lvi As New ListViewItem(listItemIDCounter.ToString())
                lvi.SubItems.Add(service.Service)
                lvi.SubItems.Add(service.Addon)
                lvi.SubItems.Add(service.ServicePrice.ToString("N2"))
                listViewServices.Items.Add(lvi)

                listItemIDCounter += 1
            Next

            nextServiceID = listItemIDCounter

            MessageBox.Show($"Service (ID: {selectedItem.Text}) was removed successfully and the list was renumbered.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected service in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Methods for Pickup Form
    Public Shared Sub AddSaleServiceInPickupForm(comboBoxServices As ComboBox, comboBoxAddons As ComboBox, textBoxPrice As TextBox, listViewServices As ListView)
        If String.IsNullOrWhiteSpace(comboBoxServices.Text) Then
            MessageBox.Show("Please enter service.", "Missing Service Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim currentID As Integer = nextServiceID
        nextServiceID += 1

        Dim services As String = comboBoxServices.Text.Trim()
        Dim addons As String = comboBoxAddons.Text.Trim()
        Dim price As Decimal
        If Not Decimal.TryParse(textBoxPrice.Text, price) Then
            MessageBox.Show("Invalid price value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim newService As New PickupService(currentID, services, addons, price)

        PickupServiceList.Add(newService)
        Dim lvi As New ListViewItem(newService.ID.ToString())

        lvi.SubItems.Add(newService.Service)
        lvi.SubItems.Add(newService.Addon)
        lvi.SubItems.Add(newService.ServicePrice.ToString("N2"))
        listViewServices.Items.Add(lvi)

        comboBoxServices.SelectedIndex = -1
        comboBoxAddons.SelectedIndex = -1
        textBoxPrice.Text = "0.00"
    End Sub

    ' Method to remove the selected service from the appointment form
    Public Shared Sub RemoveSelectedServiceInPickupForm(listViewServices As ListView)
        If listViewServices.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a service from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedItem As ListViewItem = listViewServices.SelectedItems(0)
        Dim selectedIndex As Integer = selectedItem.Index

        If selectedIndex >= 0 AndAlso selectedIndex < PickupServiceList.Count Then

            PickupServiceList.RemoveAt(selectedIndex)

            listViewServices.Items.Remove(selectedItem)
            Dim remainingServices As List(Of PickupService) = PickupServiceList.ToList()
            listViewServices.Items.Clear()
            PickupServiceList.Clear()
            Dim listItemIDCounter As Integer = 1
            For Each service As PickupService In remainingServices
                PickupServiceList.Add(service)
                Dim lvi As New ListViewItem(listItemIDCounter.ToString())
                lvi.SubItems.Add(service.Service)
                lvi.SubItems.Add(service.Addon)
                lvi.SubItems.Add(service.ServicePrice.ToString("N2"))
                listViewServices.Items.Add(lvi)

                listItemIDCounter += 1
            Next

            nextServiceID = listItemIDCounter

            MessageBox.Show($"Service (ID: {selectedItem.Text}) was removed successfully and the list was renumbered.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected service in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
