using STOshopService.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IBackupService
    {
        void SaveJSON(BackupBindingModel model);
    }
}
