namespace StartVormDavidMyrseth
{
    public partial class PiltideLeidmise : Form
    {
        TableLayoutPanel tableLayoutPanel; 
        Label firstClicked = null; 
        Label secondClicked = null; 
        System.Windows.Forms.Timer timer; // Таймер для задержки между кликами
        Random random = new Random();
        List<string> iconsW = new List<string>() 
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        int tries; // Количество попыток

        Label timeLabel; // Значок для отображения времени
        System.Windows.Forms.Timer gameTimer; // Таймер для отсчета времени игры
        int timeElapsed; // Переменная для хранения прошедшего времени

        public PiltideLeidmise(int w, int h)
        {
            // Настройка размера окна
            this.Width = w > 800 ? w : 800;
            this.Height = h > 600 ? h : 600;
            this.Text = "Piltide leidmine";

            // Инициализация таймера для задержки между кликами
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Интервал в 1000 миллисекунд
            timer.Tick += Timer_Tick; // Привязка обработчика события

            // Панель для кнопок внизу окна
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 100
            };

            // Кнопка для закрытия игры
            Button closeButton = new Button
            {
                Text = "Sulge",
                Dock = DockStyle.Left,
                Height = 60,
                Width = 200
            };
            closeButton.Click += (sender, e) => this.Close();

            // Кнопка для перезапуска игры
            Button restartButton = new Button
            {
                Text = "Taaskäivitada",
                Dock = DockStyle.Left,
                Height = 60,
                Width = 200
            };
            restartButton.Click += (sender, e) => RestartGame();

            // Метка для отображения количества попыток
            Label counterLabel = new Label
            {
                Text = "Proovid: 0",
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 18)
            };

