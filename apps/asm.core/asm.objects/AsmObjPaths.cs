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
            => AppDb.Targets($"projects/{ws.Project}");

        public DbTargets AsmTargets(IProjectWs ws)
            => DbTargets(ws).Targets("asm.code");

        public DbTargets HexTargets(IProjectWs ws)
            => DbTargets(ws).Targets("obj.hex");

        public FS.FilePath AsmCode(IProjectWs ws, string origin)
            => AsmTargets(ws).Path(FS.file(string.Format("{0}.code", origin), FS.Csv));

        public DbTargets RecodedTargets(IProjectWs ws)
            => AppDb.Project(ProjectNames.McRecoded).Targets($"src/{ws.Name}");

        public FS.FilePath CoffSymPath(IProjectWs ws)
            => AsmTargets(ws).Table<CoffSymRecord>(ws.Project);

        public FS.FilePath RecodedPath(IProjectWs ws, string origin)
            => RecodedTargets(ws).Path(FS.file(origin.Remove(string.Format(".{0}", FileKind.ObjAsm.Ext().Format())), FileKind.Asm.Ext()));

        public FS.FilePath AsmSyntaxTable(IProjectWs ws)
            => AsmTargets(ws).Table<AsmSyntaxRow>(ws.Project);

        public FS.FilePath CodeMap(IProjectWs ws)
            => AsmTargets(ws).Table<AsmCodeMapEntry>(ws.Project);

        public FS.FilePath InstructionTable(IProjectWs ws)
            => AsmTargets(ws).Table<AsmInstructionRow>(ws.Project);

        public FS.FilePath AsmEncodingTable(IProjectWs ws)
            => AsmTargets(ws).Table<XedDisasmRow>(ws.Project);

        public FS.FilePath ObjBlockPath(IProjectWs ws)
            => AsmTargets(ws).Table<ObjBlock>(ws.Project);

        public FS.FilePath ObjRowsPath(IProjectWs ws)
            => AsmTargets(ws).Table<ObjDumpRow>(ws.Project);

        [MethodImpl(Inline)]
        public static implicit operator AsmObjPaths(AppDb src)
            => new AsmObjPaths(src);
    }
}