using ChessMaster.Фигуры;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChessMaster
{
    public partial class Form2 : Form
    {
        private ChessFigure pFig = null; // наша фигура
        // Create an instance of the ListBox.
        private ComboBox ChessFigursComboBox = new ComboBox();
        private ComboBox ChessFigurColorComboBox = new ComboBox();
        private ComboBox ChessFigureCoordX = new ComboBox();
        private ComboBox ChessFigureCoordY = new ComboBox();

        private bool ActiveFigur;// ждет ли хода
        private List<Button> buttons = new List<Button>();// создаем массив кнопок
        private string path; // ссылка на картинку
        private ChessBoard _chessBoard;
        public Form2()
        {
            InitializeComponent();
            _chessBoard = new ChessBoard(); // создаем доску
            h_Render_learn();
            this.WindowState = FormWindowState.Maximized;//форма во весь экран
        }

        private void Form2_Load(object sender, EventArgs e)
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
                Arr = Field1.TureHod(x_t, y_t); // все возможные ходы ладьи
            }
            else if (field.Figure is BishopChessFigure)
            {
                var Field1 = field.Figure as BishopChessFigure; // слон 
                Arr = Field1.BishopHod(x_t, y_t); // все возможные ходы слона
            }
            else if (field.Figure is KingChessFigure)
            {
                var Field1 = field.Figure as KingChessFigure; // король 
                Arr = Field1.KingHod(x_t, y_t); // все возможные ходы короля
            }
            else if (field.Figure is QueenChessFigure)
            {
                var Field1 = field.Figure as QueenChessFigure; // ферзь 
                Arr = Field1.QueenHod(x_t, y_t); // все возможные ходы ферзя
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
            ActiveFigur = false; // фигура не активна (ее еще вообще нет))))
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
                pB.Parent = panel1;
                pB.Tag = pF; // добавляем тэг
                pB.Click += h_onPBOnClick;  // добавляем метод клика
                buttons.Add(pB); // добавили кнопку в массив кнопок
            }
            #region фигурки ComboBox
            // Set the size and location of the ListBox.
            ChessFigursComboBox.Size = new System.Drawing.Size(200, 100);
            ChessFigursComboBox.Location = new System.Drawing.Point(10, 10);
            ChessFigursComboBox.Parent = panel1; // листбокс поверх panel           
            ChessFigursComboBox.Items.Add("Король");
            ChessFigursComboBox.Items.Add("Ферзь");
            ChessFigursComboBox.Items.Add("Слон");
            ChessFigursComboBox.Items.Add("Конь");
            ChessFigursComboBox.Items.Add("Ладья");
            ChessFigursComboBox.Items.Add("Пешка");
            ChessFigursComboBox.Text = "Пешка";
            #endregion
            #region Цвет фигурки ComboBox
            // Set the size and location of the ListBox.
            ChessFigurColorComboBox.Size = new System.Drawing.Size(200, 100);
            ChessFigurColorComboBox.Location = new System.Drawing.Point(300, 10);
            ChessFigurColorComboBox.Parent = panel1; // листбокс поверх panel           
            ChessFigurColorComboBox.Items.Add("Белый");
            ChessFigurColorComboBox.Items.Add("Черный");
            ChessFigurColorComboBox.Text = "Белый";
            #endregion
            #region Конпка
            Button button = new Button();
            button.Size = new System.Drawing.Size(190, 50);
            button.Location = new System.Drawing.Point(1000, 10);
            button.Parent = panel1; // листбокс поверх panel   
            button.Text = "Добавить";
            button.Click += h_onPB1Click;  // добавляем метод клика
            #endregion
            #region Координата X
            // Set the size and location of the ListBox.
            ChessFigureCoordX.Size = new System.Drawing.Size(200, 100);
            ChessFigureCoordX.Location = new System.Drawing.Point(550, 10);
            ChessFigureCoordX.Parent = panel1; // листбокс поверх panel           
            ChessFigureCoordX.Items.Add("A");
            ChessFigureCoordX.Items.Add("B");
            ChessFigureCoordX.Items.Add("C");
            ChessFigureCoordX.Items.Add("D");
            ChessFigureCoordX.Items.Add("E");
            ChessFigureCoordX.Items.Add("F");
            ChessFigureCoordX.Items.Add("G");
            ChessFigureCoordX.Items.Add("H");
            ChessFigureCoordX.Text = "A";
            #endregion
            #region Координата Y
            // Set the size and location of the ListBox.
            ChessFigureCoordY.Size = new System.Drawing.Size(200, 100);
            ChessFigureCoordY.Location = new System.Drawing.Point(750, 10);
            ChessFigureCoordY.Parent = panel1; // листбокс поверх panel           
            ChessFigureCoordY.Items.Add("1");
            ChessFigureCoordY.Items.Add("2");
            ChessFigureCoordY.Items.Add("3");
            ChessFigureCoordY.Items.Add("4");
            ChessFigureCoordY.Items.Add("5");
            ChessFigureCoordY.Items.Add("6");
            ChessFigureCoordY.Items.Add("7");
            ChessFigureCoordY.Items.Add("8");
            ChessFigureCoordY.Text = "1";
            #endregion
            #region Запрет ввода значений в комбобоксы
            ChessFigursComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ChessFigurColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ChessFigureCoordX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ChessFigureCoordY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        }

        private void h_onPB1Click(object sender, EventArgs e) // копка создания фигуры
        {
            ActiveFigur = false;
            string ColorFig;
            string NameFig;
            foreach (Field pF in _chessBoard.Fields)
            {
                int rrr;
                if (pF.Active)
                {
                    pF.Active = false;
                    rrr = ChessFigure.coords_to_position(pF.Position.X, pF.Position.Y); // вызываем статический метод 
                    buttons[rrr].BackColor = pF.Color == EChessColor.Black ? Color.Chocolate : Color.Beige;
                }
                if (pF.Figure != null) //нашли фигуру
                {
                    rrr = ChessFigure.coords_to_position(pF.Position.X, pF.Position.Y); // вызываем статический метод 
                    buttons[rrr].BackgroundImage = null;
                    pF.Figure = null; // Здесь нужен деструктор???
                }
            }
            ColorFig = ChessFigurColorComboBox.Text.ToString();
            NameFig = ChessFigursComboBox.Text;
            pFig = _chessBoard.FindFigure(NameFig, ColorFig); // вызвали метод поиска фигуры
            string srtx = ChessFigureCoordX.Text.ToString();
            int numx = Field.StrToInt(srtx) - 1;
            int numy = Convert.ToInt32(ChessFigureCoordY.Text) - 1;
            int num = ChessFigure.coords_to_position(numx, numy);
            _chessBoard.Fields[num].Figure = pFig;
            path = _chessBoard.h_image(pFig); // ищем нужную ссылку на картинку
            buttons[num].Tag = _chessBoard.Fields[num]; // добавляем тэг
            buttons[num].BackgroundImage = Image.FromFile(path, false);
            buttons[num].BackgroundImageLayout = ImageLayout.Center;
        }

        private void h_onPBOnClick(object sender, EventArgs args) //метод клика на поле
        {
            if (pFig == null) //нам нужна фигура!
            {
                return;
            }
            Button btn = (sender as Button);
            var pO = btn.Tag;
            Field field = pO as Field; // это поле

            if (ActiveFigur) //фигура выбрана и ждет хода
            {

            }
            else //фигура не выбрана
            {
                h_hod(btn);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
