//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Generate
{
    public class OctetGen : BitSetGen
    {
        public override byte Digits => 8;

        public override byte MaxValue => 255;
    }
}