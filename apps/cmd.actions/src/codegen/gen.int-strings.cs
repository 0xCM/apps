//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial class CodeGenProvider
    {
        [CmdOp("gen/int-strings")]
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
            var dst = Ws.Project("gen").Subdir("literals") + FS.file(name, FS.Cs);
            var svc = Wf.CodeGen().StringLiterals();
            svc.Emit(name,values.ViewDeposited(), dst);
            return result;
        }
    }
}