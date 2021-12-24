using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;

namespace Northwind.EntityLayer.Concrete.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AlphabeticalListOfProduct, DtoAlphabeticalListOfProduct>().ReverseMap();
            CreateMap<Category, DtoCategory>().ReverseMap();
            CreateMap<CategorySalesFor1997, DtoCategorySalesFor1997>().ReverseMap();
            CreateMap<CurrentProductList, DtoCurrentProductList>().ReverseMap();
            CreateMap<Customer, DtoCustomer>().ReverseMap();
            CreateMap<CustomerCustomerDemo, DtoCustomerCustomerDemo>().ReverseMap();
            CreateMap<CustomerDemographic, DtoCustomerDemographic>().ReverseMap();
            CreateMap<Employee, DtoEmployee>().ReverseMap();
            CreateMap<EmployeeTerritory, DtoEmployeeTerritory>().ReverseMap();
            CreateMap<Invoice, DtoInvoice>().ReverseMap();
            CreateMap<OperationClaim, DtoOperationClaim>().ReverseMap();
            CreateMap<OrderDetail, DtoOrderDetail>().ReverseMap();
            CreateMap<DtoOrderDetailsExtended, DtoOrderDetailsExtended>().ReverseMap();
            CreateMap<OrdersQry, DtoOrdersQry>().ReverseMap();
            CreateMap<OrderSubtotal, DtoOrderSubtotal>().ReverseMap();
            CreateMap<Product, DtoProduct>().ReverseMap();
            CreateMap<ProductsAboveAveragePrice, DtoProductsAboveAveragePrice>().ReverseMap();
            CreateMap<ProductSalesFor1997, DtoProductSalesFor1997>().ReverseMap();
            CreateMap<ProductsByCategory, DtoProductsByCategory>().ReverseMap();
            CreateMap<QuarterlyOrder, DtoQuarterlyOrder>().ReverseMap();
            CreateMap<Region, DtoRegion>().ReverseMap();
            CreateMap<SalesByCategory, DtoSalesByCategory>().ReverseMap();
            CreateMap<SalesTotalsByAmount, DtoSalesTotalsByAmount>().ReverseMap();
            CreateMap<Shipper, DtoShipper>().ReverseMap();
            CreateMap<SummaryOfSalesByQuarter, DtoSummaryOfSalesByQuarter>().ReverseMap();
            CreateMap<SummaryOfSalesByYear, DtoSummaryOfSalesByYear>().ReverseMap();
            CreateMap<Supplier, DtoSupplier>().ReverseMap();
            CreateMap<Territory, DtoTerritory>().ReverseMap();
            CreateMap<User, DtoUser>().ReverseMap();
            CreateMap<UserOperationClaim, DtoUserOperationClaim>().ReverseMap();
        }
    }
}