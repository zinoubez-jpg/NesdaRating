using Anade.Domain.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class Wilaya : IEntity<int>
    {
        public Wilaya()
        {
            this.Commune = new HashSet<Commune>();
        }

        [Key]
        [Column("Id_Wilaya")]
        public int Id { get; set; }
        public string Code_Wilaya { get; set; }
        public string Nom_Wilaya { get; set; }
        public virtual ICollection<Commune> Commune { get; set; }
    }
}