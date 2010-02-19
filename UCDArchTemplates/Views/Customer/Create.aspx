<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UCDArchTemplates.Controllers.CustomerViewModel>" %>
<%@ Import Namespace="UCDArchTemplates.Models"%>
<%@ Import Namespace="xVal.Html"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

	<%= Html.ClientSideValidation<Customer>() %>

    <% using (Html.BeginForm()) {%>
        <%= Html.AntiForgeryToken() %>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Customer.CompanyName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Customer.CompanyName) %>
                <%= Html.ValidationMessageFor(model => model.Customer.CompanyName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Customer.ContactName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Customer.ContactName) %>
                <%= Html.ValidationMessageFor(model => model.Customer.ContactName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Customer.Country) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Customer.Country) %>
                <%= Html.ValidationMessageFor(model => model.Customer.Country) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Customer.Fax) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Customer.Fax) %>
                <%= Html.ValidationMessageFor(model => model.Customer.Fax) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

