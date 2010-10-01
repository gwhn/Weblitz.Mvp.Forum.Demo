﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weblitz.Mvp.Forum.Core;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Presenters;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Web
{
    public partial class _Default : System.Web.UI.Page, IForumListView
    {
        public IEnumerable<IForumDisplay> Forums
        {
            get { return (IEnumerable<IForumDisplay>)ForumRepeater.DataSource; }
            set { ForumRepeater.DataSource = value; }
        }

        public event EventHandler<IdEventArgs> Show;

        public event EventHandler New;

        public void GoToForumForm()
        {
            Response.Redirect("~/ForumForm.aspx");
        }

        public void GoToForumItem(int id)
        {
            Response.Redirect("~/ShowForum.aspx");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            new ForumPresenter(this, new ForumProvider());
        }

        protected void NewForumLinkButton_OnClick(object sender, EventArgs e)
        {
            New(this, e);
        }

        protected void ForumRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) 
                return;
            var data = e.Item.DataItem as IForumDisplay;
            if (data == null) 
                return;
            var nameLink = e.Item.FindControl("NameHyperLink") as HyperLink;
            if (nameLink != null)
                nameLink.Text = data.Name;
            
        }
    }
}