//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct BitPatternDef
    {
        const string TableId = "bits.patterns.specs";

        /// <summary>
        /// The pattern name
        /// </summary>
        public readonly asci32 Name;

        /// <summary>
        /// The name of the pattern source
        /// </summary>
        public readonly BfOrigin Origin;

        /// <summary>
        /// The pattern content
        /// </summary>
        public readonly asci64 Data;

        [MethodImpl(Inline)]
        internal BitPatternDef(asci32 name, BfOrigin origin, asci64 data)
        {
            Name = name;
            Origin = origin;
            Data = data;
        }
    }
}