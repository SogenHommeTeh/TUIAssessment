using System.Collections.Generic;
using System.Linq;
using TUI.Data.Common.Options;

namespace TUI.Data.Common.DTOs
{
    public abstract class DTO<TDTO, TModel> where TDTO : DTO<TDTO, TModel>, new()
    {
        public static TDTO CreateDTO(TModel model)
        {
            var dto = new TDTO();
            if (model != null)
                dto.AssignFromModel(model);
            return dto;
        }

        public abstract void AssignFromModel(TModel model);

        public static IEnumerable<TDTO> CreateDTOs(IEnumerable<TModel> models)
        {
            return models?.Select(CreateDTO) ?? new List<TDTO>();
        }

        public static PaginatedDTO CreatePaginatedDTOs(PaginationOptions options, IEnumerable<TModel> models)
        {
            return new PaginatedDTO(options, models);
        }

        public class PaginatedDTO
        {
            public int PageNumber { get; set; }

            public int PageSize { get; set; }

            public IEnumerable<TDTO> Data { get; set; }

            public PaginatedDTO(PaginationOptions options, IEnumerable<TModel> models)
            {
                PageNumber = options.PageNumber;
                PageSize = options.PageSize;
                Data = CreateDTOs(models);
            }
        }
    }
}
