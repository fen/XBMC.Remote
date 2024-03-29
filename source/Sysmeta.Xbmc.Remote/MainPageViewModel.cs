namespace Sysmeta.Xbmc.Remote 
{
    using Caliburn.Micro;

    using Sysmeta.Xbmc.Remote.ViewModels;

    public class MainPageViewModel : Screen
    {
        public MainPageViewModel(MainMenuViewModel mainMenu, RecentlyAddedMoviesViewModel recentlyAddedMovies)
        {
            this.MainMenu = mainMenu;
            this.RecentlyAddedMovies = recentlyAddedMovies;
        }

        public MainMenuViewModel MainMenu { get; set; }

        public RecentlyAddedMoviesViewModel RecentlyAddedMovies { get; set; }

        protected override void OnActivate()
        {
            base.OnActivate();

            this.RecentlyAddedMovies.Update();
        }
    }
}
