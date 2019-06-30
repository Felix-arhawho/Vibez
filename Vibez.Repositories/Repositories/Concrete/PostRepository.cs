using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Vibez.Domain.Context;
using Vibez.Domain.Models;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.Dtos.ResponseDtos;
using Vibez.Repositories.Repositories.Interface;

namespace Vibez.Repositories.Repositories.Concrete
{
    public class PostRepository : Repository<int, Post>, IPostRepository
    {
        private VibezContext _context;
        public PostRepository(VibezContext context) : base(context)
        {
            _context = context;
        }

        public List<PostResponseDto> GetAllPost()
        {
            var posts = _context.Posts.Include("Images").Include("Comments").ToList();
            posts.Reverse();
            var listOfPost = new List<PostResponseDto>();
            var listOfImages = new List<ImageResponseDto>();
            var listOfComments = new List<CommentResponseDto>();

            foreach (var post in posts)
            {
                if (post.Comments.Count != 0)
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
                }

                if (post.Images.Count != 0)
                {
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
                }

                var postDto = new PostResponseDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Likes = post.Likes,
                    Dislikes = post.Dislikes,
                    //Comments = listOfComments,
                    Images = listOfImages,
                    CategoryId = post.CategoryId
                };

                listOfPost.Add(postDto);
            }

            return listOfPost;
        }

        public PostResponseDto GetPostById(int Id)
        {
            var post = _context.Posts.Include("Images").Where(p => p.Id == Id).FirstOrDefault();

            var listOfImages = new List<ImageResponseDto>();
            var listOfComments = new List<CommentResponseDto>();

            //foreach (var comment in post.Comments)
            //{
            //    var commentDto = new CommentResponseDto
            //    {
            //        Id = comment.Id,
            //        ContentOfComment = comment.Content,
            //        postId = comment.postId
            //    };
            //    listOfComments.Add(commentDto);
            //}

            if(post.Images.Count != 0)
            {
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

            return postDto;
        }

        public void CreatePost(PostRequestDto postRequestDto)
        {
            var post = new Post
            {
                Title = postRequestDto.Title,
                Content = postRequestDto.Content,
                Likes = postRequestDto.Likes,
                Dislikes = postRequestDto.Dislikes,
                CategoryId = 5
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            var postId = post.Id;

            var imageNameWithoutExtension = Path.GetFileNameWithoutExtension(postRequestDto.ImageFile.FileName);
            var imageExtension = Path.GetExtension(postRequestDto.ImageFile.FileName);
            var imageName = imageNameWithoutExtension + imageExtension;

            var pathToImage = "~/UploadedImages/" + imageName;

            var imagePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedImages/"), imageName);
            postRequestDto.ImageFile.SaveAs(imagePath);

            var image = new Image
            {
                Name = imageName,
                Url = pathToImage,
                Extension = imageExtension,
                postId = postId
            };
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public void EditPost(PostRequestDto postRequestDto)
        {
            var post = GetById(postRequestDto.Id);
            post.Id = postRequestDto.Id;
            post.Title = postRequestDto.Title;
            post.Content = postRequestDto.Content;
        }

        public void DeletePost(int Id)
        {
            var post = GetById(Id);

            foreach (var img in post.Images)
            {
                _context.Images.Remove(img);
                _context.SaveChanges();
            }

            foreach (var comment in post.Comments)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }

            Remove(post);
        }
    }
}