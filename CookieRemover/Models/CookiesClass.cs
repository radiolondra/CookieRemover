using BlazorStrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieExtension.Models
{
    public class CookiesClass
    {        

        public IList<CookieItem> data { get; set; }
        public string _customFilter { get; set; } = string.Empty;
        public BSDataTable<CookieItem> _customFilterRef { get; set; }
        public int _startPage { get; set; } = 1;
        public int _count { get; set; } = 0;
        public IEnumerable<CookieItem> _cookies { get; set; }
        public int ItemsPerPage { get; set; } = 20;

        public string content { get; set; } = string.Empty;
        public string selected { get; set; } = string.Empty;

        public CookiesClass(int IPP, int SP)
        {
            ItemsPerPage = IPP;
            _startPage = SP;

            data = new List<CookieItem>();
            _customFilterRef = new BSDataTable<CookieItem>();
            _cookies = new List<CookieItem>();
        }

        /// <summary>
        /// OnChange event for the BS table
        /// </summary>
        /// <param name="dataRequest"></param>
        public void OnChange(DataRequest dataRequest)
        {
            //Console.WriteLine(dataRequest.Descending);
            _count = data.Count();

            if (dataRequest.FilterColumnProperty != null && dataRequest.Filter != null)
            {
                _cookies = data.Where(q =>
                    q.CookieDomain.ToLower().Contains(dataRequest.Filter) && nameof(q.CookieDomain) == dataRequest.FilterColumn
                    ).ToList();
                _count = _cookies.Count();
            }
            else if (dataRequest.SortColumnProperty != null)
            {
                if (dataRequest.Descending)
                    _cookies = data.OrderByDescending(x => dataRequest.SortColumnProperty.GetValue(x)).Skip(dataRequest.Page * ItemsPerPage).Take(ItemsPerPage);
                else
                    _cookies = data.OrderBy(x => dataRequest.SortColumnProperty.GetValue(x)).Skip(dataRequest.Page * ItemsPerPage).Take(ItemsPerPage);
            }
            else

            {
                _cookies = data.Skip(dataRequest.Page * ItemsPerPage).Take(ItemsPerPage);
            }
        }
        public void CustomFilter(string e)
        {
            _customFilter = e;
            _customFilterRef.Page = 1;
            if (!string.IsNullOrEmpty(_customFilter))
            {
                _cookies = data.Where(q => q.CookieDomain.ToLower().Contains(_customFilter.ToLower()) ).ToList();
                _count = _cookies.Count();
                selected = $"Selected: {_count}";
            }
            else
            {
                _cookies = data.Take(ItemsPerPage);
                _count = _cookies.Count();
                selected = "";
            }

            
            
        }

        /// <summary>
        /// Resets the cookies grid
        /// </summary>
        /// <returns></returns>
        public async Task ClearGrid()
        {
            data.Clear();
            _count = 0;
            CustomFilter("");            
            content = string.Empty;
            selected = string.Empty;
            await _customFilterRef.Refresh();
        }
    }
}
