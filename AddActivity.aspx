<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddActivity.aspx.cs" Inherits="AddActivity" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>AddActivity</h3>
    <br>
    <p>
        <asp:TextBox ID="TextBoxType" placeholder="Type" CssClass="form-control" minlength="2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="submit"
                 runat="server" ControlToValidate ="TextBoxType" ForeColor="red"
                 ErrorMessage="You cannot leave the page without filling out this field.">
             </asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:TextBox ID="TextBoxtitle" placeholder="Title" CssClass="form-control" minlength="2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="submit"
                 runat="server" ControlToValidate ="TextBoxtitle" ForeColor="red"
                 ErrorMessage="You cannot leave the page without filling out this field.">
             </asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:TextBox ID="TextBoxActivity" placeholder="Activity" CssClass="form-control" minlength="2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="submit" 
                 runat="server" ControlToValidate ="TextBoxActivity" ForeColor="red"
                 ErrorMessage="You cannot leave the page without filling out this field.">
             </asp:RequiredFieldValidator>

    </p>

    <p>
        <asp:TextBox ID="TextBoxDate" placeholder="Date" CssClass="form-control" runat="server" Type ="Date"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="submit"
                 runat="server" ControlToValidate ="TextBoxDate" ForeColor="red"
                 ErrorMessage="You cannot leave the page without filling out this field.">
             </asp:RequiredFieldValidator>
    </p>
           

    <p>

    </p>
    
        <asp:Button ID="ButtonSubmit" runat="server" Text="Add" CssClass="btn btn-success" ValidationGroup="submit" OnClick="ButtonSubmit_Click" />
    
        





    </asp:Content>