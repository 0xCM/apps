//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct GateInfo
    {
        public readonly GateKind Kind;

        public readonly byte PinWidth;

        public readonly byte InputCount;

        public readonly byte OutputCount;

        [MethodImpl(Inline)]
        public GateInfo(GateKind kind, byte width, byte ins, byte outs)
        {
            Kind = kind;
            InputCount = ins;
            OutputCount = outs;
            PinWidth = width;
        }
    }
}