<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentLeases.aspx.cs" Inherits="Marina.Web.UI.CurrentLeases" Title="Untitled Page" %>
<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Infrastructure"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Current Leases</h1>
    <asp:Repeater ID="uxLeasesRepeater" runat="server">
        <HeaderTemplate>
            <table>
            <tr>
                <td>Slip ID</td>
                <td>Start Date:</td>
                <td>Expiry Date:</td>
            </tr>                        
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Transform.From( Container.DataItem).To<DisplayLeaseDTO>( ).SlipID %></td>
                <td><%# Transform.From( Container.DataItem).To<DisplayLeaseDTO>( ).StartDate %></td>
                <td><%# Transform.From( Container.DataItem).To<DisplayLeaseDTO>( ).ExpiryDate %></td>
            </tr>                        
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
