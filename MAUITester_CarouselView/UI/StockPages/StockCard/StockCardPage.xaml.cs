using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITester_CarouselView.UI.StockPages.StockCard
{
    /// <summary>
    /// Page with the items (StockCards) in selected category.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockCardPage : ContentPage, IDisposable
    {

        #region FIELDS

        MAUITester_CarouselView.UI.StockViewModels.StockCard.StockCardViewModel _StockCardViewModel = null;

        private MAUITester_CarouselView.AppEngine.AppEngine _AppEngine = null;


        #endregion

        /// <summary>
        /// Const.
        /// </summary>
        /// <param name="u_AppEngine"></param>
        public StockCardPage(MAUITester_CarouselView.AppEngine.AppEngine u_AppEngine)
        {
            InitializeComponent();

            _AppEngine = u_AppEngine;

            _StockCardViewModel = new MAUITester_CarouselView.UI.StockViewModels.StockCard.StockCardViewModel(this,_AppEngine);

            this.BindingContext = _StockCardViewModel;

            _AppEngine.AppNavigation.UserAction += eh_UserActions;
        }

        /// <summary>
        /// Event is invoked after user action (changing category for instance).
        /// </summary>
        void eh_UserActions(MAUITester_CarouselView.AppEngine.AppNavigation.cls_UserActionEventArgs u_UserActionEventArgs)
        {
            try
            {
                if (u_UserActionEventArgs.UserAction == MAUITester_CarouselView.AppEngine.AppNavigation.cls_UserActionEventArgs.enm_UserAction.MenuCategories)
                {
                    // Set selected category
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        int tmp_CategoryIndex = _AppEngine.CategoryFeatures.Items.IndexOf(_AppEngine.CategoryFeatures.SelectedCategory);
                        if (tmp_CategoryIndex >= 0)
                        {
                            fro_CarouselView_Categories.IsScrollAnimated = false;
                            if (Device.RuntimePlatform == Device.Android)
                            {
                                fro_CarouselView_Categories.CurrentItem = _AppEngine.CategoryFeatures.Items[tmp_CategoryIndex];
                            }
                            else if (Device.RuntimePlatform == Device.iOS)
                            {
                                // Use position instead of CurrentItem, bcs CurrentItem is not working on IOS.
                                fro_CarouselView_Categories.Position = tmp_CategoryIndex;
                            }

                            _StockCardViewModel.OnPropertyChanged("ActiveCategoryName");
                        }

                        await Task.Delay(0);
                    });

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        /// <summary>
        /// Item in StockCard Categories was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fro_CarouselView_Categories_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            try
            {

                if (fro_CarouselView_Categories.ItemsSource == null)
                {
                    return;
                }

                if (e.PreviousItem == null)
                {
                    return;
                }

                if (e.CurrentItem is MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category)
                {
                    // Set new category
                    if (_AppEngine.CategoryFeatures.SelectedCategory != (MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category)e.CurrentItem)
                    {
                        _AppEngine.CategoryFeatures.SetCategory((MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category)e.CurrentItem);
                    }
                }

                _StockCardViewModel.OnPropertyChanged("ActiveCategoryName");

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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
                        this._StockCardViewModel.Dispose();

                    }

                    // Unmap events
                    _AppEngine.AppNavigation.UserAction -= eh_UserActions;
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