<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForumForm.aspx.cs" Inherits="Weblitz.Mvp.Forum.Web.ForumForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="forum">
    <fieldset>
        <dl>
           <dt><asp:Label ID="NameLabel" runat="server" Text="Name" AssociatedControlID="NameTextBox"/></dt>
           <dd><asp:TextBox ID="NameTextBox" runat="server"/></dd> 
        </dl>
        <div class="options">
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_OnClick" />
        </div>
    </fieldset>
    </div>
</asp:Content>
