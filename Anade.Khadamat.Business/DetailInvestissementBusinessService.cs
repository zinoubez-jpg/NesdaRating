using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class DetailInvestissementBusinessService : GenericBusinessService<DetailInvestissement, int>
    {

        //private readonly AcquisitionBusinessService _acquisitionService;

        public DetailInvestissementBusinessService(IUnitOfWork unitOfWork/*, AcquisitionBusinessService acquisitionService*/) : base(unitOfWork)
        {
            //  _acquisitionService = acquisitionService;
        }

        public override Expression<Func<DetailInvestissement, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<DetailInvestissement, object>> loadAcquisitions = x => x.Acquisitions;

            return new Expression<Func<DetailInvestissement, object>>[] { loadAcquisitions };
            //Expression<Func<DetailInvestissement, object>> loadAcquisitions = x => x.Acquisitions;
            //Expression<Func<DetailInvestissement, object>> loadAcquisitionsWithAnnee = x => x.Acquisitions.Select(a => a.Annee);

            //return new Expression<Func<DetailInvestissement, object>>[] { loadAcquisitions, loadAcquisitionsWithAnnee };
        }




        //public int Count_AnneeId(int detailInvestissementId)
        //{
        //    int countAnneeIds = 0;

        //    // Récupérez les acquisitions en utilisant AcquisitionBusinessService
        //    var acquisitions = _acquisitionService.GetAllFiltered(a => a.DetailInvestissementId == detailInvestissementId);

        //    if (acquisitions != null)
        //    {
        //        foreach (var item in acquisitions)
        //        {
        //            // Annee devrait déjà être chargée grâce à AcquisitionBusinessService
        //            countAnneeIds += item.Annee.Id;
        //        }
        //    }

        //    return countAnneeIds;
        //}



        //public int Count_AnneeId(int detailInvestissementId)
        //{
        //    int countAnneeIds = 0;

        //    // Récupérez le DetailInvestissement avec les Acquisitions et Annee chargées
        //    var detailInvestissement = _repository.GetById(detailInvestissementId);

        //    if (detailInvestissement != null)
        //    {
        //        foreach (var item in detailInvestissement.Acquisitions)
        //        {
        //            // Annee est déjà chargée
        //            countAnneeIds += item.Annee.Id;
        //        }
        //    }

        //    return countAnneeIds;
        //}










    }
}
