using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface ITransactionTypeService
    {
        public Task<IEnumerable<TransactionTypeDTO>> GetAllTransactionTypeDTOs();
        public Task<TransactionTypeDTO> GetTransactionTypeDTO(int Id);


    }
}
