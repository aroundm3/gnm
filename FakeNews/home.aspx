<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="FakeNews.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
              crossorigin="anonymous">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">


  <link href="https://fonts.googleapis.com/css?family=B612+Mono|Cabin:400,700&display=swap" rel="stylesheet">

  <link rel="stylesheet" href="fonts/icomoon/style.css">

  <link rel="stylesheet" href="css/bootstrap.min.css">
  <link rel="stylesheet" href="css/jquery-ui.css">
  <link rel="stylesheet" href="css/owl.carousel.min.css">
  <link rel="stylesheet" href="css/owl.theme.default.min.css">
  <link rel="stylesheet" href="css/owl.theme.default.min.css">

  <link rel="stylesheet" href="css/jquery.fancybox.min.css">

  <link rel="stylesheet" href="css/bootstrap-datepicker.css">

  <link rel="stylesheet" href="fonts/flaticon/font/flaticon.css">

  <link rel="stylesheet" href="css/aos.css">
  <link href="css/jquery.mb.YTPlayer.min.css" media="all" rel="stylesheet" type="text/css">

  <link rel="stylesheet" href="css/style.css">
</head>
<body data-spy="scroll" data-target=".site-navbar-target" data-offset="300">
    <form id="form1" runat="server">
        <div class="site-wrap">

    <div class="site-mobile-menu site-navbar-target">
      <div class="site-mobile-menu-header">
        <div class="site-mobile-menu-close mt-3">
          <span class="icon-close2 js-menu-toggle"></span>
        </div>
      </div>
      <div class="site-mobile-menu-body"></div>
    </div>


    
    <div class="header-top">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-12 col-lg-6 d-flex">
            <a href="home.aspx" class="site-logo">
               GameSpot
            </a>

            <a href="#" class="ml-auto d-inline-block d-lg-none site-menu-toggle js-menu-toggle text-black"><span
                class="icon-menu h3"></span></a>

          </div>
          <div class="col-12 col-lg-6 ml-auto d-flex">
            <div class="ml-md-auto top-social d-none d-lg-inline-block">
              <a href="#" class="d-inline-block p-3"><span class="icon-facebook"></span></a>
                <a href="#" class="d-inline-block p-3"><span class="icon-twitter"></span></a>
                <a href="#" class="d-inline-block p-3"><span class="icon-instagram"></span></a>
            </div>
            <form action="#" class="search-form d-inline-block">

              <div class="d-flex">
                <input type="email" AutoPostBack="true" id="titleInput" class="form-control" placeholder="Search...">
                <button type="submit" class="btn btn-secondary" ><span class="icon-search"></span></button>
              </div>
            </form>

            
          </div>
          <div class="col-6 d-block d-lg-none text-right">
            
          </div>
        </div>
      </div>
         <div class="site-navbar py-2 js-sticky-header site-navbar-target d-none pl-0 d-lg-block" role="banner">

      <div class="container">
        <div class="d-flex align-items-center">
          
          <div class="mr-auto">
            <nav class="site-navigation position-relative text-right" role="navigation">


              <ul class="site-menu main-menu js-clone-nav mr-auto d-none pl-0 d-lg-block">
                  <asp:Repeater ID="platformBar" runat="server">
                      <ItemTemplate>
                          <li class="active">
                                <a DataNavigateUrlFormatString="home.aspx??" DataNavigateUrlFields="platformid"
                                    class="nav-link text-left"> <%#Eval("platformname")%></a>
                          </li>
                      </ItemTemplate>
                  </asp:Repeater>
              </ul>   
            </nav>

          </div>
         
        </div>
      </div>

    </div>
        </div>

    <div class="site-section py-0">
      <div class="owl-carousel hero-slide owl-style">

        <div class="site-section">
          <div class="container">
            <div class="half-post-entry d-block d-lg-flex bg-light">
              <div class="img-bg" style="background-image: url('images/big_img_1.jpg')"></div>
              <div class="contents">
                <span class="caption">Editor's Pick</span>
                <h2><a href="blog-single.html">News Needs to Meet Its Audiences Where They Are</a></h2>
                <p class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptate vero obcaecati natus adipisci necessitatibus eius, enim vel sit ad reiciendis. Enim praesentium magni delectus cum, tempore deserunt aliquid quaerat culpa nemo veritatis, iste adipisci excepturi consectetur doloribus aliquam accusantium beatae?</p>
                
                <div class="post-meta">
                  <span class="d-block"><a href="#">Dave Rogers</a> in <a href="#">Food</a></span>
                  <span class="date-read">Jun 14 <span class="mx-1">&bullet;</span> 3 min read <span class="icon-star2"></span></span>
                </div>

              </div>
            </div>
          </div>
        </div>

        <div class="site-section">
          <div class="container">
            <div class="half-post-entry d-block d-lg-flex bg-light">
              <div class="img-bg" style="background-image: url('images/big_img_1.jpg')"></div>
              <div class="contents">
                <span class="caption">Editor's Pick</span>
                <h2><a href="blog-single.html">News Needs to Meet Its Audiences Where They Are</a></h2>
                <p class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptate vero obcaecati natus adipisci necessitatibus eius, enim vel sit ad reiciendis. Enim praesentium magni delectus cum, tempore deserunt aliquid quaerat culpa nemo veritatis, iste adipisci excepturi consectetur doloribus aliquam accusantium beatae?</p>
                
                <div class="post-meta">
                  <span class="d-block"><a href="#">Dave Rogers</a> in <a href="#">Food</a></span>
                  <span class="date-read">Jun 14 <span class="mx-1">&bullet;</span> 3 min read <span class="icon-star2"></span></span>
                </div>

              </div>
            </div>
          </div>
        </div>


      </div>
    </div>
        
      </div>
        <div class="site-section">
      <div class="container">
        <div class="row">
          <div class="col-lg-6">
            <div class="section-title">
              <h2>News</h2>
            </div>
              <asp:Repeater ID="postList" runat="server">
                  <ItemTemplate>
                      <div class="post-entry-2 d-flex">
                        <div> <img src="../image/<%#Eval("image")%>"  width="350" height="250"> </div>
                        <div class="contents">
                        <h2><a href="detail.aspx?id=<%#Eval("postid")%>" ><%#Eval("title")%> </a></h2>
                        <div class="post-meta">
                         <span class="d-block"><a href="#">cre: </a> <%#Eval("username")%> <a href="#"> writer</a></span>
                        <span class="date-read"><%#Eval("datecreated")%><span class="mx-1">&bullet;</span> <span class="icon-star2"></span></span>
                        </div>
                        </div>
                    </div>
                   </ItemTemplate>
              </asp:Repeater>
            
          </div>
        </div>
      </div>
    </div>
        <div class="footer">
      <div class="container">
        

        <div class="row">
          <div class="col-12">
            <div class="copyright">
                <p>
                    <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                    Copyright &copy;<script>document.write(new Date().getFullYear());</script> All rights reserved | This template is made with <i class="icon-heart text-danger" aria-hidden="true"></i> by <a href="https://colorlib.com" target="_blank" >Colorlib</a>
                    <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                    </p>
            </div>
          </div>
        </div>
      </div>
    </div>
    </form>
</body>
</html>
