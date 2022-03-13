//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedRender;
    using static core;

    using Asm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var ocx = opcodes(patterns);
            var lookup = patterns.Map(x => (x.PatternId,x)).ToDictionary();
            var count = ocx.Count;
            var buffer = alloc<PatternIdentity>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var oc = ref ocx[i];
                var pattern = lookup[oc.PatternId];
                var id = identify(pattern);
                ref var dst = ref seek(buffer,i);
                dst.PatternId = pattern.PatternId;
                dst.Class = pattern.Class;
                dst.Name = identify(pattern);
                dst.OcKind = oc.Kind;
                dst.OcValue = oc.Value;
                dst.PatternBody = pattern.BodyExpr;
            }

            buffer.Sort();

            TableEmit(@readonly(buffer), PatternIdentity.RenderWidths, AppDb.XedTable<PatternIdentity>());

            return true;
        }

        static Identifier identify(InstPattern src)
        {
            var dst = text.buffer();
            dst.Append(format(src.Class).ToLower());
            for(var i=0; i<src.OperandCount; i++)
            {
                dst.Append(Chars.Underscore);
                ref readonly var op = ref src.Operands[i];
                var w = op.OpWidth;
                dst.AppendFormat("{0}{1}", format(op.Kind), w == 0 ? "V" : w);
            }

            return dst.Emit();
        }

        [CmdOp("xed/check/modrm")]
        Outcome CheckModRm(CmdArgs args)
        {
            var spec = ModRmVar.init();
            Write(spec.Format());

            spec.Mod(0b10);
            var a0 = spec.Evaluate();
            Require.equal(a0.Mod(), (uint2)0b10);
            Write(spec.Format());

            spec.Reg(0b101);
            var a1 = spec.Evaluate();
            Require.equal(a1.Reg(), (uint3)0b101);
            Write(spec.Format());

            spec.Rm(0b011);
            var a2 = spec.Evaluate();
            Require.equal(a2.Rm(), (uint3)0b011);
            Write(spec.Format());

            return true;
        }
    }
}