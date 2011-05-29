namespace Sysmeta.Xbmc.Remote {
    using System;
    using System.Collections.Generic;

    using Caliburn.Micro;

    using Sysmeta.Xbmc.Remote.ViewModels;
    using Sysmeta.Xbmc.Remote.Views.Movies;

    public class MainPageViewModel
    {
        public MainPageViewModel(MainMenuViewModel mainMenu)
        {
            this.MainMenu = mainMenu;
        }

        public MainMenuViewModel MainMenu { get; set; }
    }
}
