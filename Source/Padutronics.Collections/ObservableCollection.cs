using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Padutronics.Collections;

public sealed class ObservableCollection<T> : Collection<T>, IObservableCollection<T>, IReadOnlyObservableCollection<T>
{
    private const int InvalidIndex = -1;

    public ObservableCollection()
    {
    }

    public ObservableCollection(IEnumerable<T> items) :
        this(items.ToList())
    {
    }

    public ObservableCollection(IList<T> wrappee) :
        base(wrappee)
    {
    }

    public event EventHandler<ChangedEventArgs<T>>? Changed;

    protected override void ClearItems()
    {
        base.ClearItems();

        OnChanged(new ChangedEventArgs<T>(ChangeType.Cleared, oldItem: default, oldItemIndex: InvalidIndex, newItem: default, newItemIndex: InvalidIndex));
    }

    protected override void InsertItem(int index, T item)
    {
        base.InsertItem(index, item);

        OnChanged(new ChangedEventArgs<T>(ChangeType.Added, oldItem: default, oldItemIndex: InvalidIndex, newItem: item, newItemIndex: index));
    }

    private void OnChanged(ChangedEventArgs<T> e)
    {
        Changed?.Invoke(this, e);
    }

    protected override void RemoveItem(int index)
    {
        T removedItem = Items[index];

        base.RemoveItem(index);

        OnChanged(new ChangedEventArgs<T>(ChangeType.Removed, oldItem: removedItem, oldItemIndex: index, newItem: default, newItemIndex: InvalidIndex));
    }

    protected override void SetItem(int index, T item)
    {
        T replacedItem = Items[index];

        base.SetItem(index, item);

        OnChanged(new ChangedEventArgs<T>(ChangeType.Replaced, oldItem: replacedItem, oldItemIndex: index, newItem: item, newItemIndex: index));
    }
}