//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(32)]
        public struct Nonterminal : IEquatable<Nonterminal>, IComparable<Nonterminal>
        {
            public static Nonterminal FromId(uint id)
                => new Nonterminal(name((int)id));

            static ConcurrentDictionary<string,int> A = new();

            static ConcurrentDictionary<int,string> B = new();

            static int Seq = 1;

            static object locker = new();

            static int token(string src)
            {
                lock(locker)
                {
                    if(A.TryGetValue(src, out var i))
                        return i;
                    else
                    {
                        A[src] = core.inc(ref Seq);
                        B[Seq] = src;
                        return Seq;
                    }
                }
            }

            static string name(int id)
            {
                if(B.TryGetValue(id, out var n))
                    return n;
                else
                    return EmptyString;
            }

            public readonly int Id;

            public Nonterminal(string name)
            {
                Id = token(text.trim(name));
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Id == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Id != 0;
            }

            public bool HasKind
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public NontermKind Kind
            {
                get
                {
                    XedParsers.parse(Name, out NontermKind k);
                    return k;
                }
            }

            public string Name
                => IsNonEmpty ? name(Id) : EmptyString;

            [MethodImpl(Inline)]
            public bool Equals(Nonterminal src)
                => Id == src.Id;

            public override bool Equals(object src)
                => src is Nonterminal x && Equals(x);

            public override int GetHashCode()
                => (int)(uint)this;

            public int CompareTo(Nonterminal src)
                => Name.CompareTo(src.Name);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static explicit operator uint(Nonterminal src)
                => core.@as<Nonterminal,uint>(src);

            [MethodImpl(Inline)]
            public static implicit operator NontermKind(Nonterminal src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(NontermKind src)
                => new Nonterminal(src.ToString());

            public static Nonterminal Empty => default;
        }
    }
}