<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Project.Manager.Web.administration._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Welcome 
                    <span>
                        <%
                            if ((_User.FirstName + " " + _User.LastName).Length > 18)
                            {%>
                        <%= (_User.FirstName +" "+_User.LastName).Substring(0, 15)%><span>...</span>
                        <% }
                            else
                            {%>
                        <%= _User.FirstName +" "+_User.LastName %>
                        <%}%>
                    </span>
                    !!!
                </h1>
            </div>
        </div>
    </div>
    <div class="breadcrumbs">
        <ul>
            <li>
                <a href="#">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="/administration/default.aspx?redirecturl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
            </li>
        </ul>
        <div class="close-bread">
            <a href="#">
                <i class="fa fa-times"></i>
            </a>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <h3>Here are the steps we need to follow...</h3>
            <ol>
                <li>
                    <h4>Adhere to the design specifications mentioned in the case study.</h4>
                </li>
                <li>
                    <h4>Please  make  sure  that  your  code  does  not  have  any  compilation  errors  while  submitting your case study solution.</h4>
                </li>
                <li>
                    <h4>The  final  solution  should  be  a  zipped  code  having  solution.  Solution  code  will  be  used  to perform Static code evaluation.</h4>
                </li>
                <li>
                    <h4>Implement the code using best design standards. </h4>
                </li>
                <li>
                    <h4>Use Internationalization for all the labels and messages in Rest API Development.</h4>
                </li>
                <li>
                    <h4>Do  not  use  System  out  statements  for  logging  in  Rest  API  and  Front-End  respectively. Use appropriate logging methods for logging statements/variable/return values. </h4>
                </li>
                <li>
                    <h4>If you are using WebAPI to develop Rest API and Visual Studio to build the project. </h4>
                </li>
                <li>
                    <h4>If  youare  using  Node  and  Express  to  develop  Rest  API,  then  use  Grunt/Gulp/NPM  to build/minify the project and create application for deployment. </h4>
                </li>
                <li>
                    <h4>Write web service which takes input and return required details from database.</h4>
                </li>
                <li>
                    <h4>Use JSON format to transfer the results.</h4>
                </li>
            </ol>
        </div>
    </div>
</asp:Content>
