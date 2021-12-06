//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.IO;

    public partial class LlvmDataEmitter : AppService<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths;

        LlvmDataProvider DataProvider;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            DataProvider = Wf.LlvmDataProvider();
        }

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

        public uint EmitClassInfo(StreamWriter dst)
        {
            var map = DataProvider.SelectX86ClassMap();
            var count = map.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(map[i].Format());
            return count;
        }

        public uint EmitDefInfo(StreamWriter dst)
        {
            var map = DataProvider.SelectX86DefMap();
            var count = map.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(map[i].Format());
            return count;
        }
    }
}