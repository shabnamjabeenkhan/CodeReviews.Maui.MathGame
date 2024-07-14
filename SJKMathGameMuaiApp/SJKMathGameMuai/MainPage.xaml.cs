using Windows.Networking.Vpn;

namespace SJKMathGameMuai
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGameChosen(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new GamePage(button.Text));
        }

        private async void OnViewPreviousGamesChosen(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new PreviousGames());
        }

     
    }
}
