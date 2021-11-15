//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct Marker
        {
            public dynamic Element {get;}

            [MethodImpl(Inline)]
            public Marker(dynamic src)
            {
                Element = src;
            }
        }
    }
}