using System;
using Core.Entities;
using Core.Specifications;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification: BaseSpecification<Product>    
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            :base(x=>
                    (String.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                    (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) && 
                    (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId)
                )
        {
            
        }
    }
}