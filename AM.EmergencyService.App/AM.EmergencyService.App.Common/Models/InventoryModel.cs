using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Common.Models
{
    public class InventoryModel
    {

        public int Id { get; set; }
        public int InventoryNumber { get; set; }
        public string InventoryName { get; set; }
        public int IdBrigade { get; set; }


    }
}
