using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class Projet : IEntity<int>
    {
        public Projet()
        {
            this.BusinessPlans = new HashSet<BusinessPlan>();
        }

        public int Id { get; set; }
        public string NumeroSIEJE { get; set; }
        public string RaisonSociale { get; set; }
        public string Categorie { get; set; }
        public string Wilaya { get; set; }
        public string Commune { get; set; }
        public string Activite { get; set; }
        public string FormeJuridique { get; set; }
        public string TypeFinancement { get; set; }

        public virtual ICollection<BusinessPlan> BusinessPlans { get; set; }
    }
}
