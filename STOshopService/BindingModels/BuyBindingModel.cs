namespace STOshopService.BindingModels
{
    public class BuyBindingModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ServeId { get; set; }

        public int? ExecutorId { get; set; }

        public int Count { get; set; }

        public int Sum { get; set; }
    }
}