            // Метка для отображения времени
            timeLabel = new Label
            {
                Text = "Aeg: 0 sek",
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 18)
            };

            // Таймер для отсчета времени
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000; // Интервал 1 секунда
            gameTimer.Tick += (sender, e) =>
            {
                timeElapsed++; // Увеличиваем время на 1 секунду
                timeLabel.Text = $"Aeg: {timeElapsed} sek"; // Обновляем отображение времени
            };
            gameTimer.Start(); // Запуск таймера

            // Кнопка для подсказки (показать все иконки на 2 секунды)
            Button hintButton = new Button
            {
                Text = "Подсказка",
                Dock = DockStyle.Left,
                Height = 60,
                Width = 200
            };
            hintButton.Click += (sender, e) =>
            {
                // Показываем все иконки желтым цветом
                foreach (Control control in tableLayoutPanel.Controls)
                {
                    Label iconLabel = control as Label;
                    if (iconLabel != null)
                    {
                        iconLabel.ForeColor = Color.Yellow;
                    }
                }

                // Создаем таймер для возврата иконок в исходное состояние через 2 секунды
                System.Windows.Forms.Timer hintTimer = new System.Windows.Forms.Timer();
                hintTimer.Interval = 2000; // Интервал 2 секунды
                hintTimer.Tick += (s, ev) =>
                {
                    // Возвращаем цвет иконок (кроме тех, которые уже найдены)
                    foreach (Control control in tableLayoutPanel.Controls)
                    {
                        Label iconLabel = control as Label;
                        if (iconLabel != null && iconLabel.ForeColor != Color.Green)
                        {
                            iconLabel.ForeColor = iconLabel.BackColor;
                        }
                    }
                    hintTimer.Stop(); // Останавливаем таймер
                };
                hintTimer.Start(); // Запускаем таймер
            };

            // Создаем таблицу для игры с 4 колонками и 4 строками
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4,
                BackColor = Color.SkyBlue // Цвет фона таблицы
            };

            // Добавляем столбцы и строки в таблицу
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            // Заполняем таблицу метками
            for (int i = 0; i < 16; i++)
            {
                Label label = new Label
                {
                    Text = "c", // Изначально все метки содержат символ "c"
                    Font = new Font("Wingdings", 60, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.SkyBlue,
                    AutoSize = false,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };
                label.Click += Label_Click; // Добавляем обработчик кликов по метке
                tableLayoutPanel.Controls.Add(label); // Добавляем метку в таблицу
            }

            AssignIconsToSquares(); // Назначаем случайные иконки для каждой метки

            // Добавляем элементы управления на панель кнопок
            buttonPanel.Controls.Add(counterLabel);
            buttonPanel.Controls.Add(timeLabel);
            buttonPanel.Controls.Add(closeButton);
            buttonPanel.Controls.Add(restartButton);
            buttonPanel.Controls.Add(hintButton);

            // Добавляем таблицу и панель кнопок на форму
            Controls.Add(tableLayoutPanel);
            Controls.Add(buttonPanel);
        }

        // Обновляет счетчик попыток на панели
        private void UpdateCounterLabel()
        {

            Label counterLabel = (Label)((Panel)Controls[1]).Controls[0];
            counterLabel.Text = $"Proovid: {tries}";
        }

        // Перезапуск игры
        private void RestartGame()
        {
            firstClicked = null;
            secondClicked = null;
            iconsW.Clear(); // Очищаем список иконок
            AssignIconsToSquares(); // Назначаем новые иконки
            tries = 0; // Сбрасываем количество попыток
            UpdateCounterLabel(); // Обновляем счетчик попыток

            timeElapsed = 0; // Сбрасываем время
            timeLabel.Text = "Aeg: 0 sek"; // Обновляем отображение времени
            gameTimer.Start(); // Перезапускаем таймер игры
        }

        // Обработчик кликов по меткам
        private void Label_Click(object? sender, EventArgs e)
        {
            if (timer.Enabled) return; // Игнорируем клики, если таймер активен

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // Если метка уже открыта (желтая или зеленая), игнорируем клик
                if (clickedLabel.ForeColor == Color.Yellow || clickedLabel.ForeColor == Color.Green)
                    return;

                // Если это первая метка, сохраняем ее
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Yellow; // Подсвечиваем желтым
                    return;
                }

                // Если это вторая метка, сохраняем ее и проверяем совпадение
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Yellow;

                tries++; // Увеличиваем количество попыток
                UpdateCounterLabel(); // Обновляем счетчик попыток

                // Если иконки совпали
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked.ForeColor = Color.Green; // Подсвечиваем зеленым
                    secondClicked.ForeColor = Color.Green; // Подсвечиваем зеленым

                    firstClicked = null;
                    secondClicked = null;

                    // Проверяем, завершена ли игра
                    if (CheckIfGameIsOver())
                    {
                        gameTimer.Stop(); // Останавливаем таймер игры
                        MessageBox.Show($"Sa oled kõik ikoonid! Arv: {tries}. Aeg: {timeElapsed} sek", "Mäng Läbi"); // Сообщение о победе
                        this.Close(); // Закрываем игру
                    }

                    return;
                }

                // Если иконки не совпали, запускаем таймер для скрытия
                timer.Start();
            }
        }

        // Таймер для скрытия иконок, если они не совпали
        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop(); // Останавливаем таймер

            // Скрываем иконки, если они не совпали
            if (firstClicked.ForeColor != Color.Green)
                firstClicked.ForeColor = firstClicked.BackColor;

            if (secondClicked.ForeColor != Color.Green)
                secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        // Назначаем случайные иконки для меток
        private void AssignIconsToSquares()
        {
            // Если список иконок пуст, заполняем его
            if (iconsW.Count == 0)
            {
                iconsW = new List<string>()
                {
                    "!", "!", "N", "N", ",", ",", "k", "k",
                    "b", "b", "v", "v", "w", "w", "z", "z"
                };
            }

            // Назначаем случайные иконки для каждой метки
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null && iconsW.Count > 0)
                {
                    int randomNumber = random.Next(iconsW.Count);
                    iconLabel.Text = iconsW[randomNumber]; // Назначаем случайную иконку
                    iconLabel.ForeColor = iconLabel.BackColor; // Скрываем иконку
                    iconsW.RemoveAt(randomNumber); // Удаляем использованную иконку
                }
            }
        }

        // Проверяем, завершена ли игра (все иконки найдены)
        private bool CheckIfGameIsOver()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null && iconLabel.ForeColor != Color.Green)
                {
                    return false; // Игра не завершена, если есть незакрашенные иконки
                }
            }
            return true; // Игра завершена
        }
    }
}
