using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace C246SpellBook_V_2.WindowView
{
    public class ChangeLog : Window, IComponentConnector
    {
        private bool _contentLoaded;

        public ChangeLog()
        {
            this.InitializeComponent();
        }

        public void InitializeComponent()
        {
            if (this._contentLoaded)
                return;
            this._contentLoaded = true;
            Application.LoadComponent((object)this, new Uri("/C246SpellBook_V_2;component/OtherWindows/Changelog.xaml", UriKind.Relative));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }
    }
}