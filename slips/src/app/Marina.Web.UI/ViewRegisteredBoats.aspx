<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRegisteredBoats.aspx.cs" Inherits="Marina.Web.UI.ViewRegisteredBoats" Title="Untitled Page" EnableViewState="false" %>
<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Infrastructure"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Your Registered Boats</h1>
    <asp:Repeater ID="uxBoatsRepeater" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>Registration Number</td>
                        <td>Manufacturer</td>
                        <td>Model Year</td>
                        <td>Length (in feet)</td>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
                <tbody>
                    <tr>
                        <td><%# Transform.From(Container.DataItem).To<BoatRegistrationDTO>().RegistrationNumber %></td>
                        <td><%# Transform.From(Container.DataItem).To<BoatRegistrationDTO>().Manufacturer %></td>
                        <td><%# Transform.From(Container.DataItem).To<BoatRegistrationDTO>().ModelYear %></td>
                        <td><%# Transform.From(Container.DataItem).To<BoatRegistrationDTO>().Length %></td>
                    </tr>
                </tbody>                    
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>    
</asp:Content>
