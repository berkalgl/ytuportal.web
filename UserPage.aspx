<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="ytuportal.web.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {

            var labels = $(".control-label");
            for (var i = 0; i < labels.length; i++) {
                if (labels[i].innerText == "") {
                    $(labels[i]).closest(".form-group").hide();
                }
            }

            var pics = $(".img-responsive");

            var imgVal = document.getElementById('<%=UserPhoto.ID %>');
            if (imgVal.src == "data:image/jpg;base64,") {
                imgVal.setAttribute('src', '/UploadedItems/765-default-avatar.png"');
            }
        });

    </script>

    <style>
        .profile-usertitle {
            text-align: center;
            margin-top: 20px;
        }

        .profile-usertitle-name {
            color: #5a7391;
            font-size: 16px;
            font-weight: 600;
            margin-bottom: 7px;
        }

        .profile-usertitle-job {
            text-transform: uppercase;
            color: #5b9bd1;
            font-size: 12px;
            font-weight: 600;
            margin-bottom: 15px;
        }
    </style>


    <div class="container-fluid">
        <section class="container">
                <h1>Profile</h1>
            <hr />
            
           
            <div class="col-md-12">
                                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1default">
                            <div class="form-horizontal" role="form">
                                <div class="container-page">
                                    <div class="col-md-6 col-md-offset-3 well">
                                        <div class="col-md-12">
                                            <div style="text-align: center;">
                                                <asp:Image runat="server" ID="UserPhoto" CssClass="img-rounded img-responsive" />
                                                <div class="profile-usertitle">
                                                    <div class="profile-usertitle-name">
                                                        <asp:Label ID="UserName" runat="server" Text="Label"> Name</asp:Label>
                                                    </div>
                                                    <div class="profile-usertitle-job">
                                                        <asp:Label ID="UserPosition" runat="server" Text="Label">Position</asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12">
                                            <br />
                                        </div>

                                        <div class="col-md-10">
                                            <div style="float: right;">
                                                <asp:HyperLink ID="EditLink" runat="server" NavigateUrl="#"><i class="glyphicon glyphicon-edit"></i><strong>Edit</strong></asp:HyperLink>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <hr />
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div style="text-align: center;">
                                                    <div class="form-group row">
                                                        <asp:Label ID="UserEmail" runat="server" Text="Label">Email</asp:Label>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label ID="UserTel" runat="server" Text="Label">Phone</asp:Label>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label ID="UserBday" runat="server" Text="Label">Birthday</asp:Label>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label ID="UserAddress" runat="server" Text="Label">Address</asp:Label>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label ID="UserEducation" runat="server" Text="Label">Education</asp:Label>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label ID="UserInterests" runat="server" Text="Label">Interests</asp:Label>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Button ID="DownloadCv" runat="server" Text="Download CV" OnClick="DownloadCv_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="tab-pane fade" id="tab2default">
                            <div class="form-horizontal" role="form">
                            </div>

                        </div>

                    </div>
               
            </div>

            </div>        
        </section>
    </div>

</asp:Content>
