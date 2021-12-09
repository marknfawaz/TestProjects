<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientHistoryUI.aspx.cs" Inherits="CommunityMedicineSystem.Web.Center.PatientHistoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Patient History - Community Medicine System</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />


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
                    <img class="img-circle" src="../assets/img/team/logo.png" alt="">
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="../index.aspx">Home</a></li>
                        <li><a href="DoctorEntryUI.aspx">Doctor Entry</a></li>
                        <li><a href="MedicineStockReportUI.aspx">Medicine Stock Report</a></li>
                        <li><a href="TreatmentGivenUI.aspx">Treatment</a></li>
                        <li><asp:Button ID="logoutButton" runat="server" CssClass="btn btn-default" Text="Logout" OnClick="logoutButton_Click" /></li>
                    </ul>
                </div>

            </div>
        </div>

        <div id="about-section">
            <div class="container">
                <div class="row main-top-margin text-center">
                    <div class="col-md-8 col-md-offset-2 col-sm-12">
                        <h2>Welcome to <asp:Label ID="centerLabel" runat="server" Text=""></asp:Label></h2>
                    </div>
                </div>
            </div>
        </div>

        <div class="form-group">
            <label for="Label1" class="col-sm-4 control-label">Show All History Of A Patient</label>
            <hr />
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Voter Id</label>
            <div class="col-sm-5">
                <asp:TextBox ID="voterIdTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Name</label>
            <div class="col-sm-5">
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Address</label>
            <div class="col-sm-5">
                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control" Height="72px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

            </div>
        </div>

        <br />

         <div class="form-group">
            <div class="col-sm-8">
                <asp:GridView ID="patientHistoryGridView" class="table table-striped" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="PatientId" HeaderText="Patient Id" SortExpression="PatientId" />
                        <asp:BoundField DataField="VoterId" HeaderText="Voter Id" SortExpression="VoterId" />
                        <asp:BoundField DataField="CenterName" HeaderText="Center Name" SortExpression="CenterName" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <center>
        <div>
                <a href="#">Show All History In A PDF Format</a>
        </div>
        </center>

        <div class="text-center" id="social">
            <a href="#"><i class="fa fa-facebook-square fa-3x color-facebook"></i></a>
            <a href="#"><i class="fa fa-twitter-square fa-3x color-twitter"></i></a>
            <a href="#"><i class="fa fa-google-plus-square fa-3x color-google-plus"></i></a>
            <a href="#"><i class="fa fa-linkedin-square fa-3x color-linkedin"></i></a>
            <a href="#"><i class="fa fa-pinterest-square fa-3x color-pinterest"></i></a>
        </div>

    <nav role="navigation" class="navbar navbar-inverse navbar-fixed-bottom">
        <div class="container">
             <div class="navbar-text pull-left">
                      <p>&copy;2015 Design and developed by Miraj Hossain | All Right Reserved</p> 
             </div>
        </div>
    </nav>

        <script src="../assets/js/jquery.js"></script>
        <script src="../Scripts/bootstrap.min.js"></script>
        <script src="../assets/js/modernizr.custom.79639.js"></script>
        <script src="../assets/js/jquery.ba-cond.min.js"></script>
        <script src="../assets/js/jquery.slitslider.js"></script>
        <script src="../assets/js/custom.js"></script>

    </form>
</body>

</html>
