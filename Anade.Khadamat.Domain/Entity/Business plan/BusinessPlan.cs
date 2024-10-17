using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class BusinessPlan : IEntity<int>
    {
        public BusinessPlan()
        {
            this.ComptesResultatPrevisionnel = new HashSet<CompteResultatPrevisionnel>();
            this.TableauxFluxTresorerie = new HashSet<TableauFluxTresorerie>();
            this.PlansTresorerieMensuel = new HashSet<PlanTresorerieMensuel>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public System.DateTime? Date_Generation { get; set; }
        public bool Complet { get; set; }
        public string Utilisateur { get; set; }

        public int ProjetId { get; set; }

        public virtual Projet Projet { get; set; }
        public virtual StuctureInvestissement StuctureInvestissement { get; set; }
        public virtual StructureFinancement StructureFinancement { get; set; }
        public virtual ICollection<CompteResultatPrevisionnel> ComptesResultatPrevisionnel { get; set; }
        public virtual ICollection<TableauFluxTresorerie> TableauxFluxTresorerie { get; set; }
        public virtual ICollection<PlanTresorerieMensuel> PlansTresorerieMensuel { get; set; }
        public virtual EvaluationProjet EvaluationProjet { get; set; }
    }
}
