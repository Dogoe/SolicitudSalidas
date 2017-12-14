<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PracticaCapas.VistasUsuario.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="text-center">
        <asp:Label ID="despliegaNombre" runat="server"></asp:Label>
        <table class="table" id="usuarios-tabla">

        </table>
        <div class="modal fade" id="modal-usuarios">
            <div class="modal-dialog">
                <div class="modal-content">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
