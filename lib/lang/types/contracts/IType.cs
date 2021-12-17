//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IType : ITextual, INullity
    {
        Identifier Name {get;}

        ulong Kind {get;}

        bool INullity.IsEmpty
            => false;
    }

    public interface IType<K> : IType
        where K : unmanaged
    {
        new K Kind {get;}

        ulong IType.Kind
            => core.bw64(Kind);
    }

    public interface IType<F,K> : IType<K>
        where K : unmanaged
        where F : IType<F,K>, new()
    {
        ParseFunction<F> ValueParser {get;}

        FormatFunction<F> ValueFormatter {get;}
    }
}