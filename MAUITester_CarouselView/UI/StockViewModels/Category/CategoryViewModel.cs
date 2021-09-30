using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUITester_CarouselView.UI.StockViewModels.Category
{
    class CategoryViewModel : MAUITester_CarouselView.UI.StockViewModels.BaseViewModel, IDisposable
    {

        #region COMMANDS
        public ICommand BackCommand { get; private set; }

        public ICommand CategoryTouchUpCommand { get; set; }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Const
        /// </summary>
        /// <param name="u_Page"></param>
        /// <param name="u_AppEngine"></param>
        public CategoryViewModel(Microsoft.Maui.Controls.ContentPage u_Page, MAUITester_CarouselView.AppEngine.AppEngine u_AppEngine) : base(u_AppEngine)
        {
            try
            {
                _Page = u_Page;

                // Category items
                prp_Category_Items = this.AppEngine.CategoryFeatures.Items;

                // prepare commands
                InitializeCommands();

                this.AppEngine.CategoryFeatures.PropertyChanged += eh_Category_PropertyChanged;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region FIELDS

        Microsoft.Maui.Controls.ContentPage _Page;

        #endregion

        #region PROPERTIES

        private ObservableCollection<MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category> prp_Category_Items;
        /// <summary>
        /// Category list.
        /// </summary>
        public ObservableCollection<MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category> Category_Items
        {
            get
            {
                return prp_Category_Items;
            }
            set
            {
                prp_Category_Items = value;
                OnPropertyChanged("Category_Items");
            }
        }


        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Pop current page.
        /// </summary>
        public async Task GoBack()
        {
            try
            {
                this.IsRunning = true;
                await this._Page.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.IsRunning = false;
            }
        }

        #endregion

        #region PRIVATE METHODS
        void InitializeCommands()
        {

            BackCommand = new Command(async () => await GoBack());

            CategoryTouchUpCommand = new Command<MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category>(async (q) => await Task_CategoryTouchUpCommand(q));
        }

        /// <summary>
        /// Otvorí page s ponukou jedál a nastaví vybratú kategóriu.
        /// </summary>
        /// <returns></returns>
        private async Task Task_CategoryTouchUpCommand(MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category u_Category)
        {
            try
            {

                // Nastaviť novú kategóriu.
                this.AppEngine.CategoryFeatures.SetCategory(u_Category);

                await this.AppEngine.AppNavigation.GoPage(MAUITester_CarouselView.AppEngine.AppNavigation.enm_Tester_PageNumbers.Stock_StockCards, u_Animation: false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region EVENTS
        /// <summary>
        /// Event handler for updating category items from main object in AppEngine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eh_Category_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {

                prp_Category_Items = this.AppEngine.CategoryFeatures.Items;

                OnPropertyChanged("Category_Items");

                await Task.Delay(0);
            });
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

                    }

                    // Remove event handlers
                    this.AppEngine.CategoryFeatures.PropertyChanged -= eh_Category_PropertyChanged;
                }
                catch (Exception)
                {
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
