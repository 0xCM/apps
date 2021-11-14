//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [Op]
        public static void traverse(FS.FilePath src, Receiver<ProcessAsmRecord> dst)
        {
            var counter = 1u;
            using var reader = src.Utf8Reader();
            var header = reader.ReadLine();
            var line = reader.ReadLine();
            var result = Outcome.Success;
            while(line != null && result.Ok)
            {
                result = AsmParser.row(counter++, line, out var row);
                if(result.Ok)
                    dst(row);
                line = reader.ReadLine();
            }
        }
    }
}