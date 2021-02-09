using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Data;
using WepApi.Dtos;
using WepApi.Models;

namespace WepApi.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*source -> Target
             * reading from database & passing it back to the client
             */
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();

            CreateMap<Shipper, ShipperReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();

            CreateMap<Orders, OrderReadDto>();
            CreateMap<OrderCreateDto, Orders>();
            CreateMap<OrderUpdateDto, Orders>();

            CreateMap<OrderStatus, OrderStatusReadDto>();
            CreateMap<OrderStatusCreateDto, OrderStatus>();
            CreateMap<OrderStatusUpdateDto, OrderStatus>();

            CreateMap<OrderItem, OrderItemReadDto>();
            CreateMap<OrderItemCreateDto, OrderItem>();
            CreateMap<OrderItemUpdateDto, OrderItem>();
        }
    }
}
