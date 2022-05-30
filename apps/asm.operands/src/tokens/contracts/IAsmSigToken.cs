//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmSigToken<V> : IToken<AsmSigTokenKind,V>
        where V : unmanaged, IEquatable<V>
    {

    }

    public interface IAsmSigToken<T,V> : IAsmSigToken<V>, IEquatable<T>, IComparable<T>
        where V : unmanaged, IEquatable<V>
        where T : unmanaged, IEquatable<T>, IAsmSigToken<T,V>
    {

    }
}