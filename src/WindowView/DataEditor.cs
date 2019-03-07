using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
//using SpellViewer.ViewModel;
using System.CodeDom.Compiler;
using System.Windows.Controls;


namespace C246SpellBook_V_2.WindowView
{
    class DataEditor : Window, IComponentConnector
    {
        internal DataGrid DataGrid_Schools;
        internal DataGrid DataGrid_Sources;
        internal DataGrid DataGrid_Components;
        private bool _contentLoaded;

        public DataEditor()
        {
            this.InitializeComponent();
        }

        private void DataEditor_Closing(object sender, CancelEventArgs e)
        {
           // (this.DataContext as SpellViewerVM).CloseDataEditor();
            this.DataGrid_Schools.CommitEdit();
            this.DataGrid_Schools.CommitEdit();
            this.DataGrid_Schools.CancelEdit();
            this.DataGrid_Schools.CancelEdit();
            this.DataGrid_Sources.CommitEdit();
            this.DataGrid_Sources.CommitEdit();
            this.DataGrid_Sources.CancelEdit();
            this.DataGrid_Sources.CancelEdit();
            this.DataGrid_Components.CommitEdit();
            this.DataGrid_Components.CommitEdit();
            this.DataGrid_Components.CancelEdit();
            this.DataGrid_Components.CancelEdit();
        }

        public void InitializeComponent()
        {
            if (this._contentLoaded)
                return;
            this._contentLoaded = true;
            Application.LoadComponent((object)this, new Uri("/C246SpellBook_V_2;component/OtherWindows/dataEditor.xaml", UriKind.Relative));
        }

        internal Delegate _CreateDelegate(Type delegateType, string handler)
        {
            return Delegate.CreateDelegate(delegateType, (object)this, handler);
        }

       
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
                    ((Window)target).Closing += new CancelEventHandler(this.DataEditor_Closing);
                    break;
                case 2:
                    this.DataGrid_Schools = (DataGrid)target;
                    break;
                case 3:
                    this.DataGrid_Sources = (DataGrid)target;
                    break;
                case 4:
                    this.DataGrid_Components = (DataGrid)target;
                    break;
                default:
                    this._contentLoaded = true;
                    break;
            }
        }
        */
    }
}