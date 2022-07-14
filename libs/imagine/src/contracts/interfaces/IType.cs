//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IType
    {
        Identifier Name {get;}

        ulong Kind => 0;

        bool IsEmpty => Name.IsEmpty;

        bool IsNonEmpty => !IsEmpty;

        string Format()
            => Name;
    }

    public interface IType<K> : IType
        where K : unmanaged
    {
        new K Kind {get;}

        ulong IType.Kind
            => Sized.bw64(Kind);
    }

    public interface IType<F,K> : IType<K>
        where K : unmanaged
        where F : IType<F,K>, new()
    {
        FormatFunction<F> ValueFormatter {get;}
    }
}