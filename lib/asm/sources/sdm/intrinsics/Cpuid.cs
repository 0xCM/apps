//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    partial class IntelIntrinsicModels
    {
        public class CpuIdMembership : List<CpuId>
        {

        }

        public struct CpuId : ITextual
        {
            public const string ElementName = "CPUID";

            public string Content;

            [MethodImpl(Inline)]
            public CpuId(string src)
            {
                Content = src;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => nonempty(Content);
            }
            public string Format()
                => Content;

            public override string ToString()
                => Content;

            [MethodImpl(Inline)]
            public static implicit operator CpuId(string src)
                => new CpuId(src);

            [MethodImpl(Inline)]
            public static implicit operator string(CpuId src)
                => src.Format();
        }
    }
}