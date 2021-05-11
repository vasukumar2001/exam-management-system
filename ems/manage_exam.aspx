<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="manage_exam.aspx.cs" Inherits="ems.manage_exam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script>
         function myFunction() {
             window.print();
         }
    </script>
    <style>
     

@media print {
   
   .noPrint {display:none;}
}
    </style>
    <form id="form1" runat="server">
        <div class="row noPrint">

         <div class="col-md-2">
            
            <asp:TextBox ID="TextBox1"  class="form-control" placeholder="Search" runat="server" ></asp:TextBox>
                
        </div>
        <div class="col-md-1">
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Search" OnClick="Button1_Click" />
        </div>
        <div class="col-md-9">
            <button class="btn btn-primary float-end hidden-print" onclick="myFunction()"><span class="glyphicon glyphicon-print" aria-hidden="true"></span> Print</button>
        </div>
        </div>
        <br />
         <div class="table-responsive-sm">

    <asp:GridView ID="GridView1" CssClass="table table-hover " OnRowCommand="GridView1_RowCommand" runat="server" GridLines="None">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView></div>
    </form>
</asp:Content>
