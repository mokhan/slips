<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DockView.aspx.cs" Inherits="Marina.Web.UI.DockView" Title="Untitled Page" %>
<%@ Import namespace="System.ComponentModel"%>
<%@ Import namespace="Marina.Web.Commands"%>
<%@ Import namespace="Marina.Web.Views"%>

<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Infrastructure"%>
<%@ Import namespace="Marina.Presentation"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div>
    <h1>Dock: <%= DTO.Name %> </h1>    
    <table>
        <tr>
            <td>Location</td>
            <td><%= DTO.LocationName %></td>                
        </tr>
        <tr>        
            <td>Water Service</td>
            <td><%= DTO.WaterService %></td>
        </tr>            
        <tr>
            <td>Electrical Service</td>
            <td><%= DTO.ElectricalService %></td>
        </tr>
    </table>
</div>
<div>
    <h1>Available Slips</h1>    
    <asp:Repeater ID="uxSlipsRepeater" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>Dock Name</td>
                        <td>Slip Width</td>
                        <td>Slip Length</td>
                        <td></td>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                        <td><%# Transform.From(Container.DataItem).To<SlipDisplayDTO>().DockName %></td>
                        <td><%# Transform.From(Container.DataItem).To<SlipDisplayDTO>().Width %></td>
                        <td><%# Transform.From(Container.DataItem).To<SlipDisplayDTO>().Length %></td>
                        <td><a href='<%= WebViews.LeaseSlip.Name() %>?<%=PayloadKeys.SlipId %>=<%# Transform.From( Container.DataItem ).To<SlipDisplayDTO>( ).SlipId %>'>Lease This Slip!</a></td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>    
</div>
<div style="text-align:center;">
    <a href='<%= WebViews.AvailableSlips.Name( ) %>'>View All Available Slips</a>
</div>

</asp:Content>
