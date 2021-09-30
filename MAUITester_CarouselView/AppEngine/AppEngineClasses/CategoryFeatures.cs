using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MAUITester_CarouselView.AppEngine.AppEngineClasses
{
    /// <summary>
    /// Contains list of categories and functions to work and edit categories.
    /// </summary>
    public class CategoryFeatures : IDisposable, INotifyPropertyChanged
    {

        public CategoryFeatures(AppEngine u_AppEngine)
        {
            prp_AppEngine = u_AppEngine;
        }


        #region PROPERTIES

        private AppEngine prp_AppEngine;
        /// <summary>
        /// Hlavný objekt programu LUKUL - predstavuje bežiacu inštanciu programu.
        /// </summary>
        public AppEngine AppEngine
        {
            get
            {
                return prp_AppEngine;
            }
        }


        private ObservableCollection<cls_Category> prp_Items;
        /// <summary>
        /// Category list.
        /// </summary>
        public ObservableCollection<cls_Category> Items
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

        private cls_Category prp_SelectedCategory;
        /// <summary>
        /// Selected category.
        /// </summary>
        public cls_Category SelectedCategory
        {
            get
            {
                return prp_SelectedCategory;
            }
            set
            {
                prp_SelectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        /// <summary>
        /// Set category and calls UI change.
        /// </summary>
        public void SetCategory(cls_Category u_Category)
        {
            try
            {
                SelectedCategory = u_Category;

                Console.WriteLine("SetCategory: " + u_Category.Name);

                // Invoke event  
                this.AppEngine.AppNavigation.OnUserAction(new MAUITester_CarouselView.AppEngine.AppNavigation.cls_UserActionEventArgs(AppNavigation.cls_UserActionEventArgs.enm_UserAction.MenuCategories));
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region PUBLIC METHODS



        /// <summary>
        /// Returns category based on name.
        /// </summary>
        public MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category GetCategory(string u_Name)
        {
            try
            {
                if (u_Name == string.Empty)
                {
                    return null;
                }

                if (this.Items == null)
                {
                    return null;
                }

                if (this.Items.Count == 0)
                {
                    return null;
                }

                foreach (MAUITester_CarouselView.AppEngine.AppEngineClasses.cls_Category e_Category in this.Items)
                {
                    if (string.Compare(e_Category.Name, u_Name) == 0)
                    {
                        // Found
                        return e_Category;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        /// <summary>
        /// Load categories to list.
        /// </summary>
        public void Load()
        {
            try
            {

                if (Items == null)
                {
                    this.Items = new ObservableCollection<cls_Category>();
                }
                else
                {
                    this.Items.Clear();
                }

                cls_Category tmp_Category;
                tmp_Category = new cls_Category(this.AppEngine);
                tmp_Category.Name = "Cars";
                this.Items.Add(tmp_Category);

                tmp_Category = new cls_Category(this.AppEngine);
                tmp_Category.Name = "Bikes";
                this.Items.Add(tmp_Category);

                tmp_Category = new cls_Category(this.AppEngine);
                tmp_Category.Name = "Planes";
                this.Items.Add(tmp_Category);

                tmp_Category = new cls_Category(this.AppEngine);
                tmp_Category.Name = "Boats";
                this.Items.Add(tmp_Category);

                tmp_Category = new cls_Category(this.AppEngine);
                tmp_Category.Name = "Rockets";
                this.Items.Add(tmp_Category);

            }
            catch(Exception ex)
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
