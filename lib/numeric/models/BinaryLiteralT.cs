//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct BinaryLiteral<T> : ILiteral<BinaryLiteral<T>,T>
        where T : unmanaged
    {
        public string Name {get;}

        public T Data {get;}

        public string Text {get;}

        [MethodImpl(Inline)]
        public BinaryLiteral(string name, T value, string text)
        {
            Name = name;
            Data = value;
            Text = text;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Name) && (empty(Text) || Data.Equals(default));
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Name) && nonempty(Text) && !Data.Equals(default);
        }

        public BinaryLiteral<T> Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public string Format()
            => $"{Name}({Data}:{NumericKinds.kind<T>().Keyword()}) := " + RP.enquote(Text);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(BinaryLiteral<T> src)
            => eq(this, src);
        public static BinaryLiteral<T> Empty
            => new BinaryLiteral<T>(EmptyString, default, EmptyString);

        [MethodImpl(Inline)]
        static bool eq(BinaryLiteral<T> x, BinaryLiteral<T> y)
            => string.Equals(x.Text, y.Text)
            && object.Equals(x.Data, y.Data)
            && string.Equals(x.Name, y.Name);
    }
}