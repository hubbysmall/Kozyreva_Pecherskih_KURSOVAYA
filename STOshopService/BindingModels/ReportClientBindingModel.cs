using System;

namespace STOshopService.BindingModels
{
    public class ReportClientBindingModel
    {
        public string FileName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
