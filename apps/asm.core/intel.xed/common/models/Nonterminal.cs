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
            public static Nonterminal FromId(int id)
                => new Nonterminal(name(id));

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
                Id = token(name);
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
            {
                var n = Name;
                if(text.nonempty(n))
                    return string.Format("{0}()", Name);
                else
                    return EmptyString;
            }

            public override string ToString()
                => Format();

            public static explicit operator uint(Nonterminal src)
                => core.@as<Nonterminal,uint>(src);

            public static Nonterminal Empty => default;
        }
    }
}