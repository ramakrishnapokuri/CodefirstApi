using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrasadCodeFirst.Data.Models
{
    [Serializable]
    public abstract class EntityBase<TId> : IAuditable
    {
        protected EntityBase()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        [Column(Order = 1)]
        public virtual TId Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}