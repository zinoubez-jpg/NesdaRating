using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public class FicheNotation : IEntity<int>
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public System.DateTime? Date { get; set; }

        [ForeignKey("PromoteurId")]
        [Required(ErrorMessage = "RequiredMessage")]
        [Display(Name = "N° Dossier ")]
        public string PromoteurId { get; set; }
        public string NOM_P { get; set; }
        public string PRENOM_P { get; set; }
        public DateTime? DDN_P { get; set; }
        public string RAISON_SOCIALE { get; set; }
        public DateTime? DATE_DEPOT { get; set; }
        public string Activite { get; set; }
        public string NomAnnexe { get; set; }
        public string NomAntenne { get; set; }



        [ForeignKey("NiveauFormationId")]
        public int NiveauFormationId { get; set; }
        [ForeignKey("ContributionFinanciereId")]
        public int ContributionFinanciereId { get; set; }
        [ForeignKey("ConcorrdenceId")]
        public int ConcorrdenceId { get; set; }
        public int CapaciteDefendreProjet { get; set; }
        public int Marche { get; set; }
        public int Concurrents { get; set; }
        public bool EtudeTechnicoEconomique { get; set; }
        public int CreationEmploi { get; set; }
        public bool ProduitTemoin { get; set; }
        public string Analyste { get; set; }
        public string appreciation { get; set; }
        public int NoteNiveauFormation { get; set; }
        public int NoteExperienceprofessionnelle { get; set; }
        public int NoteConcordance { get; set; }
        public int NoteContributionFinanciere { get; set; }
        public int NoteClients { get; set; }
        public int NoteMarketing { get; set; }
        public int NotePricing { get; set; }
        public int NoteEtudeTechnicoEconomique { get; set; }
        public int NoteVan { get; set; }
        public int NoteDr { get; set; }
        public int NoteProduitTemoin { get; set; }
        public string Deliberation { get; set; }




        public int ScorePorteurProjet { get; set; }
        public int ScoreEtudeMarche { get; set; }
        public int ScoreBusinessPlan { get; set; }
        public int ScoreSousTotal { get; set; }
        public int ScoreTotal { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        [ForeignKey("MarketingId")]
        public int MarketingId { get; set; }
        [ForeignKey("PricingId")]
        public int PricingId { get; set; }
        [ForeignKey("VanId")]
        public int VanId { get; set; }
        [ForeignKey("DrId")]
        public int DrId { get; set; }
        [ForeignKey("ExperienceProfessionnelId")]
        public int ExperienceProfessionnelId { get; set; }
        [Display(Name = "Annexe")]
        [Required(ErrorMessage = "Ce champs est requis")]
        public int AnnexeId { get; set; }
        public virtual Annexe Annexe { get; set; }
        public virtual NiveauFormation NiveauFormation { get; set; }
        public virtual ExperienceProfessionnel ExperienceProfessionnel { get; set; }
        public virtual Van Van { get; set; }
        public virtual Dr Dr { get; set; }
        public virtual Pricing Pricing { get; set; }
        public virtual Marketing Marketing { get; set; }
        public virtual ContributionFinanciere ContributionFinanciere { get; set; }
        public virtual Concorrdence Concorrdence { get; set; }
        public virtual Client Client { get; set; }

    }
}
