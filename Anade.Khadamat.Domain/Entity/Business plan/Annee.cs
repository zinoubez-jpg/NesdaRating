using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class Annee : IEntity<int>
    {
        public Annee()
        {
            this.ComptesResultatPrevisionnel = new HashSet<CompteResultatPrevisionnel>();
            this.TableauxFluxTresorerie = new HashSet<TableauFluxTresorerie>();
            this.DetailsEvaluationProjet = new HashSet<DetailEvaluationProjet>();
            this.Mois = new HashSet<Mois>();
        }

        public int Id { get; set; }
        public string Numero { get; set; }

        public int AcquisitionId { get; set; }
        public int DetailChiffreAffaireId { get; set; }
        public int DetailAchatsDirectsId { get; set; }
        public int DetailChargesExternesId { get; set; }

        public virtual Acquisition Acquisition { get; set; }
        public virtual DetailChiffreAffaire DetailChiffreAffaire { get; set; }
        public virtual DetailAchatsDirects DetailAchatsDirects { get; set; }
        public virtual DetailChargesExternes DetailChargesExternes { get; set; }

        public virtual ICollection<CompteResultatPrevisionnel> ComptesResultatPrevisionnel { get; set; }
        public virtual ICollection<TableauFluxTresorerie> TableauxFluxTresorerie { get; set; }
        public virtual ICollection<DetailEvaluationProjet> DetailsEvaluationProjet { get; set; }
        public virtual ICollection<Mois> Mois { get; set; }

    }
}
