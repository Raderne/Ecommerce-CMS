<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/YoneticiAna.Master" AutoEventWireup="true" CodeBehind="KullaniciEkleme.aspx.cs" Inherits="Ecommerce.Yonetici.KullaniciEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-title">
            <h2>Kullanıcı Ekleme</h2>
        </div>
        <div class="card-body">
            <div class="basic-form">
                <div>
                    <div class="form-group">
                        <label>Eposta Adressi</label>
                        <asp:TextBox ID="txt_eposta" runat="server" class="form-control" placeholder="Eposta"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Şifre</label>
                        <asp:TextBox ID="txt_sifre" runat="server" class="form-control" placeholder="Kullanıcı Şifre"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Kullanıcı Adı</label>
                        <asp:TextBox ID="txt_kullaniciAdi" runat="server" class="form-control" placeholder="Ad"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Kullanıcı Soyadı</label>
                        <asp:TextBox ID="txt_kullaniciSoyad" runat="server" class="form-control" placeholder="Soyad"></asp:TextBox>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="cb_isAdmin" runat="server" />
                            Admin		
                        </label>
                    </div>
                    <asp:Button ID="btn_KullaniciEkleme" runat="server" class="btn btn-dark pl-5 pr-5" Text="Ekle" OnClick="btn_KullaniciEkleme_Click" />
                    <asp:Label ID="lbl_EklemeSonuc" runat="server" Text="Sonuç"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
