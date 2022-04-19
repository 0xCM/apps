//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TaggedTool : IEquatable<TaggedTool>
    {
        public ToolId Tool {get;}

        public text15 Tag {get;}

        [MethodImpl(Inline)]
        public TaggedTool(ToolId tool, text15 tag)
        {
            Tool = tool;
            Tag = tag;
        }

        public bool Equals(TaggedTool src)
            => Tool == src.Tool && Tag == src.Tag;

        public override bool Equals(object src)
            => src is TaggedTool t && Equals(t);

        public string Format()
            => string.Format("{0}-{1}", Tool, Tag);

        public override int GetHashCode()
            => Format().GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator TaggedTool((ToolId tool, string tag) src)
            => new TaggedTool(src.tool, src.tag);
    }
}