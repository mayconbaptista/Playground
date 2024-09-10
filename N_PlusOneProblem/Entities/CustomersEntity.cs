using N_PlusOneProblem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_PlusOneProblem.Entities
{
    public sealed class CustomersEntity : BaseEntity
    {
        public Status Status { get; init; }
        public DateTime Pucherse { get; init; }
        public DateTime? ApprovedAt { get; init; }
        public DateTime? Delivered { get; init; }
        public DateTime? EstimatedDelivery { get; init; }

        CustomersEntity(
            DateTime? aprovedAt = null, 
            DateTime? delivered = null, 
            DateTime? estimatedDelivery = null)
        {
            Pucherse = DateTime.UtcNow;
            Status = Status.PENDENTE;
            ApprovedAt = aprovedAt;
            Delivered = delivered;
            EstimatedDelivery = estimatedDelivery;
        }
    }
}
