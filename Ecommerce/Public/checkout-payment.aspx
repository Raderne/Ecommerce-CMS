<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout-payment.aspx.cs" Inherits="Ecommerce.Public.checkout_payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Page Meta Tags-->
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta name="keywords" content="">

    <!-- Custom Google Fonts-->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@500;600&family=Roboto:wght@300;400;700&display=auto"
        rel="stylesheet">

    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="180x180" href="./assets/images/favicon/apple-touch-icon.png">
    <link rel="icon" type="image/png" sizes="32x32" href="./assets/images/favicon/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="./assets/images/favicon/favicon-16x16.png">
    <link rel="mask-icon" href="./assets/images/favicon/safari-pinned-tab.svg" color="#5bbad5">
    <meta name="msapplication-TileColor" content="#da532c">
    <meta name="theme-color" content="#ffffff">

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
    <title>OldSkool | Ödeme</title>

</head>
<body>
    <form id="form" runat="server">
        <!-- Main Section-->
        <section class="mt-0  vh-lg-100">
            <!-- Page Content Goes Here -->
            <div class="container">
                <div class="row g-0 vh-lg-100">
                    <div class="col-lg-7 pt-5 pt-lg-10">
                        <div class="pe-lg-5">
                            <!-- Logo-->
                            <a class="navbar-brand fw-bold fs-3 flex-shrink-0 mx-0 px-0" href="./index.aspx">
                                <div class="d-flex align-items-center">
                                    <svg class="f-w-7" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 77.53 72.26">
                                        <path d="M10.43,54.2h0L0,36.13,10.43,18.06,20.86,0H41.72L10.43,54.2Zm67.1-7.83L73,54.2,68.49,62,45,48.47,31.29,72.26H20.86l-5.22-9L52.15,0H62.58l5.21,9L54.06,32.82,77.53,46.37Z" fill="currentColor" fill-rule="evenodd" />
                                    </svg>
                                </div>
                            </a>
                            <!-- / Logo-->
                            <nav class="d-none d-md-block">
                                <ul class="list-unstyled d-flex justify-content-start mt-4 align-items-center fw-bolder small">
                                    <li class="me-4"><a class="nav-link-checkout"
                                        href="./cart.aspx">Sizin Sepetiniz</a></li>
                                    <li><a class="nav-link-checkout nav-link-last active"
                                        href="#">Ödeme</a></li>
                                </ul>
                            </nav>
                            <div class="mt-5">
                                <!-- Checkout Panel Information-->
                                <h3 class="fs-5 fw-bolder mb-4 border-bottom pb-4">Payment Information</h3>

                                <div class="row">
                                    <!-- Payment Option-->
                                    <div class="col-12">
                                        <div class="form-check form-group form-check-custom form-radio-custom mb-3">
                                            <input class="form-check-input" type="radio" name="checkoutPaymentMethod" id="checoutPaymentStripe" checked="checked" />
                                            <label class="form-check-label" for="checoutPaymentStripe">
                                                <span class="d-flex justify-content-between align-items-start">
                                                    <span>
                                                        <span class="mb-0 fw-bolder d-block">Kredi Kartı</span>
                                                    </span>
                                                    <i class="ri-bank-card-line"></i>
                                                </span>
                                            </label>
                                        </div>
                                    </div>

                                    <!-- Payment Option-->
                                    <div class="col-12">
                                        <div class="form-check form-group form-check-custom form-radio-custom mb-3">
                                            <input class="form-check-input" type="radio" name="checkoutPaymentMethod" id="checkoutPaymentPaypal">
                                            <label class="form-check-label" for="checkoutPaymentPaypal">
                                                <span class="d-flex justify-content-between align-items-start">
                                                    <span>
                                                        <span class="mb-0 fw-bolder d-block">PayPal</span>
                                                    </span>
                                                    <i class="ri-paypal-line"></i>
                                                </span>
                                            </label>
                                        </div>
                                    </div>

                                </div>

                                <!-- Payment Details-->
                                <div class="card-details">
                                    <div class="row pt-3">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="cc-name" class="form-label">Name on card</label>
                                                <input type="text" class="form-control" id="cc-name" placeholder="" required="" />
                                                <small class="text-muted">Kartta gösterilen tam ad</small>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="cc-number" class="form-label">Kredi kartı numaranız</label>
                                                <input type="text" class="form-control" id="cc-number" placeholder="" required="" />
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="cc-expiration" class="form-label">Son kullanma tarihi</label>
                                                <input type="text" class="form-control" id="cc-expiration" placeholder="" required="" />
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="d-flex">
                                                    <label for="cc-cvv" class="form-label d-flex w-100 justify-content-between align-items-center">Güvenlik Kodu</label>
                                                </div>
                                                <input type="text" class="form-control" id="cc-cvv" placeholder="" required="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- / Payment Details-->

                                <!-- Paypal Info-->
                                <div class="paypal-details bg-light p-4 d-none my-3 fw-bolder">
                                    Lütfen siparişi tamamla butonuna tıklayınız. Daha sonra ödeme bilgilerinizi girmeniz için Paypal'a aktarılacaksınız.
                                </div>
                                <!-- /Paypal Info-->

                                <!-- Accept Terms Checkbox-->
                                <div class="form-group form-check m-0">
                                    <input type="checkbox" class="form-check-input" id="accept-terms" checked="checked" />
                                    <label class="form-check-label fw-bolder" for="accept-terms">
                                        I agree to OldSkool's <a href="#">terms & conditions</a></label>
                                </div>

                                <div class="pt-5 mt-5 pb-5 border-top d-flex flex-column flex-md-row justify-content-between align-items-center">
                                    <a href="./Cart.aspx" class="btn ps-md-0 btn-link fw-bolder w-100 w-md-auto mb-2 mb-md-0" role="button">Sepete Geri Dön</a>
                                    <%-- TODO: Complete order --%>
                                    <a href="#" class="btn btn-dark w-100 w-md-auto" role="button">Siparişi Tamamlayın</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-lg-5 bg-light pt-lg-10 aside-checkout pb-5 pb-lg-0 my-5 my-lg-0">
                        <div class="p-4 py-lg-0 pe-lg-0 ps-lg-5">
                            <div class="pb-3">
                                <!-- Cart Item-->
                                <asp:Literal ID="LiteralCheckoutItems" runat="server"></asp:Literal>
                                <!-- / Cart Item-->
                            </div>
                            <div class="py-4 border-bottom">
                                <div class="d-flex justify-content-between align-items-center mb-2">
                                    <p class="m-0 fw-bolder fs-6">Ara Toplam</p>
                                    <p class="m-0 fs-6 fw-bolder" id="lbl_AraToplam" runat="server"></p>
                                </div>
                                <div class="d-flex justify-content-between align-items-center ">
                                    <p class="m-0 fw-bolder fs-6">Kargo</p>
                                    <p class="m-0 fs-6 fw-bolder">25 TL</p>
                                </div>
                            </div>
                            <div class="py-4 border-bottom">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <p class="m-0 fw-bold fs-5">Genel Toplam</p>
                                        <span class="text-muted small"></span>
                                    </div>
                                    <p class="m-0 fs-5 fw-bold" id="lbl_genelToplam" runat="server"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
