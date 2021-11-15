//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISized
    {
        BitWidth Width {get;}

        ByteSize Size
            => Width.Bytes;
    }

    [Free]
    public interface ISized<T> : ISized
        where T : unmanaged
    {
        ByteSize ISized.Size
            => minicore.size<T>();

        BitWidth ISized.Width
            => minicore.width<T>();
    }
}