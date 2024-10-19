namespace StartVormDavidMyrseth
{
    public partial class PildiVaatamine : Form
    {
        string[] pildid = { "Boy.png", "Jesus.png", "Patrick.png", "SpongeBob.png" };
        PictureBox pbox;
        Button JargmineBtn;
        Button TagasiBtn;
        CheckBox chkb;
        Button show;
        Button exit;
        Button backgrn;
        Button close;
        ColorDialog colorDialog;


        public PildiVaatamine(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Pildi vaatamine";

            // PictureBox
            colorDialog = new ColorDialog();
            pbox = new PictureBox();
            pbox.Size = new Size(800, 500);
            pbox.Location = new Point(30, 30);
            pbox.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(pbox);

            // Кнопка "Järgmine"
            JargmineBtn = new Button();
            JargmineBtn.Text = "Järgmine";
            JargmineBtn.BackColor = Color.MediumSeaGreen;  // Заменен цвет
            JargmineBtn.ForeColor = Color.White;
            JargmineBtn.Font = new Font("Arial", 12, FontStyle.Bold);  // Увеличен шрифт
            JargmineBtn.Size = new Size(120, 40);  // Увеличен размер
            JargmineBtn.Location = new Point(50, 550);
            JargmineBtn.Click += JrBtn_Click;
            Controls.Add(JargmineBtn);

            // Кнопка "Eelmine"
            TagasiBtn = new Button();
            TagasiBtn.Text = "Eelmine";
            TagasiBtn.BackColor = Color.MediumSeaGreen;  // Заменен цвет
            TagasiBtn.ForeColor = Color.White;
            TagasiBtn.Font = new Font("Arial", 12, FontStyle.Bold);
            TagasiBtn.Size = new Size(120, 40);
            TagasiBtn.Location = new Point(180, 550);  // Логичное размещение рядом
            TagasiBtn.Click += TgBtn_Click;
            Controls.Add(TagasiBtn);

            // Чекбокс "Venitada"
            chkb = new CheckBox();
            chkb.Checked = false;
            chkb.Text = "Venitada";
            chkb.ForeColor = Color.Black;
            chkb.Font = new Font("Arial", 12, FontStyle.Bold);  // Увеличен шрифт
            chkb.Size = new Size(150, 40);
            chkb.Location = new Point(320, 550);  // Перемещено для большего пространства
            chkb.CheckedChanged += Chk_CheckedChanged;
            Controls.Add(chkb);

            // Кнопка "Näita"
            show = new Button();
            show.Text = "Näita";
            show.BackColor = Color.MediumSeaGreen;
            show.ForeColor = Color.White;
            show.Font = new Font("Arial", 12, FontStyle.Bold);
            show.Size = new Size(120, 40);
            show.Location = new Point(500, 550);
            show.Click += Show_Click;
            Controls.Add(show);

            // Кнопка "Muuta taustavärvi"
            backgrn = new Button();
            backgrn.Text = "Muuta taustavärvi";
            backgrn.BackColor = Color.MediumSeaGreen;
            backgrn.ForeColor = Color.White;
            backgrn.Font = new Font("Arial", 12, FontStyle.Bold);
            backgrn.Size = new Size(200, 40);  // Увеличен размер для большего текста
            backgrn.Location = new Point(640, 550);
            backgrn.Click += backGround_Click;
            Controls.Add(backgrn);

            // Кнопка "Sulge pilt"
            close = new Button();
            close.Text = "Sulge pilt";
            close.BackColor = Color.IndianRed;
            close.ForeColor = Color.White;
            close.Font = new Font("Arial", 12, FontStyle.Bold);
            close.Size = new Size(120, 40);
            close.Location = new Point(50, 600);  // Перемещено ниже
            close.Click += Close_Click;
            Controls.Add(close);

            // Кнопка "Väljuda"
            exit = new Button();
            exit.Text = "Väljuda";
            exit.BackColor = Color.IndianRed;
            exit.ForeColor = Color.White;
            exit.Font = new Font("Arial", 12, FontStyle.Bold);
            exit.Size = new Size(120, 40);
            exit.Location = new Point(180, 600);  // Логичное размещение рядом с "Sulge"
            exit.Click += Exit_Click;
            Controls.Add(exit);
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            pbox.Image = null;
        }

        private void backGround_Click(object? sender, EventArgs e)
        {
            // Näita värvidialoogiboksi. Kui kasutaja klõpsab OK, siis muutke 
            // PictureBox juhtelemendi taust selle värviga, mille kasutaja valis.
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pbox.BackColor = colorDialog.Color;
        }

        private void Show_Click(object? sender, EventArgs e)
        {
            pbox.Image = Image.FromFile(@"..\..\..\" + pildid[3]);           
        }

        int tt = 0;
        private void JrBtn_Click(object? sender, EventArgs e)
        {
            string fail = pildid[tt];
            pbox.Image = Image.FromFile(@"..\..\..\" + fail);
            tt++;
            if (tt == 4) 
            { 
                tt = 0; 
            }
        }

        private void TgBtn_Click(object? sender, EventArgs e)
        {
            string fail = pildid[tt];
            pbox.Image = Image.FromFile(@"..\..\..\" + fail);
            tt--;
            if (tt < 0) 
            { 
                tt = pildid.Length-1; 
            }
        }

        private void Chk_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkb.Checked)
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pbox.SizeMode = PictureBoxSizeMode.Zoom;
        }

    }
}