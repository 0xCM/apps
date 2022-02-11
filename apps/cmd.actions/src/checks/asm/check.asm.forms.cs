//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CheckCmdProvider
    {
        public static bool diff(in AsmOpCode a, in AsmOpCode b, out Pair<AsmOcToken> dst)
        {
            var count = min(a.TokenCount, b.TokenCount);
            dst = default;
            var result = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var ta = ref a[i];
                ref readonly var tb = ref b[i];
                if(ta == tb)
                    continue;

                if(ta.Kind == AsmOcTokenKind.Sep || tb.Kind == AsmOcTokenKind.Sep)
                    continue;

                dst = (ta,tb);
                result = true;
                break;
            }
            return result;
        }

        [CmdOp("check/asm/forms")]
        Outcome CheckAsmForms(CmdArgs args)
        {
            const string RP = "{0,-6} | {1,-48} | {2,-48} | {3,-32} | {4,-6} | {5,-6} | {6,-6}";
            var result = Sdm.LoadForms(out var forms);
            if(result.Fail)
                return result;

            var count = forms.Count;
            var path = ProjectDb.Subdir("sdm") + Tables.filename<AsmFormDetail>();
            var lookup = dict<Identifier,AsmFormDetail>();
            var buffer = alloc<AsmFormDetail>(count);

            for(var i=0u; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var form = ref forms[i];
                ref readonly var sig = ref form.Sig;
                ref readonly var opcode = ref form.OpCode;
                dst.Seq = i;
                dst.Sig = sig;
                dst.OpCode = opcode;
                dst.IsRex = AsmOpCodes.rex(opcode);
                dst.IsVex = AsmOpCodes.vex(opcode);
                dst.IsEvex = AsmOpCodes.evex(opcode);

                var name = AsmSigs.identify(sig);
                var rex = AsmOpCodes.rex(opcode);
                var vex = AsmOpCodes.vex(opcode);
                var evex = AsmOpCodes.evex(opcode);
                if(lookup.TryGetValue(name, out var prior))
                {
                    if(rex)
                        name = string.Format("{0}_{1}", name, "rex");
                    else if(vex)
                        name = string.Format("{0}_{1}", name, "vex");
                    else if(evex)
                        name = string.Format("{0}_{1}", name, "evex");
                    else
                    {
                        if(diff(prior.OpCode, opcode, out var dx))
                            name = string.Format("{0}_{1}", name, dx.Right);
                        else
                            name = string.Format("{0}_duplicate", name);
                    }
                }

                dst.Name = name;
                if(!lookup.TryAdd(name, dst))
                {
                    Warn(string.Format("{0,-48} | {1}", name, form));
                }
            }

            TableEmit(@readonly(buffer), AsmFormDetail.RenderWidths, ProjectDb.Subdir("sdm") + Tables.filename<AsmFormDetail>());
            return result;
        }
    }
}