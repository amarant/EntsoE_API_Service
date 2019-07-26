using EntsoE_DataAccess.Data;
using EntsoE_DataAccess.Utils;
using EntsoE_DataModel;
using EntsoE_DataModel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace EntsoE_BusinessLogic.Loaders
{
    public class ForecastGenerationLoader : LoaderBase
    {
        public ForecastGenerationLoader(int retryCount, int pollingCount) : base (retryCount, pollingCount)
        {
        }
    }
}
