<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="update_subject.aspx.cs" Inherits="ems.update_subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server" class="row g-2">

        <div class="col-md-6">

            <div class="form-group">
                <asp:Label ID="Label1" for="subject" runat="server" Text="Subject:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="subject" ErrorMessage="*Please enter subject." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="subject" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">

            <div class="form-group">
                <asp:Label ID="Label2" for="subjectcode" runat="server" Text="Subject Code:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="subjectcode" ErrorMessage="*Please enter subject code." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="subjectcode" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">

            <div class="form-group">
                <asp:Label ID="Label3" for="programeDropDownList1" runat="server" Text="Programe:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="programeDropDownList1" ErrorMessage="*Please select programe." ForeColor="Red" InitialValue="Select Programe"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="programeDropDownList1" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-6">

            <div class="form-group">
                <asp:Label ID="Label4" for="semesterDropDownList2" runat="server" Text="Semester:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="semesterDropDownList2" ErrorMessage="*Please select semester." ForeColor="Red" InitialValue="Select Semester"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="semesterDropDownList2" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>

                <div class="col-12">
        
            <br />
            <asp:Button ID="submit" runat="server" class="btn btn-primary" OnClick="submit_Click" Text="Update" />

           
        </div>

    </form>
</asp:Content>
