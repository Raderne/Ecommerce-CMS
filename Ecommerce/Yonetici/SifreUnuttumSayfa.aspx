<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SifreUnuttumSayfa.aspx.cs" Inherits="Ecommerce.Yonetici.SifreUnuttumSayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Şifreyi Sıfırla</title>

    <!-- ================= Favicon ================== -->
    <!-- Standard -->
    <link rel="shortcut icon" href="http://placehold.it/64.png/000/fff" />
    <!-- Retina iPad Touch Icon-->
    <link rel="apple-touch-icon" sizes="144x144" href="http://placehold.it/144.png/000/fff" />
    <!-- Retina iPhone Touch Icon-->
    <link rel="apple-touch-icon" sizes="114x114" href="http://placehold.it/114.png/000/fff" />
    <!-- Standard iPad Touch Icon-->
    <link rel="apple-touch-icon" sizes="72x72" href="http://placehold.it/72.png/000/fff" />
    <!-- Standard iPhone Touch Icon-->
    <link rel="apple-touch-icon" sizes="57x57" href="http://placehold.it/57.png/000/fff" />

    <!-- Styles -->
    <link href="assets/css/lib/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/lib/themify-icons.css" rel="stylesheet" />
    <link href="assets/css/lib/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/lib/helper.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
</head>
<body class="bg-primary">
    <form id="form1" runat="server">
        <div class="unix-login">
            <div class="container-fluid">
                <div class="row justify-content-center">
                    <div class="col-lg-6">
                        <div class="login-content">
                            <div class="login-logo">
                                <a href="index.aspx"><span>Focus</span></a>
                            </div>
                            <div class="login-form">
                                <h4>Şifreyi sıfırla</h4>
                                <div class="form-group">
                                    <label>Eposta adresi</label>
                                    <input runat="server" id="txt_resetEmail" type="email" class="form-control" placeholder="Email"/>
                                </div>
                                <asp:Button ID="btn_resetPassword" class="btn btn-primary btn-flat m-b-15" runat="server" Text="Şifre Sıfırla" />
                                <div class="register-link text-center">
                                    <p><a href="KullaniciGiris.aspx">Kullanıcı Giriş</a> Geri Dön</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
