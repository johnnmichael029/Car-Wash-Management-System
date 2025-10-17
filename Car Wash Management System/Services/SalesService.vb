﻿Public Class SalesService
    Public Property ServiceID As Integer
    Public Property Price As Decimal
    Public Property Addon As String
    Public Property Service As String
    Public Property ServicePrice As Decimal

    Public Sub New()
        ' Parameterless constructor for object initialization
    End Sub

    ' --- Corrected Parameterized Constructor ---
    ' NOTE: I swapped the assignments below to match the intent (plateNum goes to PlateNumber property).
    Public Sub New(service As String, addon As String, servicePrice As Decimal)
        Me.Addon = addon       ' Corrected assignment
        Me.Service = service    ' Corrected assignment
        Me.ServicePrice = servicePrice
    End Sub

    ' Optional: Override ToString for easy debugging or displaying in simple ListBoxes
    Public Overrides Function ToString() As String
        Return $"Service: {Service}, Addon: {Addon}, Price: {ServicePrice}"
    End Function
End Class
