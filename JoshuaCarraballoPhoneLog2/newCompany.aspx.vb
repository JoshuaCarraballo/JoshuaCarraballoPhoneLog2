Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class newCompany
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
        ddlEmpList.DataSource = dt
        ddlEmpList.DataValueField = "empID"
        ddlEmpList.DataTextField = "empName"
        ddlEmpList.DataBind()
        ddlEmpList.Items.Insert(0, "-- Select --")
        con.Close()
    End Sub

    'Redirects back to company maintainance page
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Company.aspx")
    End Sub

    'Inserting new company record into database
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        con.Open()
        Dim getID As New SqlCommand()
        'Getting the employee ID from the employee's Name to be saved into the company record
        getID = New SqlCommand("SELECT empID FROM Employees WHERE empName='" & ddlEmpList.SelectedItem.Text & "' ", con)
        Dim sdr As SqlDataReader = getID.ExecuteReader()
        If sdr.Read() Then
            'Temporarily saving the queried employee ID
            Dim tempID As Integer
            tempID = sdr.GetValue(0)

            'Inserting the new record into the database
            cmd = New SqlCommand("INSERT INTO ForeignCompany (compID, compName, compNum, compCity, compCountry, empID) VALUES('" & Convert.ToInt32(compID.Text) & "', '" & compName.Text & "', '" & compNum.Text & "','" & compCity.Text & "', '" & compCountry.Text & "', '" & tempID & "') ", con)
            If cmd.ExecuteNonQuery Then
                con.Close()
                Response.Redirect("Company.aspx")
            End If
        End If
    End Sub
End Class