<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UCDArchTemplates.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

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
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Html.Encode(Model.Id) %></div>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

