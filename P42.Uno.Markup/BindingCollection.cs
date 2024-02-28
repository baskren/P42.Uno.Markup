using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P42.Utils;

namespace P42.Uno.Markup;
internal class BindingCollection : ObservableConcurrentCollection<WorkaroundBinding>
{
    protected override void InsertItem(int index, WorkaroundBinding item)
    {
        if (this.FirstOrDefault(i => i.TargetProperty == item.TargetProperty) is WorkaroundBinding oldBinding)
            Remove(oldBinding);

        base.InsertItem(index, item);
    }

    protected override void RemoveItem(int index)
    {
        this[index]?.Dispose();
        base.RemoveItem(index);
    }

    protected override void SetItem(int index, WorkaroundBinding item)
    {
        if (this.FirstOrDefault(i => i.TargetProperty == item.TargetProperty) is WorkaroundBinding oldBinding)
            Remove(oldBinding);

        base.SetItem(index, item);
    }

    protected override void ClearItems()
    {
        foreach (var item in this)
            item.Dispose();

        base.ClearItems();
    }
}
