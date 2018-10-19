﻿using System.Collections.Generic;
using System.Linq;
using TUI.Data.Common.Utils;

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

        public static PaginatedDTO CreatePaginatedDTOs(PageModel<TModel> model)
        {
            return new PaginatedDTO(model);
        }

        public class PaginatedDTO : DTOs.PaginatedDTO
        {
            public IEnumerable<TDTO> Data { get; set; }

            public PaginatedDTO(PageModel<TModel> model)
            {
                PageNumber = model.PageNumber;
                PageSize = model.PageSize;
                TotalData = model.TotalData;
                TotalPage = model.TotalPage;
                Data = CreateDTOs(model.Data);
            }
        }
    }

    public class PaginatedDTO
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalData { get; set; }

        public int TotalPage { get; set; }
    }
}
