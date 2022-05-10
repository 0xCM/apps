//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial class InstSigs
        {
            public readonly struct SigToken
            {
                readonly asci8 Value;

                [MethodImpl(Inline)]
                public SigToken(asci8 src)
                {
                    Value = src;
                }

                public string Format()
                    => Value.Format();

                public override string ToString()
                    => Format();

                [MethodImpl(Inline)]
                public static implicit operator SigToken(string src)
                    => new SigToken(src);
            }
        }
    }
}