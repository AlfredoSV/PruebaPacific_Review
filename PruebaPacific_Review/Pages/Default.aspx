<%@ Page Language="C#" AutoEventWireup="true" ViewStateMode="Enabled" CodeBehind="Default.aspx.cs" EnableViewState="true" Inherits="PruebaPacific_Review.Pages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Forms</title>
    <link rel="stylesheet" runat="server" href="../wwwroot/styles/style.css" />

</head>
<body>

    <form id="form1" runat="server">
        <asp:Label ID="DateForm" runat="server" />
        <br />

        <asp:ScriptManager ID="ScriptManagerGen" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>

                <asp:Button ID="CargaTabla" CssClass="btnCargaClientes" OnClick="CargaTabla_Click"  Text="Carga tabla" runat="server" />
                <asp:Table ID="tblClientes" CssClass="miTabla" Visible="false"  runat="server">
                    <asp:TableHeaderRow>

                        <asp:TableHeaderCell>Primer Apellido</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Segundo Nombre</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Sexo</asp:TableHeaderCell>
                       
                    </asp:TableHeaderRow>
                </asp:Table>
              
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
