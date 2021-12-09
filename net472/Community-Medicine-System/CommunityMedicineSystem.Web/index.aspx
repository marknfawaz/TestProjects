<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<title>Community Medicine</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.3.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<style type="text/css">
.carousel,.item,.active{height:100%;}
.carousel-inner{height:100%;}
    body{
         background-color:gray; 
         padding-top: 75px;
         }
    .carousel{
                 background-color:gray; 
             }
.carousel .item img{
    width:100%;
}
</style>

</head> 
<body>
<nav role="navigation" class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" data-target="#navbarCollapse" data-toggle="collapse" class="navbar-toggle">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a href="#" class="navbar-brand"><span style=" font-size:x-large; color:yellowgreen">Community Medicine System</span> </a>
        </div>
        <!-- Collection of nav links and other content for toggling -->
        <div id="navbarCollapse" class="collapse navbar-collapse">
            <ul class="nav navbar-nav navbar-right">
                <li class="active"><a href="#">Home</a></li>
                <li><a href="./HeadOffice/HeadOfficeMainUI.aspx">Head Office</a></li>
                <li><a href="./Center/CenterLoginUI.aspx">Center</a></li>
            </ul>
        </div>
    </div>
</nav>
<div class="container">
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Carousel indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>   
        <!-- Wrapper for carousel items -->
        <div class="carousel-inner">
            <div class="item active">
               <img src="images/slider1.jpg" />
            </div>
            <div class="item">
                <img src="images/slider2.jpg" />
            </div>
            <div class="item">
                <img src="images/slider3.jpg" />
            </div>
        </div>
        <!-- Carousel controls -->
        <a class="carousel-control left" href="#myCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
        </a>
        <a class="carousel-control right" href="#myCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
        </a>
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