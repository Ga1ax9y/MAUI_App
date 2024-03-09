using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stanishewski253505.Entities;

namespace Stanishewski253505.Services
{
    public interface IRateService
    {
        IEnumerable<Rate> GetRates(DateTime date);//IEnumerable<Rate>
    }
}
