//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDigit : IHashed
    {
        char Char {get;}

        string Format();
    }

    public interface IDigit<D,B,S,C,V> : IDigit, IComparable<D>, IEquatable<D>, IHashed
        where D : unmanaged, IDigit<D,B,S,C,V>
        where B : unmanaged, INumericBase<B>
        where S : unmanaged
        where V : unmanaged
        where C : unmanaged
    {
        S Symbol {get;}

        V Value {get;}

        C Code {get;}
    }
}