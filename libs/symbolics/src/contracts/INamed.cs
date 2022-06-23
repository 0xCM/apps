//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INamed<T> : IDataType<T>
        where T : unmanaged, INamed<T>
    {
        string Format();
    }
}