//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct OpCode
        {
            public readonly Hex8 Value {get;}

            [MethodImpl(Inline)]
            public OpCode(byte src)
            {
                Value = src;
            }

            [MethodImpl(Inline)]
            public static implicit operator OpCode(byte src)
                => new OpCode(src);

            public string Format()
                => Value.ToString();

            public override string ToString()
                => Format();
        }
    }
}