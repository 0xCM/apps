//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TriadGen : BitSetGen
    {
        public static BitSetGen Service => new TriadGen();

        public override byte Digits => 3;

        public override byte MaxValue => 7;
    }
}