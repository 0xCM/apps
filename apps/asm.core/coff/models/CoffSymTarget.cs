//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct CoffSymTarget
    {
        public ushort Section;

        public Address32 Location;

        [MethodImpl(Inline)]
        public CoffSymTarget(ushort section, Address32 location)
        {
            Section = section;
            Location = location;
        }
    }
}