using AutoMapper;
using BusinessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.UnitOfWork;
using DataAccessObjects.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        public async Task<RequestProductDTO> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.GetByID(id);
                var map = _mapper.Map<RequestProductDTO>(result);
                if (map != null)
                {
                    return map;
                } else
                {
                    return null;
                }
            
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ResponseProductDTO>> GetAllProducts(ResponseProductDTO productDTO)
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.GetProduct();
                var map = _mapper.Map<IEnumerable<ResponseProductDTO>>(productDTO);
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
            public async Task<RequestProductDTO> CreateProduct(RequestProductDTO newProduct)
        {
            try
            {
                var map = _mapper.Map<Product>(newProduct);
                map.Popularities = 1;
                map.Status = 1;
                var createProduct = await _unitOfWork.ProductRepository.CreateProduct(map);
                
                if (createProduct != null)
                {
                    
                    var result = _mapper.Map<RequestProductDTO>(createProduct);
                    return result;
                }
                else 
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

            /*public async Task<ResponseProductDTO> GetById(int id)
            {
                await _unitOfWork.ProductRepository.DeleteProduct(id);
                return true;
            }
            return false;*/
        


        //Error Update
        public async Task<RequestProductDTO> UpdateProduct(RequestProductDTO updateProduct)
        {
            try
            {
                var map = _mapper.Map<Product>(updateProduct);
                var result=await _unitOfWork.ProductRepository.UpdateProduct(map);
                if (result != null)
                {
                    var mapResult = _mapper.Map<RequestProductDTO>(result);
                    return mapResult;
                }
                else 
                    return null;

                /*try
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
                }*/
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
                        var result = await _unitOfWork.ProductRepository.UpdateProduct(map);
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
        public async Task<IEnumerable<ProductDTO>> GetProductsByUserIdAsync(int userId)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductsByUserIdAsync(userId);
                return _mapper.Map<IEnumerable<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDTos> UpdateProductSec(ProductDTos updateProduct)
        {
            try
            {
                var map = _mapper.Map<Product>(updateProduct);
                var checkExist = await _unitOfWork.ProductRepository.GetByID(map.Id);
                if (checkExist != null)
                {
                    var result = await _unitOfWork.ProductRepository.UpdateProduct(map);
                    var mapResult = _mapper.Map<ProductDTos>(result);
                    return mapResult;
                }
                else return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                return await _unitOfWork.ProductRepository.GetCategories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Paging<ProductDTos>> GetProductsPaging(int pageIndex, int pageSize, string? title = null, float? minPrice = null, float? maxPrice = null, int? categoryId = null, string? sortField = null, string sortOrder = "asc")
        {
            return await _unitOfWork.ProductRepository.GetProductsPaging(pageIndex, pageSize, title, minPrice, maxPrice, categoryId, sortField, sortOrder);
        }

        public async Task<List<ProductDTos>> GetTopPopularProductsAsync()
        {
            return await _unitOfWork.ProductRepository.GetTopPopularProductsAsync();
        }
        public async Task<IEnumerable<ProductDTos>> GetProductsByTransactionId(int transactionId)
        {
            try
            {
                var products = await _unitOfWork.TransactionProductRepository.GetProductsByTransactionIdAsync(transactionId);

                if (products == null || !products.Any())
                {
                    return Enumerable.Empty<ProductDTos>();
                }

                var productDtos = products.Select(p => new ProductDTos
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Image = p.Image,
                    Location = p.Location,
                    // Map other properties as necessary
                });

                if (productDtos != null)
                {
                    var mapperResult =  _mapper.Map<IEnumerable<ProductDTos>>(productDtos);
                    return mapperResult;
                } else
                {
                    return Enumerable.Empty<ProductDTos>();
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
