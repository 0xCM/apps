//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    class ApiMdEmitter : WfSvc<ApiMdEmitter>
    {
        IApiPack Target;

        ApiMd Md;

        public void Emit(IApiPack dst)
        {
            Target = dst;
            Emit();
        }

        void Emit()
        {
            exec(true,
                Md.EmitDataFlows,
                Md.EmitTypeLists,
                Md.EmitApiLiterals,
                () => Md.EmitComments(),
                () => Md.EmitAssets(),
                () => Md.EmitSymLits(Md.SymLits),
                Md.EmitParsers,
                Md.EmitApiTables,
                Md.EmitApiCommands,
                () => Md.EmitApiTokens()
            );

        }

        public static ApiMdEmitter create(IWfRuntime wf, ApiMd md)
        {
            var dst = create(wf);
            dst.Md = md;
            return dst;
        }
    }
}