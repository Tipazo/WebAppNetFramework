<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="WebForm1.Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <!-- Botón Crear -->
    <div class="mb-2 pull-right">
        <asp:Button ID="btnNuevo" runat="server" Text="➕ Crear nuevo empleado" OnClick="btnNuevo_Click" CssClass="btn btn-success btn-sm"  />
    </div>

    <!-- Filtros -->
    <div class="card mb-5 p-0">
         <div class="card-body">
        <div class="row g-2 mb-3">
            <div class="col-md-3">
                <label class="form-label">Departamento</label>
                <asp:DropDownList ID="ddlFiltroDepartamento" runat="server" CssClass="form-control">
                    <asp:ListItem Text="-- Todos --" Value="" />
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="form-label">Estado</label>
                <asp:DropDownList ID="ddlFiltroEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Text="-- Todos --" Value="" />
                    <asp:ListItem Text="Activo" Value="Active" />
                    <asp:ListItem Text="Inactivo" Value="Inactive" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="row g-2 mb-3">
            <div class="col-md-3">
                <label class="form-label">Fecha Ingreso Desde</label>
                <asp:TextBox ID="txtFiltroFechaInicio" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Fecha Ingreso Hasta</label>
                <asp:TextBox ID="txtFiltroFechaFin" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mt-4" OnClick="btnFiltrar_Click" />
            </div>
        </div>
        </div>
    </div>

    <!-- Tabla de empleados -->
    <asp:Repeater ID="rptEmpleados" runat="server" OnItemCommand="rptEmpleados_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped table-hover">
                <tr>
                    <th>ID</th>
                    <th>Nombres</th>
                    <th>Apellidos</th>
                    <th>DPI</th>
                    <th>Fecha Nacimiento</th>
                    <th>Edad</th>
                    <th>Genero</th>
                    <th>Estado</th>
                    <th>Nit</th>
                    <th>Departamento</th>
                    <th>Fecha de contrato</th>
                    <th>Antiguedad</th>
                    <th>Acciones</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("EmployeeID") %></td>
                <td><%# Eval("FirstName") %></td>
                <td><%# Eval("LastName") %></td>
                <td><%# Eval("DPI") %></td>
                <td><%# Eval("BirthDate") %></td>
                <td><%# Eval("Age") %></td>
                <td><%# Eval("Gender") %></td>
                <td style='<%# Eval("Status").ToString() == "Active" ? "color:green;" : "color:red;" %>'>
                    <%# Eval("Status") %>
                </td>
                <td><%# Eval("NIT") %></td>
                <td><%# Eval("DepartmentName") %></td>
                <td><%# Eval("HireDate") %></td>
                <td><%# Eval("Antiguedad") %></td>
                <td>
                    <asp:Button runat="server" 
                        Text="Editar" 
                        CommandName="Editar" 
                        CommandArgument='<%# Eval("EmployeeID") %>' 
                        CssClass="btn btn-primary btn-sm" 
                    />
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
