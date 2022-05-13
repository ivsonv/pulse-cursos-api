using Admin.Domain.Entities;
using Admin.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Admin.Infra.Extensions
{
    public static class ContextExtensions
    {
        public static void AutoMapperContextWebSite(this ModelBuilder model)
        {
            model.Entity<WebSiteGroupPermission>(new WebSiteGroupPermissionMap().Configure);
            model.Entity<WebSiteGroupPermissionAttached>(new GroupPermissionAttachedMap().Configure);
            model.Entity<WebSiteUser>(new WebSiteUserMap().Configure);
            model.Entity<WebSiteUserGroupPermission>(new UserGroupPermissionMap().Configure);
            model.Entity<WebSiteCategory>(new WebSiteCategoryMap().Configure);
            model.Entity<WebSiteCarousel>(new WebSiteCarouselMap().Configure);
        }

        public static void AutoMapperContextCustomer(this ModelBuilder model)
        {
            //model.Entity<Customer>(new CustomerMap().Configure);
            //model.Entity<CustomerAddress>(new CustomerAddressMap().Configure);
            //model.Entity<CustomerFavorite>(new CustomerFavoriteMap().Configure);
            //model.Entity<CustomerReview>(new CustomerReviewMap().Configure);
            //model.Entity<CustomerAddressDelivery>(new CustomerAddressDeliveryMap().Configure);
        }

        public static void AutoMapperContextSalesOrders(this ModelBuilder model)
        {
            //model.Entity<Order>(new OrderMap().Configure);
            //model.Entity<OrderPayment>(new OrderPaymentMap().Configure);
            //model.Entity<OrderProduct>(new OrderProductMap().Configure);
        }
    }
}