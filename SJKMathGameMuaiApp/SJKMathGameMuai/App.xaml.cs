using SJKMathGameMuai.Data;

namespace SJKMathGameMuai
{
    public partial class App : Application
    {

        public static GameRepository GameRepository { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            GameRepository = gameRepository;
        }
    }
}
