<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="userdetail.aspx.cs" Inherits="Project.Manager.Web.administration.userdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>User Detail</h1>
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
                    <a href="/administration/User.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979">User</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">
                        <asp:label id="lblBcTitle" runat="server"></asp:label>
                    </a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <asp:panel id="pnlErrorMessage" class="page-header" runat="server" visible="false" style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Update User Detail</h3>
                        <asp:hiddenfield id="hdnUserId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtTitle" class="control-label col-sm-2">FirstName</label>
                                <div class="col-sm-10">
                                    <asp:textbox id="txtFirstName" runat="server" class="form-control" width="50%"></asp:textbox>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" forecolor="Red" runat="server" errormessage="Enter FirstName for User" controltovalidate="txtFirstName" validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtLastName" class="control-label col-sm-2">LastName</label>
                                <div class="col-sm-10">
                                    <asp:textbox id="txtLastName" runat="server" class="form-control" width="50%"></asp:textbox>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" forecolor="Red" runat="server" errormessage="Enter LastName for User" controltovalidate="txtLastName" validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtEmailId" class="control-label col-sm-2">EmailId</label>
                                <div class="col-sm-10">
                                    <asp:textbox id="txtEmailId" runat="server" class="form-control" width="50%"></asp:textbox>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" forecolor="Red" runat="server" errormessage="Enter EmailId for User" controltovalidate="txtEmailId" validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Date Created</label>
                                <div class="col-sm-10">
                                    <asp:label id="lblDateCreated" runat="server"></asp:label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Is Active?</label>
                                <div class="col-sm-10">
                                    <asp:checkbox id="chkIsDefault" runat="server" />
                                    Is Active
                                </div>
                            </div>
                        </div>
                        <div class="form-actions col-sm-offset-2 col-sm-10">
                            <asp:button id="btnSubmit" runat="server" text="Save" class="btn btn-primary" validationgroup="admin" onclick="btnSubmit_Click" />
                            &nbsp;&nbsp;&nbsp;
                                 <asp:button id="btnDelete" runat="server" text="Delete" class="btn btn-danger" onclick="btnDelete_Click" onclientclick="return DeleteItem()" />
                            &nbsp;&nbsp;&nbsp;
                                <a href="/administration/Users.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979"
                                    class="btn btn-default">Cancel</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function DeleteItem() {
            if (confirm("Are you sure you want to delete this User?")) {
                return true;
            }
            return false;
        }
    </script>
</asp:Content>
