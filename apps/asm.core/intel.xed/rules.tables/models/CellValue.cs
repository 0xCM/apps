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
        public readonly struct CellValue : IEquatable<CellValue>
        {
            public readonly FieldKind Field;

            public readonly ulong Data;

            public readonly CellRole Role;

            [MethodImpl(Inline)]
            public CellValue(FieldKind field, bit data)
            {
                Field = field;
                Data = (byte)data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, Hex8 data)
            {
                Field = kind;
                Data = data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, Hex4 data)
            {
                Field = kind;
                Data = data;
                Role = CellRole.HexLiteral;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind field, byte data)
            {
                Field = field;
                Data = data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, ushort data)
            {
                Field = kind;
                Data = data;
                Role = CellRole.FieldValue;
            }

            // [MethodImpl(Inline)]
            // public CellValue(BfSeg data)
            // {
            //     Field = data.Field;
            //     Data = (ulong)data.Pattern;
            //     Role = CellRole.FieldValue;
            // }

            [MethodImpl(Inline)]
            public CellValue(Seg data)
            {
                Field = data.Field;
                Data = (ulong)data.Value;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(BfSpec data)
            {
                Field = 0;
                Data = (byte)data;
                Role = CellRole.BfSpec;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, ImmSeg data)
            {
                Field = kind;
                Data = (ushort)data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(ImmSpec src)
            {
                Field = 0;
                Data = (byte)src;
                Role = CellRole.ImmSpec;
            }

            [MethodImpl(Inline)]
            public CellValue(DispSpec src)
            {
                Field = 0;
                Data = (byte)src;
                Role = CellRole.DispSpec;
            }

            [MethodImpl(Inline)]
            public CellValue(RuleKeyword src)
            {
                Field = 0;
                Data = (byte)src;
                Role = CellRole.Keyword;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, ulong data, CellRole role = CellRole.FieldValue)
            {
                Field = kind;
                Data = data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, MachineMode data)
            {
                Field = kind;
                Data = (ushort)data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, XedRegId data)
            {
                Field = kind;
                Data = (ushort)data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, Nonterminal data, CellRole role = CellRole.FieldValue)
            {
                Field = kind;
                Data = (ushort)data;
                Role = role;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, DispSeg data)
            {
                Field = kind;
                Data = (byte)data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, BCastKind data)
            {
                Field = kind;
                Data = (byte)data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, IClass data)
            {
                Field = kind;
                Data = (ushort)data;
                Role = CellRole.FieldValue;
            }

            [MethodImpl(Inline)]
            public CellValue(FieldKind kind, ChipCode data)
            {
                Field = kind;
                Data = (uint)data;
                Role = CellRole.FieldValue;
            }

            public readonly bit IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => Role == CellRole.NontermCall;
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
            public DispSpec ToDispSpec()
                => (DispSpec)Data;

            [MethodImpl(Inline)]
            public Seg ToSeg()
                => new Seg(Field, 0, (asci8)Data);

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
            public static implicit operator EoszKind(CellValue src)
                => (EoszKind)XedRules.widths((EOSZ)src);

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