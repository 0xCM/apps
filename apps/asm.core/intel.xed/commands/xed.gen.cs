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

    using FK = OpCodeId.FieldKind;

    public readonly struct HexMax
    {
        [MethodImpl(Inline)]
        public static Hex1 max(N1 n)
            => Hex1.MaxValue;

        [MethodImpl(Inline)]
        public static Hex2 max(N2 n)
            => Hex2.MaxValue;

        [MethodImpl(Inline)]
        public static Hex3 max(N3 n)
            => Hex3.MaxValue;

        [MethodImpl(Inline)]
        public static Hex4 max(N4 n)
            => Hex4.MaxValue;

        [MethodImpl(Inline)]
        public static Hex5 max(N5 n)
            => Hex5.MaxValue;

        [MethodImpl(Inline)]
        public static Hex6 max(N6 n)
            => Hex6.MaxValue;

        [MethodImpl(Inline)]
        public static Hex7 max(N7 n)
            => Hex7.MaxValue;

        [MethodImpl(Inline)]
        public static Hex8 max(N8 n)
            => Hex8.MaxValue;

        [MethodImpl(Inline)]
        public static Hex10 max(N10 n)
            => Hex10.MaxValue;

        [MethodImpl(Inline)]
        public static Hex12 max(N12 n)
            => Hex12.MaxValue;

        [MethodImpl(Inline)]
        public static Hex14 max(N14 n)
            => Hex14.MaxValue;

        [MethodImpl(Inline)]
        public static Hex16 max(N16 n)
            => Hex16.MaxValue;

        [MethodImpl(Inline)]
        public static Hex32 max(N32 n)
            => Hex32.MaxValue;

        [MethodImpl(Inline)]
        public static Hex64 max(N64 n)
            => Hex64.MaxValue;

        public static Hex64 max(byte n)
            => n switch
            {
                1 => (ulong)Hex1.Max,
                2 => (ulong)Hex2.Max,
                3 => (ulong)Hex3.Max,
                4 => (ulong)Hex4.Max,
                5 => (ulong)Hex5.Max,
                6 => (ulong)Hex6.Max,
                7 => (ulong)Hex7.Max,
                8 => (ulong)Hex8.Max,
                10 => Hex10.Max,
                12 => Hex12.Max,
                14 => Hex14.Max,
                16 => (ulong)Hex16.Max,
                32 => (ulong)Hex32.Max,
                64 => Hex64.Max,

                _ => Hex64.Zero
            };
    }

    public struct OpCodeId
    {

        public const byte FieldCount = (byte)FK.Class + 1;

        public static ReadOnlySpan<FieldKind> FieldKinds => new FieldKind[FieldCount]{
            FK.Rep,
            FK.Rex,
            FK.Lock,
            FK.Mod,
            FK.OpCode,
            FK.Class
            };

        public const byte RepWidth = RepIndicator.Width;

        public const byte RexWidth = RexBit.Width;

        public const byte LockWidth = InstLock.Width;

        public const byte ModWidth = ModIndicator.Width;

        public const byte OcWidth = Hex8.Width;

        public const byte ClassWidth = InstClass.Width;

        public const byte TotalWidth = ClassWidth + OcWidth + ModWidth + LockWidth + RexWidth + RepWidth;

        const byte RepPos = z8;

        const byte RexPos = RepWidth;

        const byte LockPos = RexWidth;

        const byte ModPos = LockWidth;

        public const byte OcPos = ModWidth;

        public const byte ClassPos = OcWidth;

        public const byte MaxIndex = ClassPos + ClassWidth;

        public const uint ModMask = (uint)uint3.MaxValue << ModPos;

        public const uint RexMask = (uint)uint2.MaxValue << RexPos;

        public const uint RepMask = (uint)uint2.MaxValue << RepPos;

        public const uint LockMask = (uint)uint2.MaxValue << LockPos;

        public const uint OcMask = (uint)byte.MaxValue << OcPos;

        public const uint ClassMask = ((uint)Hex12.MaxValue) << ClassPos;

        public enum FieldKind
        {
            Rep,

            Rex,

            Lock,

            Mod,

            OpCode,

            Class,
        }

        public static ReadOnlySpan<byte> FieldWidths
            => new byte[FieldCount]{RepWidth, RexWidth, LockWidth, ModWidth, OcWidth, ClassWidth,};

        public static ReadOnlySpan<byte> FieldPositions
            => new byte[FieldCount]{
                0,
                skip(FieldWidths, (byte)FK.Rep),
                skip(FieldWidths, (byte)FK.Rex),
                skip(FieldWidths, (byte)FK.Lock),
                skip(FieldWidths, (byte)FK.Mod),
                skip(FieldWidths, (byte)FK.OpCode),
                };

        public static ReadOnlySpan<Hex32> FieldMasks
            => new Hex32[FieldCount]{
                    (Hex32)HexMax.max(skip(FieldWidths, (byte)FK.Rep)),
                    (Hex32)HexMax.max(skip(FieldWidths, (byte)FK.Rex)),
                    (Hex32)HexMax.max(skip(FieldWidths, (byte)FK.Lock)),
                    (Hex32)HexMax.max(skip(FieldWidths, (byte)FK.Mod)),
                    (Hex32)HexMax.max(skip(FieldWidths, (byte)FK.OpCode)),
                    (Hex32)HexMax.max(skip(FieldWidths, (byte)FK.Class)),
                    };

        public static Hex32 FieldMask => math.or(
            math.or(skip(FieldMasks,0), skip(FieldMasks,1), skip(FieldMasks,2)),
                skip(FieldMasks,3),
                skip(FieldMasks,4),
                skip(FieldMasks,5)
            );

        uint Data;

        public static OpCodeId Empty => default;

        [MethodImpl(Inline)]
        public static ref OpCodeId @class(InstClass src, ref OpCodeId dst)
        {
            dst.Data = bits.gather(dst.Data, ~ClassMask);
            dst.Data |= bits.scatter((Hex12)src, ClassMask);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref OpCodeId opcode(Hex8 src, ref OpCodeId dst)
        {
            dst.Data = bits.gather(dst.Data, ~OcMask);
            dst.Data |= bits.scatter(src, OcMask);
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
        [CmdOp("xed/fuck")]
        Outcome CheckBits2(CmdArgs args)
        {
            var total = z8;
            for(var i=0; i<FieldCount; i++)
            {
                ref readonly var width = ref FieldWidths[i];
                ref readonly var pos = ref FieldPositions[i];
                total += width;
                var seg = bits.enable(0u,0, width);
                var segbits = slice(span(seg.FormatBits()), TotalWidth - pos, pos);

                Write(string.Format("{0,-2} {1,-2} {2} ", width, total, text.format(segbits)));
            }


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