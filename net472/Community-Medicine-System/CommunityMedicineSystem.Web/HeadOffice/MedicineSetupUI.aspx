<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedicineSetupUI.aspx.cs" Inherits="CommunityMedicineSystem.Web.HeadOffice.MedicineSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Medicine Setup - Community Medicine System</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <%--<link href="assets/css/bootstrap.css" rel="stylesheet" />--%>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />

    <link href="../assets/css/style-slide.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />

    <link href="../assets/css/style.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server" class="form-horizontal">

        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                   <a href="#" class="navbar-brand"><span style=" font-size:x-large; color:yellowgreen">Community Medicine System</span> </a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="../index.aspx">Home</a></li>
                        <%--<li><a href="#">Medicine Setup</a></li>--%>
                        <li><a href="DiseaseSetupUI.aspx">Disease Setup</a></li>
                        <li><a href="CreateNewCenterUI.aspx">Create New Center</a></li>
                        <li><a href="SendMedicineToCenterUI.aspx">Send Medicine to Center</a></li>
                        <li><a href="PatientHistoryUI.aspx">Search Patient History</a></li>
                        <%--<li><a href="#offer"><i class="color-twitter">Today's OFFER</i></a></li>--%>
                    </ul>
                </div>

            </div>
        </div>

        <div id="about-section">
            <div class="container">
                <div class="row main-top-margin text-center">
                    <div class="col-md-8 col-md-offset-2 col-sm-12">
                        <h2>Welcome to Head Office</h2>
                    </div>
                </div>

                <div class="form-group">
                    <label for="Label1" class="col-sm-3 control-label">Basic Medicine Setup :</label>
                    <hr />
                </div>

                <div class="form-group">
                    <label for="inputName" class="col-sm-2 control-label">Generic Name</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" placeholder="Medicine Name"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <label for="inputPower" class="col-sm-2 control-label">Power</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="powerTextBox" runat="server" CssClass="form-control" placeholder="Power"></asp:TextBox>

                    </div>
                    <div class="col-sm-1">
                        <asp:DropDownList ID="mgMlDropDownList" CssClass="form-control" runat="server">
                            <asp:ListItem>mg</asp:ListItem>
                            <asp:ListItem>ml</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="saveButton" runat="server" CssClass="btn btn-info" Text="Save" OnClick="saveButton_Click" />
                    </div>
                </div>

                <asp:Label ID="msgLabel" runat="server"></asp:Label>
            </div>
        </div>
         <nav role="navigation" class="navbar navbar-inverse navbar-fixed-bottom">
            <div class="container">
                 <div class="navbar-text pull-left">
                          <p>&copy;2015 Design and developed by Miraj Hossain | All Right Reserved</p> 
                 </div>
            </div>
        </nav>

        <script src="../assets/js/jquery.js"></script>
        <%--<script src="assets/js/bootstrap.min.js"></script>--%>
        <script src="../Scripts/bootstrap.min.js"></script>
        <script src="../assets/js/modernizr.custom.79639.js"></script>
        <script src="../assets/js/jquery.ba-cond.min.js"></script>
        <script src="../assets/js/jquery.slitslider.js"></script>
        <script src="../assets/js/custom.js"></script>

    </form>
</body>

</html>

