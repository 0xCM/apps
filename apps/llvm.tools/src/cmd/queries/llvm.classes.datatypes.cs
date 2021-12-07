//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string ClassDatatypeQuery = "llvm/classes/datatypes";

        [CmdOp(ClassDatatypeQuery)]
        Outcome QueryClassDatatypes(CmdArgs args)
        {
            var src = DataProvider.SelectClassFields();
            var count = src.Count;
            var dst = hashset<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref src[i];
                var fmt = field.DataType.Trim();
                if(nonempty(fmt))
                    dst.Add(fmt);
            }

            Flow(ClassDatatypeQuery, @readonly(dst.Array()));

            return true;
        }
    }
}