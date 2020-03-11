using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Will have to be integrated into microservice later on.
/// </summary>
namespace TagMe2.Models
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

        #endregion
    }
}
