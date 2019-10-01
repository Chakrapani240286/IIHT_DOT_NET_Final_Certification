<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="Project.Manager.Web.administration.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        RestSharp.RestClient client = new RestSharp.RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        List<Project.Manager.Entities.User> User;
        var request = new RestSharp.RestRequest("user/list", RestSharp.Method.GET);
        var response = client.Execute<List<Project.Manager.Entities.User>>(request);
        User = response.Data;
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>User</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">User</a>
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
                <div class="box">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-edit"></i>New User</h3>
                    </div>
                    <div class="box-content">
                        <div class="form-group">
                            <label for="textfield" class="control-label col-sm-2">FirstName</label>
                            <div class="col-sm-10">
                                <asp:textbox id="txtFirstName" runat="server" class="form-control input-sm" placeholder="Enter FirstName"></asp:textbox>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator1" forecolor="Red" runat="server"
                                    errormessage="Enter FirstName" controltovalidate="txtFirstName" validationgroup="User"></asp:requiredfieldvalidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="password" class="control-label col-sm-2">LastName</label>
                            <div class="col-sm-10">
                                <asp:textbox id="txtLastName" runat="server" class="form-control input-sm" placeholder="Enter LastName"></asp:textbox>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator2" forecolor="Red" runat="server"
                                    errormessage="Enter LastName" controltovalidate="txtLastName" validationgroup="User"></asp:requiredfieldvalidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="file" class="control-label col-sm-2">EmailId</label>
                            <div class="col-sm-10">
                                <asp:textbox id="txtEmailId" runat="server" class="form-control input-sm" placeholder="Enter EmailId"></asp:textbox>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator3" forecolor="Red" runat="server"
                                    errormessage="Enter EmailId" controltovalidate="txtEmailId" validationgroup="User"></asp:requiredfieldvalidator>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:button id="btnSubmit" runat="server" text="Save" class="btn btn-primary" validationgroup="User" OnClick="btnSubmit_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="box box-color box-bordered">
                <div class="box-title">
                    <h3>
                        <i class="fa fa-table"></i>
                        User
                    </h3>
                </div>
                <div class="box-content nopadding">
                    <table class="table table-hover table-nomargin table-bordered dataTable dataTable-tools">
                        <thead>
                            <tr>
                                <th>UserId</th>
                                <th>FirstName</th>
                                <th>LastName</th>
                                <th>EmailId</th>
                                <th>CreatedDate</th>
                                <th>Status</th>
                                <th><i class="fa fa-edit fa-lg"></i></th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in User)
                                {
                            %>
                            <tr>
                                <td><%=item.UserId %></td>
                                <td><%=item.FirstName %></td>
                                <td><%=item.LastName %></td>
                                <td><%=item.EmailId %></td>
                                <td><%=item.DateCreated.ToString("D") %></td>
                                <%if (item.Status.ToLower() == "active")
                                    { %>
                                <td class='hidden-350'>
                                    <span class="label label-success"><%=item.Status %>
                                    </span>
                                </td>
                                <%}
                                    else
                                    {%>
                                <td class='hidden-350'>
                                    <span class="label label-danger"><%=item.Status %>
                                    </span>
                                </td>
                                <%} %>
                                <td><a href="/administration/userdetail.aspx?Userid=<%=item.UserId %>"><i class="fa fa-edit fa-lg"></i></a></td>
                            </tr>
                            <%
                                }
                            %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
