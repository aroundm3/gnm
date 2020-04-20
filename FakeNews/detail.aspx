<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="FakeNews.detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <style type="text/css">
body {
	margin: 0;
}
body, table, td, p, a, li, blockquote {
	-webkit-text-size-adjust: none!important;
	font-family: sans-serif;
	font-style: normal;
	font-weight: 400;
}
button {
	width: 90%;
}

@media screen and (max-width:600px) {
/*styling for objects with screen size less than 600px; */
body, table, td, p, a, li, blockquote {
	-webkit-text-size-adjust: none!important;
	font-family: sans-serif;
}
table {
	/* All tables are 100% width */
	width: 100%;
}
.footer {
	/* Footer has 2 columns each of 48% width */
	height: auto !important;
	max-width: 48% !important;
	width: 48% !important;
}
table.responsiveImage {
	/* Container for images in catalog */
	height: auto !important;
	max-width: 30% !important;
	width: 30% !important;
}
table.responsiveContent {
	/* Content that accompanies the content in the catalog */
	height: auto !important;
	max-width: 66% !important;
	width: 66% !important;
}
.top {
	/* Each Columnar table in the header */
	height: auto !important;
	max-width: 48% !important;
	width: 48% !important;
}
.catalog {
	margin-left: 0%!important;
}
}

@media screen and (max-width:480px) {
/*styling for objects with screen size less than 480px; */
body, table, td, p, a, li, blockquote {
	-webkit-text-size-adjust: none!important;
	font-family: sans-serif;
}
table {
	/* All tables are 100% width */
	width: 100% !important;
	border-style: none !important;
}
.footer {
	/* Each footer column in this case should occupy 96% width  and 4% is allowed for email client padding*/
	height: auto !important;
	max-width: 96% !important;
	width: 96% !important;
}
.table.responsiveImage {
	/* Container for each image now specifying full width */
	height: auto !important;
	max-width: 96% !important;
	width: 96% !important;
}
.table.responsiveContent {
	/* Content in catalog  occupying full width of cell */
	height: auto !important;
	max-width: 96% !important;
	width: 96% !important;
}
.top {
	/* Header columns occupying full width */
	height: auto !important;
	max-width: 100% !important;
	width: 100% !important;
}
.catalog {
	margin-left: 0%!important;
}
button {
	width: 90%!important;
}
}
</style>
</head>
<body>
    <form id="form1" runat="server">
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
                <input type="email" class="form-control" placeholder="Search...">
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
        <div>
			<table width="100%"  cellspacing="0" cellpadding="0">
				<tbody>
					<tr>
						<td>
							<table width="600"  align="center" cellpadding="0" cellspacing="0">
								<asp:Repeater ID="postCt" runat="server">
									<ItemTemplate>
										<tbody>
									<td style="font-size: 0; line-height: 0;" height="20"><table align="left"  cellpadding="0" cellspacing="0" >
										<tr>
											 <td ><img src="../image/<%#Eval("image")%>"  alt="" height="" width="100%" class=""></td>
										</tr>
									</table></td>
									<tr> 
									<!-- Introduction area -->
										<td><table width="96%"  align="left" cellpadding="0" cellspacing="0">
											<tr> 
											 <!-- row container for TITLE/EMAIL THEME -->
												<td align="center" style="font-size: 32px; font-weight: 300; line-height: 2.5em; color: #929292; font-family: sans-serif;"><%#Eval("title")%></td>
											</tr>
										  <tr> 
											<!-- row container for Tagline -->
											<td align="center" style="font-size: 16px; font-weight:300; color: #929292; font-family: sans-serif;">Cre <%#Eval("username")%></td>
										  </tr>
										  <tr>
											<td style="font-size: 0; line-height: 0;" height="20"><table width="96%" align="left"  cellpadding="0" cellspacing="0">
												<tr> 
												  <!-- HTML Spacer row -->
												  <td style="font-size: 0; line-height: 0;" height="20">&nbsp;</td>
												</tr>
											  </table></td>
										  </tr>
										  <tr> 
											<!-- Row container for Intro/ Description -->
											<td align="left" style="font-size: 14px; font-style: normal; font-weight: 100; color: #929292; line-height: 1.8; 
														text-align:justify; padding:10px 20px 0px 20px; font-family: sans-serif;">
												<%#Eval("content")%>
											
												</tr>
									</table></td>
								</tr>
								</tbody>
									</ItemTemplate>
								</asp:Repeater>
								
							</table>
						</td>	
					</tr>
				</tbody>
			</table>
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
