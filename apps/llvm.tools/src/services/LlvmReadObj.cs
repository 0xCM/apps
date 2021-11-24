//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public sealed class LlvmReadObj : ToolService<LlvmReadObj>
    {
        public override ToolId Id
            => LlvmNames.Tools.llvm_readobj;

        public FS.Files ObjInfoFiles(FS.FolderPath src)
            => src.Files(FS.ext("obi"), true);

        public CoffObjInfo Load(FS.FilePath src)
        {
            const string PathMarker = "File:";
            var lines = src.ReadNumberedLines(TextEncodingKind.Asci);
            foreach(var line in lines)
            {
                ref readonly var content = ref line.Content;
                var i = text.index(line.Content, PathMarker);
                if(i >= 0)
                {
                    var path = FS.path(text.right(line.Content, i + PathMarker.Length));
                    if(path.Exists)
                        return new CoffObjInfo(new CoffObjFile(path), lines);
                    else
                        Error(FS.missing(path));
                }
            }

            return CoffObjInfo.Empty;
        }
    }
}