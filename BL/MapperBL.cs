using AutoMapper;
using DAL.MySqlDbContext;
using Entities;

namespace BL
{
    public class MapperBL : Profile
    {
        public MapperBL()
        {
            CreateMap<AddressDO, Address>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.OrderDeliveryAddresses, opt => opt.MapFrom(src => src.OrderDeliveryAddresses))
                .ForMember(dest => dest.OrderInvoiceAddresses, opt => opt.MapFrom(src => src.OrderInvoiceAddresses))
                .ReverseMap();

            CreateMap<AdminDO, Admin>().ReverseMap();

            CreateMap<BankDO, Bank>()
                .ForMember(dest => dest.BankInstallments, opt => opt.MapFrom(src => src.BankInstallments))
                .ReverseMap();

            CreateMap<BankInstallmentDO, BankInstallment>()
                .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank))
                .ReverseMap();

            CreateMap<BasketDO, Basket>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<BrandDO, Brand>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();

            CreateMap<CategoryDO, Category>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();

            CreateMap<CityDO, City>()
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();


            CreateMap<OrderDO, Order>()
                .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
                .ForMember(dest => dest.InvoiceAddress, opt => opt.MapFrom(src => src.InvoiceAddress))
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Orderitems, opt => opt.MapFrom(src => src.Orderitems))
                .ReverseMap();

            CreateMap<OrderitemDO, Orderitem>()
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<PageDO, Page>()
                .ReverseMap();

            CreateMap<PaymentDO, Payment>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Shipping, opt => opt.MapFrom(src => src.Shipping))
                .ReverseMap();

            CreateMap<ProductDO, Product>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.Baskets, opt => opt.MapFrom(src => src.Baskets))
                .ForMember(dest => dest.Orderitems, opt => opt.MapFrom(src => src.Orderitems))
                .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages))
                .ForMember(dest => dest.Wishlists, opt => opt.MapFrom(src => src.Wishlists))
                .ReverseMap();

            CreateMap<ProductImageDO, ProductImage>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ReverseMap();

            CreateMap<ProvinceDO, Province>()
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities))
                .ReverseMap();

            CreateMap<ResetpasswordDO, Resetpassword>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<SettingDO, Setting>()
                .ReverseMap();

            CreateMap<ShippingDO, Shipping>()
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments))
                .ReverseMap();

            CreateMap<SliderDO, Slider>()
                .ReverseMap();

            CreateMap<UnitDO, Unit>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();

            CreateMap<UserDO, User>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Baskets, opt => opt.MapFrom(src => src.Baskets))
                .ForMember(dest => dest.Orderitems, opt => opt.MapFrom(src => src.Orderitems))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments))
                .ForMember(dest => dest.Resetpasswords, opt => opt.MapFrom(src => src.Resetpasswords))
                .ForMember(dest => dest.Wishlists, opt => opt.MapFrom(src => src.Wishlists))
                .ReverseMap();

            CreateMap<WishlistDO, Wishlist>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();


        }
    }
}
