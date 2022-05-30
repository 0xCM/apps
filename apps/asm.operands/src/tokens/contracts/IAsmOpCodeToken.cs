//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmOpCodeToken<V> : IToken<AsmOcTokenKind,V>
        where V : unmanaged, IEquatable<V>
    {

    }

    public interface IAsmOpCodeToken<T,V> : IAsmOpCodeToken<V>, IEquatable<T>, IComparable<T>
        where V : unmanaged, IEquatable<V>
        where T : unmanaged, IAsmOpCodeToken<T,V>
    {

    }
}