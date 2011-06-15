namespace Sysmeta.Xbmc.Remote.ViewModels.Tvshows
{
    using System;
    using System.Windows.Media.Imaging;

    using Caliburn.Micro;

    using Sysmeta.Xbmc.Remote.Model;
    using Sysmeta.Xbmc.Remote.Services;

    public class TvSeasonViewModel : PropertyChangedBase
    {
        private readonly TvSeason tvSeason;

        private readonly IXbmcHost host;

        private readonly INavigationService navigationService;

        public TvSeasonViewModel(IXbmcHost host, INavigationService navigationService)
        {
            this.host = host;
            this.navigationService = navigationService;
        }

        internal TvSeasonViewModel(IXbmcHost xbmcHost, INavigationService navigationService, TvSeason tvSeason)
            : this(xbmcHost, navigationService)
        {
            this.tvSeason = tvSeason;
        }

        private int tvshowId = -1;
        public int TvshowId
        {
            get
            {
                if (this.tvSeason == null)
                {
                    return this.tvshowId;
                }

                if (this.tvshowId == -1)
                {
                    this.tvshowId = this.tvSeason.TvshowId;
                }

                return this.tvshowId;
            }

            set
            {
                this.tvshowId = value;
            }
        }

        public string Title
        {
            get
            {
                if (this.tvSeason == null)
                {
                    return null;
                }

                return this.tvSeason.Title;
            }
        }

        private bool thumbnailResolved = false;
        private BitmapImage thumbnail;
        public BitmapImage Thumbnail
        {
            get
            {
                if (this.tvSeason == null)
                {
                    return null;
                }

                // Images is resolved when the View asks for them
                if (!this.thumbnailResolved && this.ThumbnailSource != null && this.tvSeason.ThumbnailImage == null)
                {
                    this.host.LoadImage(this.ThumbnailSource, image =>
                    {
                        this.thumbnailResolved = true;
                        this.tvSeason.ThumbnailImage = image;
                        this.Thumbnail = image;
                    });
                }

                if (this.tvSeason.ThumbnailImage != null)
                {
                    return this.tvSeason.ThumbnailImage;
                }

                if (this.thumbnail == null)
                {
                    return null;
                }

                return this.thumbnail;
            }

            set
            {
                this.thumbnail = value;
                NotifyOfPropertyChange(() => this.Thumbnail);
            }
        }

        public Uri ThumbnailSource
        {
            get
            {
                if (this.tvSeason == null)
                {
                    return null;
                }

                return this.tvSeason.Thumbnail;
            }
        }

        public int Episodes
        {
            get
            {
                if (this.tvSeason == null)
                {
                    return 0;
                }

                return this.tvSeason.Episodes;
            }
        }

        public int Season
        {
            get
            {
                if (this.tvSeason == null)
                {
                    return 0;
                }

                return this.tvSeason.Season;
            }
        }
    }
}