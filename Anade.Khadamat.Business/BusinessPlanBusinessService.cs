using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class BusinessPlanBusinessService : GenericBusinessService<BusinessPlan, int>
    {
        public BusinessPlanBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override Expression<Func<BusinessPlan, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<BusinessPlan, object>> loadEtape = x => x.Etape;
            Expression<Func<BusinessPlan, object>> loadInformationBase = x => x.InformationBase;
            Expression<Func<BusinessPlan, object>> loadStuctureInvestissement = x => x.StuctureInvestissement;
            Expression<Func<BusinessPlan, object>> loadStructureFinancement = x => x.StructureFinancement;
            Expression<Func<BusinessPlan, object>> loadEvaluationProjet = x => x.EvaluationProjet;
            Expression<Func<BusinessPlan, object>> loadWilaya = x => x.InformationBase.CommuneBP.WilayaBP;

            return new Expression<Func<BusinessPlan, object>>[] { loadEtape, loadInformationBase, loadStuctureInvestissement, loadStructureFinancement, loadEvaluationProjet, loadWilaya };
        }

        public string GenererNumero(string codeStructure, int numSequ)
        {
            var numeroSequentiel = numSequ + 1;

            // Generate the sequential number string with leading zeros
            return $"{codeStructure}{numeroSequentiel:D5}";
        }

    }
}
