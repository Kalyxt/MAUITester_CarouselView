using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MAUITester_CarouselView.UI.StockViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseViewModel(MAUITester_CarouselView.AppEngine.AppEngine u_AppEngine)
        {
            try
            {
                AppEngine = u_AppEngine;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        #region PROPERTIES

        protected MAUITester_CarouselView.AppEngine.AppEngine AppEngine { get; set; }

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Activity tracker.
        /// </summary>
        protected bool prp_IsRunning = false;
        public bool IsRunning
        {
            get { return prp_IsRunning; }
            set
            {
                prp_IsRunning = value;
                OnPropertyChanged("IsRunning");
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

        public bool SetProperty<T>(ref T urf_Property, T value, [CallerMemberName] string propertyName = "")
        {
            try
            {

                if (EqualityComparer<T>.Default.Equals(urf_Property, value) == false)
                {
                    urf_Property = value;

                    if (string.IsNullOrWhiteSpace(propertyName) == false)
                        OnPropertyChanged(propertyName);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        #endregion

    }
}
