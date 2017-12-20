<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="Notificaciones.aspx.cs" Inherits="PracticaCapas.VistasUsuario.Notificaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Javascrip/jquery-3.2.1.min.js"></script>    
    <script src="../Javascrip/bootstrap.min.js"></script> 
    <script src="../Javascrip/bootstrap-notify.min.js"></script> 
    <script src="../VistasUsuario/js/Solicitudes.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="formNotificaciones" runat="server">
        <asp:HiddenField ID="TABSeleccionada" runat="server" Value="docente" />
        <h3>Notificaciones</h3>

        <ul id="tabSolicitudesPendientes" class="nav nav-tabs">
            <li id="tabDocentes" runat="server" class="active"><a data-toggle="tab" href="#docente">Docente <span class="badge"><asp:Label ID="contadorNotificacionesDocente" runat="server" Text="0"></asp:Label></span></a></li>
            <li id="tabValidador" runat="server"><a data-toggle="tab" href="#validador"><asp:Label ID="lblTituloTabValidador" runat="server"></asp:Label> <span class="badge"><asp:Label ID="contadorNotificacionesValidador" runat="server" Text="0"> </asp:Label></span></a></li>
        </ul>

        <div class="tab-content">
            <!--Tab Solicitudes pendientes docente -->
            <div id="docente" class="tab-pane fade in active">
                <h3>Solicitudes</h3>
                <asp:Label ID="msjTablaDocente" Text="" runat="server" />

                <asp:GridView ID="gvSolicitudesPendientesDocente" CssClass="table table-responsive table-bordered table-striped"
                    runat="server" OnPageIndexChanging="gvSolicitudesPendientesDocente_PageIndexChanging" AllowPaging="True" PageSize="6" 
                    AutoGenerateColumns="false" OnRowCommand="gvSolicitudesPendientesDocente_RowCommand" OnRowDataBound="gvSolicitudesPendientesDocente_RowDataBound">
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
                        <asp:TemplateField HeaderText="Periodo" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("CicloPeriodo") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre del evento" ItemStyle-Width="" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("NombreEvento") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de salida" ItemStyle-Width="" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("FechaHoraSalida") %>' runat="server" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label ID="lblDescripcionEstado" Text='<%# Eval("DescripcionEstado") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="130px">
                            <ItemTemplate>
                               
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Consultar Solicitud" ID="linkButonConsultarSol" class="btn btn-default btn-xs glyphicon glyphicon-eye-open" runat="server" CommandName="Consultar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Editar Solicitud" ID="linkButonEditarSol" class="btn btn-primary btn-xs glyphicon glyphicon-pencil" runat="server" CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Subir Reporte de Salida" ID="linkButonSubirReporte" class="btn btn-default btn-xs glyphicon glyphicon-save-file" runat="server" CommandName="SubirReporte" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                                
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <i>Estas viendo <%=gvSolicitudesPendientesDocente.PageIndex + 1%> de <%=gvSolicitudesPendientesDocente.PageCount%> Registros</i>
            </div>
            <!--Tab Validador en turno-->
            <div id="validador" class="tab-pane fade">
                <h3>Solicitudes</h3>
                <asp:Label ID="msj" Text="" runat="server" />
                <asp:GridView ID="gvSolicitudesPendientesAdmin" CssClass="table table-responsive table-bordered table-striped"
                    runat="server" OnPageIndexChanging="gvSolicitudesPendientesAdmin_PageIndexChanging" AllowPaging="True" 
                    PageSize="6" AutoGenerateColumns="false" OnRowCommand="gvSolicitudesPendientesAdmin_RowCommand1" OnRowDataBound="gvSolicitudesPendientesAdmin_RowDataBound">
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
                        
                        <asp:TemplateField HeaderText="Periodo" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("CicloPeriodo") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre del evento" ItemStyle-Width="" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("NombreEvento") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de salida" ItemStyle-Width="" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("FechaHoraSalida") %>' runat="server" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("DescripcionEstado") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="130px">
                            <ItemTemplate>
                                
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Aceptar Solicitud" ID="linkButonAceptarSol" class="btn btn-default btn-xs glyphicon glyphicon-send" runat="server" CommandName="Aceptar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Consultar Solicitud" ID="linkButonConsultarSol" class="btn btn-default btn-xs glyphicon glyphicon-eye-open" runat="server" CommandName="Consultar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Aprobar Solicitud" ID="linkButonAprobar" class="btn btn-success btn-xs glyphicon glyphicon-ok" runat="server" CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                                <asp:LinkButton data-toggle="tooltip" data-placement="right" title="Rechazar Solicitud" ID="linkButonRechazarSol" class="btn btn-danger btn-xs glyphicon glyphicon-remove" runat="server" CommandName="Rechazar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"> </asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <i>Estas viendo <%=gvSolicitudesPendientesAdmin.PageIndex + 1%> de <%=gvSolicitudesPendientesAdmin.PageCount%> Registros</i>
            </div>
        </div>
        <!-- Modal Confirmar Aceptar solicitud-->
        <div id="ModalConfirmarSolicitud" class="modal fade" data-backdrop="static" data-keyboard="false" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4> <asp:Label class="modal-title" ID="lblTituloModalConfirmar" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <!--Informacion de solicitud-->
                    <div  class="modal-body">
                         <div class="form-group">
                             <h3><asp:Label ID="lblMsjContenidoModal" runat="server" Text=""></asp:Label></h3>
                            <asp:TextBox ID="txtIdSolicitudIdSolicitudHidde" class="form-control" Text="" runat="server" Style="display: none" />

                        </div>
                        <div class="form-group">
                            <h3><asp:Label ID="lblMsjComentarioRechazado" runat="server" Text=""></asp:Label></h3>
                            <asp:TextBox ID="txtComentarioRechazar" class="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server" />

                        </div>
                        <div class="form-group">
                             <asp:FileUpload ID="FileUpload" runat="server"/>

                        </div>
                    </div>


                    <div class="modal-footer">
                        <asp:Button ID="btnAceptarSolicitud" OnClick="btnAceptarSolicitud_Click" Text="Aceptar" runat="server" CssClass="btn btn-success" />
                        <asp:Button ID="btnRechazarSolicitud" OnClick="btnRechazarSolicitud_Click" Text="Rechazar" runat="server" CssClass="btn btn-success" />
                        <asp:Button ID="btnAprobarSolicitud" OnClick="btnAprobarSolicitud_Click" Text="Aprobar" runat="server" CssClass="btn btn-success" />
                        <asp:Button ID="btnUploadReporte" OnClick="btnUploadReporte_Click" Text="Subir" runat="server" CssClass="btn btn-success" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                    </div>
                </div>

            </div>
        </div>
        <!--Termina Modal Confirmar Aceptar solicitud-->
        
        
        <!-- Modal ModificarConsultar-->
        <div id="ModalModificarConsultarSolicitud" class="modal fade" data-backdrop="static" data-keyboard="false" role="dialog">
            <div id="mdialTamanio" class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Solicitud</h4>
                    </div>
                    <!--Informacion de solicitud-->
                    <asp:HiddenField ID="idSolEnModal" runat="server" />
                    <div class="container modal-body">
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
                            <div class="form-group col-md-6 col-lg-6">
                                <label for="carrera">Carrera*</label>
                                <asp:DropDownList ID="ddlCarrera" runat="server" CssClass="form-control btn btn-default dropdown-toggle" data-toggle="dropdown" required="true"></asp:DropDownList>
                            </div>

                            <div class="form-group col-md-6 col-lg-6">
                                <label for="Periodo">Periodo*</label>
                                <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form-control btn btn-default dropdown-toggle" data-toggle="dropdown" required="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div style="margin-bottom: 50px;"></div>
                        <!--Fechas de la solicitud-->
                        <div class="row">
                            <div class="col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label for="Periodo">Fecha de Salida*</label>
                                    <asp:TextBox ID="txtFechaSalida" runat="server" class="form-control" type="date" required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Fecha de salida no válida</div>

                                </div>
                            </div>

                            <div class="col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label for="Periodo">Hora de Salida(HH:mm - Ej. 22:05)*</label>
                                    <asp:TextBox ID="txtHoraSalida" runat="server" class="form-control" required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Hora de salida no válida </div>

                                </div>
                            </div>
                            <div class="col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label for="Periodo">Fecha de Regreso*</label>
                                    <asp:TextBox ID="txtFechaRegreso" runat="server" class="form-control" type="date"  required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Fecha de regreso no válida</div>

                                </div>
                            </div>

                            <div class="col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label>Hora de Regreso(HH:mm - Ej. 22:05)*</label>
                                    <asp:TextBox ID="txtHoraRegreso" runat="server" class="form-control" required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Hora de Regreso no válida </div>

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
                                        <label>Descripci&oacute;n otros Recursos(Opcional)</label>
                                        <asp:TextBox ID="txtRecursoSolicitadoOtro" runat="server" class="form-control" type="text" placeholder="Otros ..."> </asp:TextBox>
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
                                    <label>Descripci&oacute;n otras Actividades(Opcional)</label>
                                    <asp:TextBox ID="txtActividadOtros" runat="server" class="form-control" type="text" placeholder="Otros ..."> </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnEditarSol" OnClick="btnEditarSol_Click" Text="Guardar Cambios" runat="server" CssClass="btn btn-success" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--Termina Modal ModificarConsultar-->
    </form>

</asp:Content>
