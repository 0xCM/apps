//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    public struct FormPatterns : IEquatable<FormPatterns>, IComparable<FormPatterns>
    {
        public readonly byte Count;

        readonly Option<InstPattern> P0;

        readonly Option<InstPattern> P1;

        readonly Option<InstPattern> P2;

        readonly InstPattern Empty;

        readonly ulong Identity;

        readonly Hash32 Hash;

        public FormPatterns(InstForm form, params InstPattern[] patterns)
        {
            Identity = (ushort)form;
            P0 = Option.none<InstPattern>();
            P1 = Option.none<InstPattern>();
            P2 = Option.none<InstPattern>();
            Empty = InstPattern.Empty;
            Count = (byte)min(patterns.Length, 3);
            var i=z8;
            switch(Count)
            {
                case 0:
                break;
                case 1:
                    P0 = skip(patterns,i);
                    Identity |= (ulong)(skip(patterns,i)).PatternId << 16;
                break;
                case 2:
                    P0 = skip(patterns,i);
                    Identity |= (ulong)(skip(patterns,i++)).PatternId << 16;
                    P1 = skip(patterns,1);
                    Identity |= (ulong)(skip(patterns,i++)).PatternId << 32;
                break;
                default:
                    P0 = skip(patterns,0);
                    Identity |= (ulong)(skip(patterns,i++)).PatternId << 16;
                    P1 = skip(patterns,1);
                    Identity |= (ulong)(skip(patterns,i++)).PatternId << 32;
                    P2 = skip(patterns,1);
                    Identity |= (ulong)(skip(patterns,i++)).PatternId << 48;
                break;
            }
            Hash = alg.hash.calc(Identity);
        }

        public InstForm Form
        {
            [MethodImpl(Inline)]
            get => (InstForm)(ushort)Identity;
        }

        public InstPattern Pattern(byte index)
        {
            var dst = Empty;
            if(index >= Count)
                return dst;

            switch(index)
            {
                case 1:
                    dst = P0.ValueOrDefault(Empty);
                break;
                case 2:
                    dst = P1.ValueOrDefault(Empty);
                break;
                case 3:
                    dst = P2.ValueOrDefault(Empty);
                break;
            }
            return dst;
        }

        public InstPattern this[byte i]
            => Pattern(i);

        [MethodImpl(Inline)]
        public bool Equals(FormPatterns src)
            => Identity == src.Identity;

        public override bool Equals(object src)
            => src is FormPatterns x && Equals(x);

        public override int GetHashCode()
            => Hash;

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-62} | {1,-2}", Form, Count);
            for(var i=z8; i<Count; i++)
                dst.AppendFormat(" | {0,-26}", this[i].OpCode);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public int CompareTo(FormPatterns src)
            => Form.CompareTo(src.Form);
    }
}