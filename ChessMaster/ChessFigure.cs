using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster
{

    /// <summary>
    /// Шахматной фигуры
    /// </summary>
    public class ChessFigure
    {
        /// <summary>
        /// Активная фигура
        /// </summary>
        public bool ActiveFig { get; set; }

        public static int coords_to_position(int x, int y)
        {
            return x * 8 + y;
        }
        public static void position_to_coords(int i_position, out int x, out int y)
        {
            x = i_position % 8;
            y = i_position / 8;
        }
        #region public properties

        /// <summary>
        /// Цвет фигуры
        /// </summary>
        public EChessColor Color { get; }
        #endregion
        #region constructors
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="color"></param>
        public ChessFigure(EChessColor color)
        {
            Color = color;
        }
        #endregion

    }
}
