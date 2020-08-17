using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessMaster
{
    /// <summary>
    /// интерфейс для клонирования объектов
    /// </summary>
    public interface ICloneable
    {
        object Clone();
    }
    public class Field
    {
        /// <summary>
        /// метод для клонирования объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #region public properties

        /// <summary>
        /// - цвет
        /// </summary>
        public EChessColor Color { get; }
        ///      - координаты
        public Coord Position { get; }

        //    - фигура
        public ChessFigure Figure { get; set; }
        /// <summary>
        /// Поле активно для хода
        /// </summary>
        public bool Active { get; set; }
        #endregion

        #region constructors
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="color"></param>
        /// <param name="position"></param>
        /// <param name="figure"></param>
        public Field(EChessColor color, Coord position, ChessFigure figure, bool active)
        {
            Color = color;
            Position = position;
            Figure = figure;
            Active = active;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Моя ли позиция
        /// </summary>
        /// <param name="iX"></param>
        /// <param name="iY"></param>
        /// <returns></returns>
        public bool IsPosition(int iX, int iY)
        {
            return (Position.X == iX && Position.Y == iY);
        }
        #endregion
        public static int StrToInt(string str)
        {
            int num=0;
            switch (str)
            {
                case "A":
                    num = 1;
                    return num;
                case "B":
                    num = 2;
                    return num;
                case "C":
                    num = 3;
                    return num;
                case "D":
                    num = 4;
                    return num;
                case "E":
                    num = 5;
                    return num;
                case "F":
                    num = 6;
                    return num;
                case "G":
                    num = 7;
                    return num;
                case "H":
                    num = 8;
                    return num;
                default:
                    return 1;
            }
        }
        public static string InttoStr(int num)
        {
            string str = "";
            switch (num)
            {
                case 0:
                    str =  "  A  ";
                    return str;
                case 1:
                    str = "  B  ";
                    return str;
                case 2:
                    str =  "  C  ";
                    return str;
                case 3:
                    str = "  D  ";
                    return str;
                case 4:
                    str = "  E  ";
                    return str;
                case 5:
                    str = "  F  ";
                    return str;
                case 6:
                    str = "  G  ";
                    return str;
                case 7:
                    str = "  H  ";
                    return str;
                default:
                    return "";
            }
        }
    }
}
