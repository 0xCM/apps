//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".asm-tp")]
        Outcome LoadThumbprints(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = ApiPackArchive.Thumbprints();
            result = AsmThumbprint.load(src, out var data);
            if(result.Fail)
                return result;

            var count = data.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref skip(data,i);
                Write(item.Statement);
            }

            return result;
        }
    }
}