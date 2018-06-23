using STOshopModel;
using STOshopService.BindingModels;
using STOshopService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace STOshopService.realizationDB
{
    public class BackupServiceDB : IBackupService
    {
        private STOshopDBContext context;

        public BackupServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public void SaveJSON(BackupBindingModel model)
        {
            DataContractJsonSerializer formatterClient = new DataContractJsonSerializer(typeof(List<Client>));
            DataContractJsonSerializer formatterBuy = new DataContractJsonSerializer(typeof(List<Buy>));
            DataContractJsonSerializer formatterBuy_Serve = new DataContractJsonSerializer(typeof(List<Buy_Serve>));
            using (FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate))
            {
                formatterClient.WriteObject(fs, context.Clients);
                formatterBuy.WriteObject(fs, context.Buys);
                formatterBuy_Serve.WriteObject(fs, context.Buy_Serves);
            }
        }
    }
}
