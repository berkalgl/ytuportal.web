<%@ Page Title="Add An Advertisement" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" CodeBehind="CAddAdv.aspx.cs" Inherits="ytuportal.web.Corporate.CAddAdv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/MyJS.js"></script>
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.min.css" />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker3.min.css" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.min.js"></script>

    <div class="container">
        <h2 style="text-align: center;">Add a new Advertisement</h2>
        <div class="col-md-4 col-md-offset-4 well">
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <asp:Label ID="CompanyName" CssClass="col-md-3" runat="server" Text="Company Name:"></asp:Label>
                    <div class="col-md-9">
                        <asp:Label ID="CName" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                    </div>

                </div>
                <div class="form-group">
                    <asp:Label ID="Position" CssClass="col-md-3" runat="server" Text="Position:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="AddPosition" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>


                </div>

                <div class="form-group">
                    <asp:Label ID="Positionlevel" CssClass="col-md-3" runat="server" Text="Position Level:"></asp:Label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DdlLevels" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                </div>

                <div class="form-group">
                    <asp:Label ID="AdTitle" CssClass="col-md-3" runat="server" Text=" Title:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="AddAdvTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="AdDefinition" CssClass="col-md-3" runat="server" Text=" Definition:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="AddAdvDefinition" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="AdAttribute" CssClass="col-md-3" runat="server" Text=" Qualification:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="AddAdvAttribute" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="AdStyle" CssClass="col-md-3" runat="server" Text=" Style:"></asp:Label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DdlStyle" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="AdPlace" CssClass="col-md-3" runat="server" Text=" Location:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="AddAdvPlace" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="AdSector" CssClass="col-md-3" runat="server" Text=" Sector:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="AddAdvSector" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="AdvFirstDate" CssClass="col-md-3" runat="server" Text=" Release Date:"></asp:Label>
                    <div class="col-md-9">
                        <div class="date">
                            <div class="input-group input-append date" id="datePicker">
                                <asp:TextBox CssClass="form-control" ID="AddAdvFirstDate" runat="server"></asp:TextBox>
                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="form-group">
                    <asp:Label ID="AdvLastDay" CssClass="col-md-3" runat="server" Text=" Last Day to Apply:"></asp:Label>
                    <div class="col-md-9">
                        <div class="date">
                            <div class="input-group input-append date" id="datePicker2">
                                <asp:TextBox CssClass="form-control" ID="AddAdvLastDay" runat="server"></asp:TextBox>
                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                        <div class="col-md-12 col-md-offset-1">
                            <asp:Button ID="AddAdvBtn" runat="server" Text="Add The Advertisement" CssClass="btn btn-primary btn-block" OnClick="AddAdvBtn_Click" />
                        </div>
                    </div>
            </div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>




    </div>
</asp:Content>
