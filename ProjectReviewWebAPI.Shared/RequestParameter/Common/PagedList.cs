﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.RequestParameter.Common
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData()
            {
                TotalCount = count,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }
    }
}
