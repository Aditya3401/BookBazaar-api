using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookBaazar.Application.Endpoints.Book;
using BookBaazar.Application.Endpoints.Cart;
using BookBaazar.Application.Endpoints.ForgotPassword;
using BookBaazar.Application.Endpoints.Order;
using BookBaazar.Application.Endpoints.User;
using BookBaazar.Domain.Entities;

namespace BookBaazar.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, Users>()
                .ForMember(dest => dest.UserID, opt => opt.Ignore())
                .ForMember(dest => dest.IsVendor, opt => opt.Ignore())
                .ForMember(dest => dest.IsTemp, opt => opt.Ignore())
                .ForMember(dest => dest.Temp_Password, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdmin, opt => opt.Ignore())
                .ForMember(dest => dest.isActive, opt => opt.Ignore());


            //CreateMap<ForgotPasswordDto, Users>()
            //    .ForMember(dest => dest.UserID, opt => opt.Ignore())
            //    .ForMember(dest => dest.IsVendor, opt => opt.Ignore())
            //    .ForMember(dest => dest.IsAdmin, opt => opt.Ignore())
            //    .ForMember(dest => dest.IsTemp, opt => opt.Ignore())
            //    .ForMember(dest => dest.FirstName, opt => opt.Ignore())
            //    .ForMember(dest => dest.Temp_Password, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastName, opt => opt.Ignore());

            CreateMap<LoginUserDto, Users>()
                .ForMember(dest => dest.UserID, opt => opt.Ignore())
                .ForMember(dest => dest.IsVendor, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdmin, opt => opt.Ignore())
                .ForMember(dest => dest.IsTemp, opt => opt.Ignore())
                .ForMember(dest => dest.Temp_Password, opt => opt.Ignore())
                .ForMember(dest => dest.FirstName, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.isActive, opt => opt.Ignore());

            CreateMap<BookDto, Books>()
                .ForMember(dest => dest.BookID, opt => opt.Ignore());

            CreateMap<CartsDto, Carts>()
                .ForMember(dest => dest.CartID, opt => opt.Ignore())
                .ForMember(dest => dest.QuantityInCart, opt => opt.Ignore());

            CreateMap<OrderDto, Orders>()
                .ForMember(dest => dest.OrderStatus, opt => opt.Ignore())
                .ForMember(dest => dest.OrderID, opt => opt.Ignore())
                .ForMember(dest => dest.UserID, opt => opt.Ignore());

            CreateMap<Books, OrderBooksRead>()
                .ForMember(dest => dest.QuantityInOrder, opt => opt.Ignore())
                .ForMember(dest => dest.orderId, opt => opt.Ignore()); 

            //CreateMap<Orders,OrderItem>()
            //    .ForMember(dest=>dest.OrderItemID,opt=>opt.Ignore())
            //    .ForMember(
            //    dest => dest.OrderID, opt => opt.MapFrom(src => src.OrderID))
            //    .ForMember(
            //    dest => dest.BookID, opt => opt.MapFrom(src => src.BookID))
            CreateMap<Users, ReadUserDto>();
            CreateMap<Books, BookCartReadDto>();
               
        }
    }
}
