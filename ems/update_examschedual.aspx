<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="update_examschedual.aspx.cs" Inherits="ems.update_examschedual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server" class="row g-2">
    
    <div class="col-md-6">

            <div class="form-group">
                <asp:Label for="programeDropDownList1" ID="Label7" runat="server" Text="Programe:"></asp:Label>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="programeDropDownList1" ErrorMessage="*Please select programe." ForeColor="Red" InitialValue="Select Program"></asp:RequiredFieldValidator>

                <asp:DropDownList ID="programeDropDownList1" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-6">

        <div class="form-group">
            <asp:Label for="semesterDropDownList2" ID="Label8" runat="server" Text="Semester:"></asp:Label>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="semesterDropDownList2" ErrorMessage="*Please select semester." ForeColor="Red" InitialValue="Select Semester" SetFocusOnError="True"></asp:RequiredFieldValidator>

            <asp:DropDownList class="form-control" ID="semesterDropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="semesterDropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </div></div>
        <div class="col-md-6">

        <div class="form-group">
            <asp:Label for="examnameDropDownList1" ID="Label2" runat="server" Text="Exam Name:"></asp:Label>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="examnameDropDownList1" ErrorMessage="*Please select exam name." ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:DropDownList ID="examnameDropDownList1" class="form-control" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </div></div>
        <div class="col-md-6">
        <div class="form-group">
            <asp:Label for="subjectDropDownList3" ID="subject" runat="server" Text="Subject:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="subjectDropDownList3" ErrorMessage="*Please select subject." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="subjectDropDownList3" class="form-control" runat="server" AutoPostBack="True" ></asp:DropDownList>

        </div></div>
        <div class="col-md-6">

        <div class="form-group">
            <asp:Label for="exam_date" ID="Label3" runat="server" Text="Exam Date:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="exam_date" ErrorMessage="*Please select exam date." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="exam_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
        </div></div>
        <div class="col-md-6">

        <div class="form-group">
            <asp:Label for="exam_starttime" ID="Label4" runat="server" Text="Exam  Start Time:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="exam_starttime" ErrorMessage="*Please select exam start time." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="exam_starttime" class="form-control" runat="server"  TextMode="Time"></asp:TextBox>
            </div> </div>
        <div class="col-md-6">

        <div class="form-group">
            <asp:Label for="exam_endtime" ID="Label5" runat="server" Text="Exam End Time:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="exam_endtime" ErrorMessage="*Please select exam end time." ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:TextBox ID="exam_endtime" class="form-control" runat="server" TextMode="Time"></asp:TextBox>
        </div></div>
        <div class="col-md-6">

        <div class="form-group">
            <asp:Label for="exam_mark" ID="Label6" runat="server" Text="Mark of Exam:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="exam_mark" ErrorMessage="please enter mark of exam." ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:TextBox ID="exam_mark" class="form-control" runat="server"></asp:TextBox>
        </div></div>
        <div class="col-12">

        <asp:Button ID="Submit" class="btn btn-primary" runat="server" Text="Submit" OnClick="Submit_Click" />

        
            </div>
    </form>
</asp:Content>
