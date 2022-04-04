//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct Nonterminals
        {
            [MethodImpl(Inline), Op]
            public static Nonterminals init(params NontermKind[] src)
                => init(@readonly(src));

            [MethodImpl(Inline), Op]
            public static Nonterminals init(ReadOnlySpan<NontermKind> src)
            {
                var dst = create();
                for(var i=0; i<src.Length; i++)
                    dst.Include(skip(src,i));
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static Nonterminals create()
                => default;

            const ushort SegWidth = 128;

            const ushort Seg0Pos = 0*SegWidth;

            const ushort Seg1Pos = 1*SegWidth;

            const ushort Seg2Pos = 2*SegWidth;

            const NontermKind LastKind = NontermKind.NEWVEX_ENC;

            public const uint MaxCount = (uint)LastKind + 1;

            BitVector128<ulong> Seg0;

            BitVector128<ulong> Seg1;

            BitVector128<ulong> Seg2;

            [MethodImpl(Inline), Op]
            public bit Contains(NontermKind src)
            {
                var pos = ToPos(src);
                var result = bit.Off;
                if(src != 0)
                {
                    if(IsSeg0(src))
                        result = Seg0.Test(pos);
                    else if(IsSeg1(src))
                        result = Seg1.Test(pos);
                    else if(IsSeg2(src))
                        result = Seg2.Test(pos);
                }
                return result;
            }

            [MethodImpl(Inline)]
            public Nonterminals Include(NontermKind src)
            {
                var pos = ToPos(src);
                if(src != 0)
                {
                    if(IsSeg0(src))
                        Seg0 = Seg0.Enable(pos);
                    else if(IsSeg1(src))
                        Seg1 = Seg1.Enable(pos);
                    else if(IsSeg2(src))
                        Seg2 = Seg2.Enable(pos);
                }
                return this;
            }

            [MethodImpl(Inline)]
            public Nonterminals Clear()
            {
                Seg0 = default;
                Seg1 = default;
                Seg2 = default;
                return this;
            }

            [MethodImpl(Inline)]
            public Nonterminals Clear(NontermKind src)
            {
                var pos = ToPos(src);
                if(src != 0)
                {
                    if(IsSeg0(src))
                        Seg0 = Seg0.Disable(pos);
                    else if(IsSeg1(src))
                        Seg1 = Seg1.Disable(pos);
                    else if(IsSeg2(src))
                        Seg2 = Seg2.Disable(pos);
                }

                return this;
            }

            [MethodImpl(Inline)]
            public Nonterminals Include(params NontermKind[] src)
            {
                for(var i=0; i<src.Length; i++)
                    Include(skip(src,i));
                return this;
            }

            [MethodImpl(Inline)]
            public uint Members(Span<NontermKind> dst)
            {
                var counter = 0u;
                for(var i=0; i<MaxCount; i++)
                {
                    if(Contains(ToKind(i)))
                        seek(dst,counter++) = (NontermKind)i;
                }
                return counter;
            }

            [MethodImpl(Inline)]
            public uint Members(Action<NontermKind> f)
            {
                var counter = 0u;
                for(var i=0; i<MaxCount; i++)
                {
                    var kind = ToKind(i);
                    if(Contains(kind))
                        f(kind);
                }
                return counter;
            }

            [MethodImpl(Inline)]
            public uint Count()
            {
                var counter = 0u;
                for(var i=0; i<MaxCount; i++)
                {
                    if(Contains(ToKind(i)))
                        counter++;
                }
                return counter;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => alg.hash.combine(Seg0.GetHashCode(), Seg1.GetHashCode(), Seg2.GetHashCode());
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Count() == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Count() != 0;
            }

            public string Format()
                => XedRender.format(this);

            public string Format(char sep)
                => XedRender.format(this, sep);

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(Nonterminals src)
                => Seg0 == src.Seg0 && Seg1 == src.Seg1 && Seg2 == src.Seg2;

            public override bool Equals(object src)
                => src is Nonterminals x && Equals(x);

            [MethodImpl(Inline)]
            public static bool operator==(Nonterminals a, Nonterminals b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(Nonterminals a, Nonterminals b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static implicit operator Nonterminals(ReadOnlySpan<NontermKind> src)
                => init(src);

            [MethodImpl(Inline)]
            public static implicit operator Nonterminals(Span<NontermKind> src)
                => init(src);

            [MethodImpl(Inline)]
            public static implicit operator Nonterminals(NontermKind[] src)
                => init(@readonly(src));

            [MethodImpl(Inline)]
            public static implicit operator Nonterminals(Index<NontermKind> src)
                => init(src.View);

            public static Nonterminals Empty => default;

            [MethodImpl(Inline)]
            static NontermKind ToKind(int pos)
            {
                if(pos <= (ushort)LastKind)
                    return (NontermKind)pos;
                else
                    return 0;
            }

            [MethodImpl(Inline)]
            static byte ToPos(NontermKind src)
            {
                var i = (ushort)src;
                if(i < Seg1Pos)
                    return (byte)(i - Seg0Pos);
                else if(i < Seg2Pos)
                    return (byte)(i - Seg1Pos);
                else if(i < MaxCount)
                    return (byte)(i - Seg2Pos);
                else
                    return 0;
            }

            [MethodImpl(Inline)]
            static bit IsSeg0(NontermKind src)
            {
                var i = (ushort)src;
                return i < Seg1Pos;
            }

            [MethodImpl(Inline)]
            static bit IsSeg1(NontermKind src)
            {
                var i = (ushort)src;
                return i >= Seg1Pos && i < Seg2Pos;
            }

            [MethodImpl(Inline)]
            static bit IsSeg2(NontermKind src)
            {
                var i = (ushort)src;
                return i >= Seg2Pos && i < MaxCount;
            }


        }
    }
}