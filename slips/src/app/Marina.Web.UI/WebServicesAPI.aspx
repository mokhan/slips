<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebServicesAPI.aspx.cs" Inherits="Marina.Web.UI.WebServicesAPI" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Our Web Services API</h1>
    <p>
        If you're interested in checking out our web services API check out:
    </p>
    <ul>
        <li><a href="services/AuthenticationServices.asmx">Authentication</a></li>
        <li><a href="services/CatalogServices.asmx">Catalog</a></li>
        <li><a href="services/LeaseServices.asmx">Leasing</a></li>
        <li><a href="services/RegistrationServices.asmx">Registration</a></li>
    </ul>
</asp:Content>
