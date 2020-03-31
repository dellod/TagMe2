using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;


using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.IO;
using TagMe2.Models.Query;

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
        /// I think we dont need, it can be saved in the IFormFile down, trying to figure it out(yossri)
        /// </summary>
        [DisplayName("Upload File")]
        public string URL
        {
            get; set;
        }

        public IFormFile ImageFile { get; set; }
        
            
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

        public string Tags
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
        public Post(Guid id, string url, Address location, User postAuthor, string caption, int likes, string tags)
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
        
        public void addToDb(SqlConnection connection)
        {
            Guid postId = Guid.NewGuid();
            connection.Open();
            string commandText = "Insert into Post (UUID,text, imagetype, imageblob) VALUES(@Id,@cap,@imageType, @imageblob)";
            SqlCommand cmd = new SqlCommand(commandText, connection);

            // adding the 'converting to blob section'
            string imageName = Path.GetFileNameWithoutExtension(this.ImageFile.FileName);
            string imageType = this.ImageFile.ContentType;
            Stream sm = this.ImageFile.OpenReadStream();
            BinaryReader br = new BinaryReader(sm);
            byte[] bytes = br.ReadBytes((Int32)sm.Length);



            cmd.Parameters.AddWithValue("@Id", postId);
            cmd.Parameters.AddWithValue("@cap", this.Caption);
            cmd.Parameters.AddWithValue("@imageType", imageType);
            cmd.Parameters.AddWithValue("@imageblob", bytes);

            cmd.ExecuteNonQuery();
       




            string postTagsQuery = "Insert into PostTags (PostID, Tag) VALUES(@PID,@tag)";
            SqlCommand addTagsCmd = new SqlCommand(postTagsQuery, connection);
            string[] tagsArr = Tags.Split("@");
            addTagsCmd.Parameters.AddWithValue("@PID", postId);
            addTagsCmd.Parameters.AddWithValue("@tag", string.Empty);
            foreach (string tag in tagsArr)
            {
                if (!tag.Equals(""))
                {
                    addTagsCmd.Parameters["@Tag"].Value = tag;
                    addTagsCmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine(Tags);

            connection.Close();
        }

        #region Methods
        /// <summary>
        /// retrive the post information from database based on the UUID
        /// </summary>
        /// <param name="post_ID"></param>
        /// <returns></returns>
        public static Post searchOnePost(Guid post_ID)
        {

            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DatabaseTagMe2;Trusted_Connection=True;MultipleActiveResultSets=true";

            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string temp = "SELECT * FROM Post WHERE UUID = @post_ID";

            //string queryString = string.Format(temp, post_ID.ToString());

//            SqlCommand command = new SqlCommand(queryString, connectDatabase.myConnection);
            SqlCommand command = new SqlCommand(temp, myConnection);
           
            command.Parameters.AddWithValue("@post_ID", post_ID);
            SqlDataReader reader = command.ExecuteReader();

            Guid ID;
            int likes;
            string text;

            reader.Read();

            //retrive data from table post
            byte[] bytes = (byte[])reader["imageblob"];
            string strBase64 = Convert.ToBase64String(bytes);
            string url = "data:Image/png;base64," + strBase64;

            ID = Guid.Parse(reader["UUID"].ToString());
            likes = 1;//Int32.Parse(reader["like"].ToString());
            text = reader["text"].ToString();

            //retrive data from table tag
            /*
           string temp1 = "SELECT * FROM PostTags WHERE PostID =@post_ID";

            //string queryString1 = string.Format(temp1, post_ID.ToString());
            SqlCommand command1 = new SqlCommand(temp1, myConnection);
            command1.Parameters.AddWithValue("@post_ID", post_ID);

            SqlDataReader reader1 = command1.ExecuteReader();

            string tags = reader1["Tag"].ToString();
            */
            // TODO: I guess we dont need tags to be saved within the post
            Post myPost = new Post(ID, url, null, null, text, likes, null);




            reader.Close();
            //reader1.Close();
            myConnection.Close();
            return myPost;
            

        }
        /// <summary>
        /// Adds a new tag to the Tag list, but there can only be 5 tags for each post.
        /// </summary>
        /// <param name="newTag"></param>
      /*  public void addNewTag(string newTag)
        {
            if(Tags.Count <= 5)
            {
                Tags.Add(newTag);
            }
            else
            {
                Console.WriteLine("CANNOT ADD MORE THAN 5 TAGS");
            }
        }*/

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
       /* public string removeTag(string tagToRemove)
        {
            if(!Tags.Any())
            {
                return "";
            }
            string takingOut = Tags.ElementAt(Tags.IndexOf(tagToRemove));
            Tags.RemoveAt(Tags.IndexOf(tagToRemove));
            return takingOut;
        }*/
        #endregion
    }
}
