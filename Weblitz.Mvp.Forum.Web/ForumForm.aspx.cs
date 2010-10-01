using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Presenters;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Web
{
    public partial class ForumForm : System.Web.UI.Page, IForumFormView
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            new ForumFormPresenter(this, new ForumProvider());
        }

        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public IForumInput Forum
        {
            get { return new ForumInput { Name = NameTextBox.Text.Trim() }; }
            set { NameTextBox.Text = value.Name; }
        }
    }
}