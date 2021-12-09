<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewCenterUI.aspx.cs" Inherits="CommunityMedicineSystem.Web.HeadOffice.CreateNewCenterUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Create New Center - Community Medicine System</title>
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
                        <li><a href="MedicineSetupUI.aspx">Medicine Setup</a></li>
                        <li><a href="DiseaseSetupUI.aspx">Disease Setup</a></li>
                        <%--  <li><a href="#">Create New Center</a></li>--%>
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
                        <hr />
                        <h4>
                            <strong>Create New Center</strong>
                        </h4>
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <label for="inputCenterName" class="col-sm-2 control-label">Center Name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputDistrictName" class="col-sm-2 control-label">District</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="districtDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputThanaName" class="col-sm-2 control-label">Thana</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="thanaDropDownList" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
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

