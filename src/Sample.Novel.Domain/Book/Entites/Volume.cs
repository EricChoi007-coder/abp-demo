using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entites
{
    public class Volume : Entity<Guid>, IHasCreationTime
    {
        public Book Book { get; set; }
        public Guid BookId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public List<Chapter> Chapters { get; set; }

        public DateTime CreationTime { get; set; }

        protected Volume()
        {
            
        }

        public Volume(string title, string description = null)
        {
            Title = title;
            Description = description;
            Chapters = new List<Chapter>();
        }

        public void AddChapter(Chapter chapter)
        {
            if (Chapters.Any(v => v.Title == chapter.Title))
            {
                return;
            }

            Chapters.Add(chapter);
        }
    }
}
