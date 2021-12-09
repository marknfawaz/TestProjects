<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiseaseWiseReport.aspx.cs" Inherits="CommunityMedicineSystem.Web.HeadOffice.DiseaseWiseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">



    <title></title>
    <%--<link href="assets/css/bootstrap.css" rel="stylesheet" />--%>
    <%--<link href="assets/css/bootstrap.css" rel="stylesheet" />--%>
</head>
<body>
    <strong>Disease-wise Report</strong>
    <form id="form1" runat="server" class="form-horizontal">
        <div>
            <label for="inputDisease" class="col-sm-2 control-label">Select Disease</label><br />
            <div class="col-sm-4">
                <asp:DropDownList ID="diseaseDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                <br />
                <br />
            </div>
            <label for="startDate" class="col-sm-2 control-label">Date between</label>
            <div class="col-sm-4">
                <input type="text" id="startTextBox" runat="server" />
            </div>
            <label for="endDate" class="col-sm-2 control-label">
                and<br />
                <input type="text" id="endTextBox" runat="server" />
            </label>
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                <br />
            </div>
            &nbsp;<div class="col-sm-4">

                <asp:GridView ID="showGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1" BorderColor="black" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="DistrictName" HeaderText="District Name" ItemStyle-Width="150">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalPatient" HeaderText="Total Patients" ItemStyle-Width="150">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PercentagePatient" HeaderText="% Over Population" ItemStyle-Width="120">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

                <br />
            </div>
        </div>

    </form>

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(function () {
            $("#startTextBox").datepicker();
            $("#endTextBox").datepicker();
        });
        $(document).ready(function () {
            $('#showGridView').dataTable();
        });

    </script>
</body>
</html>
