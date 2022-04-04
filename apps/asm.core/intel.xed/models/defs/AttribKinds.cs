//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct XedModels
    {
        public struct AttribKinds
        {
            [MethodImpl(Inline), Op]
            public static AttribKinds init(ReadOnlySpan<AttributeKind> src)
            {
                var length = min(src.Length, 8);
                var data = 0ul;
                if(length != 0)
                {
                    ref var dst = ref uint8(ref data);
                    ref readonly var a = ref core.first(src);
                    for(byte i=0; i<length; i++)
                        seek(dst,i) = (byte)skip(a,i);
                }
                return new AttribKinds(data);
            }

            readonly Cell128 Data;

            [MethodImpl(Inline)]
            internal AttribKinds(Cell128 data)
            {
                Data = data;
            }

            [MethodImpl(Inline)]
            public bit Test(AttributeKind index)
            {
                var i = (byte)index;
                if((byte)index <= 63)
                    return bit.test(Data.Lo, i);
                else
                    return (bit.test(Data.Hi, (byte)(i - 64)));
            }

            [MethodImpl(Inline)]
            public void Enable(AttributeKind kind)
            {
                var i = (byte)kind;
                if(i <= 63)
                    bit.enable(Data.Lo, i);
                else
                    bit.enable(Data.Hi, (byte)(i - 64));
            }

            public ReadOnlySpan<AttributeKind> Enabled()
            {
                var storage = ByteBlock32.Empty;
                var buffer = recover<AttributeKind>(storage.Bytes);
                var kinds = Symbols.index<AttributeKind>().Kinds;
                var count = kinds.Length;
                var counter = 0;
                for(var i=0; i<count && counter < buffer.Length; i++)
                {
                    var kind = (AttributeKind)i;
                    if(Test(kind))
                        seek(buffer,counter++) = kind;
                }
                return slice(buffer,0,counter);
            }

            public string Format()
            {
                var lo = BitRender.format64x8(Data.Lo);
                var hi = BitRender.format64x8(Data.Hi);
                return string.Format("{0} {1}", hi, lo);
            }

            public override string ToString()
                => Format();

            public static AttribKinds Empty => default;
        }
    }
}