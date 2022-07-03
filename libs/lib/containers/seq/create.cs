//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        public static S create<S,T>(uint count)
            where S : ISeq<S,T>, new()
        {
            var dst = new S();
            var buffer = sys.alloc<T>(count);
            return dst;
        }
    }
}