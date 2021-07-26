<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sign-up.aspx.cs" Inherits="ytuportal.web.Sign_up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid" style="margin-top: 70px;">
        <section class="container">
            <div class="container-page">
                <div class="col-md-9 col-md-offset-3">
                    <div class="col-md-4 well">

                        <h3 class="dark-grey" style="text-align: center;"><b>Registration</b></h3>


                        <p style="text-align: center;">To register, please fill the blanks.</p>
                        <hr />
                        <div class="row">
                            <div class="form-group col-md-6">
                                <label>Name:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-user"></i>
                                    <asp:TextBox ID="TextName" runat="server" CssClass="form-control" placeholder="Berk"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group col-md-6">
                                <label>Surname:</label>
                                <asp:TextBox ID="TextSurname" runat="server" CssClass="form-control" placeholder="Algül"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-md-12">
                                <label>Email Address:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-envelope"></i>
                                    <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="abc@example.com"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label>Password:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-lock"></i>
                                    <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="*******"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-md-12">
                                <hr />
                                <div style="text-align: center;">
                                    <asp:Button ID="AddUserBtn" runat="server" Text="Register" CssClass="btn btn-primary" Width="150px" OnClick="AddUserBtn_Click" />
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="col-md-4 well" style="height: 470px;">
                        <div style="margin-top: 25px;">
                            <h3 class="dark-grey">If you already signed up, please <a href="LoginPage.aspx">Log in</a></h3>
                            <hr />
                            <p>
                                By clicking on "Register" you agree to The Company's' Terms and Conditions
				
					While rare, prices are subject to change based on exchange rate fluctuations - 
					should such a fluctuation happen, we may request an additional payment. You have the option to request a full refund or to pay the new price. (Paragraph 13.5.8)
				
					Should there be an error in the description or pricing of a product, we will provide you with a full refund (Paragraph 13.5.6)
				
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </section>
        <div class="col-md-9 col-md-offset-3" style="text-align: center; font-weight:bold;">
            <div class="col-md-9">
                <div id="alertdiv" runat="server" class="alert alert-danger" role="alert">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </div>
            </div>

        </div>
    </div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

</asp:Content>
