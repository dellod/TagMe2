using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagMe2.Models.Comments;

namespace TagMe2.Models.Comments
{
    /// <summary>
    /// Handles updates for comments.
    /// </summary>
    public class CommentCommandHandler
    {
        void execute(Comment comment)
        {
            Commands command = comment.Command;
            switch(command)
            {
                case Commands.AddNewComment:
                    AddNewComment(comment);
                    break;
                case Commands.DeleteComment:
                    DeleteComment(comment);
                    break;
                case Commands.EditComment:
                    EditComment(comment);
                    break;
                    
            }
        }
        void AddNewComment(Comment comment)
        {

        }

        void DeleteComment(Comment comment)
        {

        }

        void EditComment(Comment comment)
        {

        }
    }
}
