//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct DispFieldSpec
        {
            public readonly byte Width;

            public readonly char Kind;

            public DispFieldSpec(byte width, char kind)
            {
                Width = width;
                Kind = kind;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static DispFieldSpec Empty => default;
        }
    }
}