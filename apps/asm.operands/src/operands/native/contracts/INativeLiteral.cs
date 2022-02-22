//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INativeLiteral
    {
        Label Name {get;}
        ReadOnlySpan<byte> Data {get;}
    }

    public interface INativeLiteral<T> : INativeLiteral
        where T : unmanaged
    {
        T Value {get;}
    }
}