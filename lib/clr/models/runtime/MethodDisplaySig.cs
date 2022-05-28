//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct MethodDisplaySig
    {
        readonly string Content;

        [MethodImpl(Inline)]
        internal MethodDisplaySig(string src)
            => Content = src ?? EmptyString;

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public bool Equals(MethodDisplaySig src)
            => Text == src.Text;

        public override int GetHashCode()
            => core.hash(Text);


        public static MethodDisplaySig Empty
        {
            [MethodImpl(Inline)]
            get => new MethodDisplaySig(EmptyString);
        }
    }
}