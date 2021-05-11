<%@ Page Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="seating_arrangement.aspx.cs" Inherits="ems.WebForm4" %>

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
    <form id="form1" runat="server" class="row g-2">
         <div class="row noPrint">

        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="Label1" for="programeDropDownList1" runat="server" Text="Programe:"></asp:Label>

                <asp:DropDownList ID="programeDropDownList1" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label for="semesterDropDownList2" ID="Label2" runat="server" Text="Semester:"></asp:Label>

                <asp:DropDownList ID="semesterDropDownList2" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="semesterDropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="Label4" for="examnameDropDownList2" runat="server" Text="Exam Name:"></asp:Label>

                <asp:DropDownList ID="examnameDropDownList2" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="Label3" for="numberofstudent" runat="server" Text="Number Of Student:"></asp:Label>

                <asp:TextBox ID="numberofstudent" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="Label5" for="class_seatlimit" runat="server" Text="Class Seat Limit:"></asp:Label>

                <asp:TextBox ID="class_seatlimit" class="form-control" runat="server" OnTextChanged="class_seatlimit_TextChanged"></asp:TextBox>
               </div></div>
                <br />
                <br />
                <div class="col-12">
                    <br />
                <asp:Button ID="save" runat="server" class="btn btn-primary" Text="Display" OnClick="save_Click" />
                    <button class="btn btn-primary hidden-print" onclick="myFunction()"><span class="glyphicon glyphicon-print" aria-hidden="true"></span> Print</button>
                </div>

                <br />
         </div>

      <b>  <asp:Label ID="Label6" runat="server" Text="Required Class:"></asp:Label><asp:Label ID="required_class" runat="server"></asp:Label>
          </b>
                <asp:Panel ID="panel" runat="server"></asp:Panel>
            
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</asp:Content>
