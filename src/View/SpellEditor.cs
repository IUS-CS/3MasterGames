using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
//using SpellViewer.ViewModel;

namespace C246SpellBook_V_2.WindowView
{
    public class SpellEditor : Window, IComponentConnector
    {
        internal ComboBox ComponentsComboBox;
        internal ItemsControl ComponentsListControl;
        internal ItemsControl ClassListControl;
        private bool _contentLoaded;

        public SpellEditor()
        {
            this.InitializeComponent();
        }

        public void InitializeComponent()
        {
            if (this._contentLoaded)
                return;
            this._contentLoaded = true;
            Application.LoadComponent((object)this, new Uri("/C246SpellBook_V_2;component/View/OtherWindows/spellEditor.xaml", UriKind.Relative));
        }

        private void SpellEditor_Closing(object sender, CancelEventArgs e)
        {
           // (this.DataContext as SpellViewerVM).CloseSpellEditor();
        }

        internal Delegate _CreateDelegate(Type delegateType, string handler)
        {
            return Delegate.CreateDelegate(delegateType, (object)this, handler);
        }

        // has to have Icompentten connect but it does something automaticly
        void IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }
        /*
        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    ((Window)target).Closing += new CancelEventHandler(this.SpellEditor_Closing);
                    break;
                case 2:
                    this.ComponentsComboBox = (ComboBox)target;
                    break;
                case 3:
                    this.ComponentsListControl = (ItemsControl)target;
                    break;
                case 4:
                    this.ClassListControl = (ItemsControl)target;
                    break;
                default:
                    this._contentLoaded = true;
                    break;
            }
        }
        */
    }
}