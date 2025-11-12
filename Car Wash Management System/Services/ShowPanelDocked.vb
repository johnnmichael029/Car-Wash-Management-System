Public Class ShowPanelDocked
    Public Shared Sub ShowVehiclePanelDocked(panel As Panel, listView As ListView)
        Dim dockForm As New ViewVehiclesDetailsInFullScreen()

        ' Store original dock setting and parent for restoration
        Dim originalParent As Control = panel.Parent
        Dim originalDock As DockStyle = panel.Dock

        ' Remove from original parent
        panel.Parent = Nothing

        ' Add to the new dock form
        panel.Parent = dockForm.VehicleInfoDockPanel
        panel.Dock = DockStyle.Fill
        SetupListViewForVehicles(listView, 380, 380)
        listView.Font = New Font("Century Gothic", 12, FontStyle.Regular)

        ' !!! CRITICAL CHANGE: This line BLOCKS execution until the user closes dockForm.
        dockForm.ShowDialog()

        ' ---------------------------------------------------------------------------------
        ' !!! CLEANUP MOVED HERE: When execution reaches this point, dockForm is already CLOSED.
        ' ---------------------------------------------------------------------------------

        ' 1. Detach from dock form 
        panel.Parent = Nothing

        ' 2. Re-attach the panel to its original parent control.
        originalParent.Controls.Add(panel)

        ' 3. Restore original dock setting
        panel.Dock = originalDock

        ' (Optional) Restore the List View size for the smaller panel
        SetupListViewForVehicles(listView, 150, 100)
        listView.Font = New Font("Century Gothic", 9, FontStyle.Regular)

        ' 4. FORCE the original parent/form to recalculate its layout.
        originalParent.Refresh()
    End Sub
    Public Shared Sub ShowServicesPanelDocked(panel As Panel, listView As ListView)
        Dim dockForm As New ViewVehiclesDetailsInFullScreen()

        ' Store original dock setting and parent for restoration
        Dim originalParent As Control = panel.Parent
        Dim originalDock As DockStyle = panel.Dock

        ' Remove from original parent
        panel.Parent = Nothing

        ' Add to the new dock form
        panel.Parent = dockForm.VehicleInfoDockPanel
        panel.Dock = DockStyle.Fill
        SetupListViewForServices(listView, 60, 310, 310, 80)
        listView.Font = New Font("Century Gothic", 12, FontStyle.Regular)

        ' !!! CRITICAL CHANGE: This line BLOCKS execution until the user closes dockForm.
        dockForm.ShowDialog()

        ' ---------------------------------------------------------------------------------
        ' !!! CLEANUP MOVED HERE: When execution reaches this point, dockForm is already CLOSED.
        ' ---------------------------------------------------------------------------------

        ' 1. Detach from dock form 
        panel.Parent = Nothing

        ' 2. Re-attach the panel to its original parent control.
        originalParent.Controls.Add(panel)

        ' 3. Restore original dock setting
        panel.Dock = originalDock

        ' (Optional) Restore the List View size for the smaller panel
        SetupListViewForServices(listView, 30, 85, 85, 50)
        listView.Font = New Font("Century Gothic", 9, FontStyle.Regular)

        ' 4. FORCE the original parent/form to recalculate its layout.
        originalParent.Refresh()
    End Sub
    Public Shared Sub SetupListViewForVehicles(listVIew As ListView, widthPlateNumber As Integer, widthVehicleType As Integer)
        listVIew.View = View.Details
        listVIew.HeaderStyle = ColumnHeaderStyle.Nonclickable
        listVIew.Columns.Clear()
        listVIew.Columns.Add("Plate Number", widthPlateNumber, HorizontalAlignment.Left)
        listVIew.Columns.Add("Vehicle Type", widthVehicleType, HorizontalAlignment.Left)
        listVIew.GridLines = True
        listVIew.FullRowSelect = True
    End Sub

    Public Shared Sub SetupListViewForServices(listVIew As ListView, widthID As Integer, widthService As Integer, widthAddon As Integer, widthPrice As Integer)
        listVIew.View = View.Details
        listVIew.HeaderStyle = ColumnHeaderStyle.Nonclickable
        listVIew.Columns.Clear()
        listVIew.Columns.Add("ID", widthID, HorizontalAlignment.Left)
        listVIew.Columns.Add("Service", widthService, HorizontalAlignment.Left)
        listVIew.Columns.Add("Addon", widthAddon, HorizontalAlignment.Left)
        listVIew.Columns.Add("Price", widthPrice, HorizontalAlignment.Left)
        listVIew.GridLines = True
        listVIew.FullRowSelect = True
    End Sub
End Class
