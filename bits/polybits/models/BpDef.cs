//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public readonly struct BpDef
    {
        const string TableId = "bits.patterns.defs";

        /// <summary>
        /// The name of the pattern source
        /// </summary>
        [Render(32)]
        public readonly BfOrigin Origin;

        /// <summary>
        /// The pattern name
        /// </summary>
        [Render(32)]
        public readonly asci32 Name;

        /// <summary>
        /// The pattern content
        /// </summary>
        [Render(1)]
        public readonly asci64 Content;

        [MethodImpl(Inline)]
        internal BpDef(BfOrigin origin, asci32 name, asci64 content)
        {
            Origin = origin;
            Name = name;
            Content = content;
        }
    }
}