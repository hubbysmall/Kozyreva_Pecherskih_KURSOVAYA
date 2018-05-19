using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.BindingModels
{
    public class AdminBindingModel
    {
        public int Id { get; set; }
        public string AdminMail { get; set; }
        public string AdminPassword { get; set; }
    }
}
