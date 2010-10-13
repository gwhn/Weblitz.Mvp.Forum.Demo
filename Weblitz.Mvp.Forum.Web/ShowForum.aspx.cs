using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weblitz.Mvp.Forum.Core;
using Weblitz.Mvp.Forum.Core.Extensions;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Presenters;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Web
{
    public partial class ShowForum : System.Web.UI.Page, IForumItemView
    {
        public IForumDisplay Forum
        {
            set
            {
                NameLabel.Text = value.Name;
                EditLinkButton.CommandArgument = value.Id.ToString();
                DeleteButton.CommandArgument = value.Id.ToString();
                TopicRepeater.DataSource = value.Topics;
            }
        }

        public int CurrentId
        {
            get { return Request["Id"].ToId(); }
        }

        public event EventHandler<IdEventArgs> Edit;

        public void GoToForumForm(int id)
        {
            Response.Redirect(string.Format("~/ForumForm.aspx?Id={0}", id));
        }

        public event EventHandler<IdEventArgs> Delete;

        public void GoToForumList()
        {
            Response.Redirect("~/Default.aspx");
        }

        public event EventHandler NewTopic;

        public void GoToTopicForm(int forumId)
        {
            Response.Redirect(string.Format("~/TopicForm.aspx?ForumId={0}", forumId));
        }

        public event EventHandler<IdEventArgs> ShowTopic;

        public void GoToTopicItem(int id)
        {
            Response.Redirect(string.Format("~/ShowTopic.aspx?Id={0}", id));
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            new ForumItemPresenter(this, new ForumProvider(ConfigurationManager.ConnectionStrings["Weblitz.Mvp.Forum"].ConnectionString));
        }

        protected void TopicRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
            var data = e.Item.DataItem as ITopicDisplay;
            if (data == null) return;
            var titleLink = e.Item.FindControl("TitleLinkButton") as LinkButton;
            if (titleLink == null) return;
            titleLink.Text = data.Title;
            titleLink.CommandArgument = data.Id.ToString();
        }

        protected void TitleLinkButton_OnCommand(object sender, CommandEventArgs e)
        {
            ShowTopic(this, new IdEventArgs {Id = e.CommandArgument.ToString().ToId()});
        }

        protected void DeleteButton_OnCommand(object sender, CommandEventArgs e)
        {
            Delete(this, new IdEventArgs { Id = e.CommandArgument.ToString().ToId() });
        }

        protected void EditLinkButton_OnCommand(object sender, CommandEventArgs e)
        {
            Edit(this, new IdEventArgs { Id = e.CommandArgument.ToString().ToId() });
        }

        protected void NewTopicLinkButton_OnCommand(object sender, CommandEventArgs e)
        {
            NewTopic(this, e);
        }
    }
}