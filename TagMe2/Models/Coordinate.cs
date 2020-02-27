using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagMe2.Models
{
    public class Coordinate
    {
        #region Properties
        public double Latitude
        {
            get; set;
        }

        public double Longitude
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (necessary for deserialization).
        /// </summary>
        public Coordinate()
        {
        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="lat"> Latitude argument </param>
        /// <param name="lon"> Longitude argument </param>
        public Coordinate(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance"> Instance that is being copied </param>
        public Coordinate(Coordinate instance) : this(instance.Latitude, instance.Longitude)
        {
        }
        #endregion


    }
}