Public Class AddVehicleToListView
    Public Shared nextServiceID As Integer = 1
    Public Shared VehicleList As New List(Of VehicleService)
    Public Shared Sub AddVehicleFunction(listView As ListView, textBoxVehicle As TextBox, textBoxPlateNumber As TextBox)
        If String.IsNullOrWhiteSpace(textBoxVehicle.Text) OrElse String.IsNullOrWhiteSpace(textBoxPlateNumber.Text) Then
            MessageBox.Show("Please enter both the Vehicle Type and the Plate Number.", "Missing Vehicle Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' check if the current ListView does have any data if not then ID will be 1 else increment by 1
        ' 1. Get the current ID and increment the counter
        If listView.Items.Count = 0 Then
            nextServiceID = 1
        ElseIf listView.Items.Count > 0 Then
            nextServiceID = listView.Items.Count + 1

        End If
        Dim currentID As Integer = nextServiceID
        nextServiceID += 1 ' Increment the counter for the next line item

        Dim plateNumber As String = textBoxPlateNumber.Text.Trim()
        Dim vehicleType As String = textBoxVehicle.Text.Trim()

        ' 2. Create the new service, passing the current ID
        Dim newVehicle As New VehicleService(currentID, plateNumber, vehicleType)

        VehicleList.Add(newVehicle)

        ' 3. Add the ID as the FIRST column in the ListView
        Dim lvi As New ListViewItem(newVehicle.ID.ToString())
        lvi.SubItems.Add(newVehicle.VehicleType)
        lvi.SubItems.Add(newVehicle.PlateNumber)
        listView.Items.Add(lvi)

        textBoxVehicle.Clear()
        textBoxPlateNumber.Clear()
        textBoxVehicle.Focus()
    End Sub

    Public Shared Sub RemoveSelectedVehicle(listView As ListView)
        If listView.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a vehicle from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected ListViewItem
        Dim selectedItem As ListViewItem = listView.SelectedItems(0)

        ' Get the Plate Number, which is used as the unique key to match the object in VehicleList
        Dim selectedIndex As Integer = selectedItem.Index

        If selectedIndex >= 0 AndAlso selectedIndex < VehicleList.Count Then

            ' 2. Remove the service object from the internal list based on index
            VehicleList.RemoveAt(selectedIndex)

            ' 3. Remove the item from the visual ListView control
            ' (This step is technically optional since we clear and re-add below, but good practice)
            listView.Items.Remove(selectedItem)

            ' 4. After removing, we must re-load and re-number the entire list
            ' This ensures the IDs (1, 2, 3...) remain sequential without gaps.

            ' Get the current list of remaining services
            ' Using ToList() creates a copy, so we can manipulate the original SaleServiceList safely below.
            Dim remainingServices As List(Of VehicleService) = VehicleList.ToList()

            ' Clear the UI and internal list (before re-adding)
            listView.Items.Clear()
            VehicleList.Clear() ' Clear the internal list so we can rebuild it with the same items

            ' Now, iterate through the remaining items and re-add them with new sequential IDs
            Dim listItemIDCounter As Integer = 1
            For Each vehicle As VehicleService In remainingServices
                VehicleList.Add(vehicle) ' Re-add to the internal list

                ' Create the ListView item with the new sequential ID
                Dim lvi As New ListViewItem(listItemIDCounter.ToString())
                lvi.SubItems.Add(vehicle.VehicleType)
                lvi.SubItems.Add(vehicle.PlateNumber)
                listView.Items.Add(lvi)

                listItemIDCounter += 1
            Next

            ' 5. Update the global counter for new additions
            nextServiceID = listItemIDCounter
            MessageBox.Show($"Vehicle with Plate {selectedItem} removed successfully from the list.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"Could not find the selected vehicle in the internal list. Please try again. your want to remove from the ID is{selectedItem}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub
End Class
