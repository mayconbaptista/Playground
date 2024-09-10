
namespace Efcore.Entities
{
    public sealed class OrderEntity : BaseEntity
    {
        public uint CustomerId { get; set; }
        public Status Status { get; set; }
        public DateTime Pucherse { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? Delivered { get; set; }
        public DateTime? EstimatedDelivery { get; set; }

        public OrderEntity? Customer { get; set; }
        public IEnumerable<PaymentEntity>? Payments { get; set; }

        public OrderEntity(uint customerId)
        {
            var validator = new ValidationDomain();
            validator.when(customerId == 0, "O id do cliente deve ser um valor válido.");
            validator.Execute();

            Pucherse = DateTime.UtcNow;
            Status = Status.PENDENTE;
            ApprovedAt = null;
            Delivered = null;
            EstimatedDelivery = null;
            CustomerId = customerId;
        }

        public void UpdateStatus(Status status, DateTime? estimated = null)
        {
            var validation = new ValidationDomain();
            validation.when(this.Status <= status, 
                $"O pedido não pode retroceder do estatus de {this.Status.ToString()} para {status.ToString()}.");
            validation.when(status == Status.APROVADO && (!estimated.HasValue || estimated == default), 
                "O tempo estimado de entrega dever ser uma valor válido.");

            validation.Execute();


            if (Status == Status.APROVADO)
            {
                Status = status;
                this.ApprovedAt = DateTime.UtcNow;
                this.EstimatedDelivery = estimated;
            }else if(Status == Status.ENTREGUE)
            {
                Status = status;
                this.Delivered = DateTime.UtcNow;
            }
            else
            {
                this.Status = status;
            }
        }

    }
}
