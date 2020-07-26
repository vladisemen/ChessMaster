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
    public partial class FormGame : Form
    {
        Color colorBtn;
        private ChessFigure pFig = null; // наша фигура
        private bool ActiveFigur;// ждет ли хода
        private List<Button> buttons = new List<Button>();// создаем массив кнопок
        private List<Button> buttonsWF = new List<Button>();// создаем массив кнопок белых фигур
        private List<Button> buttonsBF = new List<Button>();// создаем массив кнопок черных фигур
        Button buttonDel;
        private string path; // ссылка на картинку
        private ChessBoard _chessBoard;
        public FormGame()
        {
            InitializeComponent();
            _chessBoard = new ChessBoard(); // создаем доску
            h_Render_learn();
            this.WindowState = FormWindowState.Maximized;//форма во весь экран

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void h_hod(Button button) // ход фигуры
        {
            var pO = button.Tag;
            var field = pO as Field; // это поле
            int x_t = field.Position.X; // позиция фигуры 
            int y_t = field.Position.Y;// позиция фигуры
            ArrayList Arr = null;
            if (field.Figure is TureChessFigure)
            {
                var Field1 = field.Figure as TureChessFigure; // ладья 
                Arr = Field1.Hod(x_t, y_t, _chessBoard.Fields, Field1.Color); // все возможные ходы ладьи
            }
            else if (field.Figure is BishopChessFigure)
            {
                var Field1 = field.Figure as BishopChessFigure; // слон 
                Arr = Field1.Hod(x_t, y_t, _chessBoard.Fields, Field1.Color); // все возможные ходы слона
            }
            else if (field.Figure is KingChessFigure)
            {
                var Field1 = field.Figure as KingChessFigure; // король 
                Arr = Field1.KingHod(x_t, y_t); // все возможные ходы короля
            }
            else if (field.Figure is QueenChessFigure)
            {
                var Field1 = field.Figure as QueenChessFigure; // ферзь 
                Arr = Field1.Hod(x_t, y_t, _chessBoard.Fields, Field1.Color); // все возможные ходы ферзя
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
            if (Arr != null) // если массив не пуст, то добавляем возможным для хода ячекам активное состояние
            {
                ActiveFigur = true;// фигура выбрана. ждем хода
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
        private void h_Render_learn() // Метод отрисовки формы(доска и вспомогательное)
        {
            ChessFigure chessFigure;//фигура для добавления фигур к кнопкам выбора
            ActiveFigur = false; // фигура не активна (ее еще вообще нет))))
            //КАКОЙ РАЗМЕР КНОПОК- ТАКОЙ РАЗМЕР И КАРТИНОК ФИГУР!!!
            const int ButtonWidth = 80;
            const int ButtonHeight = 80;
            const int ButtonPadding = 5;
            Button pB;
            // panel1.Controls.Clear();
            foreach (Field pF in _chessBoard.Fields)  //цикл построения доски()
            {
                pB = new Button();
                int iX = pF.Position.X * (ButtonWidth + ButtonPadding);
                int iY = (ChessBoard.Height - pF.Position.Y) * (ButtonHeight + ButtonPadding);
                pB.Width = ButtonWidth;
                pB.Height = ButtonHeight;
                pB.Location = new Point(iX, iY);
                pB.BackColor = pF.Color == EChessColor.Black ? Color.Chocolate : Color.Beige;
                pB.Parent = panel1;
                pB.Tag = pF; // добавляем тэг
                pB.Click += h_onPBOnClick;  // добавляем метод клика
                buttons.Add(pB); // добавили кнопку в массив кнопок
            }
            for (int i = 0; i < 8; i++)
            {

            }
            #region кнопочки с фигурами
            for (int i = 0; i < 6; i++)
            {
                pB = new Button();
                pB.Width = ButtonWidth;
                pB.Height = ButtonHeight;
                pB.Location = new Point(750 + i * (ButtonWidth + ButtonPadding), 85);
                pB.Parent = panel1;
                switch (i)
                {
                    case 0:
                        chessFigure = new SimpleChessFigure(EChessColor.White);
                        break;
                    case 1:
                        chessFigure = new TureChessFigure(EChessColor.White);
                        break;
                    case 2:
                        chessFigure = new HorseChessFigure(EChessColor.White);
                        break;
                    case 3:
                        chessFigure = new BishopChessFigure(EChessColor.White);
                        break;
                    case 4:
                        chessFigure = new QueenChessFigure(EChessColor.White);
                        break;
                    case 5:
                        chessFigure = new KingChessFigure(EChessColor.White);
                        break;
                    default:
                        chessFigure = new TureChessFigure(EChessColor.White);//такого быть не может, но чтобы не было ошибки надо))
                        break;
                }
                pB.Tag = chessFigure; //запомнили фигуру
                path = _chessBoard.h_image(chessFigure); // ищем нужную ссылку на картинку
                pB.Click += h_onPBFigOnClick;  // добавляем метод клика
                buttonsWF.Add(pB); // добавили кнопку в массив кнопок
                buttonsWF[i].BackgroundImage = Image.FromFile(path, false);
                buttonsWF[i].BackgroundImageLayout = ImageLayout.Center;
            }
            for (int i = 0; i < 6; i++)
            {
                pB = new Button();
                pB.Width = ButtonWidth;
                pB.Height = ButtonHeight;
                pB.Location = new Point(750 + i * (ButtonWidth + ButtonPadding), 185);
                pB.Parent = panel1;
                switch (i)
                {
                    case 0:
                        chessFigure = new SimpleChessFigure(EChessColor.Black);
                        break;
                    case 1:
                        chessFigure = new TureChessFigure(EChessColor.Black);
                        break;
                    case 2:
                        chessFigure = new HorseChessFigure(EChessColor.Black);
                        break;
                    case 3:
                        chessFigure = new BishopChessFigure(EChessColor.Black);
                        break;
                    case 4:
                        chessFigure = new QueenChessFigure(EChessColor.Black);
                        break;
                    case 5:
                        chessFigure = new KingChessFigure(EChessColor.Black);
                        break;
                    default:
                        chessFigure = new TureChessFigure(EChessColor.Black);//такого быть не может, но чтобы не было ошибки надо))
                        break;
                }
                pB.Tag = chessFigure; //запомнили фигуру
                path = _chessBoard.h_image(chessFigure); // ищем нужную ссылку на картинку
                pB.Click += h_onPBFigOnClick;  // добавляем метод клика
                buttonsBF.Add(pB); // добавили кнопку в массив кнопок
                buttonsBF[i].BackgroundImage = Image.FromFile(path, false);
                buttonsBF[i].BackgroundImageLayout = ImageLayout.Center;
            }
            #endregion
            #region кнопочка очистить
            buttonDel = new Button();
            buttonDel.Width = ButtonWidth;
            buttonDel.Height = ButtonHeight;
            buttonDel.Location = new Point(900, 300);
            buttonDel.Click += h_onPBCressOnClick;  // добавляем метод клика
            buttonDel.Parent = panel1;
            path = System.IO.Path.GetFullPath(@"картинки\cross.png");
            buttonDel.BackgroundImage = Image.FromFile(path, false);
            buttonDel.BackgroundImageLayout = ImageLayout.Center;
            #endregion
            #region очистить доску
            pB = new Button();
            pB.Width = ButtonWidth+100;
            pB.Height = ButtonHeight;
            pB.Location = new Point(1100, 300);
            pB.Text = "Очистить поле";
            pB.Click += h_onPBClearOnClick;  // добавляем метод клика
            pB.Parent = panel1;
            #endregion
            #region циклы для букв и чесел 
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
            colorBtn = pB.BackColor; //я не знаю какой у кнопки цвет))

        }

        private void h_onPBClearOnClick(object sender, EventArgs e) //очистить доску
        {
            _chessBoard.h_FullFieldsClear();
        //    _chessBoard.h_FullFieldsNoActive();
            foreach (var btn in buttons)
            {
                btn.BackgroundImage = null;
            }
            foreach (Field pF in _chessBoard.Fields)
            {
                int rrr;
                if (pF.Active)
                {
                    pF.Active = false;
                    rrr = ChessFigure.coords_to_position(pF.Position.X, pF.Position.Y); // вызываем статический метод 
                    buttons[rrr].BackColor = pF.Color == EChessColor.Black ? Color.Chocolate : Color.Beige;
                }
            }
        }

        private void h_onPBCressOnClick(object sender, EventArgs e) // конопка крестика
        {
            foreach (var btnbtn in buttonsWF)
            {
                btnbtn.BackColor = colorBtn;// подкрасили ее
            }
            foreach (var btnbtn in buttonsBF)
            {
                btnbtn.BackColor = colorBtn;// подкрасили ее
            }
            pFig = null; // наша фигура
            Button btn = (sender as Button);
            btn.BackColor = Color.Aquamarine;// подкрасили ее

        }

        private void h_onPBFigOnClick(object sender, EventArgs e) // кнопки добавления фигур
        {
            buttonDel.BackColor = colorBtn;
            foreach (var btnbtn in buttonsWF)
            {
                btnbtn.BackColor = colorBtn;// подкрасили ее
            }
            foreach (var btnbtn in buttonsBF)
            {
                btnbtn.BackColor = colorBtn;// подкрасили ее
            }
            Button btn = (sender as Button);
            var pO = btn.Tag;
            pFig = pO as ChessFigure; // это фигурка (запомнили ее в глобальную)
            btn.BackColor = Color.OrangeRed;// подкрасили ее
        }

        private void h_onPBOnClick(object sender, EventArgs args) //метод клика на поле
        {
            Button btn = (sender as Button);
            var pO = btn.Tag;
            Field field = pO as Field; // это поле

            if (pFig == null) // если не выбрана фигура для добавления, то будем чистить)
            {

                h_hod(btn);
              //  field.Figure = null;
              //  btn.BackgroundImage = null;
              //  btn.Tag = field;
                return;
            }
            field.Figure = pFig; //поставили фигуру
            btn.Tag = field; // добавляем тэг

            path = _chessBoard.h_image(pFig); // ищем нужную ссылку на картинку
            btn.BackgroundImage = Image.FromFile(path, false);
            btn.BackgroundImageLayout = ImageLayout.Center;
        }

    }
}
