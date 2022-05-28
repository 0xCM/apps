//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static core;

    partial class CsLang
    {
        const string EnumReplicantContainer = "EnumDefs";

        public void EmitReplicants(Type[] enums, FS.FolderPath dst)
        {
            var types = enums.GroupBy(x => x.Namespace).Map(x => (x.Key, x.ToArray())).ToDictionary();
            var namespaces = types.Keys.ToIndex();
            iter(namespaces, ns => EmitReplicants(ns,types[ns], dst), true);
        }

        static FS.FilePath EnumReplicantPath(FS.FolderPath dst, string ns)
            => dst + FS.file(string.Format("{0}.{1}", ns, EnumReplicantContainer), FS.Cs);

        void EmitReplicants(string ns, Type[] types, FS.FolderPath dst)
        {
            var buffer = text.emitter();
            RenderHeader(core.timestamp(), buffer);
            CsRender.EnumReplicants(ns, EnumReplicantContainer, types, buffer, e => Write(e.Format(), e.Flair));
            AppSvc.FileEmit(buffer.Emit(), types.Length, EnumReplicantPath(dst,ns), TextEncodingKind.Utf8);
        }
    }
}