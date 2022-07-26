//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    [Free]
    sealed class App : AppCmdShell<App>
    {
        static IAppCmdService commands(IWfRuntime wf)
            => IntelCommands.create(wf);

        public static void Main(params string[] args)
            => run(commands, args);
    }

    class IntelCommands : AppCmdService<IntelCommands>
    {

        [CmdOp("asm/check/hex")]
        void Hello()
        {
            var input = "66 66 2e 0f 1f 84 00 00 00 00 00 00";
            var buffer = ByteBlock16.Empty;
            var size = (byte)Hex.parse(input, buffer.Bytes).Require();
            var data = slice(buffer.Bytes,0,size);
            buffer[15] = size;
            var dst = new AsmHexCode(@as<ByteBlock16,Cell128>(buffer));
            Write(dst.Format());

        }

        ModuleArchives Archives => Wf.ModuleArchives();

        [CmdOp("api/mods")]
        void Modules()
        {
            var src = Archives.PartArchive();
            iter(src.ManagedDll(), dll => Write(dll.Format()));
        }

    }
}