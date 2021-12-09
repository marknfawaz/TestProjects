<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HeadOfficeMainUI.aspx.cs" Inherits="CommunityMedicineSystem.Web.HeadOffice.HeadOfficeMainUI" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Head Office - Community Medicine System</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/style-slide.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.3.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <style type="text/css">
    .list-group{width:300px; margin:auto}
   </style>
</head>


<body>
   <nav role="navigation" class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header ">
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
                    </ul>
                </div>

            </div>
 </nav>


       <div id="about-section">
            <div class="container">
                <div class="row main-top-margin text-center">
                    <div class="col-md-8 col-md-offset-2 col-sm-12">
                        <h2>Welcome to Head office</h2>
                        <hr/>
                    </div>
                </div>
            </div>
        </div><br />  
<div class="container">
 <div class="list-group">
  <a href="CreateNewCenterUI.aspx" class="list-group-item list-group-item-warning">Create new Center</a>
  <a href="MedicineSetupUI.aspx" class="list-group-item list-group-item-success">Enter Medicine</a>
  <a href="DiseaseSetupUI.aspx" class="list-group-item list-group-item-info">Enter Disease</a>
  <a href="SendMedicineToCenterUI.aspx" class="list-group-item list-group-item-danger">Send Medicine to Center</a>
  <a href="PatientHistoryUI.aspx" class="list-group-item list-group-item-danger">Search patient History</a>
  <a href="DiseaseWiseReport.aspx" class="list-group-item list-group-item-danger">Create Report</a>
</div>
</div>
 <nav role="navigation" class="navbar navbar-inverse navbar-fixed-bottom">
    <div class="container">
         <div class="navbar-text pull-left">
                  <p>&copy;2015 Design and developed by Miraj Hossain | All Right Reserved</p> 
         </div>
    </div>
</nav>
</body>

</html>
