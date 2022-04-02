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
        public readonly struct RuleTableName : IComparable<RuleTableName>, IEquatable<RuleTableName>
        {
            public RuleTableName(RuleTableKind kind, string name)
            {
                var data = ByteBlock48.Empty;
                var full = name + "." + kind.ToString().ToUpper();
                data[46] = (byte)kind;
                data[47] = (byte)Asci.encode(full, 0u, data.Bytes);
                Data = data;
            }

            readonly ByteBlock48 Data;

            public string ShortName
            {
                get
                {
                    var full = Format();
                    return text.slice(full,0, full.Length - 4);
                }
            }

            Span<byte> CharBytes
            {
                [MethodImpl(Inline)]
                get => slice(Data.Bytes,0,Length);
            }

            public readonly byte Length
            {
                [MethodImpl(Inline)]
                get => Data[47];
            }

            public readonly RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => (RuleTableKind)Data[46];
            }

            public readonly bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind == 0;
            }

            public readonly bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind != 0;
            }

            public string Format()
            {
                var count = Length;
                var storage = CharBlock48.Null;
                var dst = storage.Data;
                Asci.decode(n48, CharBytes, dst);
                return new string(slice(dst,0,count));
            }

            public override string ToString()
                => Format();

            public bool Equals(RuleTableName src)
            {
                if(TableKind != src.TableKind || Length != src.Length)
                    return false;
                return CharBytes.SequenceEqual(src.CharBytes);
            }

            public Hash32 Hash
                => alg.hash.marvin(CharBytes);

            public override int GetHashCode()
                => Hash;

            public override bool Equals(object src)
                => src is RuleTableName x && Equals(x);

            public int CompareTo(RuleTableName src)
            {
                var result = Format().CompareTo(src.Format());
                if(result == 0)
                    result = XedRules.cmp(TableKind, src.TableKind);
                return result;
            }

            [MethodImpl(Inline)]
            public static bool operator ==(RuleTableName a, RuleTableName b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(RuleTableName a, RuleTableName b)
                => !a.Equals(b);

            public static RuleTableName Empty => default;
        }
    }
}