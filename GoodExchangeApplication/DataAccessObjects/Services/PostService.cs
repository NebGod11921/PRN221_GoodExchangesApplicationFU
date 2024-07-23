using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.UnitOfWork;
using DataAccessObjects.ViewModels.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostDTO> CreatePostAsync(PostDTO postDto, int userId, int productId)
        {
            try
            {
                var mapper = _mapper.Map<Post>(postDto);   
                var getUserId = await _unitOfWork.AccountRepository.GetByIdAsync(userId);
                var getProductid = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
                if (getUserId != null && getProductid != null)
                {
                    mapper.ProductId = getProductid.Id;
                    mapper.UserId = getUserId.Id;
                    mapper.Status = 1;
                    await  _unitOfWork.PostRepository.AddAsync(mapper);
                    var IsSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (IsSuccess)
                    {
                        var resultMapper = _mapper.Map<PostDTO>(mapper);
                        return resultMapper;
                    } else
                    {
                        return new PostDTO();
                    }



                }
                return new PostDTO();






            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostDTO> GetPostByIdAsync(int postId)
        {
            try
            {
                var result = await _unitOfWork.PostRepository.GetByIdAsync(postId);
                if (result != null)
                {
                    var mapper = _mapper.Map<PostDTO>(result);
                    return mapper;
                }
                else
                {
                    return new PostDTO();
                }



                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsAsync()
        {
            try
            {
                var result = await _unitOfWork.PostRepository.GetAllAsync();
                if (result != null)
                {
                    var mappedResult = _mapper.Map<IEnumerable<PostDTO>>(result);
                    return mappedResult;
                }
                else
                {
                    return new List<PostDTO>();
                }




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostDTO> UpdatePostAsync(PostDTO postDto, int postId)
        {
            try
            {
                var getPostId = await _unitOfWork.PostRepository.GetByIdAsync(postId);
                var mapper = _mapper.Map<Post>(postDto);
                if (getPostId != null)
                {
                    _unitOfWork.PostRepository.Update(mapper);
                    var IsSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (IsSuccess)
                    {
                        var mapperResuult = _mapper.Map<PostDTO>(postDto);
                        return mapperResuult;
                    }else
                    {
                        return new PostDTO();
                    }


                } else
                {
                    return new PostDTO();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            try
            {
                var getPostId = await _unitOfWork.PostRepository.GetByIdAsync(postId);
                if (getPostId != null)
                {
                    _unitOfWork.PostRepository.SoftRemove(getPostId);
                    var IsSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (IsSuccess)
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                }
                return false;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*public async Task<IEnumerable<PostDTO>> GetPostsByUserIdAsync(int userId)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/
    }
}
