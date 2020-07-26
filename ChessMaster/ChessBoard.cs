
using ChessMaster.Фигуры;
using System;
using System.Collections;
using System.Collections.Generic;

/*
 * Шахматы
 *  1. Шахматная доска
 *      -[] полей
 *      2. Поле шахмотной доски
 *        - активность
 *        - цвет
 *        - координата
 *        - фигура
 *           3. Фигура поля шахматной доски
 *                 
 *                 - цвет фигуры 
             *           3.1. Конь - фигура (наследник)
             *           3.2. Пешка - фигура (наследник)
             *           3.3. Ладья - фигура (наследник)
             *           3.4. Слон - фигура (наследник)
             *           3.5. Король - фигура (наследник)
             *           3.6. Ферзь - фигура (наследник)
 */

namespace ChessMaster
{
    public class ChessBoard
    {
        #region private members

        public const int Width = 8;
        public const int Height = 8;

        public List<Field> Fields { get; }
        public EGameProperty GameProperty { get; set; }

        #endregion


        #region constructors

        public ChessBoard()
        {
            Fields = new List<Field>(); // массив полей
            h_Fill();  // заполняем массив полей
        }

        #endregion

        /// <summary>
        /// из массива полей делает их активными на доске
        /// </summary>
        /// <param name="Arr"> Массив индексов нужных нам полей</param>
        public void FieldActive(ArrayList Arr) 
        {
            foreach (int s in Arr)
            {
                Fields[s].Active = true;
            }
        }

        private Field h_FindField(int X, int Y)
        {
            for (int ii = 0; ii < Fields.Count; ii++)
            {
                Field pF = Fields[ii];
                if (pF.IsPosition(X, Y))
                {
                    return pF;
                }
            }
            return null;
        }

        public void h_FillFigures() // добавление всех и фигур и расстановка для игры
        {
            #region заполнение белых пешек
            for (int ii = 0; ii < Width; ii++)
            {
                SimpleChessFigure pFig = new SimpleChessFigure(EChessColor.White);
                h_SetFigure(pFig, ii, 1);
            }
            #endregion

            #region заполнение черных пешек
            for (int ii = 0; ii < Width; ii++)
            {
                SimpleChessFigure pFig = new SimpleChessFigure(EChessColor.Black);
                h_SetFigure(pFig, ii, 6);
            }
            #endregion

            #region заполнение коников
            HorseChessFigure pHorseFig1 = new HorseChessFigure(EChessColor.White); //белый
            h_SetFigure(pHorseFig1, 1, 0);

            HorseChessFigure pHorseFig2 = new HorseChessFigure(EChessColor.White); //белый
            h_SetFigure(pHorseFig2, 6, 0);
            HorseChessFigure pHorseFig3 = new HorseChessFigure(EChessColor.Black); //черный
            h_SetFigure(pHorseFig3, 1, 7);
            HorseChessFigure pHorseFig4 = new HorseChessFigure(EChessColor.Black); //черный
            h_SetFigure(pHorseFig4, 6, 7);
            #endregion

            #region заполнение ладей
            TureChessFigure pTureFig3 = new TureChessFigure(EChessColor.Black); //черный
            h_SetFigure(pTureFig3, 0, 7);
            TureChessFigure pTureFig4 = new TureChessFigure(EChessColor.Black); //черный
            h_SetFigure(pTureFig4, 7, 7);
            TureChessFigure pTureFig1 = new TureChessFigure(EChessColor.White); //белый
            h_SetFigure(pTureFig1, 0, 0);
            TureChessFigure pTureFig2 = new TureChessFigure(EChessColor.White); //белый
            h_SetFigure(pTureFig2, 7, 0);
            #endregion

            #region заполнение слоников
            BishopChessFigure pBishopFig1 = new BishopChessFigure(EChessColor.White); //белый
            h_SetFigure(pBishopFig1, 2, 0);

            BishopChessFigure pBishopFig2 = new BishopChessFigure(EChessColor.White); //белый
            h_SetFigure(pBishopFig2, 5, 0);
            BishopChessFigure pBishopFig3 = new BishopChessFigure(EChessColor.Black); //черный
            h_SetFigure(pBishopFig3, 2, 7);
            BishopChessFigure pBishopFig4 = new BishopChessFigure(EChessColor.Black); //черный
            h_SetFigure(pBishopFig4, 5, 7);
            #endregion

            #region заполнение ферзей
            QueenChessFigure pQueenFig1 = new QueenChessFigure(EChessColor.White); //белый
            h_SetFigure(pQueenFig1, 3, 0);
            QueenChessFigure pQueenFig2 = new QueenChessFigure(EChessColor.Black); //черный
            h_SetFigure(pQueenFig2, 3, 7);
            #endregion

            #region заполнение королей
            KingChessFigure pKingFig1 = new KingChessFigure(EChessColor.White); //белый
            h_SetFigure(pKingFig1, 4, 0);
            KingChessFigure pKingFig2 = new KingChessFigure(EChessColor.Black); //черный
            h_SetFigure(pKingFig2, 4, 7);
            #endregion
        }

