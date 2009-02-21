<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterBoat.aspx.cs" Inherits="Marina.Web.UI.RegisterBoat" Title="Untitled Page" %>
<%@ Import namespace="Marina.Web.Views"%>

<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Infrastructure"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Register Boat</h1>
    
    <asp:Repeater ID="uxResponseRepeater" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><%# Transform.From(Container.DataItem).To<DisplayResponseLineDTO>().Message %></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>    
    
    <table>
        <tr>
            <td>registration number:</td>
            <td><input name="uxRegistrationNumberTextBox" type="text" /></td>
        </tr>
        <tr>
            <td>manufacturer:</td>
            <td><input name="uxManufacturerTextBox" type="text" /></td>
        </tr>
        <tr>
            <td>model year:</td>
            <td><input name="uxModelYearTextBox" type="text" /></td>
        </tr>
        <tr>
            <td>length:</td>
            <td><input name="uxLengthTextBox" type="text" /></td>
        </tr>        
    </table>
    <asp:Button ID="uxRegisterBoatButton" runat="server" Text="Register" />    
    
    <div>
        <a href="<%= WebViews.ViewRegisteredBoats.Name( ) %>" >View All Registered Boats</a>
    </div>

</asp:Content>

