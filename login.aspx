<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
  
    <p>

    </p>
    <div class="input-group">
         <span class="input-group-addon"><i class="fas fa-user"></i></span>
        <asp:TextBox ID="TextBoxEmail" placeholder="email" CssClass="form-control" runat="server"></asp:TextBox> 
    </div>
    <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-lock"></i></span>
        <asp:TextBox ID="TextBoxPass"  TextMode="Password" CssClass="form-control" placeholder="password" runat="server"></asp:TextBox>
    </div>
    <p>

    </p>
    <p> <asp:Button ID="ButtonSubmit" runat="server" Text="Login" CssClass="btn btn-success" OnClick="ButtonSubmit_Click" />
    


         <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>


</p>
    
 
</asp:Content>
