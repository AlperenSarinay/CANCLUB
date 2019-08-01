<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">

    <br>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1"  OnRowDeleting="DeleteUser" BackColor="Black" ForeColor="#009900" Width="1329px">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="surname" HeaderText="surname" SortExpression="surname" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />

            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="birthdate" HeaderText="birthdate" SortExpression="birthdate" />

            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                     <asp:LinkButton ID="lnkdel" runat="server" Text="Delete" class="btn btn-danger"  CommandName="Delete" 
                     OnClientClick="return confirm('All data belonging to the user will be deleted. Sure ?);"
                    ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webDbConnectionString %>" SelectCommand="SELECT [id], [name], [surname], [email], [department], [username], [birthdate] FROM [user] ORDER BY [id]" DeleteCommand="DELETE FROM [user] WHERE [id] = @id" InsertCommand="INSERT INTO [user] ([name], [surname], [email], [department], [username], [birthdate]) VALUES (@name, @surname, @email, @department, @username, @birthdate)" UpdateCommand="UPDATE [user] SET [name] = @name, [surname] = @surname, [email] = @email, [department] = @department, [username] = @username, [birthdate] = @birthdate WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="surname" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="department" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="birthdate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="surname" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="department" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="birthdate" Type="DateTime" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    








</asp:Content>