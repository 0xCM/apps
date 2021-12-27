//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        Outcome FileTypeTest1()
        {
            var result = Outcome.Success;
            var src = ApiLiterals.provided(typeof(FileKindNames)).Sort();
            var values = src.Map(x => x.Value().Format().Remove(RP.Tick));
            result = HashFunctions.perfect(values, out var entries);
            if(result.Fail)
                return result;

            var count = src.Length;
            var formatter = Tables.formatter<HashEntry>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                Write(formatter.Format(entry));
            }

            return result;
        }
    }
}