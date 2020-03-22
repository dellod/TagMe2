using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Will have to be integrated into microservice later on.
/// </summary>
namespace TagMe2.Models.Comments
{
    public class Comment
    {
        #region Properties
        public Guid ID
        {
            get; set;
        }

        public Guid Parent_ID
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }

        public User Author
        {
            get; set;
        }

        public Boolean IsCurrentState
        {
            get; set;
        }

        /// <summary>
        /// This will indicate the NEXT action that the comment has been instructed to take.
        /// </summary>
        public Commands Command
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (necessary for deserialization).
        /// </summary>
        public Comment()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <param name="text"></param>
        /// <param name="author"></param>
        public Comment(Guid id, Guid parentId, string text, User author)
        {
            ID = id;
            Parent_ID = parentId;
            Text = text;
            Author = author;
        }

        /// <summary>
        /// Copy Constructor.
        /// </summary>
        /// <param name="instance"></param>
        public Comment(Comment instance): this(instance.ID, instance.Parent_ID, instance.Text, instance.Author)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Changes the original text field of the comment but will always add "(Edited)" on a new line.
        /// </summary>
        /// <param name="newText"></param>
        public void editComment(string newText)
        {
            Text = newText + "\n(Edited)";
        }

        // TODO need to add queries.
        #endregion
    }
}
