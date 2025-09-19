<%@ Page Title="EditarEmpleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEmpleado.aspx.cs" Inherits="WebForm1.EditarEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Editar Empleado</h2>
        <asp:Label ID="lblErrores" runat="server" CssClass="alert alert-danger" EnableViewState="false" Style="display:block;"></asp:Label>
        <asp:HiddenField ID="hfEmployeeID" runat="server" />

        <div class="mb-3">
            <label for="txtFirstName" class="form-label">Nombre</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtLastname" class="form-label">Apellidos</label>
            <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtDPI" class="form-label">DPI</label>
            <asp:TextBox ID="txtDPI" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtBirthDay" class="form-label">Fecha de Nacimiento</label>
            <asp:TextBox ID="txtBirthDay" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="mb-3">
            <label for="txtGenre" class="form-label">Género</label>
            <asp:RadioButtonList ID="rblGenre" runat="server" RepeatDirection="Horizontal" CssClass="form-check form-check-inline">
                <asp:ListItem Text="Hombre" Value="Male" />
                <asp:ListItem Text="Mujer" Value="Female" />
            </asp:RadioButtonList>
        </div>

        <div class="mb-3">
            <label for="txtHideDate" class="form-label">Fecha de Contrato</label>
            <asp:TextBox ID="txtHideDate" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="mb-3">
            <label class="form-label">Estado</label>
            <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" CssClass="form-check form-check-inline">
                <asp:ListItem Text="Activo" Value="Active" />
                <asp:ListItem Text="Inactivo" Value="Inactive" />
            </asp:RadioButtonList>
        </div>

        <div class="mb-3">
            <label for="txtNit" class="form-label">NIT</label>
            <asp:TextBox ID="txtNit" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtAddress" class="form-label">Dirección</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="ddlDepartamentos" class="form-label">Departamento</label>
            <asp:DropDownList ID="ddlDepartamentos" runat="server" CssClass="form-control" />
        </div>

        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClick="btnCancelar_Click" CausesValidation="false" />
    </div>
</asp:Content>
