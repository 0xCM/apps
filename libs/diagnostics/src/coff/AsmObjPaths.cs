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

        public IDbTargets DbTargets(ProjectId id)
            => AppDb.ProjectData(id);

        public IDbTargets RecodedTargets(ProjectId id)
            => AppDb.ProjectTargets("mc.recoded").Targets($"src/{id}");

        public FS.FilePath RecodedPath(ProjectId ws, string origin)
            => RecodedTargets(ws).Path(FS.file(origin.Remove(string.Format(".{0}", FileKind.ObjAsm.Ext().Format())), FileKind.Asm.Ext()));

        public FS.FilePath AsmCodeTable(ProjectId ws, string origin)
            => AppDb.AsmTargets(ws).Path(FS.file(string.Format("{0}.code", origin), FS.Csv));

        public FS.FilePath CoffSymPath(ProjectId id)
            => DbTargets(id).Table<CoffSymRecord>(id);

        public FS.FilePath AsmSyntaxTable(ProjectId id)
            => DbTargets(id).Table<AsmSyntaxRow>(id);

        public FS.FilePath CodeMap(ProjectId ws)
            => DbTargets(ws).Table<AsmCodeMapEntry>(ws);

        public FS.FilePath InstructionTable(ProjectId id)
            => DbTargets(id).Table<AsmInstructionRow>(id);

        public FS.FilePath AsmEncodingTable(ProjectId id)
            => DbTargets(id).Table<XedDisasmRow>(id);

        public FS.FilePath ObjBlockPath(ProjectId ws)
            => DbTargets(ws).Table<ObjBlock>(ws);

        public FS.FilePath ObjRowsPath(ProjectId ws)
            => DbTargets(ws).Table<ObjDumpRow>(ws);
    }
}