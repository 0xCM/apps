//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        Outcome LoadStanfordForms()
        {
            var catalog = Wf.StanfordCatalog();
            var rows = catalog.LoadAsset();
            var count = rows.Length;
            var forms = alloc<AsmFormInfo>(count);
            var dst = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                AsmParser.sigxpr(row.Instruction, out var sig);
                var form = new AsmFormInfo(asm.ocstring(row.OpCode), sig);
                seek(forms,i) = form;
                var spec = string.Format("{0,-32} | {1,-42} | {2,-42}", form.Sig.Mnemonic, form.OpCode, form.Sig);
                dst.Add(spec);
            }

            dst.Sort();
            iter(dst.ViewDeposited(), x => Wf.Row(x));

            return true;
        }
    }
}