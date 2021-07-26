<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="ytuportal.web.EditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#datePicker')
                .datepicker({
                    autoclose: true,
                    format: 'mm/dd/yyyy'
                })
                .on('changeDate', function (e) {
                    // Revalidate the date field
                    $('#eventForm').formValidation('revalidateField', 'date');
                });

            $('#eventForm').formValidation({
                framework: 'bootstrap',
                icon: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    name: {
                        validators: {
                            notEmpty: {
                                message: 'The name is required'
                            }
                        }
                    },
                    EditBday: {
                        validators: {
                            notEmpty: {
                                message: 'The date is required'
                            },
                            EditBday: {
                                format: 'MM/DD/YYYY',
                                message: 'The date is not a valid'
                            }
                        }
                    }
                }
            });
        });
    </script>

    <style>
          .empty-field-alert {
            position: absolute;
            top: -135%;
            left: 58%;
            min-width: 100px;
            border-radius: 4px;
            padding: 6px;            
            font-size: 11px;
            border: 1px solid #960f0f;
            background: #ddb0b0;
            color: #960f0f;
        }
    </style>
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.min.css" />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker3.min.css" />

    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.min.js"></script>

    <div class="container">
        <h1>Edit Profile</h1>
        <hr>
        <div class="row">

            <div class="col-md-3">
                <div class="text-center">
                    <asp:Image runat="server" ID="EditPhoto" CssClass="avatar img-circle" />
                    <h6>Upload a different photo...</h6>

                    <asp:FileUpload CssClass="form-control" ID="EditImage" runat="server" Font-Bold="False" Font-Size="Small" />
                </div>
            </div>


            <div class="col-md-9 personal-info">
               <%-- <div class="alert alert-info alert-dismissable">
                    <a class="panel-close close" data-dismiss="alert">×</a>
                    <i class="fa fa-coffee"></i>
                    This is an <strong>.alert</strong>. Use this to show important messages to the user.
                </div>--%>

                <h3>User Information</h3>

                <div class="panel with-nav-tabs panel-default">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1default" data-toggle="tab">General</a></li>
                            <li><a href="#tab2default" data-toggle="tab">Contact</a></li>
                            <li><a href="#tab3default" data-toggle="tab">Education</a></li>
                            <li><a href="#tab4default" data-toggle="tab">Upload your CV</a></li>
                            <li style="float: right;"><a href="#tab5default" data-toggle="tab"><i class="glyphicon glyphicon-lock"></i>Change Your Password</a></li>

                        </ul>
                    </div>
                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tab1default">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Gender:</label>
                                        <div class="col-lg-8">
                                            <asp:RadioButtonList ID="RadioBtnEditGender" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">First name:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditFname" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Last name:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditLname" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Email:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditEmail" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Birthday:</label>
                                        <div class="col-lg-5 date">
                                            <div class="input-group input-append date" id="datePicker">
                                                <asp:TextBox CssClass="form-control" ID="EditBday" runat="server"></asp:TextBox>
                                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="tab-pane fade" id="tab2default">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Address:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditAddress" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">District:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditDistrict" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">City:</label>
                                        <div class="col-lg-8">
                                            <asp:DropDownList ID="DropDownCityList" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Phone:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditPhone" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="tab-pane fade" id="tab3default">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Position:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditPosition" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Department:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditDepartment" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">University:</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox CssClass="form-control" ID="EditUni" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="tab-pane fade" id="tab4default">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Resume:</label>
                                        <div class="col-lg-8">
                                            <asp:FileUpload CssClass="form-control" ID="CvUpload" runat="server" Font-Bold="False" Font-Size="Small" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab5default">
                                <div id="identicalForm" class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Password</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="EditPassword" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Retype password</label>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="confirmPassword" runat="server" CssClass="form-control" TextMode="Password" OnTextChanged="ConfirmPassword_TextChanged"></asp:TextBox>
                                            <%--<asp:CompareValidator ID="CompareValidator1" runat="server"
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
                                            </asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-8 col-lg-offset-3">
                                            <asp:Button ID="SaveBtn" runat="server" Text="Save The Password" CssClass="btn btn-primary btn-block" OnClick="ChangePassBtn_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-3 control-label"></label>
                    <div class="col-md-8">
                        <asp:Button ID="SaveButton" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="SaveButton_Click" />
                        <span></span>
                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-default" />
                    </div>
                </div>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>

            </div>
        </div>
    </div>

</asp:Content>
