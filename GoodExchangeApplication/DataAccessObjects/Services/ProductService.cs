using AutoMapper;
using BusinessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessObjects.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private AppDbContext _appDbContext;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, AppDbContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appDbContext = context;
        }

        public async Task<IEnumerable<ProductDTO>> SearchProductByNameOrCodeAsync(string searchQuery)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.SearchProductByNameOrCode(searchQuery);
                var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
                return productDTOs;
            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

            public async Task<IEnumerable<ResponseProductDTO>> GetAllProducts()
            {
                try
                {
                    var result = await _unitOfWork.ProductRepository.GetProduct();
                    var map = _mapper.Map<IEnumerable<ResponseProductDTO>>(result);
                    if (result == null)
                    {
                        return null;
                    }
                    else
                        return map;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<ResponseProductDTO> GetById(int id)
            {
                try
                {
                    var result = await _unitOfWork.ProductRepository.GetByID(id);
                    var map = _mapper.Map<ResponseProductDTO>(result);
                    if (map != null)
                    {
                        return map;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public async Task<RequestProductDTO> CreateProduct(RequestProductDTO newProduct)
            {
                try
                {
                    var map = _mapper.Map<Product>(newProduct);
                    var createProduct = await _unitOfWork.ProductRepository.CreateProduct(map);
                    if (createProduct != null)
                    {
                        var result = _mapper.Map<RequestProductDTO>(createProduct);
                        return result;
                    }
                    else return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<bool> DeleteProduct(int id)
            {
                var result = await _unitOfWork.ProductRepository.CheckExist(id);
                if (result != null)
                {
                    await _unitOfWork.ProductRepository.DeleteProduct(id);
                    return true;
                }
                return false;
            }


            //Error Update
            public async Task<ResponseProductDTO> UpdateProduct(ResponseProductDTO updateProduct)
            {
                try
                {
                    var map = _mapper.Map<Product>(updateProduct);
                    var checkExist = await _unitOfWork.ProductRepository.GetByID(map.Id);
                    if (checkExist != null)
                    {
                        var result = await _unitOfWork.ProductRepository.UpdateProduct(map.Id);
                        var mapResult = _mapper.Map<ResponseProductDTO>(result);
                        return mapResult;
                    }
                    else return null;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<IEnumerable<ProductDTos>> GetAllProductsSecVers()
            {
                try
                {
                    var result = await _unitOfWork.ProductRepository.GetAllAsync();
                    if (result != null)
                    {
                        var mappedResult = _mapper.Map<IEnumerable<ProductDTos>>(result);
                        return mappedResult;
                    }
                    else
                    {
                        return null;
                    }




                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<ProductDTos> GetProductByIdSecondVers(int productId)
            {
                try
                {
                    var result = await _unitOfWork.ProductRepository.GetByID(productId);
                    if (result != null)
                    {
                        var mappedResult = _mapper.Map<ProductDTos>(result);
                        return mappedResult;
                    }
                    else
                    {
                        return null;
                    }



                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        public async Task<Pagination<ProductDTos>> GetProductsPaging(int pageIndex, int pageSize, string? title = null, float? minPrice = null, float? maxPrice = null, int? categoryId = null, string? sortField = null, string sortOrder = "asc")
        {
            return await _unitOfWork.ProductRepository.GetProductsPaging(pageIndex, pageSize, title, minPrice, maxPrice, categoryId, sortField, sortOrder);
        }
        public async Task<IEnumerable<Category>> GetProductCategories()
        {
            return await _unitOfWork.ProductRepository.GetProductCategories();
        }
    }
}
