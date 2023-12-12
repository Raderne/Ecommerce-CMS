<%@ Page Title="" Language="C#" MasterPageFile="~/Public/KullaniciAna.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Ecommerce.Public.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main Section-->
    <section class="mt-0 ">
        <!-- Page Content Goes Here -->

        <!-- Breadcrumbs-->
        <div class="bg-dark py-6">
            <div class="container-fluid">
                <nav class="m-0" aria-label="breadcrumb">
                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item breadcrumb-light"><a href="./index.aspx">Ana Sayfa</a></li>
                        <li class="breadcrumb-item breadcrumb-light"><a href="./UrunlerListe.aspx" id="link_CategoryName" runat="server"></a></li>
                        <li class="breadcrumb-item  breadcrumb-light active" aria-current="page" id="lbl_productName" runat="server"></li>
                    </ol>
                </nav>
            </div>
        </div>
        <!-- / Breadcrumbs-->

        <div class="container-fluid mt-5">

            <!-- Product Top Section-->
            <div class="row g-9" data-sticky-container>

                <!-- Product Images-->
                <div class="col-12 col-md-6 col-xl-7">
                    <div class="row g-3" data-aos="fade-right">
                        <div class="col-12">
                            <picture>
                                <img class="img-fluid" data-zoomable src="" alt="" id="img_ProductImage1" runat="server">
                            </picture>
                        </div>
                        <div class="col-12">
                            <picture>
                                <img class="img-fluid" data-zoomable src="" alt="" id="img_ProductImage2" runat="server">
                            </picture>
                        </div>
                        <div class="col-12">
                            <picture>
                                <img class="img-fluid" data-zoomable src="" alt="" id="img_ProductImage3" runat="server">
                            </picture>
                        </div>
                        <div class="col-12">
                            <picture>
                                <img class="img-fluid" data-zoomable src="" alt="" id="img_ProductImage4" runat="server">
                            </picture>
                        </div>
                    </div>
                </div>
                <!-- /Product Images-->

                <!-- Product Information-->
                <div class="col-12 col-md-6 col-lg-5">
                    <div class="sticky-top top-5">
                        <div class="pb-3" data-aos="fade-in">
                            <div class="d-flex align-items-center mb-3">
                                <p class="small fw-bolder text-uppercase tracking-wider text-muted m-0 me-4" id="lbl_ProductMarka" runat="server"></p>
                                <%--REVIEWS SECTİON--%>
                                <%--<div class="d-flex justify-content-start align-items-center disable-child-pointer cursor-pointer"
                                    data-pixr-scrollto
                                    data-target=".reviews">
                                    <!-- Review Stars Small-->
                                    <div class="rating position-relative d-table">
                                        <div class="position-absolute stars" style="width: 80%">
                                            <i class="ri-star-fill text-dark mr-1"></i>
                                            <i class="ri-star-fill text-dark mr-1"></i>
                                            <i class="ri-star-fill text-dark mr-1"></i>
                                            <i class="ri-star-fill text-dark mr-1"></i>
                                            <i class="ri-star-fill text-dark mr-1"></i>
                                        </div>
                                        <div class="stars">
                                            <i class="ri-star-fill mr-1 text-muted opacity-25"></i>
                                            <i class="ri-star-fill mr-1 text-muted opacity-25"></i>
                                            <i class="ri-star-fill mr-1 text-muted opacity-25"></i>
                                            <i class="ri-star-fill mr-1 text-muted opacity-25"></i>
                                            <i class="ri-star-fill mr-1 text-muted opacity-25"></i>
                                        </div>
                                    </div>
                                    <small class="text-muted d-inline-block ms-2 fs-bolder">(105 reviews)</small>
                                </div>--%>
                            </div>

                            <h1 class="mb-1 fs-2 fw-bold" id="lbl_ProductTitle" runat="server"></h1>
                            <div class="d-flex justify-content-between align-items-center">
                                <p class="fs-4 m-0" id="lbl_ProductPrice" runat="server"></p>
                            </div>
                            <div class="border-top mt-4 mb-3 product-option">
                                <small class="text-uppercase pt-4 d-block fw-bolder">
                                    <span class="text-muted">Mevcut boyutlar </span> : <span class="selected-option fw-bold"
                                        data-pixr-product-option="size">M</span>
                                </small>
                                <div class="mt-4 d-flex justify-content-start flex-wrap align-items-start">
                                    <div class="form-check-option form-check-rounded">
                                        <input
                                            type="radio"
                                            name="product-option-sizes"
                                            value="S"
                                            id="option-sizes-0">
                                        <label for="option-sizes-0">

                                            <small>S</small>
                                        </label>
                                    </div>
                                    <div class="form-check-option form-check-rounded">
                                        <input
                                            type="radio"
                                            name="product-option-sizes"
                                            value="SM"
                                            id="option-sizes-1">
                                        <label for="option-sizes-1">

                                            <small>SM</small>
                                        </label>
                                    </div>
                                    <div class="form-check-option form-check-rounded">
                                        <input
                                            type="radio"
                                            name="product-option-sizes"
                                            value="M"
                                            checked
                                            id="option-sizes-2">
                                        <label for="option-sizes-2">

                                            <small>M</small>
                                        </label>
                                    </div>
                                    <div class="form-check-option form-check-rounded">
                                        <input
                                            type="radio"
                                            name="product-option-sizes"
                                            value="L"
                                            id="option-sizes-3">
                                        <label for="option-sizes-3">

                                            <small>L</small>
                                        </label>
                                    </div>
                                    <div class="form-check-option form-check-rounded">
                                        <input
                                            type="radio"
                                            name="product-option-sizes"
                                            value="Xl"
                                            id="option-sizes-4">
                                        <label for="option-sizes-4">

                                            <small>XL</small>
                                        </label>
                                    </div>
                                    <div class="form-check-option form-check-rounded">
                                        <input
                                            type="radio"
                                            name="product-option-sizes"
                                            value="XXL"
                                            id="option-sizes-5">
                                        <label for="option-sizes-5">

                                            <small>XXL</small>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="btn_AddToShoppingCart" runat="server" class="btn btn-dark w-100 mt-4 mb-0 hover-lift-sm hover-boxshadow" Text="Alışveriş sepetinize ekleyin" OnClick="btn_AddToShoppingCart_Click" />

                            <!-- Product Highlights-->
                            <div class="my-5">
                                <div class="row">
                                    <div class="col-12 col-md-4">
                                        <div class="text-center px-2">
                                            <i class="ri-24-hours-line ri-2x"></i>
                                            <small class="d-block mt-1">Sonraki Gün Teslimat</small>
                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="text-center px-2">
                                            <i class="ri-secure-payment-line ri-2x"></i>
                                            <small class="d-block mt-1">Güvenli Ödeme</small>
                                        </div>
                                    </div>
                                    <div class="col-12 col-md-4">
                                        <div class="text-center px-2">
                                            <i class="ri-service-line ri-2x"></i>
                                            <small class="d-block mt-1">Ücretsiz İade</small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- / Product Highlights-->

                            <!-- Product Accordion -->
                            <div class="accordion" id="accordionProduct">
                                <div class="accordion-item">
                                    <h2 class="accordion-header" id="headingOne">
                                        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                            Ürün Bilgileri
                                
                                        </button>
                                    </h2>
                                    <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordionProduct">
                                        <div class="accordion-body">
                                            <p class="m-0" id="lbl_ProductsDetails" runat="server"></p>
                                        </div>
                                    </div>
                                </div>
                                <div class="accordion-item">
                                    <h2 class="accordion-header" id="headingTwo">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                            Detaylar & Bakım
                                  
                                        </button>
                                    </h2>
                                    <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionProduct">
                                        <div class="accordion-body">
                                            <ul class="list-group list-group-flush">
                                                <li class="list-group-item d-flex border-0 row g-0 px-0">
                                                    <span class="col-4 fw-bolder">Kompozisyon</span>
                                                    <span class="col-7 offset-1">98% Cotton, 2% elastane</span>
                                                </li>
                                                <li class="list-group-item d-flex border-0 row g-0 px-0">
                                                    <span class="col-4 fw-bolder">Bakım Ürünleri</span>
                                                    <span class="col-7 offset-1">Sadece profesyonel kuru temizleme. Ağartıcı kullanmayın. Ütülemeyin.</span>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="accordion-item">
                                    <h2 class="accordion-header" id="headingThree">
                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                            Teslimat & İadeler
                                
                                        </button>
                                    </h2>
                                    <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionProduct">
                                        <div class="accordion-body">
                                            <ul class="list-group list-group-flush">
                                                <li class="list-group-item d-flex border-0 row g-0 px-0">
                                                    <span class="col-4 fw-bolder">Teslimat</span>
                                                    <span class="col-7 offset-1">99TL üzeri siparişlerde standart teslimat ücretsiz. Ertesi gün teslimat 9,99TL</span>
                                                </li>
                                                <li class="list-group-item d-flex border-0 row g-0 px-0">
                                                    <span class="col-4 fw-bolder">İade</span>
                                                    <span class="col-7 offset-1">30 day return period. Şartlar ve koşullarımıza bakın.</span>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- / Product Accordion-->
                        </div>
                    </div>
                </div>
                <!-- / Product Information-->
            </div>
            <!-- / Product Top Section-->

        </div>

        <!-- /Page Content -->
    </section>
    <!-- / Main Section-->
</asp:Content>
