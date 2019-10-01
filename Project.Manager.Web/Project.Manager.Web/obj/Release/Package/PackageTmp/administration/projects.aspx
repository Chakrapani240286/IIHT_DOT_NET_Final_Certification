<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="projects.aspx.cs" Inherits="Project.Manager.Web.administration.projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        RestSharp.RestClient client = new RestSharp.RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        List<Project.Manager.Entities.Projects> Project;
        var request = new RestSharp.RestRequest("projects/list", RestSharp.Method.GET);
        var response = client.Execute<List<Project.Manager.Entities.Projects>>(request);
        Project = response.Data;
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Project</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Project</a>
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
                <div class="box">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-edit"></i>New Project</h3>
                    </div>
                    <div class="box-content">
                        <div class="form-group">
                            <label for="textfield" class="control-label col-sm-2">Title</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtTitle" runat="server" class="form-control input-sm" placeholder="Enter Title"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                    ErrorMessage="Enter Title" ControlToValidate="txtTitle" ValidationGroup="Project"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="password" class="control-label col-sm-2">Description</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control input-sm" placeholder="Enter Description"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                    ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="Project"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="password" class="control-label col-sm-2">&nbsp;</label>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkStartEnddate" runat="server" Text="Set Start and End Date" AutoPostBack="true" OnCheckedChanged="chkStartEnddate_CheckedChanged" />
                            </div>
                        </div>
                        <asp:Panel ID="pnlStartEndDate" runat="server" Visible="false">
                            <div class="form-group">
                                <label for="file" class="control-label col-sm-2">StartDate</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" class="form-control input-sm" placeholder="Enter StartDate"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter StartDate" ControlToValidate="txtStartDate" ValidationGroup="Project"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="file" class="control-label col-sm-2">EndDate</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" class="form-control input-sm" placeholder="Enter EndDate"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server"
                                            ErrorMessage="Enter EndDate" ControlToValidate="txtEndDate" ValidationGroup="Project"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="form-group">
                            <label for="password" class="control-label col-sm-2">Priority</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlPriority" runat="server" class="chosen-select form-control">
                                    <asp:ListItem>Select...</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                                    ErrorMessage="Select Priority" ControlToValidate="ddlPriority" ValidationGroup="Project"
                                    InitialValue="Select..."></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="password" class="control-label col-sm-2">Manager</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlManager" runat="server" class="chosen-select form-control">
                                     <asp:ListItem>Select...</asp:ListItem>
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server"
                                    ErrorMessage="Select Manager" ControlToValidate="ddlManager" ValidationGroup="Project"
                                    InitialValue="Select..."></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="Project" OnClick="btnSubmit_Click" />
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
                        Project
                    </h3>
                </div>
                <div class="box-content nopadding">
                    <table class="table table-hover table-nomargin table-bordered dataTable dataTable-tools">
                        <thead>
                            <tr>
                                <th>ProjectId</th>
                                <th>Title</th>
                                <th>Priority</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Date Created</th>
                                <th><i class="fa fa-edit fa-lg"></i></th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in Project)
                                {
                            %>
                            <tr>
                                <td><%=item.ProjectsId %></td>
                                <td><%=item.Title %></td>
                                <td><%=item.Priority %></td>
                                <td><%=item.StartDate.ToString("D") %></td>
                                <td><%=item.EndDate.ToString("D") %></td>
                                <td><%=item.DateCreated.ToString("D") %></td>
                                <td><a href="/administration/Projectdetail.aspx?Projectsid=<%=item.ProjectsId %>"><i class="fa fa-edit fa-lg"></i></a></td>
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
