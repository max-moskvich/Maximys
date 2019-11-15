//      *********    НЕ ИЗМЕНЯЙТЕ ЭТОТ ФАЙЛ     *********
//      Этот файл обновляется средством разработки. Внесение
//      изменений в этот файл может привести к ошибкам.
namespace Expression.Blend.SampleData.SampleDataSource
{
    using System; 
    using System.ComponentModel;

// Чтобы значительно уменьшить объем памяти, занимаемой примерами данных в рабочем приложении, можно задать
// константу условной компиляции DISABLE_SAMPLE_DATA и отключить пример данных во время выполнения.
#if DISABLE_SAMPLE_DATA
    internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("ms-appx:/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private ItemCollection _Collection = new ItemCollection();

        public ItemCollection Collection
        {
            get
            {
                return this._Collection;
            }
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Property1 = string.Empty;

        public string Property1
        {
            get
            {
                return this._Property1;
            }

            set
            {
                if (this._Property1 != value)
                {
                    this._Property1 = value;
                    this.OnPropertyChanged("Property1");
                }
            }
        }

        private bool _Property2 = false;

        public bool Property2
        {
            get
            {
                return this._Property2;
            }

            set
            {
                if (this._Property2 != value)
                {
                    this._Property2 = value;
                    this.OnPropertyChanged("Property2");
                }
            }
        }
    }

    public class ItemCollection : System.Collections.ObjectModel.ObservableCollection<Item>
    { 
    }
#endif
}
