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
            public CellValue(SegVar src)
            {
                Field = FieldKind.INVALID;
                Data = (ulong)src;
                CellKind = RuleCellKind.SegVar;
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
            public CellValue(FieldKind kind, RuleName data)
            {
                Field = kind;
                Data = (ushort)data;
                CellKind =  kind != 0 ? RuleCellKind.NontermExpr : RuleCellKind.NontermCall;
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

            public readonly bit IsNontermCall
            {
                [MethodImpl(Inline)]
                get => CellKind == RuleCellKind.NontermCall;
            }

            public readonly bit IsNontermExpr
            {
                [MethodImpl(Inline)]
                get => CellKind == RuleCellKind.NontermExpr;
            }

            public readonly bit IsNonterm
            {
                [MethodImpl(Inline)]
                get => IsNontermCall || IsNontermExpr;
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
                => CellRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public VexClass ToVexClass()
                => (VexClass)Data;

            [MethodImpl(Inline)]
            public VexLength ToVexLength()
                => (VexLength)Data;

            [MethodImpl(Inline)]
            public VexKind ToVexKind()
                => (VexKind)Data;

            [MethodImpl(Inline)]
            public MachineMode ToMode()
                => (ModeClass)Data;

            [MethodImpl(Inline)]
            public RuleKeyword ToKeyword()
                => RuleKeyword.from((KeywordKind)Data);

            [MethodImpl(Inline)]
            public XedRegId ToReg()
                => (XedRegId)Data;

            [MethodImpl(Inline)]
            public SegVar ToSegVar()
                => (SegVar)Data;

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
            public byte ToByte()
                => (byte)Data;

            [MethodImpl(Inline)]
            public Hex8 ToHex8()
                => (Hex8)Data;

            [MethodImpl(Inline)]
            public uint5 ToBinaryLiteral()
                => (uint5)Data;

            [MethodImpl(Inline)]
            public RuleName ToRuleName()
                => (RuleName)Data;

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
            public static implicit operator VexLength(CellValue src)
                => src.ToVexLength();

            [MethodImpl(Inline)]
            public static implicit operator VexKind(CellValue src)
                => src.ToVexKind();

            [MethodImpl(Inline)]
            public static implicit operator ModeClass(CellValue src)
                => src.ToMode();

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
            public static implicit operator bit(CellValue src)
                => src.ToBit();

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