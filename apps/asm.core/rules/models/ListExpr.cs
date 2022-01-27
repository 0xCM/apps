//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListExpr<T> : IExpr
    {
        public Index<T> Items {get;}

        public ListExpr(T[] src)
        {
            Items = src;
        }

        public string Format()
            => Items.Delimit(Chars.Comma, fence:RenderFence.Embraced).Format();

        public override string ToString()
            => Format();

        public static implicit operator ListExpr<T>(T[] src)
            => new ListExpr<T>(src);
    }
}