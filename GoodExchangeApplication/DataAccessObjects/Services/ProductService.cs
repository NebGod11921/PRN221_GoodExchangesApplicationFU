using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.Product;
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

        public async Task<ResponseProductDTO> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.ProductRepository.GetByIdAsync(id);
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
        public async Task<ResponseProductDTO> CreateProduct(RequestProductDTO newProduct)
        {
            try
            {
                var map=_mapper.Map<Product>(newProduct);
                var createProduct = await _unitOfWork.ProductRepository.CreateProduct(map);
                if(createProduct != null)
                {
                    createProduct.Popularities = 1;
                    /*var checkExist=await _unitOfWork.ProductRepository.CheckExist(createProduct.Id);*/
                    var result = _mapper.Map<ResponseProductDTO>(createProduct);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
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
                var checkExist = await _unitOfWork.ProductRepository.GetByID(updateProduct.Id);
                if (checkExist != null)
                {
                    updateProduct.Location=checkExist.Location;
                    updateProduct.Status=checkExist.Status;
                    updateProduct.Quantity=checkExist.Quantity;
                    updateProduct.Price=checkExist.Price;
                    updateProduct.Description=checkExist.Description;
                    updateProduct.Image=checkExist.Image;
                    updateProduct.Title=checkExist.Title;
                    _unitOfWork.ProductRepository.Update(checkExist);
                }
                
                return updateProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
