using Anade.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class Fournisseur : IEntity<int>
    {
        public Fournisseur()
        {
        }

        [Key]
        [Column("Id_Fournisseur")]
        public int Id { get; set; }
        public string NIF { get; set; }
        public string Raison_Sociale { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string NIS { get; set; }
        public string NRC_Fellah_Art { get; set; }
        public bool Gele { get; set; }
        public int Id_Pays { get; set; }
        public int Id_Commune { get; set; }

        [ForeignKey("Id_Commune")]
        public virtual Commune Commune { get; set; }
        [ForeignKey("Id_Pays")]
        public virtual Pays Pays { get; set; }
    }
}
