<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/YoneticiAna.Master" AutoEventWireup="true" CodeBehind="UrunYonetim.aspx.cs" Inherits="Ecommerce.Yonetici.UrunYonetim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="./images/favicon.png" />
    <!-- Datatable -->
    <link href="./vendor/datatables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <!-- Custom Stylesheet -->
    <link href="./css/style.css" rel="stylesheet" />

    <style>
        body{
            width: 100vw !important;
        }
        .header{
            padding: 0 15rem 0 2rem !important;
        }
        .nav-control{
            right: auto !important;
            left: 0 !important;
        }
    </style>
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
                            </tr>
                        </thead>
                        <tbody>
                            <%--<tr>
                                <td>Tiger Nixon</td>
                                <td>System Architect</td>
                                <td>Edinburgh</td>
                                <td>61</td>
                                <td>2011/04/25</td>
                                <td>$320,800</td>
                            </tr>--%>
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
</asp:Content>
