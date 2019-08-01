<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    
    <h3>Profil</h3>
    
    <p>
        <asp:Image ID="ProfilResmi" runat="server" Height="300px" CssClass="img-fluid img-thumbnail" Width="300px" />
    </p>
        
    
    <div class="input-group">
        <span class="input-group-addon"><i class="far fa-user"></i></span>
        <asp:TextBox ID="TextBoxFname" placeholder="First name" CssClass="form-control" runat="server" EnableViewState="False"></asp:TextBox></p>
    </div>
        
<p></p>
    <div class="input-group">
        <span class="input-group-addon"><i class="far fa-user"></i></span>
        <asp:TextBox ID="TextBoxLastName" placeholder="Last name" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <p></p>
        <div class="input-group">
        <span class="input-group-addon"><i class="far fa-user"></i></span>
        <asp:TextBox ID="TextBoxUserName" placeholder="User name" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
<p></p>      
    <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-envelope"></i></span>
             <asp:TextBox ID="TextBoxEmail" placeholder="email" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
        </div>
    <p></p>
    <p></p>
        <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-th-list"></i></span>
        <asp:TextBox ID="TextBoxDepartment" placeholder="Department" CssClass="form-control" runat="server"></asp:TextBox>
         </div>
    <p></p>
    <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-key"></i></span>
        <asp:TextBox ID="TextBoxPass" placeholder="Password" CssClass="form-control" minlength="8" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1"
            runat="server" ControlToValidate="TextBoxPass" ForeColor="red" ValidationGroup="submit"
            ErrorMessage="You cannot leave the page without filling out this field.">
        </asp:RequiredFieldValidator>
        </div>
    <p></p>
    <asp:FileUpload ID="fluDosya" CssClass ="btn btn-primary" runat="server" />
    <p></p>
    
    <p> <asp:Button ID="ButtonSubmit" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="ButtonSubmit_Click" ValidationGroup="submit" /></p>
   
   
    
</asp:Content>