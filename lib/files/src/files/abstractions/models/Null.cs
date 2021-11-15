//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType]
    public readonly struct Null : ITextual, INullity, INullary<Null>
    {
        public const string Identifier = "∅";

        public const string Label = "null";

        public const string Indicator = "!!null!!";

        public const string NullField = Identifier + nameof(NullField) + Identifier;

        public const string NullMethod = Identifier + nameof(NullMethod) + Identifier;

        public const string NullType = Identifier + nameof(NullType) + Identifier;

        public static Null Value => default;

        [MethodImpl(Inline)]
        public static object Banish(object src)
            => src ?? Value;

        [MethodImpl(Inline)]
        public static string Banish(string src)
            => src ?? Identifier;

        [MethodImpl(Inline)]
        public static bool Is(object src)
            => src is Null || src is null;

        [MethodImpl(Inline)]
        public static bool IsNot(object src)
            => !Is(src);

        [MethodImpl(Inline)]
        public static T Banish<T>(T src, T alt)
            where T : class
                => src ?? alt;

        public bool IsEmpty
            => true;

        public Null Zero
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Label;

        public override string ToString()
            => Format();
    }
}