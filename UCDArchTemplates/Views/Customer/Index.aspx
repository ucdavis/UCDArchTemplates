<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<UCDArchTemplates.Models.Customer>>" %>
<%@ Import Namespace="Telerik.Web.Mvc.UI"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>


<p>
    <%= Html.ActionLink("Create New", "Create") %>
</p>

<% Html.Telerik().Grid(Model) 
            .Name("List")
            .PrefixUrlParameters(false) //True if >0 sortable/pageable grids
            .Columns(col => {
            col.Add(x => {%>
				<%= Html.ActionLink("Edit", "Edit", new { id = x.Id }) %>           
				<%});
			            col.Add(x => x.CompanyName);
                        col.Add(x => x.ContactName);
                        col.Add(x => x.Country);
                        col.Add(x => x.Fax);
                        col.Add(x => x.Id);
                        })
            //.Pageable()
            //.Sortable()
            .Render(); 
        %>

</asp:Content>

