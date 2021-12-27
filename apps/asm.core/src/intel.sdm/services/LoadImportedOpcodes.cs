//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;
    using static SdmModels;

    partial class IntelSdm
    {
        public Index<SdmOpCode> LoadImportedOpCodes()
        {
            var src = SdmPaths.ImportPath("sdm.opcodes", FS.Txt);
            var data = src.ReadLines().Where(text.nonempty);
            var count = data.Length;
            var buffer = alloc<SdmOpCode>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var line = ref data[i];
                ref var dst = ref seek(buffer,i);
                dst.OpCodeKey = i;

                var j = text.index(line,Chars.LParen);
                var k = text.index(line,Chars.RParen);
                if(j <  0 || k < 0)
                {
                    Error(string.Format("Operand fence in {0} not found", line));
                    break;
                }

                if(k - j == 1)
                    dst.Operands = CharBlock64.Null;
                else
                    dst.Operands = text.inside(line,j, k);

                dst.Mnemonic = text.left(line,j);
                dst.Expr = text.trim(text.right(line,Chars.Eq));
            }

            return buffer;
        }
    }
}