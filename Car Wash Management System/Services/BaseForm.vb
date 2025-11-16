
Public Class BaseForm
    Inherits Form

    Protected constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Protected ReadOnly reservationDatabaseHelper As ReservationDatabaseHelper
    Protected ReadOnly onTheDayDatabaseHelper As OnTheDayDatabaseHelper
    Protected ReadOnly activityLogInDashboardService As ActivityLogInDashboardService
    Protected ReadOnly appointmentManagementDatabaseHelper As AppointmentManagementDatabaseHelper
    Protected ReadOnly salesDatabaseHelper As SalesDatabaseHelper
    Protected ReadOnly activityLogManagement As ActivityLogManagement
    Protected ReadOnly adminDatabaseHelper As AdminDatabaseHelper
    Protected ReadOnly carwashDatabaseHelper As CarwashDatabaseHelper
    Protected ReadOnly contractsDatabaseHelper As ContractsDatabaseHelper
    Protected ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
    Protected ReadOnly listofActivityLogInDashboardDatabaseHelper As ListofActivityLogInDashboardDatabaseHelper
    Protected ReadOnly activityLogService As ActivityLogInDashboardService
    Protected ReadOnly dashboardDatabaseHelper As DashboardDatabaseHelper
    Protected ReadOnly HistoryDatabaseHelper As HistoryDatabaseHelper
    Protected ReadOnly salesAnalyticsDatabaseHelper As SalesAnalyticsDatabaseHelper
    Protected ReadOnly chartDatabaseHelper As ChartDatabaseHelper
    Public Sub New()
        ' Add any initialization after the InitializeComponent() call.
        reservationDatabaseHelper = New ReservationDatabaseHelper(constr)
        onTheDayDatabaseHelper = New OnTheDayDatabaseHelper(constr)
        activityLogInDashboardService = New ActivityLogInDashboardService(constr)
        appointmentManagementDatabaseHelper = New AppointmentManagementDatabaseHelper(constr)
        salesDatabaseHelper = New SalesDatabaseHelper(constr)
        activityLogManagement = New ActivityLogManagement(constr)
        adminDatabaseHelper = New AdminDatabaseHelper(constr)
        carwashDatabaseHelper = New CarwashDatabaseHelper(constr)
        contractsDatabaseHelper = New ContractsDatabaseHelper(constr)
        listofActivityLogInDashboardDatabaseHelper = New ListofActivityLogInDashboardDatabaseHelper(constr)
        activityLogService = New ActivityLogInDashboardService(constr)
        dashboardDatabaseHelper = New DashboardDatabaseHelper(constr)
        customerInformationDatabaseHelper = New CustomerInformationDatabaseHelper(constr)
        HistoryDatabaseHelper = New HistoryDatabaseHelper(constr)
        salesAnalyticsDatabaseHelper = New SalesAnalyticsDatabaseHelper(constr)
        chartDatabaseHelper = New ChartDatabaseHelper(constr)

    End Sub

End Class
