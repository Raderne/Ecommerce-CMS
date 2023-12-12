<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/YoneticiAna.Master" AutoEventWireup="true" CodeBehind="UrunEkleme.aspx.cs" Inherits="Ecommerce.Yonetici.UrunEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="./images/favicon.png" />

    <!-- Custom CSS -->
    <style>
        .image-size {
            width: 150px;
            height: 150px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <div class="card-header">
            <h1 class="card-title">Ürün Ekleme</h1>
        </div>
        <div class="card-body">
            <div class="basic-form">
                <div>
                    <div class="form-row m-t-30">
                        <div class="col-md-12">
                            <h4>Ürün Detaylar</h4>
                        </div>
                    </div>

                    <div class="form-row m-b-30">
                        <div class="image-size m-b-30">
                            <img id="img_UrunResim" runat="server" src="https://via.placeholder.com/150" class="img-fluid" alt="Responsive image" />
                        </div>
                        <div class="input-group col-md-12">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Ürün Resim</span>
                            </div>
                            <div class="custom-file">
                                <asp:FileUpload ID="File_UrunResim" runat="server" class="custom-file-input image-input" />
                                <label class="custom-file-label">Resim Seç...</label>
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
                                <input type="number" id="txt_UrunIndirimFiyat" runat="server" class="form-control" disabled value="0">
                            </div>
                            <div class="col-md-1"></div>
                            <div class="form-group row">
                                <div class="col-sm-2">Indirim</div>
                                <div class="col-sm-10">
                                    <div class="form-check">
                                        <input class="form-check-input sale-checkbox" runat="server" id="checkbox_UrunIsOnSale" type="checkbox">
                                        <label class="form-check-label" for="ContentPlaceHolder1_checkbox_UrunIsOnSale">
                                            Ürün indirimde mi?
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <label>Ürün Kategori</label>
                            <asp:DropDownList ID="select_Urunkategori" runat="server" class="form-control">
                                <asp:ListItem Text="Seç..." Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-3">
                            <label>Ürün Marka</label>
                            <asp:DropDownList ID="select_UrunMarka" runat="server" class="form-control">
                                <asp:ListItem Text="Seç..." Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <label>Ürün Boyut</label>
                            <select id="select_UrunBoyut" runat="server" class="form-control">
                                <option selected="">Seç...</option>
                                <option>Small</option>
                                <option>Medium</option>
                                <option>Large</option>
                                <option>X-Large</option>
                                <option>XX-Large</option>
                                <option>XXX-Large</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            <label>Ürün Renk</label>
                            <select id="select_UrunRenk" runat="server" class="form-control">
                                <option selected="">Seç...</option>
                                <option>Siyah</option>
                                <option>Beyaz</option>
                                <option>Kırmızı</option>
                                <option>Mavi</option>
                                <option>Sarı</option>
                                <option>Yeşil</option>
                                <option>Mor</option>
                                <option>Turuncu</option>
                                <option>Gri</option>
                                <option>Kahverengi</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            <label>Cinsiyet</label>
                            <select id="select_cinsiyet" runat="server" class="form-control">
                                <option selected="">Seç...</option>
                                <option>Male</option>
                                <option>Female</option>
                            </select>
                        </div>
                        <div class="form-group col-md-3">
                            <div>Yeni Ürün</div>
                            <div class="form-check form-control">
                                <input class="form-check-input" id="checkbox_UrunIsNew" runat="server" type="checkbox">
                                <label class="form-check-label" for="checkbox_UrunIsNew">
                                    Ürün Yeni mi?
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="form-row m-t-30">
                        <div class="col-md-12">
                            <h4>Ürün Resimleri</h4>
                        </div>
                    </div>

                    <div class="form-row m-b-50">
                        <div class="input-group col-md-6 h-25">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Resim 1</span>
                            </div>
                            <div class="custom-file">
                                <asp:FileUpload ID="File_UrunResim1" runat="server" class="custom-file-input image-input first-image-upload" />
                                <label class="custom-file-label">Resim Seç...</label>
                            </div>
                        </div>
                        <div class="image-size col-md-6 d-flex justify-content-center">
                            <img id="img_UrunResim1" runat="server" src="https://via.placeholder.com/150" class="img-fluid" alt="Responsive image" />
                        </div>
                    </div>
                    <div class="form-row m-b-50">
                        <div class="input-group col-md-6 h-25">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Resim 2</span>
                            </div>
                            <div class="custom-file">
                                <asp:FileUpload ID="File_UrunResim2" runat="server" class="custom-file-input image-input" />
                                <label class="custom-file-label">Resim Seç...</label>
                            </div>
                        </div>
                        <div class="image-size col-md-6 d-flex justify-content-center">
                            <img id="img_UrunResim2" runat="server" src="https://via.placeholder.com/150" class="img-fluid" alt="Responsive image" />
                        </div>
                    </div>
                    <div class="form-row m-b-50">
                        <div class="input-group col-md-6 h-25">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Resim 3</span>
                            </div>
                            <div class="custom-file">
                                <asp:FileUpload ID="File_UrunResim3" runat="server" class="custom-file-input image-input" />
                                <label class="custom-file-label">Resim Seç...</label>
                            </div>
                        </div>
                        <div class="image-size col-md-6 d-flex justify-content-center">
                            <img id="img_UrunResim3" runat="server" src="https://via.placeholder.com/150" class="img-fluid" alt="Responsive image" />
                        </div>
                    </div>
                    <div class="form-row m-b-50">
                        <div class="input-group col-md-6 h-25">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Resim 3</span>
                            </div>
                            <div class="custom-file">
                                <asp:FileUpload ID="File_UrunResim4" runat="server" class="custom-file-input image-input" />
                                <label class="custom-file-label">Resim Seç...</label>
                            </div>
                        </div>
                        <div class="image-size col-md-6 d-flex justify-content-center">
                            <img id="img_UrunResim4" runat="server" src="https://via.placeholder.com/150" class="img-fluid" alt="Responsive image" />
                        </div>
                    </div>


                </div>


            </div>
            <asp:Button ID="btn_UrunEkle" class="btn btn-primary w-100" runat="server" Text="Ürün Ekle" OnClick="btn_UrunEkle_Click" />
        </div>
    </div>

    <script>
        let isOnSale = document.querySelector(".sale-checkbox");
        let SalePrice = document.getElementById("ContentPlaceHolder1_txt_UrunIndirimFiyat");

        isOnSale.addEventListener("change", function () {
            if (isOnSale.checked) {
                SalePrice.disabled = false;
            } else {
                SalePrice.disabled = true;
            }
        });

        let imageInputs = document.querySelectorAll(".image-input");
        let imagePreviews = document.querySelectorAll(".img-fluid");
        let imageLabels = document.querySelectorAll(".custom-file-label");

        imageInputs.forEach((input, index) => {
            input.addEventListener("change", function () {
                let file = this.files[0];
                if (file && (file.type === "image/png" || file.type === "image/jpeg" || file.type === "image/jpg")) {
                    let reader = new FileReader();
                    reader.onload = function (e) {
                        imagePreviews[index].src = e.target.result;
                    }
                    imageLabels[index].innerHTML = file.name;
                    reader.readAsDataURL(file);
                } else {
                    alert("Lütfen resim dosyası seçiniz.");
                }
            });
        });
    </script>


</asp:Content>
