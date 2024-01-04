<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/YoneticiAna.Master" AutoEventWireup="true" CodeBehind="SliderEkleme.aspx.cs" Inherits="Ecommerce.Yonetici.SliderEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="./images/favicon.png" />

    <!-- Custom CSS -->
    <style>
        .image-size {
            height: 300px !important;
        }

        .img-fluid {
            height: 100% !important;
        }

        .btn.btn-secondary.w-100 {
            margin-top: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-header">
            <h1 class="card-title">Slider Ekleme</h1>
        </div>
        <div class="card-body">
            <div class="basic-form">
                <div>
                    <div class="form-row m-b-30">
                        <div class="image-size m-b-30 col-md-12">
                            <img id="img_SliderResim" runat="server" src="https://via.placeholder.com/600x300" class="img-fluid" alt="Responsive image" />
                        </div>
                        <div class="input-group col-md-6">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Slider Resim</span>
                            </div>
                            <div class="custom-file">
                                <asp:FileUpload ID="File_SliderResim" runat="server" class="custom-file-input image-input" />
                                <label class="custom-file-label">Resim Seç...</label>
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label>Slider Başlığı</label>
                            <input type="text" id="txt_SliderIsim" runat="server" class="form-control" placeholder="Summer Essentials">
                        </div>
                        <div class="form-group col-md-6">
                            <label>Slider Açıklaması</label>
                            <textarea class="form-control" rows="4" id="txt_SliderAciklama" runat="server" placeholder="İhtiyacınız Olan Herşey"></textarea>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Slider URL</label>
                            <input type="text" id="txt_SliderUrl" runat="server" class="form-control" placeholder="./UrunlerListe.aspx?isNew=true">
                        </div>
                        <div class="form-group col-md-6">
                            <label>Slider URL Açıklaması</label>
                            <input type="text" id="txt_SliderUrlAciklama" runat="server" class="form-control" placeholder="Yeni Gelenler Alışverişi">
                        </div>
                    </div>
                </div>
            </div>

            <asp:Button ID="btn_SliderEkle" class="btn btn-secondary w-100" runat="server" Text="SLİDER EKLE" OnClick="btn_SliderEkle_Click" />
        </div>
    </div>

    <script>
        let imageInput = document.querySelector('.image-input');
        let image = document.querySelector('.img-fluid');
        let imageLabel = document.querySelector(".custom-file-label");

        imageInput.addEventListener('change', function () {
            let file = this.files[0];

            if (file && (file.type === "image/png" || file.type === "image/jpeg" || file.type === "image/jpg")) {
                let reader = new FileReader();
                reader.onload = function (e) {
                    image.src = e.target.result;
                }
                imageLabel.innerHTML = file.name;
                reader.readAsDataURL(file);
            } else {
                alert("Lütfen resim dosyası seçiniz.");
            }
        });
    </script>
</asp:Content>
