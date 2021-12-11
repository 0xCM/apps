//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class TextVarKind<T> : ITextVarKind
        where T : TextVarKind<T>,new()
    {
        public virtual bool IsFenced => Fence.Left != AsciNull.Literal && Fence.Right != AsciNull.Literal;

        public virtual Fence<char> Fence => Fence<char>.Empty;

        public virtual string Prefix => EmptyString;

        public virtual bool IsPrefixed => text.nonempty(Prefix);

        public static T create()
            => new T();
    }
}