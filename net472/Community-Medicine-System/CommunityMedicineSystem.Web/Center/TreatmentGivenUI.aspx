<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreatmentGivenUI.aspx.cs" Inherits="CommunityMedicineSystem.Web.Center.TreatmentGivenUI" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="myApp">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Treatment Given - Community Medicine System</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Content/datepicker.css" rel="stylesheet" />
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/style-slide.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <link href="../myStyle.css" rel="stylesheet" />
    <style>
        li #logoutButton{margin-top:8PX}
    </style>
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
                        <li><a href="DoctorEntryUI.aspx">Doctor Entry</a></li>
                        <li><a href="MedicineStockReportUI.aspx">Medicine Stock Report</a></li>
                        <li><a href="#">Treatment</a></li>
                        <li><asp:Button ID="logoutButton" runat="server" CssClass="btn btn-danger" Text="Logout" OnClick="logoutButton_Click" /></li>
                    </ul>
                </div>

            </div>
        </div>

        <div id="about-section">
            <div class="container">
                <div class="row main-top-margin text-center">
                    <div class="col-md-8 col-md-offset-2 col-sm-12">
                        <h2>Welcome to
                            <asp:Label ID="centerLabel" runat="server" Text=""></asp:Label></h2>
                        <hr />
                        <h4>Treatment</h4>
                    </div>

                </div>
                <hr />
                <div class="form-group">
                    <asp:Label ID="infoLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label for="voterIdTextBox" class="col-sm-2 control-label">Voter Id</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="voterIdTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="showDetailsButton" runat="server" Text="Show Details" CssClass="btn btn-success" OnClick="showDetailsButton_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="nameTextBox" class="col-sm-2 control-label">Name</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addressTextBox" class="col-sm-2 control-label">Address</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control" ReadOnly="True" Height="72px" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ageTextBox" class="col-sm-2 control-label">Age</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="ageTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="serviceGivenTextBox" class="col-sm-2 control-label">Service Given</label>
                    <div class="col-sm-1">
                        <asp:TextBox ID="serviceGivenTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">times</label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-3">
                        <asp:Button ID="showAllHistoryButton" runat="server" Text="Show All History" CssClass="btn btn-default btn-lg btn-block" OnClick="showAllHistoryButton_Click" />
                        <%--<asp:HyperLink ID="showAllHistoryLink" NavigateUrl="PatientHistoryUI.aspx" runat="server" CssClass="btn btn-default btn-lg btn-block">Show All History</asp:HyperLink>--%>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-1">
                        <label for="observationTextBox" class="control-label">Observation</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="observationTextBox" runat="server" CssClass="form-control" Height="72px" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-sm-1">
                        <label for="dateTextBox" class="control-label">Date</label>
                    </div>
                    <div class="col-sm-3">
                        <input type="text" runat="server" id="dateTextBox" class="form-control" readonly="readonly" />
                        <%--<asp:TextBox ID="dateTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>--%>
                    </div>
                    <div class="col-sm-1">
                        <label for="doctorDropDownList" class="control-label">Doctor</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="doctorDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <hr />

                <div class="form-group">
                    <label for="diseaseDropDownList" class="col-sm-1 control-label">Select Disease</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ng-model="disease" ID="diseaseDropDownList" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <label for="medicineDropDownList" class="col-sm-1 control-label">Select Medicine</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ng-model="medicine" ID="medicineDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <label for="doseDropDownList" class="col-sm-1 control-label">Dose</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ng-model="dose" ID="doseDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem>1+0+0</asp:ListItem>
                            <asp:ListItem>0+1+0</asp:ListItem>
                            <asp:ListItem>0+0+1</asp:ListItem>
                            <asp:ListItem>1+1+0</asp:ListItem>
                            <asp:ListItem>1+0+1</asp:ListItem>
                            <asp:ListItem>0+1+1</asp:ListItem>
                            <asp:ListItem>1+1+1</asp:ListItem>
                            <asp:ListItem>1+1+1+1</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3">
                        <input type="radio" ng-model="doseType" value="Before Meal" class="radio radio-inline" />Before Meal
                        <input type="radio" ng-model="doseType" value="After Meal" class="radio radio-inline" />After Meal
                    </div>
                </div>
                <div class="form-group">
                    <label for="quantityGivenTextBox" class="col-sm-1 control-label">Quantity Given</label>
                    <div class="col-sm-2">
                        <asp:TextBox ng-model="quantityGiven" ID="quantityGivenTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label for="noteTextBox" class="col-sm-1 control-label">Note</label>
                    <div class="col-sm-3">
                        <asp:TextBox ng-model="note" ID="noteTextBox" runat="server" CssClass="form-control" Height="72px" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <button type="button" ng-click="AddSuggestion(disease, medicine, dose, doseType, quantityGiven, note)" class="btn btn-success">Add</button>

                    </div>
                </div>
                <hr />

                <div class="form-group">
                    <table id="tbl" runat="server" class="table table-hover">
                        <thead>
                            <tr>
                                <td>Disease</td>
                                <td>Medicine</td>
                                <td>Dose</td>
                                <td>Before/After Meal</td>
                                <td>Quantity Given</td>
                                <td>Note</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="aSuggestion in suggestions">
                                <td>{{aSuggestion.Disease}}</td>
                                <td>{{aSuggestion.Medicine}}</td>
                                <td>{{aSuggestion.Dose}}</td>
                                <td>{{aSuggestion.DoseType}}</td>
                                <td>{{aSuggestion.QuantityGiven}}</td>
                                <td>{{aSuggestion.Note}}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <p>
                    <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="saveButton_Click" />
                </p>
            </div>
        </div>
    <nav role="navigation" class="navbar navbar-inverse navbar-bottom">
        <div class="container">
             <div class="navbar-text pull-left">
                      <p>&copy;2015 Design and developed by Miraj Hossain | All Right Reserved</p> 
             </div>
        </div>
    </nav>>
        <input type="hidden" id="diseaseName" runat="server" />
        <input type="hidden" id="medicineName" runat="server" />
        <input type="hidden" id="medicineDose" runat="server" />
        <input type="hidden" id="medicineDoseType" runat="server" />
        <input type="hidden" id="medicineQuantityGiven" runat="server" />
        <input type="hidden" id="notes" runat="server" />
    </form>

    <script src="../Scripts/jquery-2.1.3.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script src="../assets/js/modernizr.custom.79639.js"></script>
    <script src="../assets/js/jquery.ba-cond.min.js"></script>
    <script src="../assets/js/jquery.slitslider.js"></script>
    <script src="../assets/js/custom.js"></script>
    <script src="../Scripts/angular.js"></script>
    <script>
        $(document).ready(function () {
            $(function () {
                $("#dateTextBox").datepicker();
            });
        });

        var myApplication = angular.module("myApp", []);
        myApplication.controller("myController", function ($scope) {
            $scope.suggestions = [];
            $scope.AddSuggestion = function (disease, medicine, dose, doseType, quantityGiven, note) {

                $scope.suggestions.push({ Disease: disease, Medicine: medicine, Dose: dose, DoseType: doseType, QuantityGiven: quantityGiven, Note: note });

                var medicineName = medicine.split(",");
                document.getElementById("diseaseName").value += disease + ",";
                document.getElementById("medicineName").value += medicineName[0] + ",";
                document.getElementById("medicineDose").value += dose + ",";
                document.getElementById("medicineDoseType").value += doseType + ",";
                document.getElementById("medicineQuantityGiven").value += quantityGiven + ",";
                document.getElementById("notes").value += note + ",";
            };
        });
    </script>
</body>

</html>
