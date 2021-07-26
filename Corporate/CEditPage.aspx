<%@ Page Title="Edit" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" CodeBehind="CEditPage.aspx.cs" Inherits="ytuportal.web.Corporate.CEditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/MyJS.js"></script>
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.min.css" />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker3.min.css" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.min.js"></script>

    <div class="container">
        <h2 style="text-align: center;">Edit Your Profile</h2>
        <div class="col-md-4 col-md-offset-4 well">
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <asp:Label ID="Gender" CssClass="col-md-3" runat="server" Text="Gender:"></asp:Label>
                    <div class="col-md-9">
                        <asp:RadioButtonList ID="RadioBtnEditGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="EmployeeName" CssClass="col-md-3" runat="server" Text="Edit Name:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="EName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>
                <div class="form-group">
                    <asp:Label ID="EmployeeTel" CssClass="col-md-3" runat="server" Text="Phone Number:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="ETel" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="EmployeeEmail" CssClass="col-md-3" runat="server" Text="E-Mail:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="EEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                  <div class="form-group">
                    <asp:Label ID="EmployeeBirthday" CssClass="col-md-3" runat="server" Text="Birthday:"></asp:Label>
                    <div class="col-md-9">
                        <div class="date">
                            <div class="input-group input-append date" id="datePicker">
                                <asp:TextBox CssClass="form-control" ID="EBirthday" runat="server"></asp:TextBox>
                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="EmployeeJob" CssClass="col-md-3" runat="server" Text=" Job:"></asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox ID="EJob" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12 col-md-offset-1">
                        <asp:Button ID="EditEmpBtn" runat="server" Text="Edit The Profile" CssClass="btn btn-primary btn-block" OnClick="EditEmpBtn_Click" />
                    </div>
                </div>
                <asp:Label ID="ReqCheck" runat="server" Text="" CssClass="empty-field-alert"></asp:Label>
            </div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>




    </div>
</asp:Content>
