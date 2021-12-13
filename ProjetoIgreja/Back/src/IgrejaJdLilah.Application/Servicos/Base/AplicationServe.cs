

using IgrejaJdLilah.Application.Infra;

namespace IgrejaJdLilah.Application.Servicos.Base
{
     public abstract class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected void BeginTran()
        {
            _unitOfWork.BeginTrasaction();
        }

        protected void Commit()
        {
            _unitOfWork.Commit();
        }

        protected void RollBack()
        {
            _unitOfWork.Rollback();
        }
    }
}