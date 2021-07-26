<%@ Page Title="View the Advertisement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAdv.aspx.cs" Inherits="ytuportal.web.AdvertisementView.ViewAdv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="container" style="margin-top: 70px;">
            <div class="container-page">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <div class="well">
                            <div class="col-lg-3 col-md-3 col-sm-3 hidden-xs">
                                <asp:Image ID="Image1" runat="server" />
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9">
                                <h1>
                                    <asp:Label ID="ViewPosition" runat="server" Text="Label"></asp:Label>
                                </h1>
                                <div>
                                    <i class="glyphicon glyphicon-briefcase"></i>
                                    <asp:Label ID="ViewCompany" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <i class="glyphicon glyphicon-map-marker"></i>
                                    <asp:Label ID="ViewLocation" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <i class="glyphicon glyphicon-time"></i>
                                    <asp:Label ID="ViewReleaseDate" runat="server"></asp:Label>
                                </div>
                                <hr />
                            </div>
                            
                            <div class="detailContent">
                                <br />
                                <br />
                                <h3>Definition of The Job</h3>
                                
                                <p>
                                    <asp:Label ID="ViewDefinition" runat="server"></asp:Label>
                                </p>
                                <h3>Qualifications of The Job</h3>
                                    <asp:Label ID="ViewQua" runat="server"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-lg-offset-9 col-md-offset-9 col-sm-offset-9">
                                    <asp:Button ID="ApplyBtn" runat="server" Text="Apply For The Job" CssClass="btn btn-success" OnClick="ApplyBtn_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="well" style="margin-top:5px;">
                            <h3><i class="glyphicon glyphicon-file"></i>  Short Information</h3>
                            <ul>
                                <li>
                                    <asp:Label ID="Pos" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3" Text="Position"></asp:Label>
                                    <span class="col-lg-1 col-md-1 col-sm-1">:</span>
                                    <asp:Label ID="ViewPosition2" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="Label1" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3" Text="Sector"></asp:Label>
                                    <span class="col-lg-1 col-md-1 col-sm-1">:</span>
                                    <asp:Label ID="ViewSector" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="Label3" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3" Text="Style"></asp:Label>
                                    <span class="col-lg-1 col-md-1 col-sm-1">:</span>
                                    <asp:Label ID="ViewStyle" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="Label5" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3" Text="Level"></asp:Label>
                                    <span class="col-lg-1 col-md-1 col-sm-1">:</span>
                                    <asp:Label ID="ViewLevel" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="Label2" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3" Text="Location"></asp:Label>
                                    <span class="col-lg-1 col-md-1 col-sm-1">:</span>
                                    <asp:Label ID="ViewLocation2" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="Label4" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3" Text="Release Date"></asp:Label>
                                    <span class="col-lg-1 col-md-1 col-sm-1">:</span>
                                    <asp:Label ID="ViewRDate" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:Label ID="Label6" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3" Text="Deadline"></asp:Label>
                                    <span class="col-lg-1 col-md-1 col-sm-1">:</span>
                                    <asp:Label ID="ViewLDate" runat="server"></asp:Label>
                                </li>
                            </ul>
                            
                        </div>
                    </div>
                </div>
                    <div id="alertdiv" runat="server" class="alert alert-danger" role="alert"><asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
                        
            </div>
        </div>
    </div>
</asp:Content>
