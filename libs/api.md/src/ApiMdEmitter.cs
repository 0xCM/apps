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

        ApiMemory ApiMemory => Wf.ApiMemory();

        public void Emit(IApiPack dst)
        {
            Target = dst;
            Emit();
        }

        void Emit()
        {
            var symlits = Md.SymLits;
            exec(true,
                Md.EmitDataFlows,
                Md.EmitTypeLists,
                Md.EmitApiLiterals,
                () => Md.EmitComments(),
                () => Md.EmitAssets(),
                () => Md.EmitSymLits(symlits),
                Md.EmitParsers,
                Md.EmitApiTables,
                Md.EmitApiCommands,
                () => ApiMemory.EmitSymHeap(Heaps.load(symlits),Target),
                () => Md.EmitApiTokens()
            );
        }

        public static ApiMdEmitter create(IWfRuntime wf, ApiMd md)
        {
            var dst = create(wf);
            dst.Md = md;
            return dst;
        }

        void EmitApiSymIndex(CmdArgs args)
        {
            var result = Outcome.Success;
            var literals = Md.SymLits;
            var count = literals.Length;
            var counter = 0u;
            var dst = Ws.Tables().Subdir(WsAtoms.machine) + FS.file("symliterals", FS.Txt);
            using var writer = dst.UnicodeWriter();
            for(var i=0u; i<count; i++)
            {
                ref readonly var literal = ref literals[i];
                var name = literal.Name.Format();
                ref readonly var pos = ref literal.Index;
                var symbol = literal.Symbol.Format();
                ref readonly var value = ref literal.Value;
                var @class = literal.Component.IsNonEmpty ? literal.Component.Format() : EmptyString;
                var type =  empty(@class) ? literal.Type.Format() : (literal.Type.Format() + RpOps.embrace(@class));
                var desc = EmptyString;
                desc = string.Format("[{0:D5}:{1:D5}:{2}:{3}] = '{4}'", i, pos, type, name, symbol);;
                writer.WriteLine(desc);
            }

        }

    }
}