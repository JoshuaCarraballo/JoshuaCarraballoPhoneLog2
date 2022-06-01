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

Public Class calls
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conStr").ConnectionString)
    Dim cmd As New SqlCommand()
    Dim tempEmp As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Launching the drop down list populating function on page load
        If Not Page.IsPostBack Then
            FillCallDropdownList()
        End If
    End Sub

    'Populating the DropDownList with the list of calls from database
    Protected Sub FillCallDropdownList()
        Dim sda As New SqlDataAdapter()
        Dim dt As New DataTable()
        'Getting a list of all companies
        cmd = New SqlCommand("SELECT * FROM Calls", con)
        sda.SelectCommand = cmd
        sda.Fill(dt)
        ddlCallRecord.DataSource = dt
        ddlCallRecord.DataValueField = "callID"
        ddlCallRecord.DataTextField = "callID"
        ddlCallRecord.DataBind()
        ddlCallRecord.Items.Insert(0, "-- Select --")
        con.Close()
    End Sub

    'Populating the DropDownList with the list of employees from database
    Protected Sub FillEmpDropdownList()
        Dim sdaEmp As New SqlDataAdapter()
        Dim dtEmp As New DataTable()
        Dim cmdEmp As New SqlCommand()
        'Getting a list of all employees
        cmdEmp = New SqlCommand("SELECT * FROM Employees", con)
        sdaEmp.SelectCommand = cmdEmp
        sdaEmp.Fill(dtEmp)
        ddlEmpRecord.DataSource = dtEmp
        ddlEmpRecord.DataValueField = "empID"
        ddlEmpRecord.DataTextField = "empName"
        ddlEmpRecord.DataBind()
        ddlEmpRecord.Items.Insert(0, tempEmp)
        con.Close()
    End Sub

    'Updating call dropdown list when user searches
    Protected Sub FillSearchedCallDropdownList()
        Dim sdaSearch As New SqlDataAdapter()
        Dim dtSearch As New DataTable()
        Dim cmdSearch As New SqlCommand()
        'Getting a list of all employees
        cmdSearch = New SqlCommand("SELECT * FROM Calls WHERE callNum='" & compNum.Text & "' ", con)
        sdaSearch.SelectCommand = cmdSearch
        sdaSearch.Fill(dtSearch)
        ddlEmpRecord.DataSource = dtSearch
        ddlEmpRecord.DataValueField = "callID"
        ddlEmpRecord.DataTextField = "CallID"
        ddlEmpRecord.DataBind()

        Dim sdrSearch As SqlDataReader = cmdSearch.ExecuteReader()
        If sdrSearch.Read() Then
            ddlCallRecord.Items.RemoveAt(0)
            ddlCallRecord.Items.Insert(0, sdrSearch.GetValue(0))
            FillEmpDropdownList()
        End If

        con.Close()
    End Sub

    'Updating employee dropdown list when user searches
    Protected Sub FillSearchedEmpDropdownList()
        Dim sdaSearch1 As New SqlDataAdapter()
        Dim dtSearch1 As New DataTable()
        Dim cmdSearch1 As New SqlCommand()
        'Getting a list of all employees
        cmdSearch1 = New SqlCommand("SELECT * FROM Calls WHERE callNum='" & compNum.Text & "' ", con)
        sdaSearch1.SelectCommand = cmdSearch1
        sdaSearch1.Fill(dtSearch1)
        ddlEmpRecord.DataSource = dtSearch1
        ddlEmpRecord.DataValueField = "callID"
        ddlEmpRecord.DataTextField = "empName"
        ddlEmpRecord.DataBind()

        Dim sdrSearch1 As SqlDataReader = cmdSearch1.ExecuteReader()
        If sdrSearch1.Read() Then
            ddlCallRecord.Items.RemoveAt(0)
            ddlCallRecord.Items.Insert(0, sdrSearch1.GetValue(0))
        End If

        con.Close()
    End Sub

    'Redirecting to the dashboard
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("Dashboard.aspx")
    End Sub

    'Redirecting to the new call page to add a new call
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("newCall.aspx")
    End Sub

    'Selecting the call from the drop down list populated by the Calls table of the database
    Protected Sub btnSelectCall_Click(sender As Object, e As EventArgs) Handles btnSelectCall.Click
        con.Open()
        cmd = New SqlCommand("SELECT * FROM Calls WHERE callID='" & Convert.ToInt32(ddlCallRecord.SelectedItem.Text) & "' ", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        Dim tempDate As DateTime

        'Setting the input fields to contain the data from the database record
        If sdr.Read() Then
            compID.Text = sdr.GetValue(4).ToString()
            compName.Text = sdr.GetValue(5).ToString()
            compNum.Text = sdr.GetValue(2).ToString()

            'Converting date format to be displayed on the DatePicker
            tempDate = FormatDateTime(sdr.GetValue(1).ToString(), DateFormat.ShortDate)
            Dim date1 As DateTime = DateTime.ParseExact(tempDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            Dim reformatted As String = date1.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            callDay.Text = reformatted
            duration.Text = sdr.GetValue(3).ToString()
            tempEmp = sdr.GetValue(7).ToString()
            FillEmpDropdownList()
            con.Close()
        End If
    End Sub

    'Deleting a call record from Call table of the database
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        con.Open()
        cmd = New SqlCommand("DELETE FROM Calls WHERE callID='" & Convert.ToInt32(ddlCallRecord.SelectedItem.Text) & "' ", con)
        If cmd.ExecuteNonQuery() Then
            con.Close()
            Response.Redirect("calls.aspx")
        End If
    End Sub

    'Updating the call records for the Call table of the database
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        con.Open()
        'Getting the employee id from the selected employee name
        Dim tempId1 As String
        Dim getEmpID1 As New SqlCommand()
        getEmpID1 = New SqlCommand("SELECT empID FROM Employees WHERE empName='" & ddlEmpRecord.SelectedItem.Text & "' ", con)
        Dim sdrEmpID1 As SqlDataReader = getEmpID1.ExecuteReader()
        If sdrEmpID1.Read() Then
            tempId1 = sdrEmpID1.GetValue(0).ToString()
        End If

        'Updating the Calls table using data from the input fields of web page
        cmd = New SqlCommand("UPDATE Calls SET callNum='" & compNum.Text & "', callDate='" & callDay.Text & "', callDuration='" & duration.Text & "', empID='" & tempId1 & "', empName='" & ddlEmpRecord.SelectedItem.Text & "' WHERE callID='" & Convert.ToInt32(ddlCallRecord.SelectedItem.Text) & "'", con)
        If cmd.ExecuteNonQuery() Then
            con.Close()
            Response.Redirect("calls.aspx")
        End If
    End Sub

    'Searching by call records
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        con.Open()
        cmd = New SqlCommand("SELECT * FROM Calls WHERE callNum='" & compNum.Text & "' ", con)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()

        'Setting the input fields to contain the data from the database record
        If sdr.Read() Then
            compID.Text = sdr.GetValue(4).ToString()
            compName.Text = sdr.GetValue(5).ToString()
            compNum.Text = sdr.GetValue(2).ToString()
            callDay.Text = FormatDateTime(sdr.GetValue(1).ToString(), DateFormat.ShortDate)
            duration.Text = sdr.GetValue(3).ToString()
            tempEmp = sdr.GetValue(7).ToString()
            FillSearchedCallDropdownList()

        Else
            Dim ans As String
            ans = MsgBox("Company Not Found Would You Like To Add A New Company?", vbYesNo)
            If ans = vbYes Then
                Response.Redirect("newCompany.aspx")
            Else
                Response.Redirect("calls.aspx")
            End If

        End If
    End Sub
End Class