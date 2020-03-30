using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagMe2.Models.Comments;

namespace TagMe2.Models
{

    /*
     *this model will contain two sub models, Post and Comment, will be passed to the commentDisplay View
     * as we need two models passed in One
     * 
     */
    public class PostComment
    {
        public Post thePost { get; set; }
        
        public LinkedList<Comment> theComments { get; set; }

        public string theReply { get; set; }
    }
}
