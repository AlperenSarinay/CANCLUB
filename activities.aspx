<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="activities.aspx.cs" Inherits="activities" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <br>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="1303px" BackColor="Black" BorderColor="Black" ForeColor="Red">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                    <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                    <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                    <asp:BoundField DataField="activity_include" HeaderText="activity_include" SortExpression="activity_include" />
                    <asp:BoundField DataField="activity_by" HeaderText="activity_by" SortExpression="activity_by" />
                    <asp:BoundField DataField="TotalLike" HeaderText="TotalLike" SortExpression="TotalLike" />
                    <asp:BoundField DataField="TotalDislike" HeaderText="TotalDislike" SortExpression="TotalDislike" />
                </Columns>
            </asp:GridView>
    <hr>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webDbConnectionString %>" SelectCommand="SELECT [id], [type], [title], [date], [activity_include], [activity_by], [TotalLike], [TotalDislike] FROM [activity] ORDER BY [id]"></asp:SqlDataSource>
            <h4>Choose activity title</h4>
            <p><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="title" DataValueField="title"></asp:DropDownList> </p>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:webDbConnectionString %>" SelectCommand="SELECT [title] FROM [activity]"></asp:SqlDataSource>
            <p><asp:TextBox ID="TextBox1" runat="server" placeholder="Comment.." Height="57px" TextMode="MultiLine" Width="633px"></asp:TextBox></p>
            <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="Button1_Click" />
    <p></p>
            <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource3" Width="1328px" BackColor="Black" ForeColor="#009933">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="activity_id" HeaderText="activity_id" SortExpression="activity_id" />
                    <asp:BoundField DataField="user_id" HeaderText="user_id" SortExpression="user_id" />
                    <asp:BoundField DataField="comment_text" HeaderText="comment_text" SortExpression="comment_text" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:webDbConnectionString %>" SelectCommand="SELECT [id], [activity_id], [user_id], [comment_text] FROM [comments] ORDER BY [activity_id]"></asp:SqlDataSource>
</asp:Content>
