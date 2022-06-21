using System;
using Prism.Common;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Forms;

namespace Prism.Controls
{
    /// <summary>
    /// Custom Prism Navigation Page that forces use of the <see cref="INavigationService"/> to go back when the Back Button is pressed
    /// </summary>
    public class PrismNavigationPage : NavigationPage
    {
        /// <summary>
        /// Creates a new <see cref="PrismNavigationPage"/>
        /// </summary>
        public PrismNavigationPage()
        {
            BackButtonPressed += HandleBackButtonPressed;
        }

        /// <summary>
        /// Event to Notify when the back button has been pressed
        /// </summary>
        public event EventHandler BackButtonPressed;

        /// <inheritdoc />
        protected override bool OnBackButtonPressed()
        {
            BackButtonPressed.Invoke(this, EventArgs.Empty);
            return false;
        }

        private async void HandleBackButtonPressed(object sender, EventArgs args)
        {
            await PageUtilities.HandleNavigationPageGoBack(this);
        }
    }
}
