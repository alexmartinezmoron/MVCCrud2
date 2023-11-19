using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCrud2.Models
{
    public class DatatableOptions
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public int OrderColumn { get; set; }
        public string OrderDir { get; set; }
        public Dictionary<int, string> ColumnSearch { get; set; }

        public DatatableOptions(HttpContext httpContext)
        {
            int draw = System.Int32.Parse(httpContext.Request.Query["draw"].ToString());
            string searchValue = httpContext.Request.Query["search[value]"].ToString();
            if (string.IsNullOrEmpty(searchValue)) searchValue = "";
            int start = Int32.Parse(httpContext.Request.Query["start"].ToString());
            int length = Int32.Parse(httpContext.Request.Query["length"].ToString());

            int orderColum = 0;
            if (!string.IsNullOrEmpty(httpContext.Request.Query["order[0][column]"].ToString()))
            {
                orderColum = Int32.Parse(httpContext.Request.Query["order[0][column]"].ToString());
            }

            string orderDir = httpContext.Request.Query["order[0][dir]"].ToString();

            int index = 0;
            ColumnSearch = new Dictionary<int, string>();
            foreach (var query in httpContext.Request.Query)
            {
                if (query.Key.Contains("columns"))
                {
                    if (query.Key.Contains("[search][value]"))
                    {
                        var value = query.Value;
                        if (string.IsNullOrEmpty(value))
                        {
                            ColumnSearch.Add(index, "");
                        }
                        else
                        {
                            ColumnSearch.Add(index, value.ToString());
                        }
                        index++;
                    }
                }
            }


            Draw = draw;
            Start = start;
            Length = length;
            SearchValue = searchValue;
            OrderColumn = orderColum;
            OrderDir = orderDir;
        }
    }
}
