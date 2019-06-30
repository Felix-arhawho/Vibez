using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibez.Domain.Context;
using Vibez.Domain.Models;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.Dtos.ResponseDtos;
using Vibez.Repositories.Repositories.Interface;

namespace Vibez.Repositories.Repositories.Concrete
{
    public class CategoryRepository : Repository<int, Category>, ICategoryRepository
    {
        private VibezContext _context;
        public CategoryRepository(VibezContext context) : base(context)
        {
            _context = context;
        }

        public List<CategoryResponseDto> GetAllCategories()
        {
            var categories = GetAll();
            var listOfCategories = new List<CategoryResponseDto>();
            var listOfPost = new List<PostResponseDto>();
            var listOfImages = new List<ImageResponseDto>();
            var listOfComments = new List<CommentResponseDto>();

            foreach (var category in categories)
            {
                foreach(var post in category.Posts)
                {
                    foreach (var comment in post.Comments)
                    {
                        var commentDto = new CommentResponseDto
                        {
                            Id = comment.Id,
                            ContentOfComment = comment.Content,
                            postId = comment.postId
                        };
                        listOfComments.Add(commentDto);
                    }

                    foreach (var image in post.Images)
                    {
                        var imageDto = new ImageResponseDto
                        {
                            Id = image.Id,
                            Name = image.Name,
                            Url = image.Url,
                            Extension = image.Extension,
                            postId = image.postId
                        };
                        listOfImages.Add(imageDto);
                    }

                    var postDto = new PostResponseDto
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        Likes = post.Likes,
                        Dislikes = post.Dislikes,
                        Comments = listOfComments,
                        Images = listOfImages,
                        CategoryId = post.CategoryId
                    };

                    listOfPost.Add(postDto);
                }


                var categoryDto = new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Posts = listOfPost
                };
            }

            return listOfCategories;
        }

        public CategoryResponseDto GetCategoryById(int Id)
        {
            var category = GetById(Id);

            var listOfPost = new List<PostResponseDto>();
            var listOfImages = new List<ImageResponseDto>();
            var listOfComments = new List<CommentResponseDto>();


            foreach (var post in category.Posts)
            {
                foreach (var comment in post.Comments)
                {
                    var commentDto = new CommentResponseDto
                    {
                        Id = comment.Id,
                        ContentOfComment = comment.Content,
                        postId = comment.postId
                    };
                    listOfComments.Add(commentDto);
                }

                foreach (var image in post.Images)
                {
                    var imageDto = new ImageResponseDto
                    {
                        Id = image.Id,
                        Name = image.Name,
                        Url = image.Url,
                        Extension = image.Extension,
                        postId = image.postId
                    };
                    listOfImages.Add(imageDto);
                }

                var postDto = new PostResponseDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Likes = post.Likes,
                    Dislikes = post.Dislikes,
                    Comments = listOfComments,
                    Images = listOfImages,
                    CategoryId = post.CategoryId
                };

                listOfPost.Add(postDto);
            }


            var categoryDto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Posts = listOfPost
            };

            return categoryDto;
        }

        public void CreateCategory(CategoryRequestDto categoryRequestDto)
        {
            var category = new Category
            {
                Name = categoryRequestDto.Name
            };

            Add(category);
        }

        public void EditCategory(CategoryRequestDto categoryRequestDto)
        {
            var category = GetById(categoryRequestDto.Id);
            category.Name = categoryRequestDto.Name;
        }

        public void DeleteCategory(int Id)
        {
            var category = GetById(Id);
            Remove(category);
        }
    }
}