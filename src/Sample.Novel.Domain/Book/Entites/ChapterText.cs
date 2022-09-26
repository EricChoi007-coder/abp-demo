using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entites
{
    public class ChapterText : Entity<Guid>
    {
        public string Content { get; set; }
        public string Memo { get; set; }

        protected ChapterText()
        {
            
        }

        public ChapterText(
            string content,string memo = null)
        {
            Content = content;
            Memo = memo;
        }
    }
}
