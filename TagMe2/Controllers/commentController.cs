using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagMe2.Models;



namespace TagMe2.Controllers
{
    /// <summary>
    /// This controller will handle event sourcing with comments and call comments in hierarchiy of their GUID.
    /// </summary>
    public class commentController : Controller
       
    {

        //Need to call comment that are under the posts

        [HttpPost]
        public string CommentOnPost(PostComment p, string caption)
        {

            //Console.WriteLine(caption);


            return p.theReply;
        }

        public string CommentOnPost()
        {

            return "JAJAJ";

        }
    }

   



}