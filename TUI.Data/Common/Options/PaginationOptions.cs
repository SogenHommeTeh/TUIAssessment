using System.ComponentModel.DataAnnotations;

namespace TUI.Data.Common.Options
{
    public class PaginationOptions
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        [Range(1, 200)]
        public int PageSize { get; set; }

        public PaginationOptions()
        {
            PageNumber = 1;
            PageSize = 5;
        }
    }
}
