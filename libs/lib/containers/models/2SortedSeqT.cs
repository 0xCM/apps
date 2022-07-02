//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SortedSeq<T> : Seq<T>, ISortedSeq<T>
        where T : IComparable<T>
    {
        public SortedSeq()
        {

        }

        public SortedSeq(T[] src)
            : base(src.Sort())
        {

        }

        public void ReSort()
        {
            Data.Sort();
        }
    }
}