using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class FicheNotationBusinessService : GenericBusinessService<FicheNotation, int>
    {
        public FicheNotationBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Expression<Func<FicheNotation, object>>[] GetDefaultLoadProperties()
        {

            Expression<Func<FicheNotation, object>> loadClient = x => x.Client;
            Expression<Func<FicheNotation, object>> loadNiveauFormation = x => x.NiveauFormation;
            Expression<Func<FicheNotation, object>> loadExperienceProfessionnel = x => x.ExperienceProfessionnel;
            Expression<Func<FicheNotation, object>> loadVan = x => x.Van;
            Expression<Func<FicheNotation, object>> loadDr = x => x.Dr;
            Expression<Func<FicheNotation, object>> loadPricing = x => x.Pricing;
            Expression<Func<FicheNotation, object>> loadMarketing = x => x.Marketing;
            Expression<Func<FicheNotation, object>> loadContributionFinanciere = x => x.ContributionFinanciere;


            return new Expression<Func<FicheNotation, object>>[] { loadClient, loadNiveauFormation, loadExperienceProfessionnel,
                                                                   loadExperienceProfessionnel,loadVan,loadDr,loadPricing,loadMarketing,
                                                                   loadContributionFinanciere};
        }

        public string GenererNumero(string codeStructure, int numSequ)
        {

            var numeroSequentiel = numSequ + 1;


            // Generate the sequential number string with leading zeros
            return $"{codeStructure}{numeroSequentiel:D5}";
        }


    }
}
