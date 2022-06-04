//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class ApiCmd : AppCmdService<ApiCmd>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        AsmDocs AsmDocs => Wf.AsmDocs();

        Heaps Heaps => Wf.Heaps();

        [CmdOp("api/emit")]
        void ApiEmit()
        {
            ApiMd.EmitDatasets();
            AsmDocs.Emit();
        }

        [CmdOp("api/emit/heaps")]
        void ApiEmitHeaps()
        {
            Heaps.Emit(Heaps.symbols(ApiMd.SymLits));
        }

        [CmdOp("api/emit/index")]
        void EmitRuntimeMembers()
        {
            var service = ApiRuntime.create(Wf);
            var members = ApiMd.CalcRuntimeMembers();
            ApiMd.EmitIndex(members);
        }

        [CmdOp("api/parts")]
        void Parts()
        {
            iter(ApiMd.Parts, part => Write(part.Name));
        }

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
        {
            ApiMd.EmitComments();
        }
    }
}