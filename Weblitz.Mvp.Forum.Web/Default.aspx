<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Weblitz.Mvp.Forum.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Forums
    </h2>
    <div class="forum list">
        <asp:Repeater ID="ForumRepeater" runat="server" OnItemDataBound="ForumRepeater_OnItemDataBound">
            <ItemTemplate>
                <div class="forum item">
                    <asp:LinkButton ID="NameLinkButton" runat="server" CssClass="name" OnCommand="NameLinkButton_OnCommand"/>
                    <asp:Label ID="TopicCountLabel" runat="server" CssClass="count"/>
                    <asp:Label ID="PostCountLabel" runat="server" CssClass="count"/>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
    <div class="options">
        <asp:LinkButton ID="NewForumLinkButton" runat="server" OnClick="NewForumLinkButton_OnClick">New forum</asp:LinkButton>
    </div>
</asp:Content>
