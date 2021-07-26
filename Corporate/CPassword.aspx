<%@ Page Title="Change Your Password" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" CodeBehind="CPassword.aspx.cs" Inherits="ytuportal.web.Corporate.CPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 style="text-align: center;">Change Your Password</h2>
        <div class="col-md-6 col-md-offset-3">
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <label class="col-lg-3 control-label">Password</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="EditPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-3 control-label">Retype password</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="confirmPassword" runat="server" CssClass="form-control" TextMode="Password" OnTextChanged="confirmPassword_TextChanged"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToValidate="confirmPassword"
                            CssClass="empty-field-alert"
                            ControlToCompare="EditPassword"
                            ErrorMessage="Passwords Do not Match"
                            ToolTip="Password must be the same" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Confirm Password is Required"
                            ControlToValidate="confirmPassword"
                            CssClass="empty-field-alert"
                            ToolTip="Compare Password is a REQUIRED field">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-8 col-lg-offset-3">
                        <asp:Button ID="SaveBtn" runat="server" Text="Save The Password" CssClass="btn btn-primary btn-block" OnClick="SaveBtn_Click" />
                    </div>
                </div>
                <asp:Label ID="ReqCheck" runat="server" Text="" CssClass="empty-field-alert"></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
