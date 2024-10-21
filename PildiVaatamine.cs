namespace StartVormDavidMyrseth
{
    public partial class PildiVaatamine : Form
    {
        string[] pildid = { "Boy.png", "Jesus.png", "Patrick.png", "SpongeBob.png" };
        OpenFileDialog openFileDialog;
        Button uploadBtn;
        PictureBox pbox;
        Button JargmineBtn;
        Button TagasiBtn;
        CheckBox chkb;
        Button show;
        Button exit;
        Button backgrn;
        Button close;

        // Новые кнопки
        Button resizeBtn;
        Button darkenBtn;
        Button saveBtn;

        ColorDialog colorDialog;

        public PildiVaatamine(int w = 1200, int h = 800) // Изменяем размеры окна
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Pildi vaatamine";

            // Инициализация OpenFileDialog
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

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
            JargmineBtn.BackColor = Color.MediumSeaGreen;
            JargmineBtn.ForeColor = Color.White;
            JargmineBtn.Font = new Font("Arial", 12, FontStyle.Bold);
            JargmineBtn.Size = new Size(120, 40);
            JargmineBtn.Location = new Point(50, 550);
            JargmineBtn.Click += JrBtn_Click;
            Controls.Add(JargmineBtn);

            // Кнопка "Eelmine"
            TagasiBtn = new Button();
            TagasiBtn.Text = "Eelmine";
            TagasiBtn.BackColor = Color.MediumSeaGreen;
            TagasiBtn.ForeColor = Color.White;
            TagasiBtn.Font = new Font("Arial", 12, FontStyle.Bold);
            TagasiBtn.Size = new Size(120, 40);
            TagasiBtn.Location = new Point(180, 550);
            TagasiBtn.Click += TgBtn_Click;
            Controls.Add(TagasiBtn);

            // Чекбокс "Venitada"
            chkb = new CheckBox();
            chkb.Checked = false;
            chkb.Text = "Venitada";
            chkb.ForeColor = Color.Black;
            chkb.Font = new Font("Arial", 12, FontStyle.Bold);
            chkb.Size = new Size(150, 40);
            chkb.Location = new Point(320, 550);
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
            backgrn.Size = new Size(200, 40);
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
            close.Location = new Point(50, 600);
            close.Click += Close_Click;
            Controls.Add(close);

            // Кнопка "Väljuda"
            exit = new Button();
            exit.Text = "Väljuda";
            exit.BackColor = Color.MediumSeaGreen;
            exit.ForeColor = Color.White;
            exit.Font = new Font("Arial", 12, FontStyle.Bold);
            exit.Size = new Size(120, 40);
            exit.Location = new Point(180, 600);
            exit.Click += Exit_Click;
            Controls.Add(exit);

            // Кнопка "Lisa Pilt" — стилизована как другие кнопки
            uploadBtn = new Button();
            uploadBtn.Text = "Lisa Pilt";
            uploadBtn.BackColor = Color.MediumSeaGreen; // Стиль кнопки как у других
            uploadBtn.ForeColor = Color.White;
            uploadBtn.Font = new Font("Arial", 12, FontStyle.Bold);
            uploadBtn.Size = new Size(120, 40);
            uploadBtn.Location = new Point(720, 600); // Переместили кнопку ниже остальных
            uploadBtn.Click += UploadBtn_Click;
            Controls.Add(uploadBtn);

            // Новая кнопка "Уменьшить картинку"
            resizeBtn = new Button();
            resizeBtn.Text = "Уменьшить";
            resizeBtn.BackColor = Color.MediumSeaGreen;
            resizeBtn.ForeColor = Color.White;
            resizeBtn.Font = new Font("Arial", 12, FontStyle.Bold);
            resizeBtn.Size = new Size(120, 40);
            resizeBtn.Location = new Point(50, 650);
            resizeBtn.Click += ResizeBtn_Click;
            Controls.Add(resizeBtn);

            // Новая кнопка "Затемнить картинку"
            darkenBtn = new Button();
            darkenBtn.Text = "Затемнить";
            darkenBtn.BackColor = Color.MediumSeaGreen;
            darkenBtn.ForeColor = Color.White;
            darkenBtn.Font = new Font("Arial", 12, FontStyle.Bold);
            darkenBtn.Size = new Size(120, 40);
            darkenBtn.Location = new Point(200, 650);
            darkenBtn.Click += DarkenBtn_Click;
            Controls.Add(darkenBtn);

            // Новая кнопка "Сохранить картинку"
            saveBtn = new Button();
            saveBtn.Text = "Сохранить";
            saveBtn.BackColor = Color.MediumSeaGreen;
            saveBtn.ForeColor = Color.White;
            saveBtn.Font = new Font("Arial", 12, FontStyle.Bold);
            saveBtn.Size = new Size(120, 40);
            saveBtn.Location = new Point(350, 650);
            saveBtn.Click += SaveBtn_Click;
            Controls.Add(saveBtn);
        }

        private void Show_Click(object? sender, EventArgs e)
        {
            pbox.Image = Image.FromFile(@"..\..\..\" + pildid[3]);
        }

        private void UploadBtn_Click(object? sender, EventArgs e)
        {
            // Используем OpenFileDialog для загрузки изображения
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                pbox.Image = Image.FromFile(filePath);
            }
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
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pbox.BackColor = colorDialog.Color;
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
                tt = pildid.Length - 1;
            }
        }

        private void Chk_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkb.Checked)
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pbox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Метод для уменьшения картинки
        private void ResizeBtn_Click(object? sender, EventArgs e)
        {
            if (pbox.Image != null)
            {
                // Уменьшаем размер картинки до 80%
                var newWidth = (int)(pbox.Image.Width * 0.8);
                var newHeight = (int)(pbox.Image.Height * 0.8);
                var resizedImage = new Bitmap(pbox.Image, new Size(newWidth, newHeight));
                pbox.Image = resizedImage;
            }
        }

        // Метод для затемнения картинки
        private void DarkenBtn_Click(object? sender, EventArgs e)
        {
            if (pbox.Image != null)
            {
                Bitmap darkenedImage = new Bitmap(pbox.Image.Width, pbox.Image.Height);
                for (int y = 0; y < pbox.Image.Height; y++)
                {
                    for (int x = 0; x < pbox.Image.Width; x++)
                    {
                        Color pixelColor = ((Bitmap)pbox.Image).GetPixel(x, y);
                        // Затемняем цвет пикселя
                        Color newColor = Color.FromArgb(pixelColor.A, pixelColor.R / 2, pixelColor.G / 2, pixelColor.B / 2);
                        darkenedImage.SetPixel(x, y, newColor);
                    }
                }
                pbox.Image = darkenedImage;
            }
        }

        // Метод для сохранения картинки
        private void SaveBtn_Click(object? sender, EventArgs e)
        {
            if (pbox.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbox.Image.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
