﻿using Admin.Domain.Entities;
using Admin.Domain.Interface.Entities.Base;

namespace Admin.Domain.Interface.Entities
{
    public interface IWebSiteCarouselRepository : ICrudRepository<WebSiteCarousel>
    {
        Task<List<WebSiteCarousel>> GetCarousels();
    }
}