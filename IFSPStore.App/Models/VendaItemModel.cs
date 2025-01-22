using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IFSPStore.App.Models
{
    public class VendaItemModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public float ValorTotal { get; set; }
        public float ValorUnitario { get; set; }
        public string Produto { get; set; }
        [JsonIgnore]
        public string Venda { get; set; }
    }
}