Public Class ActivityLogInDashboardService
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly actitvityLogDBHelper As ListofActivityLogInDashboardDatabaseHelper
    Public Sub New(connectionString As String)
        actitvityLogDBHelper = New ListofActivityLogInDashboardDatabaseHelper(constr)
    End Sub
    Public Sub AddNewCustomer(customerName As String)
        actitvityLogDBHelper.LogActivity("New Customer Added", $"A new customer '{customerName}' was added to the system.")
    End Sub
    Public Sub AddNewService(serviceName As String)
        actitvityLogDBHelper.LogActivity("New Service Added", $"A new service '{serviceName}' was added to the system.")
    End Sub
    Public Sub RecordSale(customerName As String, amount As Decimal)
        actitvityLogDBHelper.LogActivity("New Sale", $"A new sale was recorded for customer: '{customerName}'. Amount: ₱{amount:N2}")
    End Sub
    Public Sub UpdateSale(customerName As String)
        actitvityLogDBHelper.LogActivity("Sale Update", $"A sale for customer: '{customerName}' was updated.")
    End Sub
    Public Sub ScheduleAppointment(customerName As String, appointmentDate As DateTime, appointmentStatus As String)
        actitvityLogDBHelper.LogActivity("New Appointment Scheduled", $"An appointment was scheduled for customer: '{customerName}' on {appointmentDate}. status '{appointmentStatus}'")
    End Sub
    Public Sub UpdateAppointment(customerName As String)
        actitvityLogDBHelper.LogActivity("Appointment Update", $"An appointment for customer: '{customerName}' was updated.")
    End Sub
    Public Sub UpdateAppointmentStatus(customerName As String, newStatus As String)
        actitvityLogDBHelper.LogActivity("Appointment Status Update", $"An appointment was scheduled for '{customerName}' was changed to new status '{newStatus}'")
    End Sub
    Public Sub RecordActivity(customerName As String, newStatus As String)
        actitvityLogDBHelper.LogActivity("Appointment Status Update", $"An appointment was scheduled for '{customerName}' was changed to new status '{newStatus}'")
    End Sub
    Public Sub AddNewContract(customerName As String)
        actitvityLogDBHelper.LogActivity("New Contract Added", $"A new contract was created for: '{customerName}'.")
    End Sub
    Public Sub UpdateContractStatus(customerName As String, newStatus As String)
        actitvityLogDBHelper.LogActivity("Contract Status Update", $"Contract for '{customerName}' was changed to new status '{newStatus}'.")
    End Sub
    Public Sub UserLogout(username As String)
        actitvityLogDBHelper.LogActivity("User Logout", $"User '{username}' logged out of the system.")
    End Sub
    Public Sub UserLogin(username As String)
        actitvityLogDBHelper.LogActivity("User Login", $"User '{username}' logged into the system.")
    End Sub
End Class
