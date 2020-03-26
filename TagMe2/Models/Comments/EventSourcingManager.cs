using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models.Comments
{
    public class EventSourcingManager
    {
        /// <summary>
        /// Will retrieve comments under common post.
        /// </summary>
        /// <param name="postID"></param>
        public void retrieveComments(Guid postID)
        {
            // TODO need to query based on post ID
            // ORDER will be oldest to newest, so the first comment will be directly attached to the post, and the newest posts will follow afterwards.
        }
    }
}
