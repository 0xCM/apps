//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class IntelSdm
    {
        public Index<SdmSigOpCode> LoadImportedOpCodes()
        {
            var src = SdmPaths.ImportPath("sdm.opcodes", FS.Txt);
            var data = src.ReadLines().Where(text.nonempty);
            var count = data.Length;
            var buffer = alloc<SdmSigOpCode>(count);
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

                // if(k - j == 1)
                //     dst.Operands = CharBlock64.Null;
                // else
                //     dst.Operands = text.inside(line,j, k);

                var operands = (k - j == 1) ? sys.empty<string>() : text.trim(text.split(text.inside(line,j, k),Chars.Comma));
                var mnemonic = (AsmMnemonic)text.left(line,j);
                dst.OpCode = asm.opcode(i,text.trim(text.right(line,Chars.Eq)));
                dst.Sig = AsmSigs.expression((AsmMnemonic)text.left(line,j),operands);
            }

            return buffer;
        }
    }
}