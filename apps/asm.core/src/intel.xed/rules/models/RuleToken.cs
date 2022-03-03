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
            public RuleToken(RuleTokenKind kind, BitfieldSeg value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)kind;
                var data = slice(storage.Bytes,1,15);
                @as<BitfieldSeg>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(RuleTokenKind kind, uint8b value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)kind;
                var data = slice(storage.Bytes,1,15);
                @as<uint8b>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(RuleTokenKind kind, Hex8 value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)kind;
                var data = slice(storage.Bytes,1,15);
                @as<Hex8>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(RuleTokenKind kind, byte value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)kind;
                var data = slice(storage.Bytes,1,15);
                @as<Hex8>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(RuleTokenKind kind, NontermCall value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)kind;
                var data = slice(storage.Bytes,1,15);
                @as<NontermCall>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(RuleTokenKind kind, FieldConstraint value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)kind;
                var data = slice(storage.Bytes,1,15);
                @as<FieldConstraint>(data) = value;
                Storage = storage;
            }

            [MethodImpl(Inline)]
            public RuleToken(RuleTokenKind kind, RuleMacro value)
            {
                var storage = ByteBlock16.Empty;
                storage[0] = (byte)kind;
                var data = slice(storage.Bytes,1,15);
                @as<RuleMacro>(data) = value;
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
                => format(this);

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

            public static RuleToken Empty => new RuleToken(0,Hex8.Zero);
        }
    }
}