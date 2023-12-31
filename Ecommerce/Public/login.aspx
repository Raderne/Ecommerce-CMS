﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Ecommerce.Public.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Page Meta Tags-->
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <meta name="keywords" content="" />

    <!-- Custom Google Fonts-->
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@500;600&family=Roboto:wght@300;400;700&display=auto"
        rel="stylesheet" />

    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="180x180" href="./assets/images/favicon/apple-touch-icon.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="./assets/images/favicon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="./assets/images/favicon/favicon-16x16.png" />
    <link rel="mask-icon" href="./assets/images/favicon/safari-pinned-tab.svg" color="#5bbad5" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="theme-color" content="#ffffff" />

    <!-- Vendor CSS -->
    <link rel="stylesheet" href="./assets/css/libs.bundle.css" />

    <!-- Main CSS -->
    <link rel="stylesheet" href="./assets/css/theme.bundle.css" />

    <!-- Fix for custom scrollbar if JS is disabled-->
    <noscript>
        <style>
            /**
        * Reinstate scrolling for non-JS clients
        */
            .simplebar-content-wrapper {
                overflow: auto;
            }
        </style>
    </noscript>

    <!-- Page Title -->
    <title>OldSkool | Login</title>
</head>
<body class=" bg-light">
    <form id="form1" runat="server">
        <!-- Main Section-->
        <section
            class="mt-0 overflow-hidden  vh-100 d-flex justify-content-center align-items-center p-4">
            <!-- Page Content Goes Here -->

            <!-- Login Form-->
            <div class="col col-md-8 col-lg-6 col-xxl-5">
                <!-- Logo-->
                <a class="navbar-brand fw-bold fs-3 flex-shrink-0 order-0 align-self-center justify-content-center d-flex mx-0 px-0" href="./index.aspx">
                    <div class="d-flex align-items-center">
                        <svg class="f-w-7" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 77.53 72.26">
                            <path d="M10.43,54.2h0L0,36.13,10.43,18.06,20.86,0H41.72L10.43,54.2Zm67.1-7.83L73,54.2,68.49,62,45,48.47,31.29,72.26H20.86l-5.22-9L52.15,0H62.58l5.21,9L54.06,32.82,77.53,46.37Z" fill="currentColor" fill-rule="evenodd" />
                        </svg>
                    </div>
                </a>
                <!-- / Logo-->
                <div class="shadow-xl p-4 p-lg-5 bg-white">
                    <h1 class="text-center fw-bold mb-5 fs-2">Login</h1>

                    <div class="form-group">
                        <label class="form-label" for="txt_loginEmail">Email address</label>
                        <input type="email" class="form-control" id="txt_loginEmail" runat="server" placeholder="name@email.com" />
                    </div>
                    <div class="form-group">
                        <label for="txt_LoginPassword" class="form-label d-flex justify-content-between align-items-center">
                            Password
                                <a href="./Forgotten-password.aspx" class="text-muted small">Forgot your password?</a>
                        </label>
                        <input type="password" class="form-control" id="txt_LoginPassword" runat="server" placeholder="Enter your password" />
                    </div>
                    <asp:Label ID="lbl_LoginError" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" class="btn btn-dark d-block w-100 my-4" Text="Login" />

                    <p class="d-block text-center text-muted">New customer? <a class="text-muted" href="./register.aspx">Sign up for an account</a></p>
                </div>

            </div>
            <!-- / Login Form-->

            <!-- /Page Content -->
        </section>
        <!-- / Main Section-->
    </form>

    <!-- Theme JS -->
    <!-- Vendor JS -->
    <script src="./assets/js/vendor.bundle.js"></script>

    <!-- Theme JS -->
    <script src="./assets/js/theme.bundle.js"></script>

</body>
</html>
