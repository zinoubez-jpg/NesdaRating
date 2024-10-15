using Anade.Domain.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class Pays : IEntity<int>
    {
        public Pays()
        {
            this.Fournisseur = new HashSet<Fournisseur>();
        }

        [Key]
        [Column("Id_Pays")]
        public int Id { get; set; }
        public string NOM_PAYS { get; set; }
        public string INDICATIF_PAYS { get; set; }
        public string Ext_Domaine { get; set; }
        public virtual ICollection<Fournisseur> Fournisseur { get; set; }
    }
}