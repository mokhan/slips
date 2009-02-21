<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="Marina.Web.UI.LeaseSlip" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h1>Would you like to lease slip: <%= Slip.SlipId %></h1>
    
    <div>
    <table>
        <thead>
            <tr>
                <td>Dock Name</td>
                <td>Location Name</td>
                <td>Length (in feet)</td>
                <td>Width (in feet)</td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><%= Slip.DockName %></td>
                <td><%= Slip.LocationName %></td>
                <td><%= Slip.Length %></td>
                <td><%= Slip.Width %></td>
            </tr>
        </tbody>
    </table>
    </div>
    
    <div>
    Select Lease Duration:
    <select name="uxLeaseDuration">
        <option value="Daily">Daily</option>
        <option value="Weekly">Weekly</option>
        <option value="Monthly">Monthly</option>
        <option value="Yearly">Yearly</option>        
    </select>    
    </div>
    
    <asp:Button ID="uxSubmitButton" runat="server" Text="Lease Now!" />
    
    <p>
        <%= ResponseMessage %>
    </p>

</asp:Content>

