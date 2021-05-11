<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="updateprograme.aspx.cs" Inherits="ems.upadate_programe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <form id="form1" runat="server" class="row g-2">

        <div class="col-md-6">
            <div class="form-group">
                <asp:Label for="programe" ID="Label1" runat="server" Text="Programe:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="programe" ErrorMessage="*Please enter programe." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="programe" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">

                <asp:Label for="programecode" ID="Label2" runat="server" Text="Programe Code:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="programecode" ErrorMessage="*Please enter code." ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:TextBox ID="programecode" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-12">
            <asp:Button ID="Button1"   runat="server"      Text="Button"  class="btn btn-primary" OnClick="Button1_Click" />    
            
   
        </div>

    </form>
</asp:Content>
