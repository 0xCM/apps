//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct OpWidthSpec
        {
            [MethodImpl(Inline)]
            public static OpWidthSpec define(OpWidthCode code, ElementType ct, ushort tw, ushort cw, ushort n)
                => new OpWidthSpec(code, GprWidth.Empty, ct, tw, cw, n);

            [MethodImpl(Inline)]
            public static OpWidthSpec define(OpWidthCode code,ushort tw)
                => new OpWidthSpec(code, GprWidth.Empty, ElementType.Empty, tw, tw, 1);

            [MethodImpl(Inline)]
            public static OpWidthSpec define(GprWidth gpr)
            {
                if(gpr.IsEmpty)
                    return new OpWidthSpec(0,gpr,ElementType.Empty,0,0,0);

                if(gpr.IsInvariant)
                    return new OpWidthSpec(0,gpr,ElementType.Empty,(ushort)gpr[w16].Width,(ushort)gpr[w16].Width,1);

                var w0 = (ushort)gpr[w16].Width;
                var w1 = (ushort)gpr[w32].Width;
                var w2 = (ushort)gpr[w64].Width;
                var bw = Bitfields.join(w0,w1,w2);
                return new OpWidthSpec(0, gpr, ElementType.Empty, Bitfields.join(w0,w1,w2), 0, 1);
            }

            [MethodImpl(Inline)]
            public static OpWidthSpec define(ushort tw)
                => new OpWidthSpec(0, GprWidth.Empty, ElementType.Empty, tw, tw, 1);

            [MethodImpl(Inline)]
            OpWidthSpec(OpWidthCode code, GprWidth gpr, ElementType ct, ulong bw, ushort cw, ushort n)
            {
                Code = code;
                Gpr = gpr;
                CellType = ct;
                CellWidth = cw;
                CellCount = n;
                BitWidth = bw;
            }

            public readonly OpWidthCode Code;

            public readonly GprWidth Gpr;

            public readonly ElementType CellType;

            readonly ushort CellWidth;

            public readonly ushort CellCount;

            readonly ulong BitWidth;

            public byte Count
            {
                [MethodImpl(Inline)]
                get => Gpr.IsEmpty ? (byte)1 : Gpr.Count;
            }

            public bool Invariant
            {
                [MethodImpl(Inline)]
                get => Gpr.IsInvariant;
            }

            public ushort W0
            {
                [MethodImpl(Inline)]
                get => (ushort)BitWidth;
            }

            public ushort W1
            {
                [MethodImpl(Inline)]
                get => (ushort)(BitWidth >> 16);
            }

            public ushort W2
            {
                [MethodImpl(Inline)]
                get => (ushort)(BitWidth >> 32);
            }

            public ushort this[W16 w]
            {
                [MethodImpl(Inline)]
                get => W0;
            }

            public ushort this[W32 w]
            {
                [MethodImpl(Inline)]
                get => W1;
            }

            public ushort this[W64 w]
            {
                [MethodImpl(Inline)]
                get => W2;
            }

            public ushort OpBits
            {
                [MethodImpl(Inline)]
                get => (ushort)BitWidth;
            }

            public static OpWidthSpec Empty => define(GprWidth.Empty);
        }
    }
}