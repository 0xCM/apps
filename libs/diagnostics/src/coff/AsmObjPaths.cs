//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using G = ApiGranules;

    public readonly struct AsmObjPaths
    {
        readonly IAppDb AppDb;

        [MethodImpl(Inline)]
        public AsmObjPaths(IAppDb db)
        {
            AppDb = db;
        }

        IDbTargets EtlTargets(ProjectId id, string scope)
            => AppDb.EtlTargets(id).Targets(scope);

        public IDbTargets AsmCsv(ProjectId id)
            => EtlTargets(id, G.asmcsv);

        public IDbTargets ObjHex(ProjectId id)
            => EtlTargets(id, G.objhex);

        public IDbTargets XedDisasm(ProjectId id)
            => EtlTargets(id, G.xeddisasm);

        public IDbTargets AsmSrc(ProjectId id)
            => EtlTargets(id, G.asmsrc);

        public FS.FilePath RecodedPath(ProjectId ws, string origin)
            => AsmSrc(ws).Path(FS.file(origin.Remove(string.Format(".{0}", FileKind.ObjAsm.Ext().Format())), FileKind.Asm.Ext()));

        public FS.FilePath AsmCodePath(ProjectId ws, string origin)
            => AsmCsv(ws).Path(FS.file(string.Format("{0}.code", origin), FS.Csv));
    }
}