//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/inst")]
        Outcome CheckInstDefs(CmdArgs args)
        {
            var dst = AppDb.Log("xed.patterns", FileKind.Txt);
            var emitting = EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.AsciWriter();
            void Print(string src)
            {
                writer.WriteLine(src);
                counter++;
            }
            var traverser = new InstTraverser(Xed, Print);
            traverser.Traverse();
            var patterns = traverser.Patterns();
            EmittedFile(emitting,counter);
            return true;
        }
    }
}