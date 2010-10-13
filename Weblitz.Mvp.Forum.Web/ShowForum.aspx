<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowForum.aspx.cs" Inherits="Weblitz.Mvp.Forum.Web.ShowForum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="forum item">
        <dl>
            <dt>Name</dt>
            <dd><asp:Label ID="NameLabel" runat="server"/></dd>
        </dl>
        <div class="topic list">
        <asp:Repeater ID="TopicRepeater" runat="server" OnItemDataBound="TopicRepeater_OnItemDataBound">
            <ItemTemplate>
                <div class="topic item">
                    <asp:LinkButton ID="TitleLinkButton" runat="server" CssClass="title" OnCommand="TitleLinkButton_OnCommand"/>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
        </div>
        <div class="options">
            <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" OnCommand="OptionsButton_OnCommand" />
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" OnCommand="OptionsButton_OnCommand" />
            <asp:Button ID="NewTopicButton" runat="server" Text="New Topic" OnClick="NewTopicButton_OnClick" />
        </div>
    </div>
</asp:Content>
