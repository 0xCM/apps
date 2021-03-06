//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct Value : IValue<ByteBlock3>
        {
            [MethodImpl(Inline)]
            public static Value untype<T>(T src)
                where T : unmanaged, IValue<T>
                    => new Value(core.bw32(src.Value));

            readonly ByteBlock4 Storage;

            [MethodImpl(Inline)]
            public Value(uint data)
            {
                Storage = data;
            }

            ByteBlock3 IValue<ByteBlock3>.Value
                => Storage.Cell<ByteBlock3>(0);

            public static Value Empty => default;
        }
    }
}