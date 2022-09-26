using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Category.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }

        protected Category()
        {
            
        }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
