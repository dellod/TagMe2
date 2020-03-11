using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models
{
    public class Post
    {
        #region Properties
        public Guid ID
        {
            get; set;
        }

        /// <summary>
        /// CHANGE LATER TO IMAGE CLASS
        /// </summary>
        public string URL
        {
            get; set;
        }

        public Address Location
        {
            get; set;
        }

        public User PostAuthor
        {
            get; set;
        }

        public string Caption
        {
            get; set;
        }

        public int Likes
        {
            get; set;
        }

        public List<string> Tags
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (necessary for deserialization).
        /// </summary>
        public Post()
        {

        }

        /// <summary>
        /// Field constructor,
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="location"></param>
        /// <param name="postAuthor"></param>
        /// <param name="caption"></param>
        /// <param name="likes"></param>
        /// <param name="tags"></param>
        public Post(Guid id, string url, Address location, User postAuthor, string caption, int likes, List<string> tags)
        {
            ID = id;
            URL = url;
            Location = location;
            PostAuthor = postAuthor;
            Caption = caption;
            Likes = likes;
            Tags = tags;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance"></param>
        public Post(Post instance) : this(instance.ID, instance.URL, instance.Location, instance.PostAuthor, instance.Caption, instance.Likes, instance.Tags)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new tag to the Tag list, but there can only be 5 tags for each post.
        /// </summary>
        /// <param name="newTag"></param>
        public void addNewTag(string newTag)
        {
            if(Tags.Count <= 5)
            {
                Tags.Add(newTag);
            }
            else
            {
                Console.WriteLine("CANNOT ADD MORE THAN 5 TAGS");
            }
        }

        /// <summary>
        /// Increments the likes that the post has.
        /// </summary>
        public void addLike()
        {
            Likes++; // TODO: might have to change this implementation later.
        }
        
        /// <summary>
        /// Changes the caption text by specified argument but will add "(Edited)" at the end of the new caption.
        /// </summary>
        /// <param name="newCaption"></param>
        public void editCaption(string newCaption)
        {
            Caption = newCaption + "\n(Edited)";
        }

        /// <summary>
        /// Removes specified tag and returns the tag that was removed.
        /// </summary>
        /// <param name="tagToRemove"></param>
        /// <returns></returns>
        public string removeTag(string tagToRemove)
        {
            if(!Tags.Any())
            {
                return "";
            }
            string takingOut = Tags.ElementAt(Tags.IndexOf(tagToRemove));
            Tags.RemoveAt(Tags.IndexOf(tagToRemove));
            return takingOut;
        }
        #endregion
    }
}
