//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a value with known size
    /// </summary>
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
            => Sized.size<T>();

        BitWidth ISized.Width
            => Sized.width<T>();
    }
}