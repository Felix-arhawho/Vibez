using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vibez.Repositories.Dtos.ResponseDtos;

namespace Vibez.WebApi.Controllers.Mvc
{
    public class PostMvcController : Controller
    {
        public async Task<ActionResult> ListOfPost()
        {
            try
            {

                //using (var client = new HttpClient())
                //{
                //    var uri = "http://localhost:50395/api/Post/GetAllPost";
                //    var response = await client.GetAsync(uri);

                //    var content = await response.Content.ReadAsStringAsync();
                //    var dotNetObject = JsonConvert.DeserializeObject<PostResponseDto>(content);
                //}
            }
            catch(Exception ex)
            {

            }

            return View();
        }

        //public ActionResult GetPostById(int Id)
        //{

        //}

        //public ActionResult CreatePost()
        //{

        //}
    }
}