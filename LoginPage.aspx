<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ytuportal.web.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <style type="text/css">
        .empty-field-alert {
            position: absolute;
            top: 1%;
            left: 100%;
            min-width: 163px;
            border-radius: 4px;
            padding: 6px;
            font-size: 13px;
            border: 1px solid #960f0f;
            background: #ddb0b0;
            color: #960f0f;
        }
    </style>

    <div class="container-fluid">
        <section class="container" style="margin-top: 70px;">
            <div class="container-page">
                <div class="col-md-4 col-md-offset-4 well">
                    <h3 class="dark-grey" style="text-align: center;"><b>Log in</b></h3>
                    <br />
                    <%--<div class="col-md-12">
                        <div style="text-align: center">
                            <asp:Button ID="FacebookBtn" runat="server" CssClass="btn btn-fb " Text="Login with Facebook" />
                        </div>
                        <br />
                        <p style="text-align: center;">Or</p>
                        <hr />
                    </div>--%>

                    <div class="form-group col-md-12">
                        <p style="text-align: center;">To login please use your e-mail and password</p>
                        <hr />
                        <div style="margin-left: 15px;">
                            <label>Email Address:</label>
                            <div class="inner-addon left-addon">
                                <i class="glyphicon glyphicon-envelope"></i>
                                <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="abc@example.com"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <div style="margin-left: 15px;">
                            <label>Password:</label>
                            <div class="inner-addon left-addon">
                                <i class="glyphicon glyphicon-lock"></i>
                                <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="********"></asp:TextBox>
                                <div runat="server" id="ReqDiv">
                                    <asp:Label ID="ReqControl" runat="server" Text="" CssClass="empty-field-alert"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="form-group pull-left">
                                <asp:Label ID="Label1" runat="server" Text="Remember Me"></asp:Label>
                                <asp:CheckBox ID="RememberCheckBox" runat="server" OnCheckedChanged="RememberCheckBox_CheckedChanged" />
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="pull-right">
                                <asp:Button ID="LoginBtn" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="LoginBtn_Click" />
                            <hr />
                            </div>
                        </div>
                    </div>
                        <p style="text-align:center;">If you have forgotten your password,<a href="UserRecovery.aspx">click here.</a></p>
                    
                    <div class="col-md-12">
                        <hr />
                        <p style="text-align: center;">If you have not sign up yet, please <a href="Sign-up.aspx">Sign Up</a></p>
                    </div>

                </div>




            </div>

        </section>
    </div>

</asp:Content>
