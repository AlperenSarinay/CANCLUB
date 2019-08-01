<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>Register</h3>
    <div class="input-group">
        <span class="input-group-addon"><i class="far fa-user"></i></span>
        <asp:TextBox ID="TextBoxFname" placeholder="First name" CssClass="form-control" runat="server" minlength="2" EnableViewState="False"></asp:TextBox>
    </div>
        <p>

    </p>
   <div class="input-group">
        <span class="input-group-addon"><i class="far fa-user"></i></span>
        <asp:TextBox ID="TextBoxLastName" placeholder="Last name" CssClass="form-control" minlength="2" runat="server"></asp:TextBox>
   </div>
        <p>

    </p>
    
    <div class="input-group">
        <span class="input-group-addon"><i class="far fa-user"></i></span>
        <asp:TextBox ID="TextBoxUserName" placeholder="User name" CssClass="form-control" minlength="2" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator 
            ID="RequiredFieldValidator3"
            runat="server" ControlToValidate="TextBoxUserName" ForeColor="red" ValidationGroup="submit"
            ErrorMessage="You cannot leave the page without filling out this field.">
        </asp:RequiredFieldValidator>
        </div>
    
    <p>

    </p>

     <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-envelope"></i></span>
         <asp:TextBox ID="TextBoxEmail" placeholder="email" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox> 
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" 
            runat="server" ControlToValidate="TextBoxEmail" ForeColor="red" ValidationGroup="submit"
            ErrorMessage="You cannot leave the page without filling out this field.">
        </asp:RequiredFieldValidator>
    </div>
    <p>

    </p>
    <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-calendar-alt"></i></span>
        <asp:TextBox ID="TextBoxBirthDate" placeholder="BirthDate" CssClass="form-control" runat="server" type ="date"></asp:TextBox>
    </div>
    <p>

    </p>
    <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-th-list"></i></span>
        <asp:TextBox ID="TextBoxDepartment" placeholder="Department" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <p>

    </p>
    <div class="input-group">
        <span class="input-group-addon"><i class="fas fa-key"></i></span>
                <asp:TextBox ID="TextBoxPass" placeholder="Password" CssClass="form-control" minlength="8" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator2"
            runat="server" ControlToValidate="TextBoxPass" ForeColor="red" ValidationGroup="submit"
            ErrorMessage="You cannot leave the page without filling out this field.">
        </asp:RequiredFieldValidator>
   </div>
   <p>
   </p>
    <asp:FileUpload ID="fluDosya" CssClass ="btn btn-primary" runat="server" />
    <p>    </p>
    
    <p> <asp:Button ID="ButtonSubmit" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="ButtonSubmit_Click" ValidationGroup="submit" />   

    <p> &nbsp;</p>
    
</asp:Content>
