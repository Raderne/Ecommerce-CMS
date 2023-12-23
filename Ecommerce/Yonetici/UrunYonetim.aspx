<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/YoneticiAna.Master" AutoEventWireup="true" CodeBehind="UrunYonetim.aspx.cs" Inherits="Ecommerce.Yonetici.UrunYonetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="./images/favicon.png" />
    <!-- Datatable -->
    <link href="./vendor/datatables/css/jquery.dataTables.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-12">
        <div class="card">
            <div class="card-header">
                <h1 class="card-title">Tüm Ürünler</h1>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table id="example2" class="display" style="width: 100%">
                        <thead>
                            <tr>
                                <th>Ürün Resim</th>
                                <th>Ürün İsim</th>
                                <th>Ürün Kategori</th>
                                <th>Ürün Fiyat</th>
                                <th>Ürün Miktar</th>
                                <th>Ürün Detay</th>
                                <th>Ürün Sil</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="Literal_UrunlerListele" runat="server"></asp:Literal>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>Ürün Resim</th>
                                <th>Ürün İsim</th>
                                <th>Ürün Kategori</th>
                                <th>Ürün Fiyat</th>
                                <th>Ürün Miktar</th>
                                <th>Ürün Detay</th>
                                <th>Ürün Sil</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <!-- Required vendors -->
    <script src="./vendor/global/global.min.js"></script>
    <script src="./js/quixnav-init.js"></script>
    <script src="./js/custom.min.js"></script>

    <!-- Datatable -->
    <script src="./vendor/datatables/js/jquery.dataTables.min.js"></script>
    <script src="./js/plugins-init/datatables.init.js"></script>

    <script type='text/javascript'>
        function UrunSil(urunID) {
            var url = "UrunYonetim.aspx/RemoveItem";

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
                    alert("Ürün Silindi");
                    window.location.reload();
                })
                .catch(error => {
                    console.error("Error:", error);
                    alert("Ürün Silinemedi");
                });
        }
    </script>

</asp:Content>
