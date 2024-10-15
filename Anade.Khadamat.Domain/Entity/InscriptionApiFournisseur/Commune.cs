using Anade.Domain.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class Commune : IEntity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commune()
        {
            this.Fournisseur = new HashSet<Fournisseur>();
        }

        [Key]
        [Column("Id_Commune")]
        public int Id { get; set; }
        public string Code_Commune { get; set; }
        public string Nom_Commune { get; set; }
        public int Id_Wilaya { get; set; }

        public virtual Wilaya Wilaya { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fournisseur> Fournisseur { get; set; }
    }
}