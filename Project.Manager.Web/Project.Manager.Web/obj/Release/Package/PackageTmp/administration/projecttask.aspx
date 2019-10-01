<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="projecttask.aspx.cs" Inherits="Project.Manager.Web.administration.projecttask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%
        RestSharp.RestClient client = new RestSharp.RestClient(ConfigurationManager.AppSettings["FSEPMServiceURL"].ToString());
        List<Project.Manager.Entities.ProjectsTask> ProjectsTask;
        var request = new RestSharp.RestRequest("ProjectsTask/list", RestSharp.Method.GET);
        var response = client.Execute<List<Project.Manager.Entities.ProjectsTask>>(request);
        ProjectsTask = response.Data;
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>ProjectsTask</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">ProjectsTask</a>
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
                            <i class="fa fa-edit"></i>New ProjectsTask</h3>
                    </div>
                    <div class="box-content">
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
                        <div class="form-actions">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ProjectsTask" OnClick="btnSubmit_Click" />
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
                        ProjectsTask
                    </h3>
                </div>
                <div class="box-content nopadding">
                    <table class="table table-hover table-nomargin table-bordered dataTable dataTable-tools">
                        <thead>
                            <tr>
                                <th>TaskId</th>
                                <th>Title</th>
                                <th>Project</th>
                                <th>Priority</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Date Created</th>
                                <th><i class="fa fa-edit fa-lg"></i></th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in ProjectsTask)
                                {
                            %>
                            <tr>
                                <td><%=item.ProjectsTaskId %></td>                                
                                <td><%=item.Title %></td>
                                <td><%=item.Projects.Title %></td>
                                <td><%=item.Priority %></td>
                                <td><%=item.StartDate.ToString("D") %></td>
                                <td><%=item.EndDate.ToString("D") %></td>
                                <td><%=item.DateCreated.ToString("D") %></td>
                                <td><a href="/administration/Projecttaskdetail.aspx?ProjectsTaskId=<%=item.ProjectsTaskId %>"><i class="fa fa-edit fa-lg"></i></a></td>
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
