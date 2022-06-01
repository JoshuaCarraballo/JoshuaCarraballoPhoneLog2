Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Company
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conStr").ConnectionString)
    Dim cmd As New SqlCommand()
    Dim currentEmp As New Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Launching the drop down list populating function on page load
        If Not Page.IsPostBack Then
            FillCompDropdownList()
        End If
    End Sub

    'Populating the DropDownList with the list of companies from database
    Protected Sub FillCompDropdownList()
        Dim sda As New SqlDataAdapter()
        Dim dt As New DataTable()
        'Getting a list of all companies
        cmd = New SqlCommand("SELECT * FROM ForeignCompany", con)
        sda.SelectCommand = cmd
        sda.Fill(dt)
        ddlComRecord.DataSource = dt
        ddlComRecord.DataValueField = "compID"
        ddlComRecord.DataTextField = "compName"
        ddlComRecord.DataBind()
        ddlComRecord.Items.Insert(0, "-- Select --")
        con.Close()
    End Sub

    'Redirects to the Dashboard page
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("Dashboard.aspx")
    End Sub

    'Updating the company records for the ForeignCompany table of the database
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        con.Open()
        'Getting the employee id from the selected employee name
        Dim tempId As String
        Dim getEmpID As New SqlCommand()
        getEmpID = New SqlCommand("SELECT empID FROM Employees WHERE empName='" & ddlEmpName.SelectedItem.Text & "' ", con)
        Dim sdrEmpID As SqlDataReader = getEmpID.ExecuteReader()
        If sdrEmpID.Read() Then
            tempId = sdrEmpID.GetValue(0).ToString()
        End If

        'Updating the ForeignCompany table using data from the input fields of web page
        cmd = New SqlCommand("UPDATE ForeignCompany SET compName='" & compName.Text & "', compNum='" & compNum.Text & "', compCity='" & compCity.Text & "', compCountry='" & compCountry.Text & "', empID='" & tempId & "' WHERE compID='" & Convert.ToInt32(compID.Text) & "'", con)
        If cmd.ExecuteNonQuery() Then
            con.Close()
            Response.Redirect("Company.aspx")
        End If
    End Sub

    'Selecting the company from the drop down list populated by the Employee table of the database
    Protected Sub btnSelectCom_Click(sender As Object, e As EventArgs) Handles btnSelectCom.Click
        con.Open()
        cmd = New SqlCommand("SELECT * FROM ForeignCompany WHERE compName='" & ddlComRecord.SelectedItem.Text & "' ", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        'Setting the input fields to contain the data from the database record
        If sdr.Read() Then
            compID.Text = sdr.GetValue(0).ToString()
            compName.Text = sdr.GetValue(1).ToString()
            compNum.Text = sdr.GetValue(2).ToString()
            compCity.Text = sdr.GetValue(3).ToString()
            compCountry.Text = sdr.GetValue(4).ToString()
            currentEmp = sdr.GetValue(5)
            FillEmpDropdownList()
            con.Close()
        End If
    End Sub

    'Populating employee dropdown list
    Protected Sub FillEmpDropdownList()
        Dim sda1 As New SqlDataAdapter()
        Dim dt1 As New DataTable()
        Dim cmdGetAllEmp As New SqlCommand()
        'Getting a list of all of the employees
        cmdGetAllEmp = New SqlCommand("SELECT * FROM Employees", con)
        sda1.SelectCommand = cmdGetAllEmp
        sda1.Fill(dt1)
        ddlEmpName.DataSource = dt1
        ddlEmpName.DataValueField = "empID"
        ddlEmpName.DataTextField = "empName"
        ddlEmpName.DataBind()

        'Setting the employee assigned to the company record to the top of the dropdown list
        Dim getSelectedEmp As New SqlCommand()
        getSelectedEmp = New SqlCommand("SELECT empName FROM Employees WHERE empID='" & currentEmp & "' ", con)
        Dim sdrSelectedEmp As SqlDataReader = getSelectedEmp.ExecuteReader()
        If sdrSelectedEmp.Read() Then
            ddlEmpName.Items.Insert(0, sdrSelectedEmp.GetValue(0).ToString())
        End If
        con.Close()
    End Sub

    'Deleting a company record from ForeignCompany table of the database
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        con.Open()
        cmd = New SqlCommand("DELETE FROM ForeignCompany WHERE compID='" & Convert.ToInt32(compID.Text) & "' ", con)
        If cmd.ExecuteNonQuery() Then
            con.Close()
            Response.Redirect("Company.aspx")
        End If
    End Sub

    'Redirects to add new company page
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("newCompany.aspx")
    End Sub
End Class