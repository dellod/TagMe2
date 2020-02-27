using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // Used for string builder
using System.Threading.Tasks;

namespace TagMe2.Models
{
    public class User
    {
        private const int encryptionValue = 6; // Used for encryption of passwords

        #region Properties
        public Guid ID
        {
            get; set;
        }
        public string Username
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public Profile UserProfile
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (necessary for deserialization).
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="f"></param>
        /// <param name="l"></param>
        public User(Guid id, string u, string f, string l, Profile p)
        {
            ID = id;
            Username = u;
            FirstName = f;
            LastName = l;
            UserProfile = p;
        }

        public User(User instance) : this(instance.ID, instance.Username, instance.FirstName, instance.LastName, instance.UserProfile)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// This method will encrypt passwords with static encryption value given the original 
        /// password and will return the newly encrypted password.
        /// </summary>
        /// <param name="pass"> Original password before encryption </param>
        /// <returns> Encrypted password </returns>
        public string encryptPassword(string pass)
        {
            string encryptedPassword;
            var builder = new StringBuilder();
            for (int i = 0; i < pass.Length; i++)
            {
                char c = pass[i];
                c += (char)encryptionValue;
                builder.Append(c);
            }
            encryptedPassword = builder.ToString();
            return encryptedPassword;
        }
        /// <summary>
        /// Decrypts a password given an encrypted password and will return the orginal 
        /// password.
        /// </summary>
        /// <param name="encryptedPass"> An encrypted password </param>
        /// <returns> Original password </returns>
        public string decryptPassword(string encryptedPass)
        {
            string orginalPassword;
            var builder = new StringBuilder();
            for (int i = 0; i < encryptedPass.Length; i++)
            {
                char c = encryptedPass[i];
                c -= (char)encryptionValue;
                builder.Append(c);
            }
            orginalPassword = builder.ToString();
            return orginalPassword;
        }

        public User queryUser(string user) // assuming usernames are unique
        {
            return null;
            // NEED TO GET FROM DATABASE
        }

        public bool addNewUser(User user)
        {
            //TODO: first check if username exists in database first
            return false;
        }
        #endregion
    }
}