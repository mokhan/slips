<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Marina.Web.UI.Login" Title="Untitled Page" %>
<%@ Import namespace="Marina.Web.Views"%>
<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Infrastructure"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>user name:</td>
            <td><input type="text" name="uxUserNameTextBox" /></td>
        </tr>
        <tr>
            <td>password:</td>
            <td><input type="password" name="uxPasswordTextBox" /></td>
        </tr>
    </table>
    <asp:Button ID="uxLoginButton" runat="server" Text="login" />
    <p>
        <a href='<%= WebViews.Registration %>'>Need to register?</a>
    </p>
    
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

