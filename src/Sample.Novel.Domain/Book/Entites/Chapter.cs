using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entites
{
    public class Chapter : Entity<Guid>, IHasCreationTime
    {
        public Volume Volume { get; set; }
        public Guid VolumeId { get; set; }
        
        public string Title { get; set; }
        public ChapterText ChapterText { get; protected set; }

        public int WordsNumber { get; set; }

        public DateTime CreationTime { get; set; }

        protected Chapter()
        {
            
        }

        public Chapter(string title, string content)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            WordsNumber = content.Length;
            ChapterText = new ChapterText(content);
        }
    }
}
