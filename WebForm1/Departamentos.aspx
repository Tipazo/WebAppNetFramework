<%@ Page Title="Departamentos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departamentos.aspx.cs" Inherits="WebForm1.Departamentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="mb-2 pull-right">
        <asp:Button 
            ID="btnNuevo" 
            runat="server" 
            Text="➕ Crear nuevo departamento" 
            OnClick="btnNuevo_Click" 
            CssClass="btn btn-success btn-sm" 
         />
    </div>
    
    <asp:Repeater ID="rptDepartamentos" runat="server" OnItemCommand="rptDepartamentos_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped">
                <thead class="thead-dark">
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Estado</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("departmentID") %></td>
                <td><%# Eval("Name") %></td>
                <td style='<%# Eval("Status").ToString() == "Active" ? "color:green;" : "color:red;" %>'>
                    <%# Eval("Status") %>
                </td>
                <td>
                    <asp:Button runat="server" 
                        Text="Editar" 
                        CommandName="Editar" 
                        CommandArgument='<%# Eval("departmentID") %>' 
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
