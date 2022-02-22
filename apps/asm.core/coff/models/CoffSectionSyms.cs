//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct CoffSectionSyms
    {
        public readonly Index<CoffSection> Sections;

        public readonly Index<CoffSymRecord> Symbols;

        public CoffSectionSyms(CoffSection[] sections, CoffSymRecord[] syms)
        {
            Sections = sections;
            Symbols = syms;
        }
    }

}
