<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopicForm.aspx.cs" Inherits="Weblitz.Mvp.Forum.Web.TopicForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="forum form">
    <fieldset>
        <dl>
           <dt><asp:Label ID="TitleLabel" runat="server" Text="Title" AssociatedControlID="TitleTextBox"/></dt>
           <dd><asp:TextBox ID="TitleTextBox" runat="server"/></dd> 
        </dl>
        <dl>
           <dt><asp:Label ID="BodyLabel" runat="server" Text="Body" AssociatedControlID="BodyTextBox"/></dt>
           <dd><asp:TextBox ID="BodyTextBox" runat="server" TextMode="MultiLine"/></dd> 
        </dl>
        <dl>
           <dt><asp:Label ID="StickyLabel" runat="server" Text="Sticky" AssociatedControlID="StickyCheckBox"/></dt>
           <dd><asp:CheckBox ID="StickyCheckBox" runat="server" /></dd> 
        </dl>
        <div class="options">
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnCommand="SubmitButton_OnCommand" />
        </div>
    </fieldset>
    </div>
</asp:Content>
