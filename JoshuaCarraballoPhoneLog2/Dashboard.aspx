<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="JoshuaCarraballoPhoneLog2.Dashboard1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
     <link href="Content/bootstrap.css" type="text/css" rel="stylesheet" media="all"/>
    <link href="style.css" type="text/css" rel="stylesheet" media="all"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</head>
<body>

<nav class="navbar navbar-expand-lg navbar-light fs-5" style="background-color:#BCE0A1;">
  <div class="container-fluid">
    <a class="navbar-brand fs-4" href="#">Dashboard</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="Employee.aspx">Employee</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="Company.aspx">Company</a>
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

    <br />
    <section class="vh-100">
        <div class="container py-5 h-100">
    <span class="h1 fw-bold">Welcome To The Phone Log</span><br />
            </div>
    </section>
</body>
</html>
