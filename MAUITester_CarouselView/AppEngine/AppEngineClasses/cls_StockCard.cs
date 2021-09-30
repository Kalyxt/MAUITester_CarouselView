using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MAUITester_CarouselView.AppEngine.AppEngineClasses
{
    /// <summary>
    /// Stock item.
    /// </summary>
    public class cls_StockCard : IDisposable, INotifyPropertyChanged
    {

        public cls_StockCard(AppEngine u_AppEngine)
        {
            prp_AppEngine = u_AppEngine;
        }

        #region PROPERTIES

        private AppEngine prp_AppEngine;

        public AppEngine AppEngine
        {
            get
            {
                return prp_AppEngine;
            }
        }

        /// <summary>Name of the StockCard.</summary>
        public string Name { get; set; }

        /// <summary>Name of the category in which stockcard is.</summary>
        public string Category { get; set; }
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
