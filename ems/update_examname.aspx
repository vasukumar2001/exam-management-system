<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="update_examname.aspx.cs" Inherits="ems.update_examname" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <form id="form1" runat="server" class="row g-2">

        <div class="col-md-6">


            <div class="form-group">
                <asp:Label For="examname" ID="Label2" runat="server" Text="Exam Name:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="examname" ErrorMessage="Please Enter Exam Name." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="examname" Class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">

            <div class="form-group">
                <asp:Label For="programeDropDownlist1" ID="Label3" runat="server" Text="Programe:"></asp:Label>


                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="programeDropDownList1" ErrorMessage="Please select programe." ForeColor="Red" InitialValue="Select Program"></asp:RequiredFieldValidator>


                <asp:DropDownList ID="programeDropDownList1" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-6">

            <div class="form-group">
                <asp:Label ID="Label4" for="semesterDropDownlist2" runat="server" Text="Semester:"></asp:Label>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="semesterDropDownList2" ErrorMessage="Please select semester. " ForeColor="Red" InitialValue="Select Semester "></asp:RequiredFieldValidator>

                <asp:DropDownList ID="semesterDropDownList2" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-12">

            <asp:Button class="btn btn-primary" ID="submit" runat="server" OnClick="submit_Click" Text="Submit" />

            


        </div>
    </form>
</asp:Content>
