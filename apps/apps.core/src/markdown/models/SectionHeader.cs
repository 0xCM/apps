//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly struct SectionHeader : IMarkdownElement<SectionHeader>
        {
            public readonly byte Depth;

            public readonly string Name;

            [MethodImpl(Inline)]
            public SectionHeader(byte depth, string name)
            {
                Depth = depth;
                Name = name;
            }

            public string Format()
                => string.Format("{0} {1}", new string(Chars.Hash,Depth), Name);

            public override string ToString()
                => Format();
        }
    }
}