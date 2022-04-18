//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    using static OpCodeId;

    public struct OpCodeId
    {
        const byte ClassWidth = InstClass.Width;

        const byte OcWidth = Hex8.Width;

        const byte ModWidth = ModIndicator.Width;

        const byte LockWidth = InstLock.Width;

        const byte RexWidth = RexBit.Width;

        const byte RepWidth = RepIndicator.Width;

        const byte MaxPos = 31;

        const byte ClassPos = MaxPos - ClassWidth;

        const byte OcPos = ClassPos - OcWidth;

        const byte ModPos = OcPos - ModWidth;

        const byte LockPos = ModPos - LockWidth;

        const byte RepPos = LockPos - RepWidth;

        const byte RexPos = RepPos - RexWidth;

        const uint ClassMask = (uint)Hex12.MaxValue >> ClassPos;

        const uint OcMask = (uint)byte.MaxValue >> OcPos;

        const uint ModMask = (uint)uint3.MaxValue >> ModPos;

        const uint RexMask = (uint)uint2.MaxValue >> RexPos;

        const uint RepMask = (uint)uint2.MaxValue >> RepPos;

        uint Data;

        public static OpCodeId Empty => default;

        [MethodImpl(Inline)]
        public static ref OpCodeId @class(InstClass src, ref OpCodeId dst)
        {
            bits.scatter((Hex12)src, ClassMask);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref OpCodeId opcode(Hex8 src, ref OpCodeId dst)
        {
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static Hex12 @class(OpCodeId src)
            => (Hex12)bits.extract(src.Data, ClassPos, ClassPos + ClassWidth);

        [MethodImpl(Inline)]
        public static Hex8 opcode(OpCodeId src)
            => (Hex8)bits.extract(src.Data, OcPos, OcPos + OcWidth);

        public string Format()
        {
            const string RenderPattern = "{0,-4} {1, -2}";
            return string.Format("{0} {1}", @class(this), opcode(this));
        }

        public override string ToString()
            => Format();

    }


    partial class XedCmdProvider
    {
        [CmdOp("check/hex")]
        Outcome CheckHex(CmdArgs args)
        {
            var h10 = Hex10.Max;
            Write(h10.Format());

            h10 = (Hex10)0x445;
            Write(h10.Format());

            h10 = (Hex10)0x665;

            Hex10.parse("0x44", out h10);
            Write(h10.Format());


            return true;
        }

        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {

            var patterns = Xed.Rules.CalcInstPatterns();
            var opcodes = Xed.Rules.CalcPoc(patterns);
            var count = Require.equal(patterns.Count, opcodes.Count);
            var lookup = patterns.Select(x => (x.PatternId,x)).ToDictionary();

            var rules = Xed.Rules.CalcRules();
            for(var i=0; i< count; i++)
            {
                ref readonly var opcode = ref opcodes[i];
                ref readonly var pid = ref opcode.PatternId;
                var pattern = lookup[pid];

                ref readonly var ops = ref pattern.OpDetails;

                var id = OpCodeId.Empty;
                OpCodeId.@class(pattern.InstClass, ref id);
                OpCodeId.opcode(opcode.OpCode.FirstByte, ref id);
                Write(id.Format());



                // Hex12 @class = (ushort)pattern.InstClass;
                // Hex8 ocbyte = opcode.OpCode.FirstByte;
                // uint3 mode = (uint3)opcode.Mode;
                // uint2 @lock = (uint2)opcode.Lock;
                // uint3 mod = (uint3)opcode.Mod;
                // bit rexw = opcode.RexW;
                // uint2 rep = (uint2)opcode.Rep;


                //var id = (uint)rep.Kind | ((uint)mod.Kind << 4) | (rexw ? 0xFFu << 8 : 0u);

                for(var j=z8; j<ops.Count; j++)
                {
                    ref readonly var op =ref ops[j];
                }
            }

            //var ops = Xed.Rules.CalcInstOpDetails(rules,patterns);


            return true;
        }

    }
}