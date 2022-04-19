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

    public record struct OpCodeId : IComparable<OpCodeId>
    {
        public enum FieldKind : byte
        {
            Rep,

            Rex,

            Lock,

            Mod,

            OpCode,

            Class,
        }

        public static OpCodeId define(InstClass @class, Hex8 oc, ModIndicator mod, LockIndicator @lock, BitIndicator rex, RepIndicator rep)
        {
            var data = math.or(
                (uint)@class << pos(FK.Class),
                (uint)oc << pos(FK.OpCode),
                (uint)mod << pos(FK.Mod),
                (uint)@lock << pos(FK.Lock),
                (uint)rex << pos(FK.Rex),
                (uint)rep << pos(FK.Rep)
                );
            return new OpCodeId(data);
        }

        public enum FieldWidth : byte
        {
            Rep = RepIndicator.Width,

            Rex = RexBit.Width,

            Lock = LockIndicator.Width,

            Mod = ModIndicator.Width,

            OpCode = Hex8.Width,

            Class = InstClass.Width,
        }

        public const FieldKind LastField = FieldKind.Class;

        public const byte FieldCount = (byte)LastField + 1;

        public static ReadOnlySpan<FieldKind> Fields
            => _Fields;

        public static ReadOnlySpan<byte> FieldWidths
            => _Widths;

        public static byte TotalWidth => FieldWidths.Sum();

        public static ReadOnlySpan<byte> FieldPositions
            => _Positions;

        public static ReadOnlySpan<Hex32> FieldMasks
            => _FieldMasks;

        [MethodImpl(Inline)]
        public static byte index(FieldKind field)
            => (byte)field;

        [MethodImpl(Inline)]
        public static byte pos(FieldKind field)
            => skip(FieldPositions, index(field));

        [MethodImpl(Inline)]
        public static ref readonly byte width(FieldKind field)
            => ref skip(FieldWidths, index(field));

        [MethodImpl(Inline)]
        public static Hex32 mask(FieldKind field)
            => skip(FieldMasks, index(field));

        public static ReadOnlySpan<BitfieldInterval> Segments
            => _Segs;

        [MethodImpl(Inline)]
        public static ref readonly BitfieldInterval segment(FieldKind field)
            => ref skip(Segments, index(field));

        static Index<BitfieldInterval> CalcSegments()
            => map(Fields, field => new BitfieldInterval(pos(field), width(field)));

        static Index<byte> CalcPositions()
        {
            var dst = alloc<byte>(FieldCount);
            var offset = z8;
            for(var i=0; i<FieldCount; i++)
            {
                var field = (FieldKind)i;
                seek(dst,i) = offset;
                offset += width(field);
            }
            return dst;
        }

        static Index<Hex32> CalcFieldMasks()
        {
            var fields = Fields;
            var dst = alloc<Hex32>(FieldCount);
            for(var i=0; i<FieldCount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var m = (Hex32)HexMax.max(width(field));
                seek(dst,i) = m << pos(field);
            }
            return dst;
        }

        static Index<byte> CalcWidths()
            => Symbols.index<FieldWidth>().Kinds.Map(x => (byte)x).ToArray();

        static string CalcRenderPattern()
        {
            var dst = text.buffer();
            var fields = Fields;
            for(var i=z8; i<FieldCount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                ref readonly var w = ref width(field);
                var slot = RP.slot(i, math.negate((sbyte)w));
                dst.Append(slot);
                if(i != FieldCount - 1)
                    dst.Append(Chars.Space);
            }
            return dst.Emit();
        }

        static Index<byte> _Positions;

        static Index<Hex32> _FieldMasks;

        static Index<FieldKind> _Fields;

        static Index<byte> _Widths;

        static Index<BitfieldInterval> _Segs;

        static string _BitfieldRender;

        static OpCodeId()
        {
            _Widths = CalcWidths();
            _Fields = Symbols.index<FieldKind>().Kinds.ToArray();
            _Positions = CalcPositions();
            _FieldMasks = CalcFieldMasks();
            _Segs = CalcSegments();
            _BitfieldRender = CalcRenderPattern();
        }

        uint Data;

        [MethodImpl(Inline)]
        OpCodeId(uint data)
        {
            Data = data;
        }

        public static OpCodeId Empty => default;

        [MethodImpl(Inline)]
        public static ref OpCodeId set<T>(T src, FieldKind field, ref OpCodeId dst)
            where T : unmanaged
        {
            dst.Data = bits.gather(dst.Data, ~mask(field));
            dst.Data |= (bw32(src) << pos(field));
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static uint get(OpCodeId src, FieldKind field)
            => bits.extract(src.Data, pos(field), (byte)(pos(field) + width(field)));

        [MethodImpl(Inline)]
        public static ref T get<T>(OpCodeId src, FieldKind field, out T dst)
        {
            dst = generic<T>(get(src,field));
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static InstClass @class(OpCodeId src)
            => get(src, FK.Class, out InstClass _);

        [MethodImpl(Inline)]
        public static Hex8 opcode(OpCodeId src)
            => get(src, FK.OpCode, out Hex8 _);

        public InstClass Class
        {
            [MethodImpl(Inline)]
            get => get(this, FK.Class, out InstClass _);
        }

        public Hex8 PrimaryByte
        {
            [MethodImpl(Inline)]
            get => get(this, FK.OpCode, out Hex8 _);
        }

        public ModIndicator Mod
        {
            [MethodImpl(Inline)]
            get => get(this, FK.OpCode, out ModIndicator _);
        }

        public RexBit Rex
        {
            [MethodImpl(Inline)]
            get => get(this, FK.OpCode, out RexBit _);
        }

        public LockIndicator Lock
        {
            [MethodImpl(Inline)]
            get => get(this, FK.OpCode, out LockIndicator _);
        }

        public RepIndicator Rep
        {
            [MethodImpl(Inline)]
            get => get(this, FK.OpCode, out RepIndicator _);
        }

        public string Format()
        {
            return Data.FormatBits();

        }

        public override string ToString()
            => Format();

        public int CompareTo(OpCodeId src)
            => Data.CompareTo(src.Data);

    }


    partial class XedCmdProvider
    {
        [CmdOp("xed/fuck")]
        Outcome CheckBits2(CmdArgs args)
        {
            var segs = Segments;
            var total = z8;
            for(var i=0; i<segs.Length; i++)
            {
                var field = (FK)i;
                ref readonly var seg = ref skip(segs,i);

                Write(string.Format("{0:D2} {1,-8} {2:D2} {3} {4}",
                    index(field),
                    seg.Format(),
                    width(field),
                    mask(field).FormatBits(n8),
                    field));
            }

            //Write(FieldMask.FormatBits(n4));

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
            var collected = alloc<OpCodeId>(count);
            for(var i=0; i< count; i++)
            {
                ref readonly var oc = ref opcodes[i];
                ref readonly var pid = ref oc.PatternId;
                var pattern = lookup[pid];

                ref readonly var ops = ref pattern.OpDetails;

                seek(collected,i) = OpCodeId.define(oc.InstClass, oc.PrimaryByte, oc.Mod, oc.Lock, oc.RexW, oc.Rep);

                //Write(id.Format());

                //Write(string.Format("{0,-18} | {1}", @class(id), opcode(id)));


                for(var j=z8; j<ops.Count; j++)
                {
                    ref readonly var op =ref ops[j];
                }
            }

            var sorted = collected.Sort();
            for(var i=0; i<count; i++)
            {
                ref readonly var id = ref skip(sorted,i);
                Write(string.Format("{0,-18} | {1}", @class(id), opcode(id)));

            }

            return true;
        }

    }
}