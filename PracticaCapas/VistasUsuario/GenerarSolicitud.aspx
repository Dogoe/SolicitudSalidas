<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="GenerarSolicitud.aspx.cs" Inherits="PracticaCapas.VistasUsuario.GenerarSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
   
        <!-- Modal -->
        <div id="SolicitudesAgregarEditarModal" class="modal fade" data-backdrop="static" data-keyboard="false" role="dialog">
            <form id="GeneraSolicitud" name="solicitud" runat="server">
            <div id="mdialTamanio" class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Editar</h4>
                    </div>
                    <!--Informacion de solicitud-->
                    <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <label>Nombre*</label>
                                <asp:TextBox ID="txtNombre" runat="server" class="form-control" ReadOnly="true"> </asp:TextBox>

                            </div>
                        </div>

                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <label for="numero">N&uacute;mero de empleado*</label>
                                <asp:TextBox ID="txtNoEmpleado" runat="server" class="form-control" ReadOnly="true"> </asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-6 col-lg-6">
                            <label for="nombre-evento">Nombre del evento*</label>
                            <asp:TextBox ID="txtNombreEvento" runat="server" class="form-control" required="true"> </asp:TextBox>
                        </div>
                        <div class="form-group col-md-6 col-lg-6">
                            <label for="costo-evento">Lugar del evento*</label>
                            <asp:TextBox ID="txtLugarEvento" runat="server" class="form-control" required="true"> </asp:TextBox>
                        </div>
                        <div class="form-group col-md-6 col-lg-6">
                            <label for="costo-evento">Costo del evento:*</label>
                            <asp:TextBox ID="txtCostoEvento" runat="server" type="number" min="0" class="form-control"> </asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-md-6">
                            <label for="carrera">Carrera*</label>
                            <asp:DropDownList ID="ddlCarrera" runat="server" CssClass="form-control btn btn-default dropdown-toggle" data-toggle="dropdown" required="true"></asp:DropDownList>

                        </div>

                        <div class="form-group col-md-6 col-lg-6">
                            <label for="categoria">Categor&iacute;a*</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control btn btn-default dropdown-toggle" data-toggle="dropdown" required="true"></asp:DropDownList>

                        </div>
                    </div>
                    <div style="margin-bottom: 50px;"></div>

                    <!--Fechas de la solicitud-->
                    <div class="row">
                        <div class="col-md-3 col-lg-3">
                            <div class="form-group">
                                <label for="fecha">Fecha de Salida*</label>
                                <asp:TextBox ID="txtFechaSalida" runat="server" class="form-control" type="date" required="true"> </asp:TextBox>
                                <div class="alert alert-danger" Style="display: none">Fecha de salida no válida</div>

                            </div>
                        </div>

                        <div class="col-md-3 col-lg-3">
                            <div class="form-group">
                                <label for="fecha">Hora de Salida*</label>
                                <asp:TextBox ID="txtHoraSalida" runat="server" class="form-control" type="time" required="true"> </asp:TextBox>
                                <div class="alert alert-danger" Style="display: none">Hora de salida no válida </div>

                            </div>
                        </div>
                        <div class="col-md-3 col-lg-3">
                            <div class="form-group">
                                <label for="fecha">Fecha de Llegada*</label>
                                <asp:TextBox ID="txtFechaLLegada" runat="server" class="form-control" type="date" required="true"> </asp:TextBox>
                                <div class="alert alert-danger" Style="display: none">Fecha de llegada no válida</div>

                            </div>
                        </div>

                        <div class="col-md-3 col-lg-3">
                            <div class="form-group">
                                <label for="fecha">Hora de Llegada*</label>
                                <asp:TextBox ID="txtHoraLlegada" runat="server" class="form-control" type="time" required="true"> </asp:TextBox>
                                <div class="alert alert-danger" Style="display: none">Hora de llegada no válida </div>

                            </div>
                        </div>
                    </div>
                    <!--Recursos a solicitar-->
                    <div style="margin-bottom: 50px;"></div>

                    <label>Recursos a solicitar</label>
                    <div>
                        <div class="row">
                            <div class="col-md-6 col-lg-6">
                                <div class="form-group">
                                    <label class="checkbox-inline">
                                        <asp:CheckBox value="true" ID="cBoxHospedaje" runat="server" />Hospedaje
                                    </label>

                                </div>
                                <div class="form-group">
                                    <label class="checkbox-inline">
                                        <asp:CheckBox value="true" ID="cBoxViaticos" runat="server" />V&iacute;aticos
                                    </label>

                                </div>
                                <div class="form-group">
                                    <label class="checkbox-inline">
                                        <asp:CheckBox value="true" ID="cBoxOficioComision" runat="server" />Oficios de comisi&oacute;n
                                    </label>

                                </div>
                                <div class="form-group">
                                    <label class="checkbox-inline">
                                        <asp:CheckBox value="true" ID="cBoxOtro" runat="server" />Otro
                                    </label>

                                </div>
                                <div class="form-group">
                                    <label>Descripci&oacute;n otros</label>
                                    <asp:TextBox ID="txtRecursoSolicitadoOtro" runat="server" class="form-control" type="text" placeholder="Otros ..." required="true"> </asp:TextBox>

                                </div>


                            </div>
                            <div class="col-md-6 col-lg-6">
                                <div class="form-group">
                                    <label for="transporte">Trasporte</label>
                                    <asp:TextBox ID="txtCantPersonas" runat="server" class="form-control" type="number" min="0" placeholder="Cantidad de personas ..." required="true"> </asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label class="checkbox-inline">
                                        <asp:CheckBox value="true" ID="cBoxCombustible" runat="server" />Combustible
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br>
                    <label>Actividades asociadas</label>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <asp:CheckBox value="true" ID="cBoxActividadCACEI" runat="server" />CACEI/CIEES
                                </label>

                            </div>
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <asp:CheckBox value="true" ID="cBoxActividadLicenciatura" runat="server" />Licenciatura
                                </label>

                            </div>
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <asp:CheckBox value="true" ID="cBoxActividadPersonal" runat="server" />Personal
                                </label>

                            </div>

                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <asp:CheckBox value="true" ID="cBoxActividadIso" runat="server" />ISO 9001:2008
                                </label>

                            </div>
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <asp:CheckBox value="true" ID="cBoxActividadPosgrado" runat="server" />Posgrado
                                </label>

                            </div>
                            <div class="form-group">
                                <label class="checkbox-inline">
                                    <asp:CheckBox value="true" ID="cBoxActividadOtro" runat="server" />Otro
                                </label>

                            </div>
                            <div class="form-group">
                                <label>Descripci&oacute;n otros</label>
                                <asp:TextBox ID="txtActividadOtros" runat="server" class="form-control" type="text" placeholder="Otros ..." required="true"> </asp:TextBox>
                            </div>

                        </div>

                    </div>
                    <div class="form-group">
                       
                    </div>
                    </div>


                    <div class="modal-footer">
                         <asp:Button ID="btnEnviarSolicitud" OnClick="Enviar_Solicitud_Click" Text="Enviar" runat="server" type="submit" CssClass="btn btn-success" />
                        <asp:Button ID="BtnCancelar" Text="Cancelar" runat="server" CssClass="Actualizar btn btn-danger" />
                    </div>
                </div>

            </div>
            </form>
        </div>
        <button id="btnNuevaSolicitud" data-toggle="modal" data-target="#SolicitudesAgregarEditarModal" class="btn btn-info">Generar Nueva Solicitud</button>
        

    

    
</asp:Content>
