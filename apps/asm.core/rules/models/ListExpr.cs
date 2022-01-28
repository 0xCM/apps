//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListExpr<T> : RuleExpr<Index<T>>
    {
        public Index<T> Items
            => Content;

        public ListExpr(T[] src)
            : base(src)
        {

        }

        public bool IsEmpty
        {
            get => Items.IsEmpty;
        }

        public bool IsNonEmpty
        {
            get => Items.IsNonEmpty;
        }

        public override string Format()
            => Items.Delimit(Chars.Comma, fence:RenderFence.Embraced).Format();

        public static implicit operator ListExpr<T>(T[] src)
            => new ListExpr<T>(src);
    }
}