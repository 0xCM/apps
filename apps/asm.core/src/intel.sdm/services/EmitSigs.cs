//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static AsmSigExpr;

    partial class IntelSdm
    {
        Index<AsmFormExpr> EmitSigs(ReadOnlySpan<SdmOpCodeDetail> opcodes)
        {
            const string Pattern = "{0,-16} | {1,-64} | {2}";
            const string OpSep = ", ";
            var dst = SdmPaths.ImportPath("sdm.sigs", FS.Csv);
            var emitting = EmittingTable<AsmFormExpr>(dst);
            using var writer = dst.UnicodeWriter();
            var _forms = SdmOps.forms(opcodes);
            var count = _forms.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref _forms[i];
                ref readonly var sig = ref form.Sig;
                var operands = EmptyString;
                var opcount = form.Sig.OperandCount;
                switch(opcount)
                {
                    case 1:
                        operands = operand(sig,0).Format();
                    break;
                    case 2:
                        operands = string.Format(RP.delimit(n2, OpSep),
                            operand(sig,0),
                            operand(sig,1)
                            );
                    break;
                    case 3:
                        operands = string.Format(RP.delimit(n3, OpSep),
                            operand(sig,0),
                            operand(sig,1),
                            operand(sig,2)
                            );
                    break;
                    case 4:
                        operands = string.Format(RP.delimit(n4, OpSep),
                            operand(sig,0),
                            operand(sig,1),
                            operand(sig,2),
                            operand(sig,3)
                            );
                    break;
                    default:
                    break;
                }
                writer.WriteLine(string.Format(Pattern, form.Sig.Mnemonic, operands, form.OpCode.Format()));
            }

            EmittedTable(emitting, count);

            return _forms;
        }
    }
}