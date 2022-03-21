//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedRender;
    using static XedModels;
    using static core;

    using Asm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var lookup = patterns.Map(x => (x.PatternId,x)).ToDictionary();
            var count = patterns.Count;
            var buffer = alloc<PatternIdentity>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                var oc = XedPatterns.opcode(pattern);
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


        static Identifier identify(in RuleOpSpec src)
        {
            var bw = src.OpWidth;
            var indicator = EmptyString;
            var dst = EmptyString;
            if(src.IsSegReg)
            {
                indicator = "sr";
            }
            else if(src.IsReg)
            {
                indicator = bw != 0 ? "r" : "reg";
            }
            else if(src.IsMem)
            {
                indicator = bw != 0 ? "m" : "mem";
            }
            else if(src.IsPtr)
            {
                indicator = "ptr";
            }
            else
            {
                indicator = format(src.Kind);
            }

            if(bw != 0)
            {
                dst = string.Format("{0}{1}", indicator, bw);
            }
            else
                dst = indicator;

            return dst;
        }

        static Identifier identify(InstPattern src)
        {
            var dst = text.buffer();
            ref readonly var attribs = ref src.InstAttribs;
            var name = EmptyString;
            var locked = attribs.Locked;
            if(locked)
                name = text.remove(format(src.Class), "_LOCK").ToLower();
            else
                name = format(src.Class).ToLower();

            dst.Append(name);

            for(var i=0; i<src.OperandCount; i++)
            {
                dst.Append(Chars.Underscore);
                ref readonly var op = ref src.OpSpecs[i];
                dst.Append(identify(op));
            }

            if(locked)
                dst.Append("_locked");

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