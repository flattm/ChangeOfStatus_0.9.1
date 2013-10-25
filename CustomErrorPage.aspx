<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CustomErrorPage.aspx.vb" Inherits="CustomErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" 
        Text="The application has encountered and error.  Please contact support and provide them with the following information."></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>

