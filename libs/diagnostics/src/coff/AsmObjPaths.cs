//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmObjPaths
    {
        readonly AppDb AppDb;

        [MethodImpl(Inline)]
        public AsmObjPaths(AppDb db)
        {
            AppDb = db;
        }

        public FS.FilePath RecodedPath(ProjectId ws, string origin)
            => AppDb.AsmSrc(ws).Path(FS.file(origin.Remove(string.Format(".{0}", FileKind.ObjAsm.Ext().Format())), FileKind.Asm.Ext()));

        public FS.FilePath AsmCodePath(ProjectId ws, string origin)
            => AppDb.AsmCsv(ws).Path(FS.file(string.Format("{0}.code", origin), FS.Csv));
    }
}