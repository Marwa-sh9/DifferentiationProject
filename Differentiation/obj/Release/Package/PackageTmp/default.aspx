<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" 
    Inherits="Differentiation._default" EnableEventValidation="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <link rel="stylesheet" href="Design/Home/HP.css"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Akaya+Telivigala&display=swap" rel="stylesheet"/>

</head>
<body>

    <form id="form1" runat="server">
                         <div style="height: 30px; width:auto; background-color:skyblue;">
        <marquee direction="right" onmouseover="this.stop()" onmouseout="this.start()">
          <asp:Label ID="lblMarquee" runat="server"
              Text="المفاضلة الجامعية 2020 تبدأ 1/8/2021 وتنتهي في التاريخ 1/9/2020"></asp:Label>
        </marquee>
      </div>
     <div>
    <nav class="navbar navbar-expand-lg navbar-light fixed-top">
       <a id="n1" class="navbar-brand" href="default.aspx">
         <img  src="Design/Home/logo.png" style="width: 20%;margin-right:20px;"/>
            University Differentiation
       </a>
        <asp:Button runat="server" class="btn btn-outline-success"
            OnClick="login_Click" style="margin-left: 950px;
           margin-right:40px; 
           margin-top:40px;
           background-color :lightgreen;font-size: 20px;
           font-style: italic;border:2px solid ;
           border-radius: 30px"
           Text="LogIn" />
    </nav>
      <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
          <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
          <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
          <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
          <div class="carousel-item active">
            <img class="d-block w-100" src="Design/Home/hp1.jpg" alt="First slide"/>
            <div class="carousel-caption d-none d-md-block">
                <h5 class="h1">Welcome To Our Wibsite</h5>
                <p class="h2" ></p>
              </div>
          </div>
          <div class="carousel-item">
            <img class="d-block w-100" src="Design/Home/hp2.jpg" alt="Second slide"/>
          </div>
          <div class="carousel-item">
            <img class="d-block w-100" src="Design/Home/hp3.png" alt="Third slide"/>
          </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="sr-only">Next</span>
        </a>
      </div>




    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
  </div>
 </form>
</body>
</html>
