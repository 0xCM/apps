//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public readonly struct AsmObjPaths
    {
        readonly AppDb AppDb;

        [MethodImpl(Inline)]
        public AsmObjPaths(AppDb db)
        {
            AppDb = db;
        }

        public DbTargets DbTargets(IProjectWs ws)
            => AppDb.DbTargets(ws);

        public DbTargets Targets(IProjectWs ws)
            => DbTargets(ws);

        public DbTargets AsmTargets(IProjectWs ws)
            => AppDb.AsmTargets(ws);

        public DbTargets HexTargets(IProjectWs ws)
            => AppDb.HexTargets(ws);

        public DbTargets RecodedTargets(IProjectWs ws)
            => AppDb.Project(ProjectNames.McRecoded).Targets($"src/{ws.Name}");

        public FS.FilePath RecodedPath(IProjectWs ws, string origin)
            => RecodedTargets(ws).Path(FS.file(origin.Remove(string.Format(".{0}", FileKind.ObjAsm.Ext().Format())), FileKind.Asm.Ext()));

        public FS.FilePath AsmCodeTable(IProjectWs ws, string origin)
            => AsmTargets(ws).Path(FS.file(string.Format("{0}.code", origin), FS.Csv));

        public FS.FilePath CoffSymPath(IProjectWs ws)
            => Targets(ws).Table<CoffSymRecord>(ws.Name);

        public FS.FilePath AsmSyntaxTable(IProjectWs ws)
            => Targets(ws).Table<AsmSyntaxRow>(ws.Name);

        public FS.FilePath CodeMap(IProjectWs ws)
            => Targets(ws).Table<AsmCodeMapEntry>(ws.Name);

        public FS.FilePath InstructionTable(IProjectWs ws)
            => Targets(ws).Table<AsmInstructionRow>(ws.Name);

        public FS.FilePath AsmEncodingTable(IProjectWs ws)
            => Targets(ws).Table<XedDisasmRow>(ws.Name);

        public FS.FilePath ObjBlockPath(IProjectWs ws)
            => Targets(ws).Table<ObjBlock>(ws.Name);

        public FS.FilePath ObjRowsPath(IProjectWs ws)
            => Targets(ws).Table<ObjDumpRow>(ws.Name);
    }
}