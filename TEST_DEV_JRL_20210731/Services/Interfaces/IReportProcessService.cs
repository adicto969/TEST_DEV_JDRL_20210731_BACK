using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Output;

namespace TEST_DEV_JRL_20210731.Services.Interfaces
{
    public interface IReportProcessService
    {
        ReportWithPaginate GetReport(int page, int countPerPage);
    }
}
