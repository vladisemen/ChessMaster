using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster
{
    /// <summary>
    /// Положение игры
    /// </summary>
    public enum EGameProperty
    {
        /// <summary>
        /// ход белых
        /// </summary>
        WhiteHod,
        /// <summary>
        /// выбрана фигура для хода
        /// </summary>
        WhiteHodCheck,
        /// <summary>
        /// ход черных
        /// </summary>
        BlackHod,
        /// <summary>
        /// выбрана фигура для хода
        /// </summary>
        BlackHodCheck,
        /// <summary>
        /// шах белым
        /// </summary>
        CheckWhite,
        /// <summary>
        /// шах черным
        /// </summary>
        CheckBlack,
        /// <summary>
        /// конец игры
        /// </summary>
        EndGame
    }

}
