//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct AttributeBits
        {
            ulong Lo;

            ulong Hi;

            [MethodImpl(Inline)]
            public AttributeBits Set(AttributeKind kind, bit state)
            {
                var i = index(kind);
                if(i < 64)
                    Lo = bit.set(Lo,i,state);
                else
                    Hi = bit.set(Hi,i, state);
                return this;
            }

            public bit Test(AttributeKind kind)
            {
                var i = index(kind);
                if(i < 64)
                    return bit.test(Lo,i);
                else
                    return bit.test(Hi,i);
            }

            public AttributeBits Clear()
            {
                Lo = 0;
                Hi = 0;
                return this;
            }


            [MethodImpl(Inline)]
            static byte index(AttributeKind kind)
                => (byte)kind;


            public static AttributeBits Zero => default;
        }
    }
}