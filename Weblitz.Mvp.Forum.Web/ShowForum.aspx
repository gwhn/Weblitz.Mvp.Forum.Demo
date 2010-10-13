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
                <div class="item">
                    <asp:LinkButton ID="TitleLinkButton" runat="server" CssClass="title" OnCommand="TitleLinkButton_OnCommand"/>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
        </div>
        <div class="options">
            <asp:LinkButton ID="EditLinkButton" runat="server" Text="Edit" OnCommand="EditLinkButton_OnCommand"/>
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" OnCommand="DeleteButton_OnCommand" />
            <asp:LinkButton ID="NewTopicLinkButton" runat="server" Text="New Topic" OnCommand="NewTopicLinkButton_OnCommand"/>
        </div>
    </div>
</asp:Content>
