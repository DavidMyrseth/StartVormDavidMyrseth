namespace StartVormDavidMyrseth
{
    public partial class Araarvamismang : Form
    {
        Label timeLabel;
        Label plusLeftLabel;
        Label plusRightLabel;
        NumericUpDown sum;
        Label minusLeftLabel;
        Label minusRightLabel;
        NumericUpDown sumMinus;
        Label timesLeftLabel;
        Label timesRightLabel;
        NumericUpDown sumMultiply;
        Label dividedLeftLabel;
        Label dividedRightLabel;
        NumericUpDown sumDivide;
        Button startButton;
        Button hintButton;
        Button colorButton;
        System.Windows.Forms.Timer timer;
        int timeLeft;
        Random rand = new Random();
        int addend1, addend2;
        int minuend, subtrahend;
        int multiplicand, multiplier;
        int dividend, divisor;
        int score;

        bool additionCorrect = false;
        bool subtractionCorrect = false;
        bool multiplicationCorrect = false;
        bool divisionCorrect = false;

        // Метки для отображения ответов
        Label additionAnswerLabel;
        Label subtractionAnswerLabel;
        Label multiplicationAnswerLabel;
        Label divisionAnswerLabel;

        public Araarvamismang(int w, int h)
        {
            this.Width = w > 150 ? w : 150;
            this.Height = h > 600 ? h : 600; 
            this.Text = "Piltide leidmine";

            // Изменение шрифта для всех элементов
            Font commonFont = new Font("Arial", 12, FontStyle.Bold);

            // Время
            timeLabel = new Label();
            timeLabel.Text = "Järelejäänud aeg: 30 sekundit";
            timeLabel.Location = new Point(60, 60);
            timeLabel.Width = 300;
            timeLabel.Font = commonFont;
            Controls.Add(timeLabel);

            // Плюс
            plusLeftLabel = new Label();
            plusLeftLabel.Text = "0";
            plusLeftLabel.Location = new Point(50, 100);
            plusLeftLabel.Font = commonFont;
            Controls.Add(plusLeftLabel);

            plusRightLabel = new Label();
            plusRightLabel.Text = "+ 0 =";
            plusRightLabel.Location = new Point(150, 100);
            plusRightLabel.Font = commonFont;
            Controls.Add(plusRightLabel);

            sum = new NumericUpDown();
            sum.Location = new Point(300, 100);
            sum.Width = 80;
            sum.Font = commonFont;
            sum.Value = 0;
            sum.Enter += answer_Enter;
            Controls.Add(sum);

            // Минус
            minusLeftLabel = new Label();
            minusLeftLabel.Text = "0";
            minusLeftLabel.Location = new Point(50, 150);
            minusLeftLabel.Font = commonFont;
            Controls.Add(minusLeftLabel);

            minusRightLabel = new Label();
            minusRightLabel.Text = "- 0 =";
            minusRightLabel.Location = new Point(150, 150);
            minusRightLabel.Font = commonFont;
            Controls.Add(minusRightLabel);

            sumMinus = new NumericUpDown();
            sumMinus.Location = new Point(300, 150);
            sumMinus.Width = 80;
            sumMinus.Font = commonFont;
            sumMinus.Value = 0;
            sumMinus.Enter += answer_Enter;
            Controls.Add(sumMinus);

            // Умножение
            timesLeftLabel = new Label();
            timesLeftLabel.Text = "0";
            timesLeftLabel.Location = new Point(50, 200);
            timesLeftLabel.Font = commonFont;
            Controls.Add(timesLeftLabel);

            timesRightLabel = new Label();
            timesRightLabel.Text = "× 0 =";
            timesRightLabel.Location = new Point(150, 200);
            timesRightLabel.Font = commonFont;
            Controls.Add(timesRightLabel);

            sumMultiply = new NumericUpDown();
            sumMultiply.Location = new Point(300, 200);
            sumMultiply.Width = 80;
            sumMultiply.Font = commonFont;
            sumMultiply.Value = 0;
            sumMultiply.Enter += answer_Enter;
            Controls.Add(sumMultiply);

            // Деление
            dividedLeftLabel = new Label();
            dividedLeftLabel.Text = "0";
            dividedLeftLabel.Location = new Point(50, 250);
            dividedLeftLabel.Font = commonFont;
            Controls.Add(dividedLeftLabel);

            dividedRightLabel = new Label();
            dividedRightLabel.Text = "÷ 0 =";
            dividedRightLabel.Location = new Point(150, 250);
            dividedRightLabel.Font = commonFont;
            Controls.Add(dividedRightLabel);

            sumDivide = new NumericUpDown();
            sumDivide.Location = new Point(300, 250);
            sumDivide.Width = 80;
            sumDivide.Font = commonFont;
            sumDivide.Value = 0;
            sumDivide.Enter += answer_Enter;
            Controls.Add(sumDivide);

            // Стартовая кнопка
            startButton = new Button();
            startButton.Text = "Viktoriini algus";
            startButton.Location = new Point(150, 300);
            startButton.Width = 150;
            startButton.Height = 50;
            startButton.Font = commonFont;
            startButton.Click += StartButton_Click;
            Controls.Add(startButton);

            // Кнопка подсказки
            hintButton = new Button();
            hintButton.Text = "Näita näpunäiteid";
            hintButton.Location = new Point(150, 370); // Новая позиция кнопки
            hintButton.Width = 150;
            hintButton.Height = 50;
            hintButton.Font = commonFont;
            hintButton.Click += HintButton_Click; // Обработчик события
            Controls.Add(hintButton);

            // Кнопка смены цвета фона
            colorButton = new Button();
            colorButton.Text = "Muutke taustavärvi";
            colorButton.Location = new Point(150, 440); // Новая позиция кнопки
            colorButton.Width = 150;
            colorButton.Height = 50;
            colorButton.Font = commonFont;
            colorButton.Click += ColorButton_Click; // Обработчик события
            Controls.Add(colorButton);

            // Таймер
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += QuizTimer_Tick;

            // Метки для отображения ответов
            additionAnswerLabel = new Label();
            additionAnswerLabel.Location = new Point(400, 100); // Позиция метки
            additionAnswerLabel.Font = commonFont;
            Controls.Add(additionAnswerLabel);

            subtractionAnswerLabel = new Label();
            subtractionAnswerLabel.Location = new Point(400, 150); // Позиция метки
            subtractionAnswerLabel.Font = commonFont;
            Controls.Add(subtractionAnswerLabel);

            multiplicationAnswerLabel = new Label();
            multiplicationAnswerLabel.Location = new Point(400, 200); // Позиция метки
            multiplicationAnswerLabel.Font = commonFont;
            Controls.Add(multiplicationAnswerLabel);

            divisionAnswerLabel = new Label();
            divisionAnswerLabel.Location = new Point(400, 250); // Позиция метки
            divisionAnswerLabel.Font = commonFont;
            Controls.Add(divisionAnswerLabel);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartQuiz();
            startButton.Enabled = false;
        }

        private void StartQuiz()
        {
            score = 0;
            timeLeft = 30;
            timeLabel.Text = "Järelejäänud aeg: 30 sekundit";
            GenerNumbers();
            timer.Start();
        }

        private void GenerNumbers()
        {
            additionCorrect = subtractionCorrect = multiplicationCorrect = divisionCorrect = false;

            addend1 = rand.Next(51);
            addend2 = rand.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = "+ " + addend2.ToString() + " =";
            sum.Value = 0;

            minuend = rand.Next(1, 101);
            subtrahend = rand.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = "- " + subtrahend.ToString() + " =";
            sumMinus.Value = 0;

            multiplicand = rand.Next(2, 11);
            multiplier = rand.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = "× " + multiplier.ToString() + " =";
            sumMultiply.Value = 0;

            do
            {
                divisor = rand.Next(2, 11);
            }
            while (divisor == 0);

            int tempQuotient = rand.Next(2, 11);
            dividend = divisor * tempQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = "÷ " + divisor.ToString() + " =";
            sumDivide.Value = 0;
        }

        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = $"Aeg on jäänud: {timeLeft} sekundid";
                CheckAnswer();
            }
            else
            {
                timer.Stop();
                timeLabel.Text = $"Aeg on läbi! Sinu tulemus on {score}.";
                startButton.Enabled = true;
            }
        }

        private void CheckAnswer()
        {
            // Addition check
            if (addend1 + addend2 == sum.Value)
            {
                if (!additionCorrect)
                {
                    sum.BackColor = Color.LightBlue;
                    score++;
                    additionCorrect = true;
                }
            }
            else
            {
                sum.BackColor = Color.Red;
                additionCorrect = false;
            }

            if (minuend - subtrahend == sumMinus.Value)
            {
                if (!subtractionCorrect)
                {
                    sumMinus.BackColor = Color.LightBlue;
                    score++;
                    subtractionCorrect = true;
                }
            }
            else
            {
                sumMinus.BackColor = Color.Red;
                subtractionCorrect = false;
            }

            if (multiplicand * multiplier == sumMultiply.Value)
            {
                if (!multiplicationCorrect)
                {
                    sumMultiply.BackColor = Color.LightBlue;
                    score++;
                    multiplicationCorrect = true;
                }
            }
            else
            {
                sumMultiply.BackColor = Color.Red;
                multiplicationCorrect = false;
            }

            if (dividend / divisor == sumDivide.Value)
            {
                if (!divisionCorrect)
                {
                    sumDivide.BackColor = Color.LightBlue;
                    score++;
                    divisionCorrect = true;
                }
            }
            else
            {
                sumDivide.BackColor = Color.Red;
                divisionCorrect = false;
            }

            if (additionCorrect && subtractionCorrect && multiplicationCorrect && divisionCorrect)
            {
                GenerNumbers();
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int LenghtAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, LenghtAnswer);
            }
        }

        // Обработчик нажатия кнопки подсказки
        private void HintButton_Click(object sender, EventArgs e)
        {
            // Показать ответы
            additionAnswerLabel.Text = (addend1 + addend2).ToString();
            subtractionAnswerLabel.Text = (minuend - subtrahend).ToString();
            multiplicationAnswerLabel.Text = (multiplicand * multiplier).ToString();
            divisionAnswerLabel.Text = (dividend / divisor).ToString();

            // Скрыть подсказки через 5 секунд
            var timerHideHints = new System.Windows.Forms.Timer();
            timerHideHints.Interval = 5000;
            timerHideHints.Tick += (s, args) =>
            {
                additionAnswerLabel.Text = "";
                subtractionAnswerLabel.Text = "";
                multiplicationAnswerLabel.Text = "";
                divisionAnswerLabel.Text = "";
                timerHideHints.Stop();
                timerHideHints.Dispose();
            };
            timerHideHints.Start();
        }

        // Обработчик нажатия кнопки смены цвета фона
        private void ColorButton_Click(object sender, EventArgs e)
        {
            // Генерация случайного цвета радуги
            Color randomColor = GetRandomRainbowColor();
            this.BackColor = randomColor; // Изменяем цвет фона формы
        }

        // Метод для получения случайного цвета радуги
        private Color GetRandomRainbowColor()
        {
            // Массив цветов радуги
            Color[] rainbowColors = new Color[]
            {
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Indigo,
                Color.Violet
            };

            // Генерация случайного индекса
            int randomIndex = rand.Next(rainbowColors.Length);
            return rainbowColors[randomIndex];
        }
    }
}
