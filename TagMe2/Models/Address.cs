using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models
{
    public class Address
    {
        #region Properties
        public string City
        {
            get; set;
        }

        public string Country
        {
            get; set;
        }

        public string ProvinceOrState
        {
            get; set;
        }

        public string Street
        {
            get; set;
        }

        public Coordinate Coordinates
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (necessary for deserialization).
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="co"></param>
        /// <param name="pos"></param>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        public Address(string ci, string co, string pos, double lat, double lon)
        {
            City = ci;
            Country = co;
            ProvinceOrState = pos;
            Coordinates = new Coordinate(lat, lon);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance"></param>
        public Address(Address instance) : this(instance.City, instance.Country, instance.ProvinceOrState, instance.Coordinates.Latitude, instance.Coordinates.Longitude)
        {

        }
        #endregion

    }
}