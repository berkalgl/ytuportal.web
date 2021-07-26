<%@ Page Title="Recovery of Password" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" CodeBehind="CRecovery.aspx.cs" Inherits="ytuportal.web.Corporate.CRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3 well" style="margin-top: 10px;">
            <div class="col-md-6 col-md-offset-3">
                <h3 style="text-align: center">Recovery Your Password</h3>
                <hr />
                <p style="text-align: center">To recover your password, please write your e-mail that you used when you registered with. </p>
                <hr />
                <label>Email Address:</label>

                <div class="form-group" style="text-align: center;">
                    <div class="input-group">
                        <span style="width: 100px;" class="input-group-addon" id="basic-addon1">@</span>
                        <asp:TextBox runat="server" Style="width: 550px;" TextMode="Email" ID="REmail" aria-describedby="sizing-addon1" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <asp:Label ID="ReqEmail" runat="server" Text="" CssClass="empty-field-alert"></asp:Label>
                </div>
                <hr />
                <div style="text-align: center;">
                    <asp:Button runat="server" ID="RBtn" CssClass="btn btn-success" Style="width: 550px;" Text="Send The Email" OnClick="RBtn_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
