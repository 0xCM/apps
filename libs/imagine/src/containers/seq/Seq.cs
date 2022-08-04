//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Seq
    {
        const NumericKind Closure = UInt64k;

        public static Seq<T> alloc<T>(uint count)
            => sys.alloc<T>(count);

        public static Seq<T> alloc<T>(int count)
            => sys.alloc<T>(count);            
    }
}