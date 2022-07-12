//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("gen/strings/ints")]
        Outcome GenIntStrings(CmdArgs args)
        {
            var result = Outcome.Success;
            result = DataParser.parse(arg(args,0).Value, out uint min);
            result = DataParser.parse(arg(args,1).Value, out uint max);
            var values = list<string>();
            var name = string.Format("Range{0}To{1}", min, max);
            var n = max.ToString().Length;
            for(var i=min; i<=max; i++)
                values.Add(i.ToString().PadLeft(n));

            var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
            CsLang.StringLits().Emit(name,values.ViewDeposited(), dst);
            return result;
        }
    }
}