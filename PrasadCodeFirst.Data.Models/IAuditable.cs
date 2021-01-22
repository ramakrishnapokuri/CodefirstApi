using System;

namespace PrasadCodeFirst.Data.Models
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }

        string ModifiedBy { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}