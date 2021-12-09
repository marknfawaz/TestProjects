<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMedicineToCenterUI.aspx.cs" Inherits="CommunityMedicineSystem.Web.HeadOffice.SendMedicineToCenterUI" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="myApp">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Send Medicine to Center - Community Medicine System</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <%--<link href="assets/css/bootstrap.css" rel="stylesheet" />--%>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />

    <link href="../assets/css/style-slide.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />

    <link href="../assets/css/style.css" rel="stylesheet" />
    <link href="../myStyle.css" rel="stylesheet" />
</head>

<body ng-controller="myController">
    <form id="sendMedicineForm" class="form-horizontal" runat="server">

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
                        <li><a href="CreateNewCenterUI.aspx">Create New Center</a></li>
                        <%--<li><a href="#">Send Medicine to Center</a></li>--%>
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
                            <strong>Send Medicine to Center</strong>
                        </h4>
                    </div>
                   
                </div>
                 <hr />
                
                <div class="form-group">
                    <label for="districtDropDownList" class="col-sm-2 control-label">District</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="districtDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="thanaDropDownList" class="col-sm-2 control-label">Thana</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="thanaDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="thanaDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="centerDropDownList" class="col-sm-2 control-label">Center</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="centerDropDownList" runat="server" CssClass="form-control" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <label for="addMedicine" class="col-sm-2 control-label">Add Medicine</label>
                    <hr />
                </div>
                
                <div class="form-group">
                    <label for="medicineDropDownList" class="col-sm-2 control-label">Select Medicine</label>
                    <div class="col-sm-3">
                        <asp:DropDownList ng-model="name" ID="medicineDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <label for="quantityTextBox" class="col-sm-2 control-label">Quantity</label>
                    <div class="col-sm-3">
                        <asp:TextBox ng-model="quantity" ID="quantityTextBox" runat="server" placeholder="Quantity" CssClass="form-control"></asp:TextBox>
                    </div>
                    <button type="button" ng-click="AddMedicine(name,quantity)" class="btn btn-success">Add</button>
                </div>
                <hr />

                <div class="form-group">
                    <table id="tbl" runat="server" class="table table-hover">
                        <thead>
                            <tr>
                                <td>Name</td>
                                <td>Quantity</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="aMedicine in medicines">
                                <td>{{aMedicine.Name}}</td>
                                <td>{{aMedicine.Quantity}}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <p>
                    <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="saveButton_Click" />
                </p>
                <asp:Label ID="infoLabel" runat="server" Text=""></asp:Label>
            </div>
        </div>
     <nav role="navigation" class="navbar navbar-inverse navbar-bottom">
        <div class="container">
             <div class="navbar-text pull-left">
                      <p>&copy;2015 Design and developed by Miraj Hossain | All Right Reserved</p> 
             </div>
        </div>
    </nav>
        <input type="hidden" id="medicineName" runat="server"/>
        <input type="hidden" id="medicineQuantity" runat="server"/>
    </form>

    <script src="../assets/js/jquery.js"></script>
    <%--<script src="assets/js/bootstrap.min.js"></script>--%>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../assets/js/modernizr.custom.79639.js"></script>
    <script src="../assets/js/jquery.ba-cond.min.js"></script>
    <script src="../assets/js/jquery.slitslider.js"></script>
    <script src="../assets/js/custom.js"></script>
    <script src="../Scripts/angular.js"></script>
    <script>
        var myApplication = angular.module("myApp", []);
        myApplication.controller("myController", function ($scope) {
            $scope.medicines = [];
            $scope.AddMedicine = function (name, quantity) {
                if (name != String.empty && quantity != String.empty) {
                    $scope.medicines.push({ Name: name, Quantity: quantity });
                    var medicineName = name.split(",");
                    document.getElementById("medicineName").value += medicineName[0] + ",";
                    document.getElementById("medicineQuantity").value += quantity + ",";
                }
            };
        });
    </script>
</body>

</html>
