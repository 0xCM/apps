//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public class CsLang : AppService<CsLang>
    {
        public static CsEmitter emitter()
            => new();

        AppServices AppSvc => Service(Wf.AppServices);

        public void EmitReplicants(Index<ClrEnumAdapter> enums, FS.FilePath dst)
        {
            var types = enums.GroupBy(x => x.Definition.Namespace).Map(x => (x.Key, x.ToArray())).ToDictionary();
            var keys = types.Keys;
            var counter = 0u;
            var buffer = text.emitter();
            var name = "EnumDefs";
            foreach(var ns in keys)
                counter += CsRender.replicants(ns, name, types[ns], buffer);
            AppSvc.FileEmit(buffer.Emit(), counter, dst);
        }
    }
}