using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ProductDTOs
{
    public class ResponseProductDTO:BaseEntity
    {
        public int TotalPage { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public object[] List { get; set; } = new object[] { };

    }
}
