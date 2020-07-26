using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster.Фигуры
{
    /// <summary>
    /// Лошадь
    /// </summary>
    public class HorseChessFigure : ChessFigure
    {
        public HorseChessFigure(EChessColor color) : base(color)
        {
        }
        internal ArrayList HorseHod(int x, int y)
        {
            ArrayList array = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(i - x) * Math.Abs(j - y) == 2)
                    {
                        int p = coords_to_position(i, j);
                        array.Add(p);
                    }
                }

            }
            return array;
        }
    }
}