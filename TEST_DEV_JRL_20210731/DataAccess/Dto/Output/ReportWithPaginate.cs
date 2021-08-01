using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_DEV_JRL_20210731.DataAccess.Dto.Output
{
    public class ReportWithPaginate
    {
        public int TotalRecord { get; set; }
        public IEnumerable<ItemReport> Data { get; set; }
    }
}
