using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vibez.Repositories.Dtos.RequestDtos;
using Vibez.Repositories.UnitOfWork.Concrete;
using Vibez.Repositories.UnitOfWork.Interface;

namespace Vibez.Web.Controllers
{
    public class PostController : Controller
    {
        private IUow _Uow;
        public PostController()
        {
            _Uow = new Uow();
        }
        public ActionResult ListOfPost()
        {
            var posts = _Uow.Posts.GetAllPost();
            return View(posts);
        }

        public ActionResult GetPostById(int Id)
        {
            var post = _Uow.Posts.GetPostById(Id);
            return View(post);
        }

        public ActionResult CreatePost(PostRequestDto postRequestDto)
        {
            _Uow.Posts.CreatePost(postRequestDto);
            return Json("Post created successfully", JsonRequestBehavior.AllowGet);
        }
    }
}