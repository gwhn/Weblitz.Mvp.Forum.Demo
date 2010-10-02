using System;
using System.Collections.Generic;
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
            get { return new ForumDisplay {Id = EditButton.CommandArgument.ToId()}; }
            set
            {
                NameLabel.Text = value.Name;
                EditButton.CommandArgument = value.Id.ToString();
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

        protected void Page_Init(object sender, EventArgs e)
        {
            new ForumItemPresenter(this, new ForumProvider());
        }

        protected void EditButton_OnCommand(object sender, CommandEventArgs e)
        {
            Edit(this, new IdEventArgs {Id = e.CommandArgument.ToString().ToId()});
        }
    }
}