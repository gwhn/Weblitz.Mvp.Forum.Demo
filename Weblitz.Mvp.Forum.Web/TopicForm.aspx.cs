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
    public partial class TopicForm : System.Web.UI.Page, ITopicFormView
    {
        public event EventHandler Create;

        public ITopicInput Topic
        {
            get
            {
                return new TopicInput
                           {
                               Title = TitleTextBox.Text, 
                               Body = BodyTextBox.Text,
                               Sticky = StickyCheckBox.Checked
                           };
            }
            set 
            { 
                TitleTextBox.Text = value.Title;
                BodyTextBox.Text = value.Body;
                StickyCheckBox.Checked = value.Sticky;
                SubmitButton.CommandArgument = value.Id.ToString();
            }
        }

        public int CurrentId
        {
            get { return Request["Id"].ToId(); }
        }

        public int ParentId
        {
            get { return Request["ForumId"].ToId(); }
        }

        public void GoToShowTopic(int id)
        {
            Response.Redirect(string.Format("~/ShowTopic.aspx?Id={0}", id));
        }

        public event EventHandler<IdEventArgs> Update;

        protected void Page_Init(object sender, EventArgs e)
        {
            new TopicFormPresenter(this, new TopicProvider());
        }

        protected void SubmitButton_OnCommand(object sender, CommandEventArgs e)
        {
            var id = e.CommandArgument.ToString().ToId();
            if (id > 0)
                Update(this, new IdEventArgs { Id = id });
            else
                Create(this, e);
        }

    }
}