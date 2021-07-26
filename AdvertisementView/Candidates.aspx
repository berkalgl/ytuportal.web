<%@ Page Title="Candidates" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Candidates.aspx.cs" Inherits="ytuportal.web.AdvertisementView.Candidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Candidates That Applied</h2>
        <table class="table table-striped">
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Resume</th>
                <th></th>
            </tr>
            <asp:Repeater ID="rptCan" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("user.Fname")%> <%#Eval("user.Sname")%></td>
                        <td><%#Eval("user.Email") %></td>
                        <td><asp:Button ID="DCv" runat="server" Text="Download The CV" CssClass="btn btn-primary" OnClick="DCv_Click" /></td>
                        <td><asp:Button ID="DCanBtn" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="DCanBtn_Click" /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <th></th>
                <th></th>
                <th><asp:Button ID="DMultipleCV" runat="server" Text=" Download The All CVs" CssClass="btn" OnClick="DMultipleCV_Click" /></th>
                <th></th>
            </tr>
        </table>
         <div id="alertdiv" runat="server" class="alert alert-danger" role="alert">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             </div>
    </div>
</asp:Content>
