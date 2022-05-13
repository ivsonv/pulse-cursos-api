namespace Admin.Domain.Models.DTO.Auth
{
    public static class Permission
    {
        public static List<Item> GetPermissions()
        {
            var _retorno = new List<Item>();
            _retorno.AddRange(WebSiteUser.permissions);
            _retorno.AddRange(WebSiteCategory.permissions);
            _retorno.AddRange(WebSiteGroupPermission.permissions);
            _retorno.AddRange(WebSiteCarousel.permissions);
            _retorno.AddRange(Partner.permissions);
            _retorno.AddRange(PartnerProducts.permissions);
            _retorno.AddRange(Customer.permissions);
            _retorno.AddRange(CustomerFavorite.permissions);
            _retorno.AddRange(CustomerReview.permissions);
            _retorno.AddRange(WebSiteContractor.permissions);
            _retorno.AddRange(WebSiteFAQ.permissions);
            return _retorno;
        }

        public static class Account
        {
            public const string Partners = "account.partners";
            public const string Customer = "account.customers";
        }

        public static class WebSiteFAQ
        {
            public const string View = "ws.faq.view";
            public const string Create = "ws.faq.create";
            public const string Edit = "ws.faq.edit";
            public const string Delete = "ws.faq.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar FAQ", value = View },
                        new Item() {label = "Criar FAQ", value = Create },
                        new Item() {label = "Editar FAQ", value = Edit },
                        new Item() {label = "Excluir FAQ", value = Delete }
                    };
                }
            }
        }

        public static class CustomerReview
        {
            public const string View = "customer.review.view";
            public const string Create = "customer.review.create";
            public const string Edit = "customer.review.edit";
            public const string Delete = "customer.review.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Clientes Reviews", value = View },
                        new Item() {label = "Criar Clientes Reviews", value = Create },
                        new Item() {label = "Editar Clientes Reviews", value = Edit },
                        new Item() {label = "Excluir Clientes Reviews", value = Delete }
                    };
                }
            }
        }
        public static class CustomerFavorite
        {
            public const string View = "customer.favorite.view";
            public const string Create = "customer.favorite.create";
            public const string Edit = "customer.favorite.edit";
            public const string Delete = "customer.favorite.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Clientes Favoritos", value = View },
                        new Item() {label = "Criar Clientes Favoritos", value = Create },
                        new Item() {label = "Editar Clientes Favoritos", value = Edit },
                        new Item() {label = "Excluir Clientes Favoritos", value = Delete }
                    };
                }
            }
        }
        public static class Customer
        {
            public const string View = "customer.view";
            public const string Create = "customer.create";
            public const string Edit = "customer.edit";
            public const string Delete = "customer.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Clientes", value = View },
                        new Item() {label = "Criar Clientes", value = Create },
                        new Item() {label = "Editar Clientes", value = Edit },
                        new Item() {label = "Excluir Clientes", value = Delete }
                    };
                }
            }
        }

        public static class PartnerProducts
        {
            public const string View = "partner.view";
            public const string Create = "partner.create";
            public const string Edit = "partner.edit";
            public const string Delete = "partner.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Vendedors", value = View },
                        new Item() {label = "Criar Vendedor", value = Create },
                        new Item() {label = "Editar Vendedor", value = Edit },
                        new Item() {label = "Excluir Vendedor", value = Delete }
                    };
                }
            }
        }

        public static class Partner
        {
            public const string View = "partner.view";
            public const string Create = "partner.create";
            public const string Edit = "partner.edit";
            public const string Delete = "partner.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Parceiro", value = View },
                        new Item() {label = "Criar Parceiro", value = Create },
                        new Item() {label = "Editar Parceiro", value = Edit },
                        new Item() {label = "Excluir Parceiro", value = Delete }
                    };
                }
            }
        }

        public static class WebSiteContractor
        {
            public const string View = "ws.contractor.view";
            public const string Create = "ws.contractor.create";
            public const string Edit = "ws.contractor.edit";
            public const string Delete = "ws.contractor.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Contratante", value = View },
                        new Item() {label = "Criar Contratante", value = Create },
                        new Item() {label = "Editar Contratante", value = Edit },
                        new Item() {label = "Excluir Contratante", value = Delete }
                    };
                }
            }
        }


        public static class WebSiteCarousel
        {
            public const string View = "ws.carousel.view";
            public const string Create = "ws.carousel.create";
            public const string Edit = "ws.carousel.edit";
            public const string Delete = "ws.carousel.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Carrossel", value = View },
                        new Item() {label = "Criar Carrossel", value = Create },
                        new Item() {label = "Editar Carrossel", value = Edit },
                        new Item() {label = "Excluir Carrossel", value = Delete }
                    };
                }
            }
        }
        public static class WebSiteGroupPermission
        {
            public const string View = "ws.group.view";
            public const string Create = "ws.group.create";
            public const string Edit = "ws.group.edit";
            public const string Delete = "ws.group.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Grupo de permissão", value = View },
                        new Item() {label = "Criar Grupo de permissão", value = Create },
                        new Item() {label = "Editar Grupo de permissão", value = Edit },
                        new Item() {label = "Excluir Grupo de permissão", value = Delete }
                    };
                }
            }
        }
        public static class WebSiteCategory
        {
            public const string View = "ws.categ.view";
            public const string Create = "ws.categ.create";
            public const string Edit = "ws.categ.edit";
            public const string Delete = "ws.categ.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Categorias", value = View },
                        new Item() {label = "Criar Categorias", value = Create },
                        new Item() {label = "Editar Categorias", value = Edit },
                        new Item() {label = "Excluir Categorias", value = Delete }
                    };
                }
            }
        }
        public static class WebSiteUser
        {
            public const string View = "ws.user.view";
            public const string Create = "ws.user.create";
            public const string Edit = "ws.user.edit";
            public const string Delete = "ws.user.delete";

            public static List<Item> permissions
            {
                get
                {
                    return new List<Item>()
                    {
                        new Item() {label = "Visualizar Usuários", value = View },
                        new Item() {label = "Criar Usuários", value = Create },
                        new Item() {label = "Editar Usuários", value = Edit },
                        new Item() {label = "Excluir Usuários", value = Delete }
                    };
                }
            }
        }
    }
}