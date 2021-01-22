using System;

namespace PrasadCodeFirst.Services.Models
{
    public abstract class BaseRequest<TIdT> : IAuditable
    {
        protected BaseRequest()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        public TIdT Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        protected int GetFinalRate(int cost, int discount)
        {
            if (discount == 0)
            {
                return cost;
            }
            var markdown = Math.Round(cost*(discount/100m), 2, MidpointRounding.ToEven);
            var discountedPrice = cost - markdown;

            return (int) discountedPrice;
        }
    }
}