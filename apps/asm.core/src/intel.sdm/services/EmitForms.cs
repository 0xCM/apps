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
            var specs = hashset<AsmFormSpec>();

            for(var i=0; i<occount; i++)
            {
                ref readonly var detail = ref skip(details,i);
                var s = detail.Sig.Format().ToLowerInvariant();
                result = AsmSigParser.expression(s, out var sigx);
                if(result.Fail)
                    break;

                var rule = SymbolizeExpression(sigx);
                var terminals = rule.Terminate().Map(t => paired(AsmSigs.identify(t), t));

                result = AsmOcParser.parse(detail.OpCode, out var opcode);
                if(result.Fail)
                    break;


                for(var j=0; j<terminals.Count; j++)
                {
                    var record = new SdmFormRecord();
                    ref readonly var terminal = ref terminals[j];

                    var sigt = AsmSigs.expression(terminal.Right);
                    var kind = terminal.Left;
                    record.Token = AsmFormSpec.token(sigt, opcode);
                    record.Mnemonic = sigx.Mnemonic;
                    record.Kind = kind;
                    record.OpCode = opcode;
                    record.Sig = sigt;
                    record.Source = sigx;
                    records.Add(record);
                }
            }

            if(result.Fail)
                return result;

            var output = records.ToArray().Sort();
            for(var i=0u; i<records.Count; i++)
                seek(output, i).Seq = i;

            TableEmit(@readonly(output), SdmFormRecord.RenderWidths, ProjectDb.TablePath<SdmFormRecord>("sdm"));

            return result;
        }

    }
}