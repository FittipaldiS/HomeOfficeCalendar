using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Helper
{
    public class ChangeTracking<DataRow> : IDisposable where DataRow : INotifyPropertyChanged
    {
        private ObservableCollection<DataRow> Items { get; set; }
        private HashSet<DataRow> Created { get; set; } = new HashSet<DataRow>();
        private HashSet<DataRow> Updated { get; set; } = new HashSet<DataRow>();
        private HashSet<DataRow> Deleted { get; set; } = new HashSet<DataRow>();

        public bool HasChanges => (Created.Count + Updated.Count + Deleted.Count) > 0;
        public List<DataRow> RowsCreated => Created.Count == 0 ? new List<DataRow>() : Created.ToList();
        public List<DataRow> RowsUpdated => Updated.Count == 0 ? new List<DataRow>() : Updated.ToList();
        public List<DataRow> RowsDeleted => Deleted.Count == 0 ? new List<DataRow>() : Deleted.ToList();

        public ChangeTracking() { }

        public ChangeTracking(ObservableCollection<DataRow> observableCollection)
        {
            Contract.Requires(observableCollection != null);
            StartTracking(observableCollection);
        }

        public void StartTracking(ObservableCollection<DataRow> observableCollection)
        {
            Contract.Requires(observableCollection != null);
            Items = observableCollection;

            Items.CollectionChanged += CollectionChanged;
            foreach (DataRow row in Items)
            {
                row.PropertyChanged += PropertyChanged;
            }
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Contract.Requires(Updated != null);
            Contract.Requires(Created != null);

            Updated.Add((DataRow)sender);
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:

                    foreach (DataRow row in e.NewItems)
                    {
                        Created.Add(row);
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:

                    foreach (var old in e.OldItems)
                    {
                        Deleted.Add((DataRow)old);
                    }

                    Created.ToList().ForEach(x =>
                    {
                        if (Deleted.Contains(x))
                        {
                            Deleted.Remove(x);
                        }
                    });

                    foreach (var old in e.OldItems)
                    {
                        DataRow row = (DataRow)old;
                        row.PropertyChanged -= PropertyChanged;
                        Created.Remove(row);
                        Updated.Remove(row);
                    }

                    break;

                case NotifyCollectionChangedAction.Reset:

                    ClearTracking();

                    break;

                default:
                    break;
            }
        }

        public void ClearTracking()
        {
            Contract.Requires(Created != null);
            Contract.Requires(Updated != null);
            Contract.Requires(Deleted != null);

            foreach (DataRow r in Created)
            {
                r.PropertyChanged += PropertyChanged;
            }

            Created.Clear();
            Updated.Clear();
            Deleted.Clear();
        }

        public void Dispose()
        {
            Contract.Requires(Items != null);

            Created.Clear();
            Updated.Clear();
            Deleted.Clear();

            Items.CollectionChanged -= CollectionChanged;
            foreach (DataRow row in Items)
            {
                row.PropertyChanged -= PropertyChanged;
            }
        }
    }
}
