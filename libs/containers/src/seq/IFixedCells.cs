//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IFixedCells : ICellSeq
    {
        uint Capacity {get;}
    }

    public interface IFixedCells<T> : ISeq<T>, IEnumerable<T>
        where T : unmanaged
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => core.@throw<IEnumerator<T>>();

        IEnumerator IEnumerable.GetEnumerator()
            => core.@throw<IEnumerator>();

    }
}