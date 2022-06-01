<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="JoshuaCarraballoPhoneLog2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <link href="Content/bootstrap.css" type="text/css" rel="stylesheet" media="all"/>
</head>
<body>
    
    <section class="vh-100" style="background-color: #BCE0A1;">
      <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col col-xl-10">
            <div class="card" style="border-radius: 1rem;">
              <div class="row g-0">
                <!--Left Side Image-->
                <div class="col-md-6 col-lg-5 d-none d-md-block">
                  <img src="https://www.junee.nsw.gov.au/wp-content/uploads/2021/09/inner_img_1.jpg"
                    alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
                </div>
                <!--Left Side Image-->

                <!--Right Side Content-->
                <div class="col-md-6 col-lg-7 d-flex align-items-center">
                  <div class="card-body p-4 p-lg-5 text-black">

                    <!--Login Form-->
                    <form id="form1" runat="server">

                      <div class="d-flex align-items-center mb-3 pb-1">

                        <span class="h1 fw-bold mb-0">Phone Log</span>
                      </div>

                      <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">User Sign In</h5>
                      <!-- User inputs for login form -->
                      <div class="form-outline mb-4">
                        <asp:TextBox ID="username" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        <label class="form-label" for="username">Username</label>
                      </div>
                      <div class="form-outline mb-4">
                        <asp:TextBox ID="password" runat="server" class="form-control form-control-lg" type="password"></asp:TextBox>
                        <label class="form-label" for="password">Password</label>
                      </div>
                      <!-- User inputs for login form -->

                      <div class="pt-1 mb-4">
                        <asp:Button ID="btnLogin" runat="server" class="btn btn-dark btn-lg btn-block" Text="Login" />
                      </div>

                      <p class="large text-muted"><span style="font-weight:bolder;color:#BCE0A1;">mcs</span>software<span style="color:#BCE0A1;">ltd.</span></p>
                      <p class="large text-muted">91 Cascade Rd., Cascade, Trinidad, West Indies.</p>
                      <p class="large text-muted">(868) 627-0114</p>
                    </form>
                    <!--Login Form-->

                  </div>
                </div>
                <!--Right Side Content-->

              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
</body>
</html>
