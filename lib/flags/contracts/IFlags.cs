//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlags : ITextual
    {
        BitWidth DataWidth {get;}

        bit this[byte index] {get;}
    }

    public interface IFlags<E> : IFlags
        where E : unmanaged
    {
        E State {get;}

    }

    public interface IFlags<E,W> : IFlags<E>
        where E : unmanaged
        where W : unmanaged
    {

    }

    public interface IFlags<F,E,W> : IFlags<E,W>
        where E : unmanaged
        where W : unmanaged
        where F : IFlags<F,E,W>
    {
    }
}