using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAUITester_CarouselView.UI.NavigationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockTabbedPage : TabbedPage
    {

        /// <summary>
        /// Const
        /// </summary>
        /// <param name="u_AppEngine"></param>
        public StockTabbedPage(MAUITester_CarouselView.AppEngine.AppEngine u_AppEngine)
        {
            InitializeComponent();

            _AppEngine = u_AppEngine;

            if (Device.RuntimePlatform == Device.Android)
            {
                this.UnselectedTabColor = Color.Parse("Red");
                this.SelectedTabColor = Color.FromRgb(128, 128, 255);

                // Disable swipe
                //this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);

                // Disable animations
                //this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSmoothScrollEnabled(false);
            }

            Create();

        }

        #region FIELDS

        MAUITester_CarouselView.AppEngine.AppEngine _AppEngine;

        MAUITester_CarouselView.UI.StockPages.Category.CategoryPage _CategoryPage;

        MAUITester_CarouselView.UI.StockPages.StockCard.StockCardPage _StockCardPage;

        #endregion

        #region METHODS
        /// <summary>
        /// Creates a list of pages for TabbedPage.
        /// </summary>
        private void Create()
        {
            try
            {
                _CategoryPage = new MAUITester_CarouselView.UI.StockPages.Category.CategoryPage(_AppEngine);
                this.Children.Add(_CategoryPage);
                this.Children[0].Title = "Categories";

                _StockCardPage = new MAUITester_CarouselView.UI.StockPages.StockCard.StockCardPage(_AppEngine);
                this.Children.Add(_StockCardPage);
                this.Children[1].Title = "StockCards";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Removes all pages from TabbedPage and creates them again.
        /// </summary>
        private void z_Recreate()
        {
            try
            {
                // Removes all pages
                z_RemovePages();

                // Dispose pages
                z_ClearContent();

                // Create all pages again
                Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Removes all pages.
        /// </summary>
        private void z_RemovePages()
        {
            try
            {
                this.Children.Remove(_CategoryPage);
                this.Children.Remove(_StockCardPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Dispose pages.
        /// </summary>
        private void z_ClearContent()
        {
            try
            {
                if (_CategoryPage != null)
                {
                    _CategoryPage.Dispose();
                    _CategoryPage = null;
                }

                if (_StockCardPage != null)
                {
                    _StockCardPage.Dispose();
                    _StockCardPage = null;
                }

                

                GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region IDisposable

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                try
                {

                    if (disposing)
                    {

                        try
                        {
                            z_RemovePages();
                        }
                        catch (Exception)
                        {
                        }

                        try
                        {
                            z_ClearContent();
                        }
                        catch (Exception)
                        {
                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion



    }
}