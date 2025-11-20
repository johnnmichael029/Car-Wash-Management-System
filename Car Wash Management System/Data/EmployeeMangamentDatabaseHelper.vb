Imports System.Transactions
Imports Microsoft.Data.SqlClient

Public Class EmployeeMangamentDatabaseHelper
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub

    Public Function ViewEmployeeData() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Try
                Dim viewEmmployeeQuery As String = "SELECT * FROM EmployeeTable"
                Using cmd As New SqlCommand(viewEmmployeeQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred while retrieving employee data: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function

    Public Sub AddEmployeeData(name As String, lastName As String, phoneNumber As String, age As Integer, email As String, address As String, barangay As String, gender As String, position As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Try
                Dim insertEmployeeQuery As String = "INSERT INTO EmployeeTable (Name, LastName, PhoneNumber, Age, Email, Address, Barangay, RegistrationDate, Gender, Position) VALUES (@Name, @LastName, @PhoneNumber, @Age, @Email, @Address, @Barangay, @RegistrationDate, @Gender, @Position)"
                Using cmd As New SqlCommand(insertEmployeeQuery, con)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@LastName", lastName)
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber)
                    cmd.Parameters.AddWithValue("@Age", age)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@Barangay", barangay)
                    cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@Position", position)
                    cmd.Parameters.AddWithValue("@Gender", gender)
                    cmd.ExecuteNonQuery()
                End Using

                Carwash.NotificationLabel.Text = "Employee Added"
                Carwash.ShowNotification()
            Catch ex As Exception
                MessageBox.Show("An error occurred while adding employee data: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Public Sub PopulateDetailerForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT EmployeeID, Name + ' ' + LastName AS fullName FROM EmployeeTable WHERE Position = 'Detailer' ORDER BY EmployeeID"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "fullName"
                        targetComboBox.ValueMember = "EmployeeID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving base services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub UpdateEmployeeData(employeeID As Integer, name As String, lastName As String, phoneNumber As String, age As Integer, email As String, address As String, barangay As String, gender As String, Position As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Try
                Dim updateEmployeeQuery As String = "UPDATE EmployeeTable SET Name = @Name, LastName = @LastName, PhoneNumber = @PhoneNumber, Age = @Age, Email = @Email, Address = @Address, Barangay = @Barangay, Gender = @Gender, Position = @Position WHERE EmployeeID = @EmployeeID"
                Using cmd As New SqlCommand(updateEmployeeQuery, con)
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@LastName", lastName)
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber)
                    cmd.Parameters.AddWithValue("@Age", age)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@Barangay", barangay)
                    cmd.Parameters.AddWithValue("@Gender", gender)
                    cmd.Parameters.AddWithValue("@Position", Position.Trim)
                    cmd.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                MessageBox.Show("An error occurred while updating employee data." & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
End Class
