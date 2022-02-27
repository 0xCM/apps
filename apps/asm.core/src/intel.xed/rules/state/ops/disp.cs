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
        partial struct RuleStateCalcs
        {
            [Op]
            public static Disp disp(in FieldState state, in AsmHexCode code)
            {
                var val = Disp.Zero;
                if(state.DISP_WIDTH != 0)
                {
                    var width = state.DISP_WIDTH;
                    var length = width/8;
                    var offset = state.POS_DISP;
                    switch(length)
                    {
                        case 1:
                            val = new Disp((sbyte)code[offset], NativeSizeCode.W8);
                        break;
                        case 2:
                            val = new Disp(slice(code.Bytes, offset, length).TakeInt16(), NativeSizeCode.W16);
                        break;
                        case 4:
                            val = new Disp(slice(code.Bytes, offset, length).TakeInt32(), NativeSizeCode.W32);
                        break;
                        case 8:
                            val = new Disp(slice(code.Bytes, offset, length).TakeInt64(), NativeSizeCode.W64);
                        break;
                    }
                }

                return val;
            }
        }
    }
}