using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.App.Models
{
    public class VendaModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
        public string Usuario { get; set; }
        public string Cliente { get; set; }
        public string Items { get; set; }
    }
}