        /// <summary>
        /// ищет ссылку на картинку фигуры
        /// </summary>
        /// <param name="figure">имя фигуры</param>
        /// <returns></returns>
        internal string h_image(ChessFigure figure)
        {
            string path="";
            if ((figure is SimpleChessFigure)) // пешки белые или черные
            {
                if (Convert.ToInt32(figure.Color) == 1)
                {
                    path = System.IO.Path.GetFullPath(@"картинки\wP.png");
                }
                else
                {
                    path = System.IO.Path.GetFullPath(@"картинки\bP.png");
                }

            }
            else if (figure is HorseChessFigure)
            {
                if (Convert.ToInt32(figure.Color) == 1)
                {
                    path = System.IO.Path.GetFullPath(@"картинки\wN.png");
                }
                else
                {
                    path = System.IO.Path.GetFullPath(@"картинки\bN.png");
                }
            }
            else if (figure is TureChessFigure)
            {
                if (Convert.ToInt32(figure.Color) == 1)
                {
                    path = System.IO.Path.GetFullPath(@"картинки\wR.png");
                }
                else
                {
                    path = System.IO.Path.GetFullPath(@"картинки\bR.png");
                }
            }
            else if (figure is BishopChessFigure)
            {
                if (Convert.ToInt32(figure.Color) == 1)
                {
                    path = System.IO.Path.GetFullPath(@"картинки\wB.png");
                }
                else
                {
                    path = System.IO.Path.GetFullPath(@"картинки\bB.png");
                }
            }
            else if (figure is QueenChessFigure)
            {
                if (Convert.ToInt32(figure.Color) == 1)
                {
                    path = System.IO.Path.GetFullPath(@"картинки\wQ.png");
                }
                else
                {
                    path = System.IO.Path.GetFullPath(@"картинки\bQ.png");
                }
            }
            else if (figure is KingChessFigure)
            {
                if (Convert.ToInt32(figure.Color) == 1)
                {
                    path = System.IO.Path.GetFullPath(@"картинки\wK.png");
                }
                else
                {
                    path = System.IO.Path.GetFullPath(@"картинки\bK.png");
                }
            }
            return path;
        }

        /// <summary>
        /// установка фигуры на нужную позицию
        /// </summary>
        /// <param name="pFig">фигура</param>
        /// <param name="iX">x</param>
        /// <param name="iY">y</param>
        internal void h_SetFigure(ChessFigure pFig, int iX, int iY) 
        {
            Field pF = h_FindField(iX, iY);
            if (pF != null)
            {
                pF.Figure = pFig;
            }
        }

        /// <summary>
        /// заполнение массива полей
        /// </summary>
        private void h_Fill() 
        {
            for (int ii = 0; ii < Width; ii++)
            {
                for (int jj = 0; jj < Height; jj++)
                {
                    EChessColor enC = ((ii + jj) % 2 == 1)
                      ? EChessColor.White
                      : EChessColor.Black;

                    Coord pP = new Coord(ii, jj);
                    Field pF = new Field(enC, pP, null, false); // создание экземпляра класса
                    Fields.Add(pF);
                }
            }
        }

        /// <summary>
        /// создает и возвращает фигуру по названию и цвету
        /// </summary>
        /// <param name="NameFig">название</param>
        /// <param name="ColorFig">цвет</param>
        /// <returns></returns>
        public ChessFigure FindFigure(string NameFig, string ColorFig) 
        {
            ChessFigure chessFigure;
            EChessColor color;
            if (ColorFig=="Белый")
            {
                color = EChessColor.White;
            }
            else if (ColorFig == "Черный")
            {
                color = EChessColor.Black;
            }
            else if (true)
            {
                return null;
            }
            switch (NameFig)
            {
                case "Ладья":
                    chessFigure = new TureChessFigure(color);
                    return chessFigure;
                case "Конь":
                    chessFigure = new HorseChessFigure(color);
                    return chessFigure;
                case "Слон":
                    chessFigure = new BishopChessFigure(color);
                    return chessFigure;
                case "Ферзь":
                    chessFigure = new QueenChessFigure(color);
                    return chessFigure;
                case "Король":
                    chessFigure = new KingChessFigure(color);
                    return chessFigure;
                case "Пешка":
                    chessFigure = new SimpleChessFigure(color);
                    return chessFigure;
                default:
                    return null;
            }


        }

        /// <summary>
        /// Пробежался по всем полям и сделал их не активными
        /// </summary>
        public void h_FullFieldsNoActive() 
        {
            foreach (var field in Fields)
            {
                field.Active = false;
            }
        }

        /// <summary> 
        /// Удалить все фигуры с доски
        /// </summary>
        public void h_FullFieldsClear() 
        {
            foreach (var field in Fields)
            {
                field.Figure = null;
            }
        }
    }

}
