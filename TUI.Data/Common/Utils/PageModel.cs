using System.Linq;
using TUI.Data.Common.Options;

namespace TUI.Data.Common.Utils
{
    public class PageModel<TModel>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalData { get; set; }

        public int TotalPage { get; set; }

        public IQueryable<TModel> Data { get; set; }

        public PageModel(PaginationOptions options = null, IQueryable<TModel> data = null)
        {
            options = options ?? new PaginationOptions();
            PageNumber = options.PageNumber;
            PageSize = options.PageSize;
            TotalData = data.Count();
            TotalPage = TotalData / PageSize;
            if (TotalData > TotalPage * PageSize) TotalPage++;
            Data = data.GetPage(options);
        }
    }
}
