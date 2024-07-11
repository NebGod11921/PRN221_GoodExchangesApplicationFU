﻿using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        public async Task<RequestProductDTO> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.GetByID(id);
                var map = _mapper.Map<RequestProductDTO>(result);
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




            } catch (Exception ex)
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



            }catch(Exception ex)
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
    }
}
