//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct AsmLayoutSpec
    {
        public readonly AsmLayoutKind Kind;

        public AsmLayoutSpec(AsmLayoutKind layout)
        {
            Kind = layout;
        }
    }
}