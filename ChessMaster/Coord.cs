using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster
{
    /// <summary>
    /// Координата
    /// </summary>
    public class Coord
    {

        #region .ctors

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion


        #region private consts

        private const string CoordNames = "ABCDEFGH";

        #endregion

        #region public properties

        /// <summary>
        /// X
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Отображение координаты Х
        /// </summary>
        public string NameX
        {
            get
            {
                return CoordNames[X - 1].ToString();
            }
        }
        /// <summary>
        /// Отображение координаты Х
        /// </summary>
        public string NameY => (Y - 1).ToString();

        /// <summary>
        /// Y
        /// </summary>
        public int Y { get; set; }
        


        #endregion
    }
}
