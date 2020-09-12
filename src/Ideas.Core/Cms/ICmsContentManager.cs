﻿using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Cms
{
    public interface ICmsContentManager: IDomainService
    {
        Task<CmsContent> GetAsync(int id);

        Task <CmsContent>CreateOrUpdateAsync(CmsContent @page);

        Task<List<CmsContent>> GetAllAsync();
    }
}