<%@ Page Title="" Language="C#" MasterPageFile="~/Public/KullaniciAna.Master" AutoEventWireup="true" CodeBehind="UrunlerListe.aspx.cs" Inherits="Ecommerce.Public.UrunlerListe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main Section-->
    <section class="mt-0 ">

        <div class="container-fluid" data-aos="fade-in">
            <!-- Category Toolbar-->
            <div class="d-flex justify-content-between items-center pt-5 pb-4 flex-column flex-lg-row">
                <div>
                    <h1 class="fw-bold fs-3 mb-2" id="lbl_PageTitle" runat="server"></h1>
                    <p class="m-0 text-muted small" id="lbl_PageSubtitle" runat="server"></p>
                </div>

            </div>
            <!-- /Category Toolbar-->

            <!-- Products-->
            <div class="row g-4">
                <%--<div class="col-12 col-sm-6 col-lg-4">
                    <!-- Card Product-->
                    <div class="card border border-transparent position-relative overflow-hidden h-100 transparent">
                        <div class="card-img position-relative">
                            <div class="card-badges">
                                <span class="badge badge-card"><span class="f-w-2 f-h-2 bg-danger rounded-circle d-block me-1"></span>Sale</span>
                            </div>
                            <span class="position-absolute top-0 end-0 p-2 z-index-20 text-muted"><i class="ri-heart-line"></i></span>
                            <picture class="position-relative overflow-hidden d-block bg-light">
                                <img class="w-100 img-fluid position-relative z-index-10" title="" src="./assets/images/products/product-1.jpg" alt="">
                            </picture>
                            <div class="position-absolute start-0 bottom-0 end-0 z-index-20 p-2">
                                <button class="btn btn-quick-add"><i class="ri-add-line me-2"></i>Quick Add</button>
                            </div>
                        </div>
                        <div class="card-body px-0">
                            <a class="text-decoration-none link-cover" href="./product.html">Nike Air VaporMax 2021</a>
                            <small class="text-muted d-block">4 colours, 10 sizes</small>
                            <p class="mt-2 mb-0 small"><s class="text-muted">$329.99</s> <span class="text-danger">$198.66</span></p>
                        </div>
                    </div>
                    <!--/ Card Product-->
                </div>--%>
                <asp:Literal ID="Literal_ListProducts" runat="server"></asp:Literal>
            </div>
            <!-- / Products-->

           <%-- <!-- Pagination-->
            <div class="d-flex flex-column f-w-44 mx-auto my-5 text-center">
                <small class="text-muted">Showing 9 of 121 products</small>
                <div class="progress f-h-1 mt-3">
                    <div class="progress-bar bg-dark" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <a href="#" class="btn btn-outline-dark btn-sm mt-5 align-self-center py-3 px-4 border-2">Load More</a>
            </div>
            <!-- / Pagination-->--%>
        </div>

        <!-- /Page Content -->
    </section>
    <!-- / Main Section-->


    <script  type='text/javascript'>
        function QuickAddClick(event, urunID) {
            event.preventDefault();

            var url = "UrunlerListe.aspx/AddToCart";

            // Construct the request options
            var options = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json; charset=utf-8",
                },
                body: JSON.stringify({ urunID: urunID }),
            };

            // Make the fetch request
            fetch(url, options)
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Request failed.");
                    }
                    return response.json();
                })
                .then(data => {
                    console.log("Server Response:", data);
                    alert("Product added to cart successfully!");
                    // refresh to show updated cart
                    location.reload();
                })
                .catch(error => {
                    console.error("Error:", error);
                    alert("Error adding product to cart.");
                });
        }
    </script>

</asp:Content>
