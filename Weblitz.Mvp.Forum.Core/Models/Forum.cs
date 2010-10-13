using System;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public class Forum : IForum
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}