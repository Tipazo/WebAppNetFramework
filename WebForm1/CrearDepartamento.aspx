<%@ Page Title="CrearDepartamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearDepartamento.aspx.cs" Inherits="WebForm1.CrearDepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container mt-4">
        <h2 class="mb-4">Crear Nuevo Departamento</h2>

        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label class="form-label">Estado</label>
            <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" CssClass="form-check">
                <asp:ListItem Text="Activo" Value="Active" />
                <asp:ListItem Text="Inactivo" Value="Inactive" />
            </asp:RadioButtonList>
        </div>

        <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClick="btnCancelar_Click" CausesValidation="false" />
    </div>

</asp:Content>
