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
    public class CommentApiController : ApiController
    {
        private IUow _Uow;
        public CommentApiController()
        {
            _Uow = new Uow();
        }

        public HttpResponseMessage CreateComment(CommentRequestDto commentRequestDto)
        {
            var response = new HttpResponseMessage();
            try
            {
                _Uow.Comments.CreateComment(commentRequestDto);
                _Uow.SaveChanges();
                response = Request.CreateResponse(HttpStatusCode.OK, "Comment created successfully");
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

        public HttpResponseMessage EditComment(CommentRequestDto commentRequestDto)
        {
            var response = new HttpResponseMessage();
            try
            {
                _Uow.Comments.EditComment(commentRequestDto);
                _Uow.SaveChanges();
                response = Request.CreateResponse(HttpStatusCode.OK, "Comment editted successfully");
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

        public HttpResponseMessage DeleteComment(int Id)
        {
            var response = new HttpResponseMessage();
            try
            {                
                _Uow.Comments.DeleteComment(Id);
                _Uow.SaveChanges();
                response = Request.CreateResponse(HttpStatusCode.OK, "Comment deleted successfully");
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