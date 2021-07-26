<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppliedAdvertisements.aspx.cs" Inherits="ytuportal.web.AppliedAdvertisements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function deleteRow(r) {
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("myTable").deleteRow(i);
        }
        <%--function toggleColor() {
            var x = document.getElementById("<%#Eval("CStatus")%>");
            var p = document.getElementsById("statusp");

            if (x === "Passive") {
                p.className = 'alert alert-danger';
            } else {
                p.className = 'alert alert-warning';
            }
        }
        window.onload = toggleColor();--%>
    </script>
    <h1>Advertisements that you applied</h1>
    <table id="myTable" class="table table-striped">
        <tr>
            <th>The Company</th>
            <th>Position</th>
            <th>Status</th>
            <th></th>
        </tr>
        <asp:Repeater ID="rptAdv" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Adv.Company.ComName") %></td>
                    <td><%#Eval("Adv.Position") %></td>
                    <td><p id="statusp" class="<%#GetClass(Eval("CStatus"))%>""><%#CheckStatus(Eval("CStatus"))%></p></td>
                    <td><button id="hide" onclick="deleteRow(this)"><span class="glyphicon glyphicon-minus-sign" aria-hidden="true"></span></button></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
