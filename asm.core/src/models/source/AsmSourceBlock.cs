//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmSourceBlock
    {
        public Bitness Bitness {get;}

        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public AsmSourceBlock(Bitness b, TextBlock content)
        {
            Bitness = b;
            Content = content;
        }

        public string Format()
        {
            var result = EmptyString;
            var bits = (byte)Bitness;
            return bits != 0 ? string.Format("bits {0}\r\n{1}", bits, Content) : Content;
        }

        public override string ToString()
            => Format();
    }
}