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
        SetupListViewService.SetupListViewForVehicles(listView, 60, 350, 350)
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
        SetupListViewService.SetupListViewForVehicles(listView, 30, 135, 85)
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
        SetupListViewService.SetupListViewForServices(listView, 60, 310, 310, 80)
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
        SetupListViewService.SetupListViewForServices(listView, 30, 85, 85, 50)
        listView.Font = New Font("Century Gothic", 9, FontStyle.Regular)

        ' 4. FORCE the original parent/form to recalculate its layout.
        originalParent.Refresh()
    End Sub
End Class
