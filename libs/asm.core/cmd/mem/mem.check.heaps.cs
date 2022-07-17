//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class AsmCoreCmd
    {
        void CheckHeaps1()
        {
            var src = CodeFiles.PartFiles(PartId.Assets);
            var hex = src.Hex.ReadLines();
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