//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class list<T> : ITerm
    {
        public const string Identifier = "list<{0}>";

        Index<T> _Data;

        [MethodImpl(Inline)]
        public list(T[] src)
        {
            _Data = src;
        }

        public ReadOnlySpan<T> Items
        {
            [MethodImpl(Inline)]
            get => _Data.View;
        }

        public string TypeName
            => string.Format(Identifier, typeof(T).Name);

        public string Format()
            => string.Format("[{0}]", text.join(",", Items));

        public override string ToString()
            => Format();

        public static implicit operator list<T>(T[] src)
            => new list<T>(src);
    }
}