using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_DEV_JRL_20210731.DataAccess.Dto.Input
{
    public class Paginate
    {
        public int? CountPerPage { get; set; }
        public int? Page { get; set; }
    }
}
