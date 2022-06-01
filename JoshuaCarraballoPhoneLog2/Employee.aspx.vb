Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Dashboard
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conStr").ConnectionString)
    Dim cmd As New SqlCommand()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Launching the drop down list populating function on page load
        If Not Page.IsPostBack Then
            FillEmpDropdownList()
        End If

    End Sub

    'Populating the DropDownList with the list of employees from database
    Protected Sub FillEmpDropdownList()
        Dim sda As New SqlDataAdapter()
        Dim dt As New DataTable()
        'Getting a list of all employees
        cmd = New SqlCommand("SELECT * FROM Employees", con)
        sda.SelectCommand = cmd
        sda.Fill(dt)
        ddlEmpRecord.DataSource = dt
        ddlEmpRecord.DataValueField = "empID"
        ddlEmpRecord.DataTextField = "empName"
        ddlEmpRecord.DataBind()
        ddlEmpRecord.Items.Insert(0, "-- Select --")
        con.Close()
    End Sub

    'Selecting the employee from the drop down list populated by the Employee table of the database
    Protected Sub btnSelectEmp_Click(sender As Object, e As EventArgs) Handles btnSelectEmp.Click
        con.Open()
        cmd = New SqlCommand("SELECT * FROM Employees WHERE empName='" & ddlEmpRecord.SelectedItem.Text & "' ", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        'Setting the input fields to contain the data from the database record
        If sdr.Read() Then
            empID.Text = sdr.GetValue(0).ToString()
            empName.Text = sdr.GetValue(1).ToString()
            empExt.Text = sdr.GetValue(2).ToString()
            con.Close()
        End If
    End Sub

    'Exiting to the dashboard
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("Dashboard.aspx")
    End Sub

    'Updating the employee records for the Employee table of the database
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        con.Open()
        'Updating the Employees table using data from the input fields of web page
        cmd = New SqlCommand("UPDATE Employees SET empName='" & empName.Text & "', empExtension='" & empExt.Text & "' WHERE empID='" & Convert.ToInt32(empID.Text) & "'", con)
        If cmd.ExecuteNonQuery() Then
            con.Close()
            Response.Redirect("Employee.aspx")
        End If
    End Sub

    'Deleting an employee record from Employee table of the database
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        con.Open()
        cmd = New SqlCommand("DELETE FROM Employees WHERE empID='" & Convert.ToInt32(empID.Text) & "' ", con)
        If cmd.ExecuteNonQuery() Then
            con.Close()
            Response.Redirect("Employee.aspx")
        End If
    End Sub

    'Redirecting to the add new employee page
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("newEmployee.aspx")
    End Sub
End Class