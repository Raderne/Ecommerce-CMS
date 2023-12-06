<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/YoneticiAna.Master" AutoEventWireup="true" CodeBehind="UrunEkleme.aspx.cs" Inherits="Ecommerce.Yonetici.UrunEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="./images/favicon.png" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-header">
            <h1 class="card-title">Ürün Ekleme</h1>
        </div>
        <div class="card-body">
            <div class="basic-form">
                <div>
                    <div class="form-row card pt-2 pb-2 m-b-25 m-t-20 col-md-6">
                        <div class="stat-widget-three">
                            <div class="stat-icon bg-primary">
                                <i class="ti-user"></i>
                                <img src="#" style="display: none" />
                            </div>
                            <div class="stat-content">
                                <label class="stat-digit">Ürün Resim</label>
                                <div class="stat-text">
                                    <input type="file" id="file_UrunResim" runat="server" class="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label>Ürün İsim</label>
                            <input type="text" id="txt_UrunIsim" runat="server" class="form-control" placeholder="Kiikii Osaka Japan Mens T-Shirt">
                        </div>
                        <div class="form-group col-md-6">
                            <label>Ürün Açıklaması</label>
                            <textarea class="form-control" rows="4" id="txt_UrunAciklama" runat="server" placeholder="Ürün Açıklama"></textarea>
                        </div>
                        <div class="form-group row col-md-6">
                            <div class="form-group">
                                <label>Ürün Fiyatı</label>
                                <input type="number" class="form-control" placeholder="Fiyat" id="txt_UrunFiyat" runat="server">
                            </div>
                            <div class="col-md-1"></div>
                            <div class="form-group">
                                <label>Ürün Miktar</label>
                                <input type="number" class="form-control" placeholder="Miktar" id="txt_UrunMiktar" runat="server">
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <div class="form-group">
                                <label>Ürün Indirimli Fiyatı</label>
                                <input type="number" id="txt_UrunIndirimFiyat" runat="server" class="form-control" disabled>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="form-group row">
                                <div class="col-sm-2">Indirim</div>
                                <div class="col-sm-10">
                                    <div class="form-check">
                                        <input class="form-check-input" id="checkbox_UrunIsOnSale" type="checkbox">
                                        <label class="form-check-label" for="checkbox_UrunIsOnSale">
                                            Ürün indirimde mi?
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label>Ürün Kategori</label>
                            <select id="inputState" class="form-control">
                                <option selected="">Seç...</option>
                                <asp:Literal ID="literal_urunKategori" runat="server"></asp:Literal>
                            </select>
                        </div>
                        <div class="form-group col-md-4">
                            <label>Ürün Marka</label>
                            <select class="form-control">
                                <option selected="">Seç...</option>
                                <asp:Literal ID="literal_UrunMarka" runat="server"></asp:Literal>
                            </select>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="form-group col-md-3">
                            <div>Yeni Ürün</div>
                            <div class="form-check form-control">
                                <input class="form-check-input" id="checkbox_UrunIsNew" type="checkbox">
                                <label class="form-check-label" for="checkbox_UrunIsNew">
                                    Ürün Yeni mi?
                                </label>
                            </div>
                        </div>
                    </div>


                    <div class="form-row">
                        <div class="col-md-12">
                            <h4>Ürün Özellikleri</h4>
                        </div>
                        <%--remove this and add images inputs--%>
                         <div class="form-group col-md-6">
                             <label>Ürün Renk</label>
                             <select class="form-control">
                                 <option selected="">Seç...</option>
                                 <option>Kırmızı</option>
                                 <option>Mavi</option>
                                 <option>Siyah</option>
                                 <option>Beyaz</option>
                                 <option>Sarı</option>
                                 <option>Yeşil</option>
                             </select>
                         </div>
                    </div>

                </div>
            </div>
            <button id="btn_UrunEkle" runat="server" class="btn btn-primary">Ürün Ekle</button>
        </div>
    </div>


    <script>
        let isOnSale = document.getElementById("checkbox_UrunIsOnSale");
        let SalePrice = document.getElementById("ContentPlaceHolder1_txt_UrunIndirimFiyat");

        isOnSale.addEventListener("change", function () {
            if (isOnSale.checked) {
                SalePrice.disabled = false;
            } else {
                SalePrice.disabled = true;
            }
        });
    </script>
</asp:Content>
