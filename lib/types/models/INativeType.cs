//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INativeType
    {
        NativeSize Size {get;}
    }

    public interface INativeType<T> : INativeType, IEquatable<T>
        where T : unmanaged, INativeType<T>
    {

    }
}