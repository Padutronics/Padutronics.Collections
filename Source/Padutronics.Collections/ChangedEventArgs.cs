using System;

namespace Padutronics.Collections;

public sealed class ChangedEventArgs<T> : EventArgs
{
    public ChangedEventArgs(ChangeType type, T? oldItem, int oldItemIndex, T? newItem, int newItemIndex)
    {
        NewItem = newItem;
        NewItemIndex = newItemIndex;
        OldItem = oldItem;
        OldItemIndex = oldItemIndex;
        Type = type;
    }

    public T? NewItem { get; }

    public int NewItemIndex { get; }

    public T? OldItem { get; }

    public int OldItemIndex { get; }

    public ChangeType Type { get; }
}