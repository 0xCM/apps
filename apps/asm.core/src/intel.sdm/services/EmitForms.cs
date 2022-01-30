//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        Outcome EmitForms(ReadOnlySpan<SdmOpCodeDetail> details)
        {
            var occount = details.Length;
            var records = list<SdmFormRecord>();
            var result = Outcome.Success;
            var k = 0u;
            for(var i=0; i<occount; i++)
            {
                ref readonly var detail = ref skip(details,i);
                var s = detail.Sig.Format().ToLowerInvariant();
                result = AsmSigExpr.parse(s, out var  _sig);
                if(result.Fail)
                    break;

                var rule = SymbolizeExpression(_sig);
                var terminals = rule.Terminate().Map(t => paired(AsmSigs.identify(t), t));

                result = AsmOcParser.parse(detail.OpCode, out var opcode);
                if(result.Fail)
                    break;

                for(var j=0; j<terminals.Count; j++)
                {
                    var record = new SdmFormRecord();
                    ref readonly var terminal = ref terminals[j];
                    record.Seq = k++;
                    record.Name = terminal.Left;
                    record.Terminal = AsmSigs.expression(terminal.Right);
                    record.Sig = _sig;
                    record.OpCode = opcode;
                    records.Add(record);
                }
            }

            if(result.Fail)
                return result;

            TableEmit(records.ViewDeposited(), SdmFormRecord.RenderWidths, ProjectDb.TablePath<SdmFormRecord>("sdm"));

            return result;
        }

    }
}