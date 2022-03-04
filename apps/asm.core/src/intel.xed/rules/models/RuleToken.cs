//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public readonly struct RuleToken
        {
            readonly ByteBlock16 Storage;

            [MethodImpl(Inline)]
            public RuleToken(BitfieldSeg value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.FieldSeg;
                var data = slice(storage.Bytes,1,15);
                @as<BitfieldSeg>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(uint8b value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.BinLit;
                var data = slice(storage.Bytes,1,15);
                @as<uint8b>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(Hex8 value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.HexLit;
                var data = slice(storage.Bytes,1,15);
                @as<Hex8>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(byte value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.DecLit;
                var data = slice(storage.Bytes,1,15);
                @as<Hex8>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(NontermCall value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.Nonterm;
                var data = slice(storage.Bytes,1,15);
                @as<NontermCall>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(FieldConstraint value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.Constraint;
                var data = slice(storage.Bytes,1,15);
                @as<FieldConstraint>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(RuleMacro value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.Macro;
                var data = slice(storage.Bytes,1,15);
                @as<RuleMacro>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(FieldAssignment value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)RuleTokenKind.Assignment;
                var data = slice(storage.Bytes,1,15);
                @as<FieldAssignment>(data) = value;
                Storage = storage;
            }

            Span<byte> Data
            {
                [MethodImpl(Inline)]
                get => slice(Storage.Bytes,1);
            }

            public ref readonly RuleTokenKind Kind
            {
                [MethodImpl(Inline)]
                get => ref @as<RuleTokenKind>(Storage.Bytes);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public bool IsMacro
            {
                [MethodImpl(Inline)]
                get => Kind == RuleTokenKind.Macro;
            }

            public bool IsBinaryLit
            {
                [MethodImpl(Inline)]
                get => Kind == RuleTokenKind.BinLit;
            }

            public bool IsConstraint
            {
                [MethodImpl(Inline)]
                get => Kind == RuleTokenKind.Constraint;
            }

            public bool IsDecimalLit
            {
                [MethodImpl(Inline)]
                get => Kind == RuleTokenKind.DecLit;
            }

            public bool IsHexLit
            {
                [MethodImpl(Inline)]
                get => Kind == RuleTokenKind.HexLit;
            }

            public bool IsFieldSeg
            {
                [MethodImpl(Inline)]
                get => Kind == RuleTokenKind.FieldSeg;
            }

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Kind == RuleTokenKind.Nonterm;
            }

            public string Format()
                => format(this, true);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public ref readonly RuleMacro AsMacro()
                => ref @as<RuleMacro>(Data);

            [MethodImpl(Inline)]
            public ref readonly FieldConstraint AsConstraint()
                => ref @as<FieldConstraint>(Data);

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHexLit()
                => ref @as<Hex8>(Data);

            [MethodImpl(Inline)]
            public ref readonly uint8b AsBinaryLit()
                => ref @as<uint8b>(Data);

            [MethodImpl(Inline)]
            public ref readonly byte AsDecimalLit()
                => ref @as<byte>(Data);

            [MethodImpl(Inline)]
            public ref readonly BitfieldSeg AsFieldSeg()
                => ref @as<BitfieldSeg>(Data);

            [MethodImpl(Inline)]
            public ref readonly NontermCall AsNonterm()
                => ref @as<NontermCall>(Data);

            [MethodImpl(Inline)]
            public ref readonly FieldAssignment AsAssignment()
                => ref @as<FieldAssignment>(Data);

            public static RuleToken Empty => new RuleToken(Hex8.Zero);
        }
    }
}