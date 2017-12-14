<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="HistorialSolicitudes.aspx.cs" Inherits="PracticaCapas.VistasUsuario.HistorialSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="lblTexto" runat="server">

    </asp:Label>
    <form id="formTodasLasSolicitudesRealizadas" runat="server">
        <h2>Historial de Solicitudes</h2>

        <ul class="nav nav-tabs">
            <li id="tabDocentes" runat="server" class="active"><a data-toggle="tab" href="#docentes">Docente</a></li>
            <li id="tabAdministrador" runat="server"><a data-toggle="tab" href="#administrador">Administrador</a></li>
        </ul>

        <div class="tab-content">
            <div id="docentes" class="tab-pane fade in active">
                <h3>HOME</h3>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
            </div>
            <div id="administrador" class="tab-pane fade">
                <h3>Solicitudes</h3>
                <asp:Label ID="msj" Text="" runat="server" />
                <asp:GridView ID="gvTodasLasSolicitudes" CssClass="table table-responsive table-bordered table-striped"
                    runat="server" OnPageIndexChanging="gvTodasLasSolicitudes_PageIndexChanging" AllowPaging="True" PageSize="6" AutoGenerateColumns="false" OnRowCommand="gvTodasLasSolicitudes_RowCommand">
                    <Columns>
                        <asp:TemplateField> 
                            <ItemTemplate>
                                    <asp:HiddenField ID="IdSolicitud" Value='<%# Eval("IdSolicitud") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Folio" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("Folio") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre del evento" ItemStyle-Width="" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("NombreEvento") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de salida" ItemStyle-Width="" ItemStyle-CssClass="Carrera control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("FechaHoraSalida") %>' runat="server" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" ItemStyle-CssClass="Correo control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("IdEstadoSolicitudSalida") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="130px">
                            <ItemTemplate>
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Consultar Solicitud" ID="linkButonConsultarSol" class="btn btn-default btn-xs glyphicon glyphicon-eye-open" runat="server" CommandName="Consultar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <i>Estas viendo <%=gvTodasLasSolicitudes.PageIndex + 1%> de <%=gvTodasLasSolicitudes.PageCount%> Registros</i>
            </div>
        </div>
    </form>
</asp:Content>
