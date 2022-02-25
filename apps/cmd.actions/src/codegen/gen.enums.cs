//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using System.Linq;


    partial class CodeGenProvider
    {
        [CmdOp("gen/listed-enums")]
        Outcome GenEnums(CmdArgs args)
        {
            var enums = LoadListedEnums(AppDb.ApiEnumListPath());
            var name = "EnumDefs";
            var dst = AppDb.CgStagePath(name, FileKind.Cs);
            CodeGen.GenEnumReplicants(enums, dst);
            return true;
        }

        Index<Type> LoadListedEnums(FS.FilePath src)
        {
            var running = Running(string.Format("Loading enum types from {0}", src.ToUri()));
            var buffer = list<Type>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var name = line.Content.Trim();
                var type = Type.GetType(name);
                if(type != null)
                    buffer.Add(type);
                else
                    Warn(string.Format("Unable to load {0}", name));
            }

            var dst = buffer.ToArray();
            Ran(running, string.Format("Loaded {0} enum types from {1}", dst.Length, src.ToUri()));
            return dst;
        }
    }
}