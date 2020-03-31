using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagMe2.Models;
using TagMe2.Models.Comments;


namespace TagMe2.Controllers
{
    /// <summary>
    /// This controller will handle event sourcing with comments and call comments in hierarchiy of their GUID.
    /// </summary>
    public class commentController : Controller
       
    {

        //Need to call comment that are under the posts

        [HttpPost]
        public IActionResult CommentOnPost(PostComment p, Guid postID, Guid parentID)
        {
            Guid ID = Guid.NewGuid();
            // call commentcommandhandler, pass the comment as a model, and will get it sorted. 
            Comment temp = new Comment(ID, parentID, postID,p.theReply,new User(),null);
            CommentCommandHandler.AddNewComment(temp);

            return RedirectToAction("commentDisplay", "Post",new { ID = postID });
        }

        public string CommentOnPost()
        {

            return "JAJAJ";

        }
    }

   



}