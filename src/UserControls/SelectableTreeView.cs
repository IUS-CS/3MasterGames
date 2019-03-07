// Decompiled with JetBrains decompiler
// Type: SpellViewer.View.UserControls.SelectableTreeView
// Assembly: SpellViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 239CB56D-5FAB-4B38-9052-67DAB0CE0A69
// Assembly location: C:\Users\ZAC16\Desktop\SpellViewer.exe

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SpellViewer.View.UserControls
{
  public class SelectableTreeView : TreeView, INotifyPropertyChanged
  {
    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(nameof (SelectedItem), typeof (object), typeof (SelectableTreeView), new PropertyMetadata((PropertyChangedCallback) null));

    public new object SelectedItem
    {
      get
      {
        return this.GetValue(TreeView.SelectedItemProperty);
      }
      set
      {
        this.SetValue(SelectableTreeView.SelectedItemsProperty, value);
        this.NotifyPropertyChanged(nameof (SelectedItem));
      }
    }

    public SelectableTreeView()
    {
      this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(this.MyTreeView_SelectedItemChanged);
    }

    private void MyTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      this.SelectedItem = base.SelectedItem;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged(string aPropertyName)
    {
      if (this.PropertyChanged == null)
        return;
      this.PropertyChanged((object) this, new PropertyChangedEventArgs(aPropertyName));
    }
  }
}
