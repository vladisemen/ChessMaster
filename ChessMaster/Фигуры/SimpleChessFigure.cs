using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster.Фигуры
{
    /// <summary>
    /// Пешка
    /// </summary>
    public class SimpleChessFigure : ChessFigure
    {
        public SimpleChessFigure(EChessColor color) : base(color)
        {
        }

        internal ArrayList SimpleHod(int x, int y, EChessColor Color)
        {
            ArrayList array = new ArrayList();
            string color = Color.ToString();
            if (color == "White")
            {
                if (y == 1) // если начальная позиция
                {
                    for (int i = 0; i < 2; i++)
                    {
                        y++;
                        int p = coords_to_position(x, y);
                        array.Add(p);
                    }
                }
                else
                {
                    y++;
                    int p = coords_to_position(x, y);
                    array.Add(p);
                }
            }
            else if (color == "Black")
            {
                if (y == 6) // если начальная позиция
                {
                    for (int i = 0; i < 2; i++)
                    {
                        y--;
                        int p = coords_to_position(x, y);
                        array.Add(p);
                    }
                }
                else
                {
                    y--;
                    int p = coords_to_position(x, y);
                    array.Add(p);
                }
            }
            else
            {
                return null;
            }
            return array;
        }

    }
}
