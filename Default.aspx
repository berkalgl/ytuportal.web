<%@ Page Title="HomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ytuportal.web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .bgimg {
            background-image: url('');
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
            height: 400px;
            margin-top: 60px;
            border-radius: 20px;
        }

        .homepageaddbackground {
            background-color: #e0e0e0;
            border-radius: 10px;
        }

        .buttonright {
            margin-left: 250px;
            margin-bottom: 30px;
            border-radius: 10px !important;
            padding-right: 7px;
            background: border-box;
        }

        .btnorange {
            background-color: darkorange;
            color: white;
        }

    </style>

    <div class="intro-header">
        <div class="container">

            <div class="row">
                <div class="col-lg-12">
                    <div class="intro-message">
                        <h2>YTU Career Platform</h2>
                        <hr class="intro-divider">
                    </div>
                </div>
            </div>

        </div>
        <!-- /.container -->

    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-3 col-md-offset-4">
                <div class="input-group">
                    <div class="input-group-btn search-panel">
                        <%--<asp:DropDownList ID="CitiesDDlist" runat="server" CssClass="btn btn-default" AppendDataBoundItems="true">
                            <asp:ListItem Enabled="true">Cities</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox ID="SearchBox" runat="server" CssClass="form-control" placeholder="Exp; Software, Finance, Selling" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Search For a Job" CssClass="btn btnorange " />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="col-md-12">
        <h1 style="text-align: center;">Prominent Jobs...</h1>
    </div>

    <table class="table table-bordered">

        <asp:Repeater ID="rptAdv" runat="server">
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-6">
                        <td style="width:200px;">
                            <div>
                                <h3><%#Eval("Company.ComName") %></h3>
                                <p><a href="AdvertisementView/ViewAdv.aspx?AdvId=<%#Eval("Id") %>"><%#Eval("Title") %></a></p>
                                <strong><%#Eval("Position")%></strong>
                            </div>
                        </td>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
