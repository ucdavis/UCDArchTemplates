<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UCDArchTemplates.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">CompanyName</div>
        <div class="display-field"><%= Html.Encode(Model.CompanyName) %></div>
        
        <div class="display-label">ContactName</div>
        <div class="display-field"><%= Html.Encode(Model.ContactName) %></div>
        
        <div class="display-label">Country</div>
        <div class="display-field"><%= Html.Encode(Model.Country) %></div>
        
        <div class="display-label">Fax</div>
        <div class="display-field"><%= Html.Encode(Model.Fax) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
		<%= Html.AntiForgeryToken() %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

