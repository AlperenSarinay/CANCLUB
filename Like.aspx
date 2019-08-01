<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Like.aspx.cs" Inherits="Like" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <br>

        <div class="align-self-start">
<asp:GridView ID="GridView1" runat="server" 
       
        AutoGenerateColumns="False"
      
        DataKeyNames="id" CssClass="table table-striped" Width="997px" OnSelectedIndexChanging="Button1_Click" BackColor="Black" ForeColor="Red" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

        <Columns>
            <asp:TemplateField HeaderText="ID">
               
                <ItemTemplate>
                    <asp:Label ID="Id" Text='<%#Bind("id")%>' runat="server"></asp:Label>
                     
                </ItemTemplate>
            </asp:TemplateField>
  <asp:TemplateField HeaderText="Type">
               
                <ItemTemplate>
                    <asp:Label ID="type" Text='<%#Bind("type")%>' runat="server"></asp:Label>
                     
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Title">
               
                <ItemTemplate>
                    <asp:Label ID="Labeltitle" Text='<%#Bind("title")%>' runat="server"></asp:Label>
                     
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Activity">
               
                <ItemTemplate>
                    <asp:Label ID="Labelactivity" Text='<%#Bind("activity_include")%>' runat="server"></asp:Label>
                     
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Date">
               
                <ItemTemplate>
                    <asp:Label ID="Labeldate" Text='<%#Bind("date")%>' runat="server"></asp:Label>
                     
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Score">
             
                <ItemTemplate>
                    <asp:Label ID="Total" Text='<%#Bind("score")%>' runat="server"></asp:Label>
                     
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Vote">
                <ItemTemplate>
              <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                 
                  <asp:ListItem Value="1">Like</asp:ListItem>
                <asp:ListItem Value="0">Disslike</asp:ListItem>

              </asp:RadioButtonList>
                  
                </ItemTemplate>
            </asp:TemplateField>


           

        </Columns>
    </asp:GridView>
                                        <p>  <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="Button1_Click" />       </p>

               <br>
                <p class="text-center">
                </p>
                <hr>
                  

        </div>
               
                        


                        

</asp:Content>
