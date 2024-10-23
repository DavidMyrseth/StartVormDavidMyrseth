namespace StartVormDavidMyrseth
{
    public partial class PiltideLeidmise : Form
    {
        TableLayoutPanel tableLayoutPanel;
        Label firstClicked = null;
        Label secondClicked = null;
        System.Windows.Forms.Timer timer;
        Random random = new Random();
        List<string> iconsW = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        int tries;

        public PiltideLeidmise(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Piltide leidmine";

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 750;
            timer.Tick += Timer_Tick;

            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80
            };

            Button closeButton = new Button
            {
                Text = "Sulge",
                Dock = DockStyle.Left,
                Height = 50,
                Width = 150
            };
            closeButton.Click += (sender, e) => this.Close();

            Button restartButton = new Button
            {
                Text = "Taaskäivitada",
                Dock = DockStyle.Left,
                Height = 50,
                Width = 150
            };
            restartButton.Click += (sender, e) => RestartGame();

            Label counterLabel = new Label
            {
                Text = "Proovid: 0",
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 16)
            };

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4,
                BackColor = Color.SkyBlue
            };


            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            for (int i = 0; i < 16; i++)
            {
                Label label = new Label
                {
                    Text = "c",
                    Font = new Font("Wingdings", 40, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.SkyBlue,
                    AutoSize = false,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };
                label.Click += Label_Click;
                tableLayoutPanel.Controls.Add(label);
            }

            AssignIconsToSquares();

            buttonPanel.Controls.Add(counterLabel);
            buttonPanel.Controls.Add(closeButton);
            buttonPanel.Controls.Add(restartButton);

            Controls.Add(tableLayoutPanel);
            Controls.Add(buttonPanel);
        }


        private void UpdateCounterLabel()
        {

            Label counterLabel = (Label)((Panel)Controls[1]).Controls[0];
            counterLabel.Text = $"Proovid: {tries}";
        }

        private void RestartGame()
        {
            firstClicked = null;
            secondClicked = null;
            iconsW.Clear();
            AssignIconsToSquares();
            tries = 0;
            UpdateCounterLabel();
        }     

        private void Label_Click(object? sender, EventArgs e)
        {
            if (timer.Enabled) return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Yellow)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Yellow;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Yellow;

                tries++;
                UpdateCounterLabel();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;

                    if (CheckIfGameIsOver())
                    {
                        MessageBox.Show($"Sa oled kõik ikoonid! Arv: {tries}", "Mäng Läbi");
                        this.Close();
                    }

                    return;
                }

                timer.Start();
            }
        }



        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void AssignIconsToSquares()
        {
            // Пересоздаём список, если он пуст
            if (iconsW.Count == 0)
            {
                iconsW = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
            }

            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null && iconsW.Count > 0)
                {
                    int randomNumber = random.Next(iconsW.Count);
                    iconLabel.Text = iconsW[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    iconsW.RemoveAt(randomNumber);
                }
            }
        }


        private bool CheckIfGameIsOver()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null && iconLabel.ForeColor != Color.Yellow)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
