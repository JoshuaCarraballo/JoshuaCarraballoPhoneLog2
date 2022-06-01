Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Globalization
Public Class newCall
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conStr").ConnectionString)
    Dim cmd As New SqlCommand()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Launching the drop down list populating function on page load
        If Not Page.IsPostBack Then
            FillCompDropdownList()
        End If
    End Sub

    'Populating the DropDownList with the list of companies and employees from database
    Protected Sub FillCompDropdownList()
        'Getting a list of all companies
        Dim sdaComp As New SqlDataAdapter()
        Dim dtComp As New DataTable()
        Dim cmdComp As New SqlCommand()
        cmdComp = New SqlCommand("SELECT * FROM ForeignCompany", con)
        sdaComp.SelectCommand = cmdComp
        sdaComp.Fill(dtComp)
        ddlCompRecord.DataSource = dtComp
        ddlCompRecord.DataValueField = "compID"
        ddlCompRecord.DataTextField = "compName"
        ddlCompRecord.DataBind()
        ddlCompRecord.Items.Insert(0, "-- Select --")

        'Getting a list of all employees
        Dim sdaEmp As New SqlDataAdapter()
        Dim dtEmp As New DataTable()
        Dim cmdEmp As New SqlCommand()
        cmdEmp = New SqlCommand("SELECT * FROM Employees", con)
        sdaEmp.SelectCommand = cmdEmp
        sdaEmp.Fill(dtEmp)
        ddlEmpRecord.DataSource = dtEmp
        ddlEmpRecord.DataValueField = "EmpID"
        ddlEmpRecord.DataTextField = "EmpName"
        ddlEmpRecord.DataBind()
        ddlEmpRecord.Items.Insert(0, "-- Select --")
        con.Close()
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("calls.aspx")
    End Sub

    'Saving and assigning the Company ID to the Company ID textfield
    Protected Sub btnSelectComp_Click(sender As Object, e As EventArgs) Handles btnSelectComp.Click
        con.Open()
        Dim getCompID As New SqlCommand()
        'Getting the Company ID from the Company's Name
        getCompID = New SqlCommand("SELECT compID FROM ForeignCompany WHERE compName='" & ddlCompRecord.SelectedItem.Text & "' ", con)
        Dim sdrComp As SqlDataReader = getCompID.ExecuteReader()
        If sdrComp.Read() Then
            compID.Text = sdrComp.GetValue(0)
            con.Close()
        End If
    End Sub

    'Saving and assigning the Employee ID to the Employee ID textfield
    Protected Sub btnSelectEmp_Click(sender As Object, e As EventArgs) Handles btnSelectEmp.Click
        con.Open()
        Dim getEmpID As New SqlCommand()
        'Getting the Employee ID from the employee's Name
        getEmpID = New SqlCommand("SELECT empID FROM Employees WHERE empName='" & ddlEmpRecord.SelectedItem.Text & "' ", con)
        Dim sdrEmp As SqlDataReader = getEmpID.ExecuteReader()
        If sdrEmp.Read() Then
            empID.Text = sdrEmp.GetValue(0)
            con.Close()
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        con.Open()
        'Inserting the new record into the database
        cmd = New SqlCommand("INSERT INTO Calls (callID, callDate, callNum, callDuration, compID, compName, empID, empName) VALUES('" & Convert.ToInt32(callID.Text) & "', '" & callDate.Text & "', '" & callNum.Text & "','" & callDuration.Text & "', '" & compID.Text & "', '" & ddlCompRecord.SelectedItem.Text & "', '" & empID.Text & "', '" & ddlEmpRecord.SelectedItem.Text & "') ", con)
        If cmd.ExecuteNonQuery Then
            con.Close()
            Response.Redirect("calls.aspx")
        End If
    End Sub
End Class