using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster.Фигуры
{
    /// <summary>
    /// Ферзь
    /// </summary>
    public class QueenChessFigure : ChessFigure
    {
        public QueenChessFigure(EChessColor color) : base(color)
        {
        }
        internal ArrayList Hod(int x, int y, List<Field> Fields, EChessColor eChessColor)
        {
            // x и y  - координаты фигуры сейчас
            int Coord;
            Field firstField = null; // первая найденная равна нулю
                                     // ArrayList A_field = new ArrayList();
            ArrayList A_hod = new ArrayList();
            int i_x = x;
            int i_y = y;
            bool b_Fig = true;
            #region ходы
            while (i_x > 0 && i_y > 0 && b_Fig)
            {
                i_x--;
                i_y--;
                firstField = Fields.Find(p => (p.Position.X == i_x && p.Position.Y == i_y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);
            }
            i_x = x;
            i_y = y;
            b_Fig = true;
            while (i_x < 7 && i_y < 7 && b_Fig)
            {
                i_y++;
                i_x++;
                firstField = Fields.Find(p => (p.Position.X == i_x && p.Position.Y == i_y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);

            }
            i_x = x;
            i_y = y;
            b_Fig = true;
            #endregion
            #region ходы по вертикали
            while (i_y > 0 && i_x < 7 && b_Fig)
            {
                i_y--;
                i_x++;
                firstField = Fields.Find(p => (p.Position.X == i_x && p.Position.Y == i_y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);
            }
            i_y = y;
            i_x = x;
            b_Fig = true;
            while (i_y < 7 && i_x > 0 && b_Fig)
            {
                i_y++;
                i_x--;
                firstField = Fields.Find(p => (p.Position.X == i_x && p.Position.Y == i_y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);
            }
            i_x = x;
            i_y = y;
            b_Fig = true;
            #endregion
            #region ходы по горизонтали
            while (i_x > 0 && b_Fig)
            {
                i_x--;
                firstField = Fields.Find(p => (p.Position.X == i_x && p.Position.Y == y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);
            }
            i_x = x;
            b_Fig = true;
            while (i_x < 7 && b_Fig)
            {
                i_x++;
                firstField = Fields.Find(p => (p.Position.X == i_x && p.Position.Y == y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);

            }
            i_x = x;
            b_Fig = true;
            #endregion
            #region ходы по вертикали
            while (i_y > 0 && b_Fig)
            {
                i_y--;
                firstField = Fields.Find(p => (p.Position.X == x && p.Position.Y == i_y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);
            }
            i_y = y;
            b_Fig = true;
            while (i_y < 7 && b_Fig)
            {
                i_y++;
                firstField = Fields.Find(p => (p.Position.X == x && p.Position.Y == i_y)); // ищем нужную клетку
                if (firstField.Figure != null)
                {
                    b_Fig = false;
                    if (firstField.Figure.Color == eChessColor) // встретилась фигура нашего цвета, то выходим
                    {
                        break;
                    }
                }
                Coord = coords_to_position(firstField.Position.X, firstField.Position.Y);
                A_hod.Add(Coord);
            }
            i_y = y;
            b_Fig = true;
            #endregion
            return A_hod;
        }
        internal ArrayList QueenHod(int x, int y)
        {
            ArrayList array = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(i - x) == Math.Abs(j - y) || i == x || j == y)
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
