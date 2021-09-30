using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAUITester_CarouselView.AppEngine
{
    public class AppNavigation : IDisposable
    {

        #region  DECLARATION   

        const string CONST_ClassName = "AppNavigation";

        /// <summary>
        /// Reprezentuje číselné označenie stránok (pages) v aplikácii.
        /// </summary>
        public enum enm_Tester_PageNumbers : int
        {
            None = 0,

            Stock_Categories = 0,

            Stock_StockCards = 1

        }

        /// <summary>
        /// Reprezentuje číselné označenie stránok (pages) v TabbedPage (Stoly, skupiny, atd.). 
        /// </summary>
        public enum enm_Stock_TabbedPageNumbers : int
        {

            Stock_Categories = 0,

            Stock_StockCards = 1,

        }

        #endregion

        #region PROPERTIES


        private INavigation prp_Navigation;
        /// <summary>
        /// System interface to work with pages.
        /// </summary>
        public INavigation Navigation
        {
            get
            {
                return prp_Navigation;
            }
            set
            {
                prp_Navigation = value;
            }
        }

        private AppEngine prp_AppEngine;

        public AppEngine AppEngine
        {
            get
            {
                return prp_AppEngine;
            }
        }

        private enm_Tester_PageNumbers prp_NavigationPage;
        /// <summary>
        /// Current page of application.
        /// </summary>
        public enm_Tester_PageNumbers NavigationPage
        {
            get
            {
                return prp_NavigationPage;
            }

            set
            {
                prp_NavigationPage = value;
            }
        }

        private TabbedPage prp_TabbedPage;
        /// <summary>
        /// Current tabPage of application.
        /// </summary>
        public TabbedPage TabbedPage
        {
            get
            {
                return prp_TabbedPage;
            }

            set
            {
                prp_TabbedPage = value;
            }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Const.
        /// </summary>
        public AppNavigation(AppEngine u_AppEngine)
        {

            try
            {

                prp_AppEngine = u_AppEngine;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }



        #endregion

        #region METHODS - PUBLIC

        /// <summary>
        /// Pops active page.
        /// </summary>
        public System.Threading.Tasks.Task GoBack(bool u_Animated = true)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await this.Navigation.PopAsync(animated: u_Animated);
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        /// <summary>
        /// Change in NavigationStack.
        /// </summary>
        /// <returns></returns>
        public System.Threading.Tasks.Task GoPage(enm_Tester_PageNumbers u_Tester_PageNumber, bool u_Animation = true)
        {
            return System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        switch (u_Tester_PageNumber)
                        {

                            case enm_Tester_PageNumbers.Stock_Categories:

                                // Main page for stock agenda
                                if (TabbedPage == null)
                                {
                                    // Standard runtime
                                    TabbedPage = new MAUITester_CarouselView.UI.NavigationPages.StockTabbedPage(this.AppEngine);
                                }

                                this.Navigation.PushAsync(TabbedPage);

                                break;

                            // Stockcards
                            case enm_Tester_PageNumbers.Stock_StockCards:

                                TabbedPage.CurrentPage = TabbedPage.Children[(int)enm_Stock_TabbedPageNumbers.Stock_StockCards];

                                break;


                        }
                    });

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        #endregion

        #region EVENTS

        /// <summary>
        /// Event is invoked after user action (changing category for instance).
        /// </summary>
        public delegate void UserActionEventHandler(cls_UserActionEventArgs u_UserActionEventArgs);
        public event UserActionEventHandler UserAction;

        public virtual void OnUserAction(cls_UserActionEventArgs u_UserActionEventArgs)
        {
            try
            {
                UserAction?.Invoke(u_UserActionEventArgs);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>Args for UserAction.</summary>
        public class cls_UserActionEventArgs : EventArgs
        {

            public enm_UserAction UserAction { get; set; }


            public cls_UserActionEventArgs(enm_UserAction u_UserAction)
            {
                this.UserAction = u_UserAction;
            }

            /// <summary>
            /// Define user action.
            /// </summary>
            public enum enm_UserAction : int
            {

                /// <summary>No action or cancel previous.</summary>
                None = 0,

                /// <summary>Category was changed.</summary>
                MenuCategories = 2,

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
