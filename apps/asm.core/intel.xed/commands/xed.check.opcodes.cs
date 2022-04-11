//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var patternLUa = patterns.Map(x => (x.PatternId, x)).ToDictionary();
            var patternLUb = patterns.Map(x => (x.PatternId, x.OcInst)).ToDictionary();
            var opcodes = XedPatterns.opcodes(patterns);
            var counter = 0u;
            var countLU = dict<OcInstClass,byte>();
            var buffer = alloc<OpCodeCounts>(patterns.Count);
            for(var i=0u; i<patterns.Count; i++)
            {
                ref var dst = ref buffer[i];
                ref var src = ref patterns[i];
                ref readonly var ocinst = ref src.OcInst;
                dst.PatternId = src.PatternId;
                dst.Mode = src.Mode;
                dst.InstClass = ocinst.InstClass;
                dst.OcKind = ocinst.OpCode.Kind;
                dst.OcValue = ocinst.OcValue;
                dst.PatternBody = src.Body;
                dst.Sort = src.Sort();
            }

            buffer.Sort();
            for(var i=0u; i<patterns.Count; i++)
                seek(buffer,i).Seq = i;

            TableEmit(@readonly(buffer), OpCodeCounts.RenderWidths, XedPaths.Table<OpCodeCounts>());

            return true;
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