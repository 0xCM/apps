//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct CellValue : IEquatable<CellValue>
        {
            [MethodImpl(Inline)]
            public static CellValue value<T>(FieldKind kind, T value)
                where T : unmanaged
                    => new CellValue(kind, core.bw64(value));

            public readonly FieldKind Field;

            public readonly ulong Data;

            public readonly RuleCellKind CellKind;

            [MethodImpl(Inline)]
            public CellValue(FieldKind field, bit data)
            {
                Field = field;
                Data = (byte)data;
                CellKind = 0;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind field, byte data)
            {
                Field = field;
                Data = data;
                CellKind = 0;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, ushort data)
            {
                Field = kind;
                Data = data;
                CellKind = 0;
            }

            [MethodImpl(Inline)]
            public CellValue(SegField src)
            {
                Field = src.Field;
                Data = (ulong)src;
                CellKind = RuleCellKind.SegField;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind field, SegFieldType type)
            {
                Field = field;
                Data = (ulong)new SegField(field, type);
                CellKind = RuleCellKind.SegField;
            }

            [MethodImpl(Inline)]
            public CellValue(RuleKeyword src)
            {
                Field = 0;
                Data = (byte)src;
                CellKind = RuleCellKind.Keyword;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, ulong data, RuleCellKind ck = 0)
            {
                Field = kind;
                Data = data;
                CellKind = ck;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, MachineMode data)
            {
                Field = kind;
                Data = (ushort)data;
                CellKind = 0;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, XedRegId data)
            {
                Field = kind;
                Data = (ushort)data;
                CellKind = 0;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, Nonterminal data)
            {
                Field = kind;
                Data = (ushort)data;
                CellKind =  kind != 0 ? RuleCellKind.NontermExpr : RuleCellKind.Nonterm;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, BCastKind data)
            {
                Field = kind;
                Data = (byte)data;
                CellKind = 0;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, IClass data)
            {
                Field = kind;
                Data = (ushort)data;
                CellKind = 0;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, ChipCode data)
            {
                Field = kind;
                Data = (uint)data;
                CellKind = 0;
            }

            public readonly bit IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => CellKind == RuleCellKind.Nonterm;
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
            public bool Equals(CellValue src)
                => Field == src.Field && Data == src.Data;

            public override bool Equals(object src)
                => src is CellValue x && Equals(x);

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
            public asci8 ToAsci()
                => (asci8)Data;

            [MethodImpl(Inline)]
            public InstClass ToInstClass()
                => (IClass)Data;

            [MethodImpl(Inline)]
            public ChipCode ToChip()
                => (ChipCode)Data;

            [MethodImpl(Inline)]
            public RepPrefix ToRepPrefix()
                => (RepPrefix)Data;

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
            public SegField ToSegField()
                => (SegField)Data;

            [MethodImpl(Inline)]
            public static implicit operator EASZ(CellValue src)
                => src.ToEASZ();

            [MethodImpl(Inline)]
            public static implicit operator EOSZ(CellValue src)
                => src.ToEOSZ();

            [MethodImpl(Inline)]
            public static implicit operator VexClass(CellValue src)
                => src.ToVexClass();

            [MethodImpl(Inline)]
            public static implicit operator VexLengthKind(CellValue src)
                => src.ToVexLength();

            [MethodImpl(Inline)]
            public static implicit operator VexKind(CellValue src)
                => src.ToVexKind();

            [MethodImpl(Inline)]
            public static implicit operator ModeKind(CellValue src)
                => src.ToMode();

            [MethodImpl(Inline)]
            public static implicit operator XedRegId(CellValue src)
                => src.ToReg();

            [MethodImpl(Inline)]
            public static implicit operator IClass(CellValue src)
                => src.ToInstClass();

            [MethodImpl(Inline)]
            public static implicit operator ChipCode(CellValue src)
                => src.ToChip();

            [MethodImpl(Inline)]
            public static implicit operator BCastKind(CellValue src)
                => src.ToBCast();

            [MethodImpl(Inline)]
            public static implicit operator RepPrefix(CellValue src)
                => src.ToRepPrefix();

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(CellValue src)
                => src.ToNonterminal();

            [MethodImpl(Inline)]
            public static implicit operator bit(CellValue src)
                => src.ToBit();

            [MethodImpl(Inline)]
            public static implicit operator Hex8(CellValue src)
                => src.ToHexLiteral();

            [MethodImpl(Inline)]
            public static implicit operator byte(CellValue src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint2(CellValue src)
                => (uint2)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint3(CellValue src)
                => (uint3)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint4(CellValue src)
                => (uint4)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Hex4(CellValue src)
                => (Hex4)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator ushort(CellValue src)
                => (ushort)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator long(CellValue src)
                => (long)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator LockIndicator(CellValue src)
                => ((bit)src) ? LockIndicator.On : LockIndicator.Off;

            [MethodImpl(Inline)]
            public static implicit operator Asm.EoszKind(CellValue src)
                => (Asm.EoszKind)XedRules.widths((EOSZ)src);

            [MethodImpl(Inline)]
            public static bool operator ==(CellValue a, CellValue b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(CellValue a, CellValue b)
                => !a.Equals(b);

            public static CellValue Empty => default;
        }
    }
}