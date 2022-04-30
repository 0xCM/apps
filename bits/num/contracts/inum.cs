//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface inum
    {
        byte Width {get;}

        ulong Value {get;}

        bit IsZero {get;}

        bit IsNonZero {get;}

        bit IsMax  {get;}
    }

    [Free]
    public interface inum<T> : inum, IEquatable<T>, IComparable<T>
        where T : unmanaged, inum<T>
    {

    }
}