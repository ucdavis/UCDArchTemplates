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

    <table>
        <tr>
            <th></th>
            <th>
                CompanyName
            </th>
            <th>
                ContactName
            </th>
            <th>
                Country
            </th>
            <th>
                Fax
            </th>
            <th>
                Id
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%= Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.CompanyName) %>
            </td>
            <td>
                <%= Html.Encode(item.ContactName) %>
            </td>
            <td>
                <%= Html.Encode(item.Country) %>
            </td>
            <td>
                <%= Html.Encode(item.Fax) %>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

