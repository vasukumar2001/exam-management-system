<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ems.WebForm1" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Login form</title>
   <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
  
    <style>
        body {
    font-family: "Lato", Gadugi;
}



.main-head{
    height: 150px;
    background: #FFF;
   
}

.sidenav {
    height: 100%;
    background-color: #000;
    overflow-x: hidden;
    padding-top: 20px;
}


.main {
    padding: 0px 10px;
}

@media screen and (max-height: 450px) {
    .sidenav {padding-top: 15px;}
}

@media screen and (max-width: 450px) {
    .login-form{
        margin-top: 10%;
    }

    .register-form{
        margin-top: 10%;
    }
}

@media screen and (min-width: 768px){
    .main{
        margin-left: 40%; 
    }

    .sidenav{
        width: 40%;
        position: fixed;
        z-index: 1;
        top: 0;
        left: 0;
    }

    .login-form{
        margin-top: 50%;
        align-content:center;
    }

    .register-form{
        margin-top: 20%;
    }
}


.login-main-text{
    margin-left:10px;
    padding: 20px;
    color: #fff;
}

.login-main-text h2{
    font-weight: 300;
}

.btn-black{
    background-color: #000 !important;
    color: #fff;
}
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            margin-left: 0px;
            height: 77px;
        }
       .a{
  box-shadow: 0 2px 0 #006599;
  transform: translateY(3px);
}
    </style>
</head>
<body>
    <div class="sidenav">
         <div  class="login-main-text">
             
        
             
            
                  
      <img " alt=""  src="images/logo.jpg"  />  <br /> 
      <img " alt=""  src="images/Untitled.jpg" width="450px" height="450px" />   

         </div>
      </div>
      <div class="main">
         <div class="col-md-6 col-sm-12">
             
            <div class="login-form">
                
               <form runat="server">
                  <div class="form-group">
                    <asp:Label for="username" ID="Label3" runat="server" Text="User Name:">User Name:</asp:Label>
                            <asp:TextBox ID="username" Class="form-control" runat="server" Name="username" placeholder="Enter Username" Height="33px" Width="247px" required></asp:TextBox>
                  </div>
                  <div class="form-group">
                     <asp:Label for="password" ID="Label4" runat="server" Text="Password:">Password:</asp:Label>
                            <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Enter Password" TextMode="Password" Width="247px" Height="33px" required></asp:TextBox>
                  </div>
                 <asp:Button ID="Button1" class="btn btn-primary a" runat="server" OnClick="login_Click" Text="Log In" />
               </form>
            </div>
         </div>
      </div>
  
   


 
</body>
</html>

