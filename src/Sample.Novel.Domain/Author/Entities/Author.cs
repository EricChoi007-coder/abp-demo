using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Author.Entities
{
    public class Author : Entity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        protected Author()
        {
            
        }

        public Author(Guid id, string name, string description = null)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
        }
    }
}
