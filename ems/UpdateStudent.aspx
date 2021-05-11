<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="UpdateStudent.aspx.cs" Inherits="ems.UpdateStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>--%>
</asp:Content>
     
         <asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server" class="row g-2">
       
             <div class="col-md-6">
                       
                    <div class="form-group">
                   
                    <asp:Label ID="label5" for="enrollmentno" runat="server" Text="Enrollment No.:"></asp:Label>

               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="enrollmentno" ErrorMessage="*Please enter the enrollment." ForeColor="Red"></asp:RequiredFieldValidator>

          
                    <asp:TextBox ID="enrollmentno" class="form-control" runat="server"></asp:TextBox>
                </div>      </div>      
             <div class="col-md-6">
                    
                <div class="form-group">
               
                    <asp:Label for="fullname" ID="Label1" runat="server" Text="Full Name:"></asp:Label>
               
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fullname" ErrorMessage="*Please enter full name." ForeColor="Red"></asp:RequiredFieldValidator>
               
               
                    <asp:TextBox ID="fullname" class="form-control" runat="server" ></asp:TextBox>
                    </div></div>
             <div class="col-md-6">

                <div class="form-group">
                
                
               
                    <asp:Label ID="Label2" For="birthdate" runat="server" Text="Birthdate:"></asp:Label>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="birthdate" ErrorMessage="*Please select Birthdate." ForeColor="Red"></asp:RequiredFieldValidator>
               
                    <asp:TextBox ID="birthdate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
               </div></div>
             <div class="col-md-6">

                <div class="form-group">

                    <asp:Label ID="Label3" for="gender" runat="server" Text="Gender:"></asp:Label>
              
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="gender" ErrorMessage="*Please select Gender." ForeColor="Red"></asp:RequiredFieldValidator>
              
                    <asp:RadioButtonList ID="gender" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="gender_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem Value="male" Selected="True">male</asp:ListItem>
                        <asp:ListItem Value="female">female</asp:ListItem>
                        <asp:ListItem Value="other">other</asp:ListItem>
                    </asp:RadioButtonList>
                    </div> </div>
             <div class="col-md-6">

                <div class="form-group">

                    <asp:Label ID="Label6" for="mobileno" runat="server" Text="Mobile No.:"></asp:Label>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="mobileno" ErrorMessage="*Please enter Mobile no." ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="mobileno" ErrorMessage="Please enter valid number." ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
               
                    <asp:TextBox ID="mobileno" class="form-control" runat="server"></asp:TextBox>
                    </div></div>
        <div class="col-md-6">

                <div class="form-group">

                    <asp:Label ID="Label7" for="email" runat="server" Text="Email:"></asp:Label>
               
              
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="email" ErrorMessage="*Please enter email." ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Please enter valid Email." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               
              
                    <asp:TextBox ID="email" class="form-control" runat="server"></asp:TextBox>
       
                    </div></div>
             <div class="col-md-6">
                <div class="form-group">

                    <asp:Label ID="Label8" for="address" runat="server" Text="Address:"></asp:Label>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="address" ErrorMessage="*Please enter address." ForeColor="Red"></asp:RequiredFieldValidator>
               
                    <asp:TextBox ID="address" runat="server" class="form-control" TextMode="MultiLine"  ></asp:TextBox>
                    </div></div>
        <div class="col-md-6">

                <div class="form-group">

                    <asp:Label ID="Label9" for="programeDropDownList1" runat="server" Text="Programe:"></asp:Label>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="programeDropDownList1" ErrorMessage="*Please select programe." ForeColor="Red" InitialValue="Select Programe"></asp:RequiredFieldValidator>
                
                    <asp:DropDownList ID="programeDropDownList1" class="form-control" runat="server" >
                    </asp:DropDownList>
                    </div></div>
        <div class="col-md-6">

                <div class="form-group">


                    <asp:Label for="semesterDropDwonList2" ID="Label10" runat="server" Text="Semester:"></asp:Label>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="semesterDropDownList2" ErrorMessage="*Please select semester." ForeColor="Red" InitialValue="Select Semester"></asp:RequiredFieldValidator>
               
                    <asp:DropDownList ID="semesterDropDownList2" class="form-control" runat="server" >
                    </asp:DropDownList>
                    </div>
                </div>
             <div class="col-12">
                
                    <asp:Button ID="submit" runat="server" class="btn btn-primary" Text="Update" OnClick="submit_Click" />
                           
       </div>
    </form>
</asp:Content>
