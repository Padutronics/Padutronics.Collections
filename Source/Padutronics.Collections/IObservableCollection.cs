using System.Collections.Generic;

namespace Padutronics.Collections;

public interface IObservableCollection<T> : IReadOnlyObservableCollection<T>, IList<T>
{
}