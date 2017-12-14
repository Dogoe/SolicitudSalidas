<%@ Page Title="" Language="C#" MasterPageFile="~/VistasUsuario/Usuarios.Master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="PracticaCapas.VistasUsuario.Solicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="formSolicitudesRealizadas" runat="server"> 
        <h3>Generar Nueva Solicitud</h3>
        <button id="btnNuevaSolicitud" data-toggle="modal" data-target="#SolicitudesAgregarEditarModal" class="btn btn-info  glyphicon glyphicon-plus"></button>
        <h2>Historial de Solicitudes</h2>
        <asp:HiddenField ID="TABSeleccionada" runat="server" Value="docente" />
        <ul id="tabSolicitudesPendientes"  class="nav nav-tabs">
            <li id="tabDocentes" runat="server" class="active"><a data-toggle="tab" href="#docente">Docente</a></li>
            <li id="tabAdministrador" runat="server"><a data-toggle="tab" href="#administrador">Administrador</a></li>
        </ul>

        <div class="tab-content">
            <div id="docente" class="tab-pane fade in active">
                <h3>Solicitudes Realizadas</h3>
                <asp:Label ID="msj" Text="" runat="server" />
                <asp:GridView ID="gvMisSolicitudes" CssClass="table table-responsive table-bordered table-striped"
                    runat="server" OnPageIndexChanging="gvMisSolicitudes_PageIndexChanging" AllowPaging="True" PageSize="6" AutoGenerateColumns="false" OnRowCommand="gvMisSolicitudes_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="IdProfesor" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("IdProfesor") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NombreEvento" ItemStyle-Width="" ItemStyle-CssClass="control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("NombreEvento") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FechaCreacion" ItemStyle-Width="" ItemStyle-CssClass="Carrera control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("FechaCreacion") %>' runat="server" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IdPeriodo" ItemStyle-CssClass="Correo control-label">
                            <ItemTemplate>
                                <small>
                                    <asp:Label Text='<%# Eval("IdPeriodo") %>' runat="server" CssClass="control-label" /></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <button type="button" class="btn btn-primary btn-xs glyphicon glyphicon-pencil"></button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <i>Estas viendo <%=gvMisSolicitudes.PageIndex + 1%> de <%=gvMisSolicitudes.PageCount%> Registros</i>
            </div>
            <div id="administrador" class="tab-pane fade">
                <h3>Todas las Solicitudes</h3>
                <asp:Label ID="Label1" Text="" runat="server" />
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
    <div>
        
        
        
    
    </div>
        <!-- Modal -->
        <div id="SolicitudesAgregarEditarModal" class="modal fade" data-backdrop="static" data-keyboard="false" role="dialog">
            <div id="mdialTamanio" class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Solicitud</h4>
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
                                    <label for="fecha">Fecha de Salida*</label>
                                    <asp:TextBox ID="txtFechaSalida" runat="server" class="form-control" type="date" required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Fecha de salida no válida</div>

                                </div>
                            </div>

                            <div class="col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label for="fecha">Hora de Salida*</label>
                                    <asp:TextBox ID="txtHoraSalida" runat="server" class="form-control" type="time" required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Hora de salida no válida </div>

                                </div>
                            </div>
                            <div class="col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label for="fecha">Fecha de Llegada*</label>
                                    <asp:TextBox ID="txtFechaLLegada" runat="server" class="form-control" type="date" required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Fecha de llegada no válida</div>

                                </div>
                            </div>

                            <div class="col-md-3 col-lg-3">
                                <div class="form-group">
                                    <label for="fecha">Hora de Llegada*</label>
                                    <asp:TextBox ID="txtHoraLlegada" runat="server" class="form-control" type="time" required="true"> </asp:TextBox>
                                    <div class="alert alert-danger" style="display: none">Hora de llegada no válida </div>

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
                    </div>


                    <div class="modal-footer">
                        <asp:Button ID="btnEnviarSolicitud" OnClick="Enviar_Solicitud_Click" Text="Enviar" runat="server" type="submit" CssClass="btn btn-success" />
                         <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    </div>
                </div>

            </div>

        </div>

    </form>
</asp:Content>
