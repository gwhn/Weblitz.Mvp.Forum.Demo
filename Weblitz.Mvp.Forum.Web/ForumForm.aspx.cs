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
    public partial class ForumForm : System.Web.UI.Page, IForumFormView
    {
        public IForumInput Forum
        {
            get
            {
                return new ForumInput
                           {
                               Id = SubmitButton.CommandArgument.ToId(),
                               Name = NameTextBox.Text.Trim()
                           };
            }
            set
            {
                NameTextBox.Text = value.Name;
                SubmitButton.CommandArgument = value.Id.ToString();
            }
        }

        public int CurrentId
        {
            get { return Request["Id"].ToId(); }
        }

        public event EventHandler Create;

        public void GoToShowForum(int id)
        {
            Response.Redirect(string.Format("~/ShowForum.aspx?Id={0}", id));
        }

        public event EventHandler<IdEventArgs> Update;

        protected void Page_Init(object sender, EventArgs e)
        {
            new ForumFormPresenter(this, new ForumProvider(ConfigurationManager.ConnectionStrings["Weblitz.Mvp.Forum"].ConnectionString));
        }

        protected void SubmitButton_OnCommand(object sender, CommandEventArgs e)
        {
            var id = e.CommandArgument.ToString().ToId();
            if (id > 0)
                Update(this, new IdEventArgs {Id = id});
            else
                Create(this, e);
        }
    }
}