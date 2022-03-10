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
        public readonly struct ImmFieldSpec
        {
            public readonly byte Index;

            public readonly byte Width;

            public ImmFieldSpec(byte index, byte width)
            {
                Index = index;
                Width = width;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static ImmFieldSpec Empty => default;
        }
    }
}