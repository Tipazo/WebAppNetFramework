<%@ Page Title="EditarDepartamento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDepartamento.aspx.cs" Inherits="WebForm1.EditarDepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar Departamento</h2>

    <asp:HiddenField ID="hdnId" runat="server" />

    <div>
        <label>Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" />
    </div>

    <div>
        <label>Estado:</label>
        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Activo" Value="Active"></asp:ListItem>
            <asp:ListItem Text="Inactivo" Value="Inactive"></asp:ListItem>
        </asp:RadioButtonList>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClick="btnCancelar_Click" CausesValidation="false" />

</asp:Content>
