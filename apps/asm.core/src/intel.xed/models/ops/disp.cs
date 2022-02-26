//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial struct XedModels
    {
        [Op]
        public static Disp disp(in OpState state, in AsmHexCode code)
        {
            var val = Disp.Zero;
            var _val = 0L;
            if(state.disp_width != 0)
            {
                var width = state.disp_width;
                var length = width/8;
                var offset = state.pos_disp;
                switch(length)
                {
                    case 1:
                        val = new Disp((sbyte)code[offset], NativeSizeCode.W8);
                        _val = (sbyte)code[offset];
                    break;
                    case 2:
                        val = new Disp(slice(code.Bytes, offset, length).TakeInt16(), NativeSizeCode.W16);
                        _val = slice(code.Bytes, offset, length).TakeInt16();
                    break;
                    case 4:
                        val = new Disp(slice(code.Bytes, offset, length).TakeInt32(), NativeSizeCode.W32);
                        _val = slice(code.Bytes, offset, length).TakeInt32();
                    break;
                    case 8:
                        val = new Disp(slice(code.Bytes, offset, length).TakeInt64(), NativeSizeCode.W64);
                        _val = slice(code.Bytes, offset, length).TakeInt64();
                    break;
                }
            }

            return val;
        }
    }
}