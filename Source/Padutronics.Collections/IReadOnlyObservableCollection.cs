using System;
using System.Collections.Generic;

namespace Padutronics.Collections;

public interface IReadOnlyObservableCollection<T> : IReadOnlyList<T>
{
    event EventHandler<ChangedEventArgs<T>>? Changed;
}