<%@ Page Title="Registration" Language="C#" MasterPageFile="~/CMasterPage.Master" AutoEventWireup="true" CodeBehind="CRegister.aspx.cs" Inherits="ytuportal.web.Corporate.CRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container-fluid" style="margin-top: 50px;">
        <section class="container">
            <div class="container-page">
                <div class="col-md-12 col-md-offset-2">
                    <div class="col-md-4 well">

                        <h3 class="dark-grey form-group col-md-12"><b>Registration</b></h3>
                        <p class="form-group col-md-12">To register, please fill the blanks.</p>
                        <hr />

                        
                            <div class="form-group col-md-12">
                                <label>Name:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-user"></i>
                                    <asp:TextBox ID="TextName" runat="server" CssClass="form-control" ></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-group col-md-12">
                                <label>Phone Number:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-earphone"></i>
                                    <asp:TextBox ID="TextPhone" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group col-md-12">
                                <label>Email Address:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-envelope"></i>
                                    <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                             <div class="form-group col-md-12">
                                <label>Password:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-lock"></i>
                                    <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                              </div>

                            <div class="form-group col-md-12">
                                <label>Company Name:</label>
                                <div class="inner-addon left-addon">
                                    <i class="glyphicon glyphicon-briefcase"></i>
                                    <asp:TextBox ID="TextCName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group col-md-12">
                                <label>City:</label>
                                <div class="inner-addon left-addon">
                                    <asp:DropDownList ID="DropDownCityList" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Enabled="true">Please choose one...</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                
                            <div class="form-group col-md-12">
                                <hr />
                                <div style="text-align: center;">
                                    <asp:Button ID="AddEmployeeBtn" runat="server" Text="Register" CssClass="btn btn-block btn-primary" OnClick="AddEmployeeBtn_Click"/>
                                </div>
                            </div>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        

                    </div>

                    <div class="col-md-4 well" style="height: 671px;">
                        <div style="margin-top:150px;">
                            <h3 class="dark-grey" >If you already signed up, please <a href="CLoginPage.aspx">Log in</a></h3>
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
        <div class="col-md-6 col-md-offset-3" style="text-align: center; font-weight:bold;">
                <div id="alertdiv" runat="server" class="alert alert-danger" role="alert">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </div>
        </div>
    </div>
</asp:Content>
