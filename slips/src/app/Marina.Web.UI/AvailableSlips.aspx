<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvailableSlips.aspx.cs" Inherits="Marina.Web.UI.AvailableSlips" Title="Untitled Page" %>
<%@ Import namespace="Marina.Web.Views"%>

<%@ Import namespace="Marina.Presentation"%>
<%@ Import namespace="Marina.Presentation.DTO"%>
<%@ Import namespace="Marina.Infrastructure"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div>
<h1>Available Slips</h1>          
<table>
	<thead>
		<tr>
			<td>Location Name</td>
			<td>Dock Name</td>
			<td>Slip Width</td>
			<td>Slip Length</td>
		</tr>
	</thead>			
	<tbody>
    <% foreach ( SlipDisplayDTO item in ViewLuggage.ClaimFor(ViewLuggageTickets.AvailableSlips) ) {%>
	    <tr>
		    <td><%= item.LocationName %></td>
		    <td>
			    <a href='<%= WebViews.DockView.Name( ) %>?<%= PayloadKeys.DockId %>=<%= item.DockId %>'>
				    <%= item.DockName %>
			    </a>
		    </td>
		    <td><%= item.Width %></td>
		    <td><%= item.Length %></td>		
	    </tr>
    <% } %>	
    </tbody>				
</table>
</div>    
</asp:Content>
