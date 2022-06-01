Imports System.Data.SqlClient


Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = "Data Source=DESKTOP-G3UERQR;Initial Catalog=PhoneLog;Integrated Security=True"

        Dim objcon As SqlConnection = Nothing
        Dim objcmd As SqlCommand = Nothing

        objcon = New SqlConnection("Data Source=DESKTOP-G3UERQR;Initial Catalog=PhoneLog;Integrated Security=True")
        objcon.Open()

        Dim query As String = "SELECT * FROM Employees WHERE username='" & username.Text & "' AND password = '" & password.Text & "'"
        objcmd = New SqlCommand(query, objcon)

        Dim reader As SqlDataReader = objcmd.ExecuteReader
        If reader.Read Then
            MsgBox("Login Successful")
            Response.Redirect("Dashboard.aspx")
        Else
            MsgBox("Login Unsuccessful")
        End If

    End Sub
End Class