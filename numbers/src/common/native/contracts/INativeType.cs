//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INativeType : ITextual
    {
        NativeSize Size {get;}

        BitWidth Width => Size.Width;
    }

    public interface INativeType<T> : INativeType, IEquatable<T>
        where T : unmanaged, INativeType<T>
    {

    }
}