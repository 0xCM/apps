//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".file-types")]
        Outcome ProjFileTypes(CmdArgs args)
        {
            var result = Outcome.Success;
            for(var i=0u; i<100; i++)
            {
                Write(string.Format("Pow2.next({0}) = {1}", i, Pow2.next(i)));
            }

            return result;
            //return FileTypeTest1();
        }

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