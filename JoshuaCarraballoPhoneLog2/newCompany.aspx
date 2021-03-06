<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="newCompany.aspx.vb" Inherits="JoshuaCarraballoPhoneLog2.newCompany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Company</title>
    <link href="Content/bootstrap.css" type="text/css" rel="stylesheet" media="all"/>
    <link href="style.css" type="text/css" rel="stylesheet" media="all"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</head>
<body>
    <!-- Nav bar -->
    <nav class="navbar navbar-expand-lg navbar-light fs-5" style="background-color:#BCE0A1;">
      <div class="container-fluid">
        <a class="navbar-brand fs-4" href="Dashboard.aspx">Dashboard</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link" href="Employee.aspx">Employee</a>
            </li>
            <li class="nav-item">
              <a class="nav-link active" aria-current="page" href="Company.aspx">Company</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="calls.aspx">Calls</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="Login.aspx" tabindex="-1">Logout</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <section class="vh-100">
      <div class="container py-5 h-100">
          
        <span class="h1 fw-bold">Company Maintainance</span><br />
        <form id="form1" runat="server" class="shadow-sm p-3 mb-5 bg-white rounded mt-3">
            <div class="form-outline mb-4">
                <h5 class="fw-large" style="letter-spacing: 1px;">New Company</h5>
                
                <!-- User inputs editing employee information -->
                <div class="row">
                    <div class="col-6 mb-2">
                    <asp:TextBox ID="compID" runat="server" class="form-control form-control-lg" type="number" required></asp:TextBox>
                    <label class="form-label" for="compID">Company ID</label>
                    </div>
                    <div class="col-6 mb-2">
                    <asp:DropDownList ID="ddlEmpList" runat="server" AutoPostBack="True" Height="48px"
                        Width="100%" CausesValidation="True">
                    </asp:DropDownList>
                    <label class="form-label" for="ddlEmpList">Employee</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 mb-2">
                    <asp:TextBox ID="compName" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                    <label class="form-label" for="compName">Company Name</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4 mb-2">
                    <asp:TextBox ID="compNum" runat="server" class="form-control form-control-lg" type="number" required></asp:TextBox>
                    <label class="form-label" for="compNum">Number</label>
                    </div>
                    <div class="col-4 mb-2">
                    <asp:TextBox ID="compCity" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                    <label class="form-label" for="compCity">City</label>
                    </div>
                    <div class="col-4 mb-2">
                    <asp:TextBox ID="compCountry" runat="server" class="form-control form-control-lg" required></asp:TextBox>
                    <label class="form-label" for="compCountry">Country</label>
                    </div>
                </div>
                
            </div>

             <!-- Buttons for controlling the new employee page -->
            <div class="row">
                <div class="col-6">
                    <asp:Button ID="btnSave" runat="server" class="btn btn-lg btn-block" Width="100%" Text="Save" />
                </div>
                <div class="col-6">
                    <asp:Button ID="btnBack" runat="server" class="btn1 btn-lg btn-dark btn-block" Width="100%" UseSubmitBehavior="false" Text="Back" />
                </div>
            </div>
        </form>
      </div>
    </section>
</body>
</html>
