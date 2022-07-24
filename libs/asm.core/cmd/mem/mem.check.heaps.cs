//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        void CheckHeaps1(IApiPack src)
        {
            var files = ApiPartFiles.create(src, PartId.Assets);
            var hex = files.Hex.ReadLines();
        }

        void CheckAssets2()
        {
            var src = TextAssets.strings(typeof(AsciText));
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var res = ref src[i];
                Write(res);
            }
        }
    }
}