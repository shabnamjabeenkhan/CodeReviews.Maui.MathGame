using SJKMathGameMuai.Models;

namespace SJKMathGameMuai
{
    public partial class GamePage : ContentPage
    {
        public string GameType { get; set; }
        int firstNumber = 0;
        int secondNumber = 0;
        int score = 0;
        const int totalQuestions = 2;
        int gamesLeft = totalQuestions;

        public GamePage(string gameType)
        {
            InitializeComponent();
            GameType = gameType;
            BindingContext = this;

            CreateNewQuestion();
        }

        private void CreateNewQuestion()
        {
            var gameOperand = GameType switch
            {
                "Addition" => "+",
                "Subtraction" => "-",
                "Multiplication" => "*",
                "Division" => "/",
                _ => ""
            };

            var random = new Random();
         

            firstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 9);
            secondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 9);

            if (GameType == "Division")
            {
                while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);   
                }
            }

            QuestionLabel.Text = $"{firstNumber} {gameOperand} {secondNumber}";

        }

        private void OnAnswerSubmitted(object sender, EventArgs e)
        {
            var answer = Int32.Parse(AnswerEntry.Text);
            var isCorrect = false;

            switch(GameType)
            {
                case "Addition":
                    isCorrect = answer == firstNumber + secondNumber;
                    break;
                case "Subtraction":
                    isCorrect = answer == firstNumber - secondNumber;
                    break;
                case "Multiplication":
                    isCorrect = answer == firstNumber * secondNumber;
                    break;
                case "Division":
                    isCorrect = answer == firstNumber / secondNumber;
                    break;
                   

            }
            ProcessAnswer(isCorrect);
            gamesLeft--;
            AnswerEntry.Text = "";

            if (gamesLeft > 0)
            {
                CreateNewQuestion();
                
                
                   
                
            }
            else
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            GameOperation gameOperation = GameType switch
            {
                "Addition" => GameOperation.Additon,
                "Subtraction" => GameOperation.Subtraction,
                "Multiplication" => GameOperation.Multiplication,
                "Division" => GameOperation.Division,
            };
            QuestionArea.IsVisible = false;
            BackToMenuBtn.IsVisible = true;
            GameOverLabel.Text = $"Game over! You got {score} out of {totalQuestions} right. ";

            App.GameRepository.Add(new Game
            {
                DatePlayed = DateTime.Now,
                Type = gameOperation,
                Score = score
            });
        }

        private void ProcessAnswer(bool isCorrect) {

            if (isCorrect)
                score += 1;
            AnswerLabel.Text = isCorrect ? "Correct!" : "Incorrect";
                }

        private void OnBackToMenu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }

   
}