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
        public struct EnumReplicantSpec
        {
            public string Namespace;

            public string DeclaringType;

            public FS.FolderPath Target;

            [MethodImpl(Inline)]
            public EnumReplicantSpec WithNamespace(string ns)
            {
                Namespace = ns;
                return this;
            }

            public EnumReplicantSpec WithDeclaringType(string name)
            {
                DeclaringType = name;
                return this;
            }
        }

        [MethodImpl(Inline)]
        public static ref EnumReplicantSpec replicant(FS.FolderPath target, out EnumReplicantSpec dst, string ns = null, string type = null)
        {
            dst.Namespace = ns ?? EmptyString;
            dst.DeclaringType = type ?? EmptyString;
            dst.Target = target;
            return ref dst;
        }

        public void EmitReplicants(EnumReplicantSpec spec, Type[] enums, FS.FolderPath dst)
        {
            var types = enums.GroupBy(x => x.Namespace).Map(x => (x.Key, x.ToArray())).ToDictionary();
            var namespaces = types.Keys.ToIndex();
            iter(namespaces, ns => EmitReplicants(spec.WithNamespace(ns), types[ns]), true);
        }

        static FS.FilePath ReplicantCodePath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Cs);

        static FS.FilePath ReplicantDataPath(EnumReplicantSpec spec, string ns)
            => spec.Target + FS.file(string.Format("{0}.{1}", ns, text.ifempty(spec.DeclaringType, "EnumDefs")), FS.Csv);

        void EmitReplicants(EnumReplicantSpec spec, Type[] types)
        {
            var tops = types.Where(t => !t.IsNested);
            var enclosed = types.Where(t => t.IsNested).GroupBy(t => t.DeclaringType).Select(t => (t.Key, t.Index())).ToDictionary();
            exec(true,
                () => EmitTopReplicants(spec,tops),
                () => EmitEnclosedReplicants(spec,enclosed)
            );
        }

        void EmitTopReplicants(EnumReplicantSpec spec, Type[] tops)
        {
            var buffer = text.emitter();
            RenderHeader(core.timestamp(), buffer);
            CsRender.EnumReplicants(spec, tops, buffer, e => Write(e.Format(),e.Flair));
            AppSvc.FileEmit(buffer.Emit(), tops.Length, ReplicantCodePath(spec, spec.Namespace), TextEncodingKind.Utf8);
        }

        void EmitEnclosedReplicants(EnumReplicantSpec spec, Dictionary<Type,Index<Type>> src)
        {
            var keys = src.Keys.Index();
            var buffer = text.emitter();
            for(var i=0; i<keys.Count; i++)
            {
                ref readonly var key = ref keys[i];
                spec = spec.WithDeclaringType(key.Name);
                RenderHeader(core.timestamp(), buffer);
                var enclosed = src[key];
                CsRender.EnumReplicants(spec, enclosed, buffer, e => Write(e.Format(),e.Flair));
                AppSvc.FileEmit(buffer.Emit(), enclosed.Count, ReplicantCodePath(spec, spec.Namespace), TextEncodingKind.Utf8);
            }
        }
    }
}