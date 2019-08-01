<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BestActivity.aspx.cs" Inherits="BestActivity" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <br>
    <asp:GridView ID="GridView1"  runat="server" CssClass="table table-striped" AutoGenerateColumns="False"  DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="5" BackColor="Black" ForeColor="Red" BorderColor="Black">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:BoundField DataField="activity_by" HeaderText="activity_by" SortExpression="activity_by" />
            <asp:BoundField DataField="activity_include" HeaderText="activity_include" SortExpression="activity_include" />
            <asp:BoundField DataField="score" HeaderText="score" SortExpression="score" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webDbConnectionString %>" SelectCommand="SELECT [id], [title], [date], [activity_by], [activity_include], [score] FROM [activity] ORDER BY [score] DESC"></asp:SqlDataSource>
   
    
    
</asp:Content>