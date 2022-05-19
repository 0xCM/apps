//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelIntrinsics
    {
        public class CpuIdMembership : List<CpuId>
        {
            public string Format()
                => this.Delimit().Format();

            public override string ToString()
                => Format();
        }

        public struct CpuId
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