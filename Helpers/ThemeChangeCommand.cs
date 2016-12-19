using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls.Theming;
using System.Windows;

namespace PortalEducase.Helpers
{
    public class ThemeChangeCommand : ICommand
    {
        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Theme themeContainer =
                  (Theme)((FrameworkElement)Application.Current.RootVisual).FindName("ThemeContainer");

            string themeName = parameter as string;


            if (themeName == null)
            {
                themeContainer.ThemeUri = null;
            }
            else
            {
                themeContainer.ThemeUri =
                     new Uri("/System.Windows.Controls.Theming." + themeName +
                     ";component/Theme.xaml", UriKind.RelativeOrAbsolute);
            }

            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        #endregion
    }
}
