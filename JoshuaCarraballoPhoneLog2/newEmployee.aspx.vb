Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class newEmployee
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conStr").ConnectionString)
    Dim cmd As New SqlCommand()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Employee.aspx")
    End Sub

    'Inserting new employee record into database
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        con.Open()
        cmd = New SqlCommand("INSERT INTO Employees (empID, empName, empExtension, username, password) VALUES('" & Convert.ToInt32(empID.Text) & "', '" & empName.Text & "', '" & empExt.Text & "','" & username.Text & "', '" & password.Text & "') ", con)
        If cmd.ExecuteNonQuery Then
            con.Close()
            Response.Redirect("Employee.aspx")
        End If
    End Sub

End Class