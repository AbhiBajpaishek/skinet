using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecParams productParams)
                :base(x=>
                    (String.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                    (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) && 
                    (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId)
                )
        {
            AddInclude(x=> x.ProductType);
            AddInclude(x=> x.ProductBrand);
            AddOrderBy(x=> x.Name);
            ApplyPaging(productParams.PageSize*(productParams.PageIndex-1),
                            productParams.PageSize);

            if(!String.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x=> x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x=> x.Price);
                        break;
                    default:
                        AddOrderBy(x=>x.Name);
                        break;
                }
            }
        }

        public ProductWithTypesAndBrandsSpecification(int id) 
            : base(p=>p.Id==id)
        {
            AddInclude(x=> x.ProductType);
            AddInclude(x=> x.ProductBrand);
        }
    }
}