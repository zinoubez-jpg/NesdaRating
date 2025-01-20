using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class InformationBase : IEntity<int>
    {
        public InformationBase()
        {
            this.DetailsActiviteMois = new HashSet<DetailActiviteMois>();
        }

        public int Id { get; set; }
        public decimal CoutProjet { get; set; }
        public decimal FondsRoulement { get; set; }
        public bool SoumisImposition { get; set; }
        public bool ExonerationTVA { get; set; }
        public int DelaiClient { get; set; }
        public int DelaiFournisseur { get; set; }
        public int DelaiPrestataire { get; set; }
        
        [NotMapped]
        public string CoutProjetString { get; set; }
        [NotMapped]
        public string FondsRoulementString { get; set; }

        public int BusinessPlanId { get; set; }
        public int TauxTVAId { get; set; }
        public int CategorieId { get; set; }
        public int CommuneBPId { get; set; }
        public int TypeFinancementId { get; set; }
        public int FormeJuridiqueId { get; set; }
        public int RegimeImpositionId { get; set; }
        public int TypeActiviteId { get; set; }

        [ForeignKey("BusinessPlanId")]
        public virtual BusinessPlan BusinessPlan { get; set; }
        public virtual TauxTVA TauxTVA { get; set; }
        public virtual Categorie Categorie { get; set; }
        public virtual CommuneBP CommuneBP { get; set; }
        public virtual TypeFinancement TypeFinancement { get; set; }
        public virtual FormeJuridique FormeJuridique { get; set; }
        public virtual RegimeImposition RegimeImposition { get; set; }
        public virtual TypeActivite TypeActivite { get; set; }

        public virtual ICollection<DetailActiviteMois> DetailsActiviteMois { get; set; }

    }
}