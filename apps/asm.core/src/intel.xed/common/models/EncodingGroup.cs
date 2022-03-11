//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct EncodingGroup
        {
            public readonly GroupName Name;

            [MethodImpl(Inline)]
            public EncodingGroup(GroupName src)
            {
                Name = src;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator EncodingGroup(GroupName src)
                => new EncodingGroup(src);

            [MethodImpl(Inline)]
            public static implicit operator GroupName(EncodingGroup src)
                => src.Name;
        }
    }
}