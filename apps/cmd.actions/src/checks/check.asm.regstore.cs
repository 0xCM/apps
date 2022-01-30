//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Asm.RegClasses;

    using static core;

    partial class CheckCmdProvider
    {
        [MethodImpl(Inline)]
        static AsmRegValue<T> regval<T>(AsmRegName name, T value)
            where T : unmanaged
                => new AsmRegValue<T>(name,value);

        [CmdOp("check/asm/regstore")]
        Outcome CheckRegstore(CmdArgs args)
        {
            var result = Outcome.Success;
            var grid = RegGrid8x64.Empty;
            var regs = RegStore8x64.Empty;
            var names = recover<AsmRegName>(ByteBlock64.Empty.Bytes);
            var pairs = recover<AsmRegValue<ulong>>(ByteBlock128.Empty.Bytes);

            for(byte i=0; i<7; i++)
            {
                regs[i] = i;
                seek(names,i) = KReg.RegName((RegIndexCode)i);
                grid[i] = regval(skip(names,i), regs[i]);
            }

            for(byte i=0; i<7; i++)
            {
                ref readonly var name = ref skip(names,i);
                ref readonly var value = ref regs[i];
                var output = grid[i].Format();
                Write(output);
            }

            var input = (ulong)PermLits.Perm16Identity;
            for(byte i=0; i<7; i++)
            {
                regs[i] = input << i*3;
                Write(regval(skip(names,i), regs[i]));
            }

            return result;
        }
    }
}