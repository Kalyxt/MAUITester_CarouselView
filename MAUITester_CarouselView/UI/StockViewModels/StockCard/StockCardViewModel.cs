using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUITester_CarouselView.UI.StockViewModels.StockCard
{
    public class StockCardViewModel : MAUITester_CarouselView.UI.StockViewModels.BaseViewModel, IDisposable
    {
        #region COMMANDS
        public ICommand BackCommand { get; private set; }

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Const.
        /// </summary>
        /// <param name="u_Page"></param>
        /// <param name="u_AppEngine"></param>
        public StockCardViewModel(Microsoft.Maui.Controls.ContentPage u_Page, MAUITester_CarouselView.AppEngine.AppEngine u_AppEngine) : base(u_AppEngine)
        {
            try
            {
                // MenuCategory items
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

        /// <summary>
        /// Name of the active category.
        /// </summary>
        public string ActiveCategoryName
        {
            get
            {
                return this.AppEngine.CategoryFeatures?.SelectedCategory?.Name;
            }
        }

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
