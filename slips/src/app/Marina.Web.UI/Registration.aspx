<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Marina.Web.UI.Registration" Title="Untitled Page" EnableViewState="false"  %>
<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Infrastructure"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Registration</h1>
    
    <table>
        <tr>
            <td>username:</td>
            <td><input name="uxUserNameTextBox" type="text" /></td>
        </tr>
        <tr>
            <td>password:</td>
            <td><input name="uxPasswordTextBox" type="password" /></td>
        </tr>
        <tr>
            <td>first name:</td>
            <td><input name="uxFirstNameTextBox" type="text" /></td>
        </tr>
        <tr>
            <td>last name:</td>
            <td><input name="uxLastNameTextBox" type="text" /></td>
        </tr>
        <tr>
            <td>phone:</td>
            <td><input name="uxPhoneNumberTextBox" type="text" /></td>
        </tr>
        <tr>
            <td>city:</td>
            <td><input name="uxCityTextBox" type="text" /></td>
        </tr>
    </table>
    <asp:Button ID="uxRegisterButton" runat="server" Text="Register" />

    <asp:Repeater ID="uxResponseMessagesRepeater" runat="server">
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
</asp:Content>
