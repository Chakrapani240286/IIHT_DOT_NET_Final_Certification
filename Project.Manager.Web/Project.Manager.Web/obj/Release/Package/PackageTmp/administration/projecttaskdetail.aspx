<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="projecttaskdetail.aspx.cs" Inherits="Project.Manager.Web.administration.projecttaskdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Project Task Detail</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Application Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/ProjectTask.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979">Project Task</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">
                        <asp:Label ID="lblBcTitle" runat="server"></asp:Label>
                    </a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <asp:Panel ID="pnlErrorMessage" class="page-header" runat="server" Visible="false" Style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Update ProjectsTask Detail</h3>
                        <asp:HiddenField ID="hdnProjectTaskId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2">Project</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlProject" runat="server" class="chosen-select form-control">
                                        <asp:ListItem>Select...</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Project" ControlToValidate="ddlProject" ValidationGroup="ProjectsTask"
                                        InitialValue="Select..."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textfield" class="control-label col-sm-2">Task</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control input-sm" placeholder="Enter Title"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Title" ControlToValidate="txtTitle" ValidationGroup="ProjectsTask"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control input-sm" placeholder="Enter Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="ProjectsTask"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label col-sm-2">Priority</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlPriority" runat="server" class="chosen-select form-control">
                                        <asp:ListItem>Select...</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Priority" ControlToValidate="ddlPriority" ValidationGroup="ProjectsTask"
                                        InitialValue="Select..."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="file" class="control-label col-sm-2">StartDate</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" class="form-control input-sm" placeholder="Enter StartDate"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter StartDate" ControlToValidate="txtStartDate" ValidationGroup="ProjectsTask"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="file" class="control-label col-sm-2">EndDate</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" class="form-control input-sm" placeholder="Enter EndDate"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter EndDate" ControlToValidate="txtEndDate" ValidationGroup="ProjectsTask"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label col-sm-2">Task User</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlManager" runat="server" class="chosen-select form-control">
                                        <asp:ListItem>Select...</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Task User" ControlToValidate="ddlManager" ValidationGroup="ProjectsTask"
                                        InitialValue="Select..."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-danger" OnClick="btnDelete_Click" OnClientClick="return DeleteItem()" />
                            &nbsp;&nbsp;&nbsp;
                                <a href="/administration/ProjectTask.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979"
                                    class="btn btn-default">Cancel</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function DeleteItem() {
            if (confirm("Are you sure you want to delete this Project Task?")) {
                return true;
            }
            return false;
        }
    </script>
</asp:Content>
