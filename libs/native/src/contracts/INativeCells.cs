
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public interface IUnmanaged
    {
        uint Size {get;}
    }

    public interface IUnmanaged<T> : IUnmanaged
        where T : unmanaged, IUnmanaged<T>
    {
        uint IUnmanaged.Size
            => core.size<T>();
    }

    public interface INativeCells : IBufferAllocation
    {
        uint CellCount {get;}
    }
}