using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace EvanPlayHouse.Controls
{
    public class BindableStackLayout : StackLayout
    {
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(BindableStackLayout), default(ElementTemplate));

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(BindableStackLayout), default(IEnumerable), propertyChanged: GetEnumerator);
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void GetEnumerator(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BindableStackLayout)bindable;

            if (oldValue is INotifyCollectionChanged oldObservableCollection)
            {
                oldObservableCollection.CollectionChanged -= control.OnItemsSourceCollectionChanged;
            }

            if (newValue is INotifyCollectionChanged newObservableCollection)
            {
                newObservableCollection.CollectionChanged += control.OnItemsSourceCollectionChanged;
            }

            if (newValue != null)
            {
                foreach (var child in newValue as IEnumerable)
                {
                    var view = (View)(bindable as BindableStackLayout).ItemTemplate.CreateContent();
                    view.BindingContext = child;
                    (bindable as BindableStackLayout).Children.Add(view);
                }
            }
        }

        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            //if (RowDefinitions.Any())
            //{
            //    RowDefinitions.Clear();
            //}
            //var numberOfRows = Math.Ceiling(e.NewItems.Count / (float)NumberOfColumns);
            //for (var i = 0; i < numberOfRows; i++)
            //{
            //    RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //}

            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                Children.Clear();
            }


            var invalidate = false;

            if (e.OldItems != null)
            {
                Children.RemoveAt(e.OldStartingIndex);
                invalidate = true;
            }

            if (e.NewItems != null)
            {
                foreach (var child in e.NewItems as IEnumerable)
                {
                    var view = (View)ItemTemplate.CreateContent();
                    view.BindingContext = child;
                    Children.Add(view);
                }

                invalidate = true;
            }

            if (invalidate)
            {
                UpdateChildrenLayout();
                InvalidateLayout();
            }
        }
    }
}