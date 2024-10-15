using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Resources;

namespace Anade.Khadamat.Business
{
    public class NesdaProjectBusinessService : GenericBusinessService<PROMOTEUR, string>
    {
        private readonly IRepository<FicheNotation, int> _ficheNotationRepository;
        private readonly ResourceManager _resourceManager;

        public NesdaProjectBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _ficheNotationRepository = unitOfWork.GetRepository<FicheNotation, int>();
            _resourceManager = new ResourceManager("Anade.Khadamat.Business.Resources.BusinessMessage", this.GetType().Assembly);
        }


        #region ficheNotation
        public BusinessResult AddFiche(FicheNotation fiche)
        {
            BusinessResult businessResult;

            try
            {
                OnAddingFiche(fiche);

                _ficheNotationRepository.Add(fiche);

                if (_unitOfWork.SaveChanges() == 0)
                    throw new DataNotUpdatedException(_resourceManager.GetString("OperationFailed"));

                businessResult = BusinessResult.Success;
            }
            catch (DataNotUpdatedException ex)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = ex.Message, MessageType = MessageType.Warning });
            }
            catch (BusinessException ex)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = ex.Message, MessageType = MessageType.Warning });
            }
            catch (Exception)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = _resourceManager.GetString("GenericError"), MessageType = MessageType.Warning });
            }

            return businessResult;
        }

        public BusinessResult UpdateFiche(FicheNotation fiche)
        {
            BusinessResult businessResult;

            try
            {
                OnUpdatingFacture(fiche);
                _ficheNotationRepository.Update(fiche);

                if (_unitOfWork.SaveChanges() == 0)
                    throw new DataNotUpdatedException(_resourceManager.GetString("OperationFailed"));

                businessResult = BusinessResult.Success;
            }
            catch (DataNotUpdatedException ex)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = ex.Message, MessageType = MessageType.Warning });
            }
            catch (BusinessException ex)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = ex.Message, MessageType = MessageType.Warning });
            }
            catch (Exception)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = _resourceManager.GetString("GenericError"), MessageType = MessageType.Warning });
            }

            return businessResult;
        }


        public BusinessResult DeleteFiche(int id)
        {
            BusinessResult businessResult;

            try
            {
                _ficheNotationRepository.Delete(new FicheNotation { Id = id });

                if (_unitOfWork.SaveChanges() == 0)
                    throw new DataNotUpdatedException(_resourceManager.GetString("OperationFailed"));

                businessResult = BusinessResult.Success;
            }
            catch (DataNotUpdatedException ex)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = ex.Message, MessageType = MessageType.Warning });
            }
            catch (BusinessException ex)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = ex.Message, MessageType = MessageType.Warning });
            }
            catch (Exception)
            {
                businessResult = new BusinessResult(false);
                businessResult.Messages.Add(new MessageResult { Message = _resourceManager.GetString("GenericError"), MessageType = MessageType.Warning });
            }

            return businessResult;
        }





        private void OnAddingFiche(FicheNotation fiche)
        {
            
            if (_ficheNotationRepository.Count(x => x.PromoteurId == fiche.PromoteurId && x.ScoreTotal >= 42) > 0)
                throw new BusinessException("Le projet a déjà été évalué et admis pour le CSVF.");
        }

        private void OnUpdatingFacture(FicheNotation fiche)
        {
            // ToDo 
        }


        #endregion
    }
}
