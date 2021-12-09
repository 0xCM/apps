//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataEmitter
    {
        public uint EmitToolHelp()
        {
            var dir = LlvmPaths.ToolSourceDocs();
            var docs = DataProvider.SelectToolHelp();
            var count = docs.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref docs[i];
                var content = doc.Content;
                var dst = dir + FS.file(doc.Tool.Format(),FS.Help);
                var emitting = EmittingFile(dst);
                using var writer = dst.Writer();
                writer.Write(content);
                EmittedFile(emitting, content.Length);
            }
            return 0;
        }
    }
}