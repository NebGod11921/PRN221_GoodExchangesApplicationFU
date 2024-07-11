using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
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

        public async Task<PostDTO> CreatePostAsync(PostDTO postDto)
        {
            try
            {
                var postEntity = _mapper.Map<Post>(postDto);
                var createdPost = await _unitOfWork.PostRepository.CreatePostAsync(postEntity);
                return _mapper.Map<PostDTO>(createdPost);
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
                var post = await _unitOfWork.PostRepository.GetPostByIdAsync(postId);
                return _mapper.Map<PostDTO>(post);
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
                var posts = await _unitOfWork.PostRepository.GetAllPostsAsync();
                return _mapper.Map<IEnumerable<PostDTO>>(posts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdatePostAsync(PostDTO postDto)
        {
            try
            {
                var postEntity = _mapper.Map<Post>(postDto);
                await _unitOfWork.PostRepository.UpdatePostAsync(postEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeletePostAsync(int postId)
        {
            try
            {
                await _unitOfWork.PostRepository.DeletePostAsync(postId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
