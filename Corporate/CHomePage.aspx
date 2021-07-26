<%@ Page Title="Companies Homepage" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" CodeBehind="CHomePage.aspx.cs" Inherits="ytuportal.web.Corporate.CHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 style="text-align: center; margin-top:50px;">Advertisements</h2>
        <table class="table table-striped">
            <tr>
                <th>Candidates</th>
                <th>Title</th>
                <th>Status</th>
                <th>Release Date</th>
                <th>Application Deadline</th>
                <th></th>
            </tr>
            <asp:Repeater ID="rptAdv" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><a href="../AdvertisementView/Candidates.aspx?AdvId=<%#Eval("Id") %>"><%#Eval("NumberOfCandidate") %> Candidate/s</a></td>
                        <td><%#Eval("Title") %>
                            <br />
                            <strong><%#Eval("Position")%></strong></td>
                        <td><%#Eval("Status") %> </td>
                        <td><%#Eval("Firstdate") %></td>
                        <td><%#Eval("Lastdate") %></td>
                        <td><a class="btn btn-primary" href="../AdvertisementView/EditAdv.aspx?AdvId=<%#Eval("Id") %>">Edit</a></td>
                    </tr>

                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
