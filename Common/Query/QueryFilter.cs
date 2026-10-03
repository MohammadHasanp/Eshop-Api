using Common.Application;
using Common.Query.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Query
{
    public class QueryFilter<TReponse,Tparam>:IQuery<TReponse> where TReponse :BasePaginate where Tparam :BaseFilterParam
    {
        public Tparam FilterParams { get; set; }
        public QueryFilter(Tparam filterParams)
        {
            FilterParams = filterParams;
        }
    }
}
