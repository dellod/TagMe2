using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models
{
    public class Profile
    {
        #region Properties
        public Address Location
        {
            get; set;
        }

        public string ProfilePictureURL
        {
            get; set;
        }

        public List<string> FavouriteTags
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Profile()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="ppurl"></param>
        /// <param name="favourites"></param>
        public Profile(Address location, string ppurl, List<string> favourites)
        {
            Location = location;
            ProfilePictureURL = ppurl;
            FavouriteTags = favourites;
        }

        /// <summary>
        /// Field constructor that makes a new profile, with an emtpy favourites list.
        /// </summary>
        /// <param name="locaiton"></param>
        /// <param name="ppurl"></param>
        public Profile(Address locaiton, string ppurl)
        {
            Location = Location;
            ProfilePictureURL = ppurl;
            FavouriteTags = new List<string>();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="instance"></param>
        public Profile(Profile instance) : this(instance.Location, instance.ProfilePictureURL, instance.FavouriteTags)
        {

        }
        #endregion


    }
}
