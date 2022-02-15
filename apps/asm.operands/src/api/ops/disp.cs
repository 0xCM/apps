//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using Operands;

    partial struct asm
    {

        [Op]
        public static Disp disp(ReadOnlySpan<byte> src, byte pos, NativeSize size)
        {
            var val = Disp.Zero;
            var width = (byte)size.Width;
            var length = (byte)(width/8);
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    val = new Disp((sbyte)skip(src, pos), width);
                break;
                case NativeSizeCode.W16:
                    val = new Disp(slice(src, pos, length).TakeInt16(), width);
                break;
                case NativeSizeCode.W32:
                    val = new Disp(slice(src, pos, length).TakeInt32(), width);
                break;
                case NativeSizeCode.W64:
                    val = new Disp(slice(src, pos, length).TakeInt64(), width);
                break;
            }

            return val;
        }
    }
}