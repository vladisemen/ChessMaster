using ChessMaster.Фигуры;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessMaster
{
    public partial class ChessForm : Form
    {
        private List<Button> buttons = new List<Button>();// создаем массив кнопок
        private string path; // ссылка на картинку
        private ChessBoard _chessBoard; // наша доска
        private bool b_AF = false; // фигура не выбрана

        public ChessForm()
        {
            InitializeComponent();
            _chessBoard = new ChessBoard(); // создаем доску
            _chessBoard.GameProperty = EGameProperty.WhiteHod; // инициализация что ход белых вначале 
            h_Render();
            this.WindowState = FormWindowState.Maximized;//форма во весь экран
        }
        private void h_hod(Button button)
        {
            var pO = button.Tag;
            var field = pO as Field; // это поле
            int x_t = field.Position.X; // позиция фигуры 
            int y_t = field.Position.Y;// позиция фигуры
            ArrayList Arr = null;
            EChessColor eChessColor = field.Figure.Color; // запомнили цвет фигуры для отправки в класс
            if (field.Figure is TureChessFigure)
            {
                var Field1 = field.Figure as TureChessFigure; // ладья 
                Arr = Field1.Hod(x_t, y_t, _chessBoard.Fields, eChessColor); // все возможные ходы ладьи
            }
            else if (field.Figure is BishopChessFigure)
            {
                var Field1 = field.Figure as BishopChessFigure; // слон 
                Arr = Field1.Hod(x_t, y_t, _chessBoard.Fields,eChessColor); // все возможные ходы слона
            }
            else if (field.Figure is KingChessFigure)
            {
                var Field1 = field.Figure as KingChessFigure; // король 
                Arr = Field1.KingHod(x_t, y_t); // все возможные ходы короля
            }
            else if (field.Figure is QueenChessFigure)
            {
                var Field1 = field.Figure as QueenChessFigure; // ферзь 
                Arr = Field1.Hod(x_t, y_t, _chessBoard.Fields,eChessColor); // все возможные ходы ферзя
            }
            else if (field.Figure is HorseChessFigure)
            {
                var Field1 = field.Figure as HorseChessFigure; // конь 
                Arr = Field1.HorseHod(x_t, y_t); // все возможные ходы коня
            }
            else if (field.Figure is SimpleChessFigure)
            {
                var Field1 = field.Figure as SimpleChessFigure; // пешка 
                Arr = Field1.SimpleHod(x_t, y_t, Field1.Color); // все возможные ходы пешки
            }
            if (Arr != null) // если массив не пуст, то показываем возможные ходы
            {
                _chessBoard.FieldActive(Arr);
                foreach (var field1 in _chessBoard.Fields)
                {
                    if (field1.Active)
                    {
                        int x = field1.Position.X;
                        int y = field1.Position.Y;
                        int rrr = ChessFigure.coords_to_position(x, y); // вызываем статический метод 
                        buttons[rrr].BackColor = Color.Blue;

                    }
                }
            }
        }
        private void h_Render()
        {
            _chessBoard.h_FillFigures(); // добавляем фигуры
            //КАКОЙ РАЗМЕР КНОПОК- ТАКОЙ РАЗМЕР И КАРТИНОК ФИГУР!!!
            const int ButtonWidth = 80;
            const int ButtonHeight = 80;
            const int ButtonPadding = 5;
            panel1.Controls.Clear();
            foreach (Field pF in _chessBoard.Fields)  //цикл построения доски()
            {
                Button pB = new Button();
                int iX = pF.Position.X * (ButtonWidth + ButtonPadding);
                int iY = (ChessBoard.Height - pF.Position.Y) * (ButtonHeight + ButtonPadding);
                pB.Width = ButtonWidth;
                pB.Height = ButtonHeight;
                pB.Location = new Point(iX, iY);
                pB.BackColor = pF.Color == EChessColor.Black ? Color.Chocolate : Color.Beige;
                path = _chessBoard.h_image(pF.Figure); // ищем нужную ссылку на картинку
                pB.Tag = pF; // добавляем тэг
                if (pF.Figure != null) // если нет фигуры- отрисовывать и нечего))
                {
                    pB.BackgroundImage = Image.FromFile(path, false);
                    pB.BackgroundImageLayout = ImageLayout.Center;
                }
                pB.Parent = panel1;
                pB.Click += h_onPBOnClick;  // добавляем метод клика
                buttons.Add(pB); // добавили кнопку в массив кнопок
            }
            #region циклы для букв и чисел 
            for (int i = 0; i < 8; i++)
            {
                Label label = new Label();
                label.Font = new Font(label.Font.FontFamily, 15, label.Font.Style);
                label.Text = (i + 1).ToString();
                label.Parent = panel1;
                label.Location = new Point(690, 706 - i * 85);
            }
            string str;
            for (int i = 0; i < 8; i++)
            {
                Label label = new Label();
                label.Font = new Font(label.Font.FontFamily, 15, label.Font.Style);
                str = Field.InttoStr(i).ToString();
                label.Text = str;
                label.Parent = panel1;
                label.Location = new Point(21 + i * 85, 770);
            }
            #endregion
        }
        private void h_onPBOnClick(object sender, EventArgs args)
        {
            Button btn = (sender as Button);
            //здесь проверка на то выбрана ли фигура для хода!!!
            if (b_AF)//фигура выбрана
            {

            }
            else // фигура не выбрана
            {
                
                h_hod(btn);
            }

        }
    }
}
