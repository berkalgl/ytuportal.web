<%@ Page Title="Login" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" CodeBehind="CLoginPage.aspx.cs" Inherits="ytuportal.web.Corporate.CLoginPage" %>

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
    <link href="../Content/MyStyle.css" rel="stylesheet" />
    <div class="divbackgr">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <div class="col-xs-12 col-md-12" >
                        <div class="form-group">
                            <h2 style="color: white;">Find your candidate fast</h2>
                        </div>
                        <div class="form-group">
                            <a href="CRegister.aspx" class="btn btn-success btn-lg">Register Now</a>
                        </div>
                    </div>
                </div>


                <div class="col-md-6 col-xs-12" style="margin-top: 70px;">
                    <div class="col-xs-12 col-md-6 col-md-offset-4 well">
                        <div class="form-group">
                            <h3>Company Log in</h3>
                            <hr />
                            <p>To login please use your e-mail and password</p>
                            <hr />
                            <label>Email Address:</label>
                            <div class="inner-addon left-addon">
                                <i class="glyphicon glyphicon-envelope"></i>
                                <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="abc@example.com"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Password:</label>
                            <div class="inner-addon left-addon">
                                <i class="glyphicon glyphicon-lock"></i>
                                <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="********"></asp:TextBox>
                                <div runat="server" id="ReqDiv">
                                    <asp:Label ID="ReqControl" runat="server" Text="" CssClass="empty-field-alert"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group ">
                            <asp:Button ID="LoginBtn" runat="server" Text="Login" CssClass="btn btn-primary btn-lg btn-block" OnClick="LoginBtn_Click" />
                        </div>
                        <div>
                            <hr />
                            <p><a href="CRecovery.aspx"><i class="glyphicon glyphicon-lock"></i>I forgot my password</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
