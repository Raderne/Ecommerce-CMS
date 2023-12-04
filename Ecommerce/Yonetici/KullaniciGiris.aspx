<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KullaniciGiris.aspx.cs" Inherits="Ecommerce.Yonetici.KullaniciGiriss" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width,initial-scale=1"/>
    <title>Kullanıcı Giriş </title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="./images/favicon.png"/>
    <link href="./css/style.css" rel="stylesheet"/>
</head>

<body class="h-100" style="height: 100vh !important">
    <form id="form1" runat="server" class="authincation h-100">
        <div class="container-fluid h-100">
            <div class="row justify-content-center h-100 align-items-center">
                <div class="col-md-6">
                    <div class="authincation-content">
                        <div class="row no-gutters">
                            <div class="col-xl-12">
                                <div class="auth-form">
                                    <h4 class="text-center mb-4">Kullanıcı Bilgileri</h4>
                                    <div class="form-group">
                                        <label><strong>Eposta</strong></label>
                                        <input type="email" runat="server" id="txt_email" class="form-control" placeholder="hello@example.com"/>
                                    </div>
                                    <div class="form-group">
                                        <label><strong>Şifre</strong></label>
                                        <input type="password" runat="server" id="txt_password" class="form-control" placeholder="Şifre"/>
                                    </div>
                                    <div class="form-row d-flex justify-content-between mt-4 mb-2">
                                        <div class="form-group">
                                            <div class="form-check ml-2">
                                                <asp:Label ID="lbl_sonuc" runat="server" Text="Sonuç"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <a href="SifreUnuttumSayfa.aspx">Şifre Unuttum</a>
                                        </div>
                                    </div>
                                    <div class="text-center">
                                        <asp:Button ID="btn_login" runat="server" Text="Giriş" class="btn btn-primary btn-block" OnClick="btn_login_Click" />
                                    </div>
                                    <div class="new-account mt-3">
                                        <p>Bir hesabınız yok mu? <a class="text-primary" href="./KullaniciUye.aspx">Üye Ol</a></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!--**********************************
     Scripts
 ***********************************-->
        <!-- Required vendors -->
        <script src="./vendor/global/global.min.js"></script>
        <script src="./js/quixnav-init.js"></script>
        <script src="./js/custom.min.js"></script>
    </form>
</body>
</html>
