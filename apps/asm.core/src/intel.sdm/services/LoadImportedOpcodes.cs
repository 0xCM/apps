//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;
    using static AsmSigs;

    partial class IntelSdm
    {
        public Index<SdmSigOpCode> LoadImportedOpCodes()
        {
            return Data(nameof(LoadImportedOpCodes), Load);

            Index<SdmSigOpCode> Load()
            {
                var src = SdmPaths.ImportPath("sdm.opcodes", FS.Txt);
                var data = src.ReadLines().Where(text.nonempty);
                var count = data.Length;
                var buffer = alloc<SdmSigOpCode>(count);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var line = ref data[i];
                    var j = text.index(line,Chars.LParen);
                    var k = text.index(line,Chars.RParen);
                    if(j <  0 || k < 0)
                    {
                        Error(string.Format("Operand fence in {0} not found", line));
                        break;
                    }

                    var operands = (k - j == 1) ? sys.empty<string>() : text.trim(text.split(text.inside(line,j, k),Chars.Comma));
                    var mnemonic = (AsmMnemonic)text.left(line,j);
                    var sig = expression((AsmMnemonic)text.left(line,j),operands);
                    var oc = asm.opcode(i,text.trim(text.right(line,Chars.Eq)));
                    seek(buffer,i) = new SdmSigOpCode(sig, oc);
                }

                return buffer;
            }
        }
    }
}