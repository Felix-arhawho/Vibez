using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.Dtos.ResponseDtos;
using Vibez.Repositories.UnitOfWork.Concrete;
using Vibez.Repositories.UnitOfWork.Interface;

namespace Vibez.WebApi.Controllers.Api
{
    [RoutePrefix("api/Post")]
    public class PostApiController : ApiController
    {
        private IUow _Uow;

        public PostApiController()
        {
            _Uow = new Uow();
        }

        [Route("GetAllPost")]
        public HttpResponseMessage GetAllPost()
        {
            var response = new HttpResponseMessage();
            try
            {
                var posts = _Uow.Posts.GetAllPost();
                response = Request.CreateResponse(HttpStatusCode.OK, posts);
                return response;
            }
            catch(Exception ex)
            {
                var ErrorResponse = new ErrorResponseDto
                {
                    ExceptionMessage = ex.Message,
                    InnerExceptionMessage = ex.InnerException == null ? "None" : ex.InnerException.Message
                };

                response = Request.CreateResponse(HttpStatusCode.BadRequest, ErrorResponse);
                return response;
            }
        }

        [Route("GetPostById/{Id}")]
        public HttpResponseMessage GetPostById(int Id)
        {
            var response = new HttpResponseMessage();
            try
            {
                var post = _Uow.Posts.GetPostById(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, post);
                return response;
            }
            catch(Exception ex)
            {
                var ErrorResponse = new ErrorResponseDto
                {
                    ExceptionMessage = ex.Message,
                    InnerExceptionMessage = ex.InnerException == null ? "None" : ex.InnerException.Message
                };

                response = Request.CreateResponse(HttpStatusCode.BadRequest, ErrorResponse);
                return response;
            }
        }

        [Route("CreatePost")]
        public HttpResponseMessage CreatePost(PostRequestDto postRequestDto)
        {
            var response = new HttpResponseMessage();
            try
            {
                _Uow.Posts.CreatePost(postRequestDto);
                response = Request.CreateResponse(HttpStatusCode.OK, "Post created successfully");
                return response;
            }
            catch(Exception ex)
            {
                var ErrorResponse = new ErrorResponseDto
                {
                    ExceptionMessage = ex.Message,
                    InnerExceptionMessage = ex.InnerException == null ? "None" : ex.InnerException.Message
                };

                response = Request.CreateResponse(HttpStatusCode.BadRequest, ErrorResponse);
                return response;
            }
        }

        [Route("EditPost")]
        public HttpResponseMessage EditPost(PostRequestDto postRequestDto)
        {
            var response = new HttpResponseMessage();
            try
            {
                _Uow.Posts.EditPost(postRequestDto);
                _Uow.SaveChanges();
                response = Request.CreateResponse(HttpStatusCode.OK, "Post editted successfully");
                return response;
            }
            catch(Exception ex)
            {
                var ErrorResponse = new ErrorResponseDto
                {
                    ExceptionMessage = ex.Message,
                    InnerExceptionMessage = ex.InnerException == null? "None" : ex.InnerException.Message
                };

                response = Request.CreateResponse(HttpStatusCode.BadRequest, ErrorResponse);
                return response;
            }
        }

        [Route("DeletePost/{Id}")]
        public HttpResponseMessage DeletePost(int Id)
        {
            var response = new HttpResponseMessage();
            try
            {
                _Uow.Posts.DeletePost(Id);
                _Uow.SaveChanges();
                response = Request.CreateResponse(HttpStatusCode.OK, "Post deleted successfully");
                return response;
            }
            catch(Exception ex)
            {
                var ErrorResponse = new ErrorResponseDto
                {
                    ExceptionMessage = ex.Message,
                    InnerExceptionMessage = ex.InnerException == null ? "None" : ex.InnerException.Message
                };

                response = Request.CreateResponse(HttpStatusCode.BadRequest, ErrorResponse);
                return response;
            }
        }
    }
}