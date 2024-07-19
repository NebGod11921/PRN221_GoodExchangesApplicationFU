using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.TransactionDTOs
{
    public class PagingTransaction<T>
    {
        public List<T> Transactions { get; set; } = new List<T>();
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
