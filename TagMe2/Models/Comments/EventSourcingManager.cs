using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models.Comments
{
    public static class EventSourcingManager
    {
        /// <summary>
        /// Will retrieve comments under common post.
        /// </summary>
        /// <param name="postID"></param>
        public static LinkedList<Comment> retrieveCommentsFromPost(Guid postID)
        {
            LinkedList<Comment> commentList = new LinkedList<Comment>();
            // TODO need to query based on post ID, then after query by order
            //          ORDER will be oldest to newest, so the first comment will be directly attached to the post, and the newest posts will follow afterwards.

            // FIrst query the comment with parent_id that matches the post_id
            // then query the next comment that has parent_id that matches the last comment
            // keep going
            return null;
        }

    }
}
