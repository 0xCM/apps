//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        const string il = nameof(il);


        [CmdOp("api/emit/classes")]
        Outcome EmitApiClasses(CmdArgs args)
        {
            var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
            var dst = text.emitter();
            Classifiers.render(classifier,dst);
            Write(dst.Emit());
            return true;
        }
   }
}