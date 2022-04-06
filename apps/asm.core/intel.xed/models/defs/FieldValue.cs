//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    using Asm;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1), DataWidth(80)]
        public readonly struct FieldValue : IEquatable<FieldValue>
        {
            public readonly FieldKind Field;

            public readonly ulong Data;

            public readonly RuleCellKind DataKind;

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, bit data)
            {
                Field = kind;
                Data = (byte)data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, uint8b data)
            {
                Field = kind;
                Data = data;
                DataKind = RuleCellKind.BinaryLiteral;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, Hex8 data)
            {
                Field = kind;
                Data = data;
                DataKind = RuleCellKind.HexLiteral;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, Hex4 data)
            {
                Field = kind;
                Data = data;
                DataKind = RuleCellKind.HexLiteral;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, byte data)
            {
                Field = kind;
                Data = data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, byte data, RuleCellKind ck)
            {
                Field = kind;
                Data = data;
                DataKind = ck;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ushort data)
            {
                Field = kind;
                Data = data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(RuleOperator src)
            {
                Field = 0;
                Data = (uint)src;
                DataKind = RuleCellKind.Operator;
            }

            [MethodImpl(Inline)]
            public FieldValue(BfSeg data)
            {
                Field = data.Field;
                Data = (ulong)data.Pattern;
                DataKind = RuleCellKind.BfSeg;
            }

            [MethodImpl(Inline)]
            public FieldValue(BfSpec data)
            {
                Field = 0;
                Data = (byte)data;
                DataKind = RuleCellKind.BfSpec;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ImmSeg data)
            {
                Field = kind;
                Data = (ushort)data;
                DataKind = RuleCellKind.ImmSeg;
            }

            [MethodImpl(Inline)]
            public FieldValue(ImmSpec src)
            {
                Field = 0;
                Data = (byte)src;
                DataKind = RuleCellKind.ImmSpec;
            }

            [MethodImpl(Inline)]
            public FieldValue(DispSpec src)
            {
                Field = 0;
                Data = (byte)src;
                DataKind = RuleCellKind.DispSpec;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ulong data)
            {
                Field = kind;
                Data = data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, XedRegId data)
            {
                Field = kind;
                Data = (ulong)data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, Nonterminal data)
            {
                Field = kind;
                Data = (ushort)data;
                DataKind = RuleCellKind.NontermCall;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, DispSeg data)
            {
                Field = kind;
                Data = (byte)data;
                DataKind = RuleCellKind.DispSeg;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, BCastKind data)
            {
                Field = kind;
                Data = (uint)data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, IClass data)
            {
                Field = kind;
                Data = (uint)data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(FieldKind kind, ChipCode data)
            {
                Field = kind;
                Data = (uint)data;
                DataKind = 0;
            }

            [MethodImpl(Inline)]
            public FieldValue(RuleKeyword kw)
            {
                Field = 0;
                Data = (byte)kw.KeywordKind;
                DataKind = kw.CellKind;
            }

            public readonly bit IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => DataKind == RuleCellKind.NontermCall;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            [MethodImpl(Inline)]
            public bool Equals(FieldValue src)
                => Field == src.Field && Data == src.Data;

            public override bool Equals(object src)
                => src is FieldValue x && Equals(x);

            public uint Hash
            {
                [MethodImpl(Inline)]
                get => (uint)((ulong)Field << 24 | (Data & 0xFFFFFF));
            }

            public override int GetHashCode()
                => (int)Hash;

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public VexClass ToVexClass()
                => (VexClass)Data;

            [MethodImpl(Inline)]
            public VexLengthKind ToVexLength()
                => (VexLengthKind)Data;

            [MethodImpl(Inline)]
            public VexKind ToVexKind()
                => (VexKind)Data;

            [MethodImpl(Inline)]
            public MachineMode ToMode()
                => (ModeKind)Data;

            [MethodImpl(Inline)]
            public RuleKeyword ToKeyword()
                => RuleKeyword.from((RuleKeyWordKind)Data);

            [MethodImpl(Inline)]
            public XedRegId ToReg()
                => (XedRegId)Data;

            [MethodImpl(Inline)]
            public InstClass ToInstClass()
                => (IClass)Data;

            [MethodImpl(Inline)]
            public ChipCode ToChip()
                => (ChipCode)Data;

            [MethodImpl(Inline)]
            public BCastKind ToBCast()
                => (BCastKind)Data;

            [MethodImpl(Inline)]
            public EOSZ ToEOSZ()
                => (EOSZ)Data;

            [MethodImpl(Inline)]
            public EASZ ToEASZ()
                => (EASZ)Data;

            [MethodImpl(Inline)]
            public bit ToBit()
                => (bit)Data;

            [MethodImpl(Inline)]
            public ImmSeg ToImmSeg()
                => (ImmSeg)Data;

            [MethodImpl(Inline)]
            public ImmSpec ToImmSpec()
                => (ImmSpec)Data;

            [MethodImpl(Inline)]
            public byte ToIntLiteral()
                => (byte)Data;

            [MethodImpl(Inline)]
            public Hex8 ToHexLiteral()
                => (Hex8)Data;

            [MethodImpl(Inline)]
            public uint8b ToBinaryLiteral()
                => (uint8b)Data;

            [MethodImpl(Inline)]
            public Nonterminal ToNonterminal()
                => (NontermKind)Data;

            [MethodImpl(Inline)]
            public DispSeg ToDispSeg()
                => (DispSeg)Data;

            [MethodImpl(Inline)]
            public DispSpec ToDispSpec()
                => (DispSpec)Data;

            [MethodImpl(Inline)]
            public static implicit operator EASZ(FieldValue src)
                => src.ToEASZ();

            [MethodImpl(Inline)]
            public static implicit operator EOSZ(FieldValue src)
                => src.ToEOSZ();

            [MethodImpl(Inline)]
            public static implicit operator VexClass(FieldValue src)
                => src.ToVexClass();

            [MethodImpl(Inline)]
            public static implicit operator VexLengthKind(FieldValue src)
                => src.ToVexLength();

            [MethodImpl(Inline)]
            public static implicit operator VexKind(FieldValue src)
                => src.ToVexKind();

            [MethodImpl(Inline)]
            public static implicit operator ModeKind(FieldValue src)
                => src.ToMode();

            [MethodImpl(Inline)]
            public static implicit operator XedRegId(FieldValue src)
                => src.ToReg();

            [MethodImpl(Inline)]
            public static implicit operator IClass(FieldValue src)
                => src.ToInstClass();

            [MethodImpl(Inline)]
            public static implicit operator ChipCode(FieldValue src)
                => src.ToChip();

            [MethodImpl(Inline)]
            public static implicit operator BCastKind(FieldValue src)
                => src.ToBCast();

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(FieldValue src)
                => src.ToNonterminal();

            [MethodImpl(Inline)]
            public static implicit operator bit(FieldValue src)
                => src.ToBit();

            [MethodImpl(Inline)]
            public static implicit operator Hex8(FieldValue src)
                => src.ToHexLiteral();

            [MethodImpl(Inline)]
            public static implicit operator byte(FieldValue src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint2(FieldValue src)
                => (uint2)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint3(FieldValue src)
                => (uint3)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint4(FieldValue src)
                => (uint4)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Hex4(FieldValue src)
                => (Hex4)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator DispSeg(FieldValue src)
                => src.ToDispSeg();

            [MethodImpl(Inline)]
            public static implicit operator ImmSeg(FieldValue src)
                => src.ToImmSeg();

            [MethodImpl(Inline)]
            public static implicit operator ushort(FieldValue src)
                => (ushort)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator long(FieldValue src)
                => (long)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator LockIndicator(FieldValue src)
                => ((bit)src) ? LockIndicator.On : LockIndicator.Off;

            [MethodImpl(Inline)]
            public static implicit operator EoszKind(FieldValue src)
                => (EoszKind)XedRules.widths((EOSZ)src);

            [MethodImpl(Inline)]
            public static bool operator ==(FieldValue a, FieldValue b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(FieldValue a, FieldValue b)
                => !a.Equals(b);

            public static FieldValue Empty => default;
        }
    }
}