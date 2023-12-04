<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/YoneticiAna.Master" AutoEventWireup="true" CodeBehind="KullaniciYonetim.aspx.cs" Inherits="Ecommerce.Yonetici.KullaniciYonetim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-responsive">

        <asp:GridView ID="GDV_kullaniciListe" class="table table-striped" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:BoundField DataField="Eposta" HeaderText="Eposta" SortExpression="Eposta" />
                <asp:BoundField DataField="Adi" HeaderText="Adi" SortExpression="Adi" />
                <asp:BoundField DataField="Soyadi" HeaderText="Soyadi" SortExpression="Soyadi" />
                <asp:BoundField DataField="KayitTarihi" HeaderText="KayitTarihi" SortExpression="KayitTarihi" />
            </Columns>
        </asp:GridView>

    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="KullaniciListele" TypeName="BLL.BllKullanici"></asp:ObjectDataSource>

</asp:Content>
