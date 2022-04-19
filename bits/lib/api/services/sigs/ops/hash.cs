//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiSigs
    {
        [Op]
        public static uint hash(in ApiSig src)
        {
            var result = 0u;
            var parts = src.Components.View;
            var count = src.Components.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                var hc = alg.hash.marvin(part.Name);
                if(i == 0)
                    result = hc;
                else
                    result = alg.hash.combine(result, hc);
            }

            return alg.hash.combine(result, (uint)src.Class);
        }
    }
}