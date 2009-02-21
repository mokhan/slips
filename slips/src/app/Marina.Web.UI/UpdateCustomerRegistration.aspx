<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateCustomerRegistration.aspx.cs" Inherits="Marina.Web.UI.UpdateCustomerRegistration" Title="Untitled Page" %>
<%@ Import namespace="Marina.Web.Views"%>
<%@ Import namespace="System.ComponentModel"%>
<%@ Import namespace="Marina.Infrastructure"%>
<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Web.UI"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h1>Update Registration</h1>
    <table>
        <tr>
            <td>username:</td>
            <td><input name="uxUserNameTextBox" type="text" value="<%= CustomerRegistration.UserName %>" readonly="readonly" /></td>
        </tr>
        <tr>
            <td>password:</td>
            <td><input name="uxPasswordTextBox" type="password" /></td>
        </tr>
        <tr>
            <td>first name:</td>
            <td><input name="uxFirstNameTextBox" type="text" value="<%= CustomerRegistration.FirstName %>" /></td>
        </tr>
        <tr>
            <td>last name:</td>
            <td><input name="uxLastNameTextBox" type="text" value="<%= CustomerRegistration.LastName %>" /></td>
        </tr>
        <tr>
            <td>phone:</td>
            <td><input name="uxPhoneNumberTextBox" type="text" value="<%= CustomerRegistration.Phone %>" /></td>
        </tr>
        <tr>
            <td>city:</td>
            <td><input name="uxCityTextBox" type="text" value="<%= CustomerRegistration.City %>" /></td>
        </tr>
    </table>
    <asp:Button ID="uxUpdateButton" runat="server" Text="Update" />

    <asp:Repeater ID="uxResponseMessagesRepeater" runat="server">
        <HeaderTemplate>
            <ul>                
        </HeaderTemplate>        
        <ItemTemplate>
                <li><%# Transform.From( Container.DataItem ).To< DisplayResponseLineDTO >( ).Message %></li>
        </ItemTemplate>        
        <FooterTemplate>                
            </ul>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>