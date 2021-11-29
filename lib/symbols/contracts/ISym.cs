//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISym : ITextual
    {
        SymKey Key {get;}

        SymIdentity Identity {get;}

        Identifier Type {get;}

        Identifier Name {get;}

        SymExpr Expr {get;}

        ulong Kind {get;}

        TextBlock Description {get;}

        bool Hidden {get;}
    }

    public interface ISym<T> : ISym
        where T : unmanaged
    {
        new T Kind {get;}

        ulong Value
            => core.bw64(Kind);

        ulong ISym.Kind
            => Value;
    }

    public interface ISym<W,T> : ISym<T>
        where W : unmanaged, IDataWidth
        where T : unmanaged
    {

    }
}