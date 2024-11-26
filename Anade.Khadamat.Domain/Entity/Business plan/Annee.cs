using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class Annee : Referentiel
    {
        public Annee()
        {
            this.ComptesResultatPrevisionnel = new HashSet<CompteResultatPrevisionnel>();
            this.TableauxFluxTresorerie = new HashSet<TableauFluxTresorerie>();
            this.DetailsEvaluationProjet = new HashSet<DetailEvaluationProjet>();
            this.Mois = new HashSet<Mois>();
            this.DetailsPoste = new HashSet<DetailPoste>();
        }

        public virtual ICollection<CompteResultatPrevisionnel> ComptesResultatPrevisionnel { get; set; }
        public virtual ICollection<TableauFluxTresorerie> TableauxFluxTresorerie { get; set; }
        public virtual ICollection<DetailEvaluationProjet> DetailsEvaluationProjet { get; set; }
        public virtual ICollection<Mois> Mois { get; set; }
        public virtual ICollection<DetailPoste> DetailsPoste { get; set; }
    }
}
