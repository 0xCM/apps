//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static DumpBin.Flag;

    public partial class DumpBin
    {
        const PathSeparator PS = PathSeparator.BS;

        public static FS.FileExt ext(Flag f)
            => Z0.FS.ext(f.ToString().ToLower());

        public FS.FileExt OutputExt(CmdName name)
        {
            switch(name)
            {
                case CmdName.EmitAsm:
                    return ext(DISASM) + FS.Asm;
                case CmdName.EmitRawData:
                    return ext(RAWDATA) + FS.Hex;
                case CmdName.EmitHeaders:
                    return ext(HEADERS) + FS.Log;
                case CmdName.EmitRelocations:
                    return ext(RELOCATIONS) + FS.Log;
                case CmdName.EmitExports:
                    return ext(EXPORTS) + FS.Log;
                case CmdName.EmitLoadConfig:
                    return ext(LOADCONFIG) + FS.Log;
            }

            return FS.Log;
        }

        public CmdScript Script<T>(string name, CmdName id, ReadOnlySeq<T> src, FS.FolderPath outdir)
            where T : IFileModule
                => script(this, name, id, src, outdir);

        public CmdScriptExpr Command(CmdName id, FS.FilePath src, FS.FolderPath dst)
        {
            var subdir = dst + FS.folder(src.FileName.WithoutExtension.Name);
            subdir.Create();
            var x = OutputExt(id);
            var output = subdir + src.FileName.ChangeExtension(x);
            var source = src.Format(PS);
            var target = output.Format(PS);
            var pattern = CmdScriptPattern.Empty;
            switch(id)
            {
                case CmdName.EmitAsm:
                    pattern = CmdScripts.pattern("dumpbin.disasm", string.Format("dumpbin /DISASM:{2} /OUT:{1} {0}", source, target, "NOBYTES"));
                    break;
                case CmdName.EmitRawData:
                    pattern = CmdScripts.pattern("dumpbin.rawdata", string.Format("dumpbin /RAWDATA:1,32 /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitHeaders:
                    pattern = CmdScripts.pattern("dumpbin.headers", string.Format("dumpbin /HEADERS /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitRelocations:
                    pattern = CmdScripts.pattern("dumpbin.relocations", string.Format("dumpbin /RELOCATIONS /OUT:{1} {0}", src.Format(PS), output.Format(PS)));
                    break;
                case CmdName.EmitExports:
                    pattern = CmdScripts.pattern("dumpbin.exports", string.Format("dumpbin /EXPORTS /OUT:{1} {0}", source, target));
                    break;
                case CmdName.EmitLoadConfig:
                    pattern = CmdScripts.pattern("dumpbin.loadconfig", string.Format("dumpbin /LOADCONFIG /OUT:{1} {0}", src.Format(PS), output.Format(PS)));
                    break;
            }
            return CmdScripts.expr(pattern);
        }
    }
}