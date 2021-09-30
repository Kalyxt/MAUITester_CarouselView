using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MAUITester_CarouselView.AppEngine.AppEngineClasses
{
    public class StockCardFeatures : IDisposable, INotifyPropertyChanged
    {

        public StockCardFeatures(AppEngine u_AppEngine)
        {
            prp_AppEngine = u_AppEngine;
        }


        #region PROPERTIES

        private AppEngine prp_AppEngine;
        /// <summary>
        /// Main object of app, contains all data classes.
        /// </summary>
        public AppEngine AppEngine
        {
            get
            {
                return prp_AppEngine;
            }
        }


        private ObservableCollection<cls_StockCard> prp_Items;
        /// <summary>
        /// Category list.
        /// </summary>
        public ObservableCollection<cls_StockCard> Items
        {
            get
            {
                return prp_Items;
            }
            set
            {
                prp_Items = value;
                OnPropertyChanged("Items");
            }
        }
        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Return stockcards based on the name.
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<cls_StockCard> GetStockCardList(string u_MenuCategory)
        {

            System.Collections.ObjectModel.ObservableCollection<cls_StockCard> tmp_StockCardList;
            tmp_StockCardList = new System.Collections.ObjectModel.ObservableCollection<cls_StockCard>();

            try
            {

                Console.WriteLine($"GetStockCardList - Category: {u_MenuCategory}");

                foreach (var e_StockCard in this.Items)
                {
                    if (string.Compare(e_StockCard.Category, u_MenuCategory) == 0)
                    {
                        // Found
                        tmp_StockCardList.Add(e_StockCard);

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            // Return list
            return tmp_StockCardList;

        }

        /// <summary>
        /// Load stockCards to list.
        /// </summary>
        public void Load()
        {
            try
            {

                if (Items == null)
                {
                    this.Items = new ObservableCollection<cls_StockCard>();
                }
                else
                {
                    this.Items.Clear();
                }

                cls_StockCard tmp_StockCard;
                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Skoda";
                tmp_StockCard.Category = "Cars";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Mercedez";
                tmp_StockCard.Category = "Cars";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Fiat";
                tmp_StockCard.Category = "Cars";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Lada";
                tmp_StockCard.Category = "Cars";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Author";
                tmp_StockCard.Category = "Bikes";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Pyranha";
                tmp_StockCard.Category = "Bikes";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Shimano";
                tmp_StockCard.Category = "Bikes";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Elite";
                tmp_StockCard.Category = "Bikes";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Yamato";
                tmp_StockCard.Category = "Boats";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Montana";
                tmp_StockCard.Category = "Boats";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Iowa";
                tmp_StockCard.Category = "Boats";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Shimakaze";
                tmp_StockCard.Category = "Boats";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Boeing";
                tmp_StockCard.Category = "Planes";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Airbus";
                tmp_StockCard.Category = "Planes";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Falcon 9";
                tmp_StockCard.Category = "Rockets";
                this.Items.Add(tmp_StockCard);

                tmp_StockCard = new cls_StockCard(this.AppEngine);
                tmp_StockCard.Name = "Starship";
                tmp_StockCard.Category = "Rockets";
                this.Items.Add(tmp_StockCard);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {

            try
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;

                changed(this, new PropertyChangedEventArgs(name));
            }
            catch
            {

            }

        }

        #endregion

        #region IDisposable

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }


                try
                {
                    if (prp_Items != null)
                    {
                        prp_Items.Clear();
                        prp_Items = null;
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
