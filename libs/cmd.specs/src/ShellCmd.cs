//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ShellCmd
    {
        public static CmdArg arg(in CmdArgs src, int index)
        {
            if(src.IsEmpty)
                sys.@throw(EmptyArgList.Format());

            var count = src.Length;
            if(count < index - 1)
                sys.@throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";



        public static CmdArgs args(ReadOnlySpan<string> src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg(skip(src,i));
            return dst;
        }

        public static string format(in ShellCmdSpec src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            dst.Append(src.Name);
            var count = src.Args.Length;
            for(ushort i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                if(nonempty(arg.Name))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Name);
                }

                if(nonempty(arg.Value))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Value);
                }
            }
            return dst.Emit();
        }

        [Op, MethodImpl(Inline)]
        public static ShellCmdSpec define(string name, CmdArgs args)
            => new ShellCmdSpec(name, args);

        [Op]
        public static ShellCmdSpec parse(ReadOnlySpan<char> src)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                return new ShellCmdSpec(text.format(src), CmdArgs.Empty);
            else
            {
                var name = text.format(text.left(src,i));
                var _args = text.format(text.right(src,i)).Split(Chars.Space);
                return new ShellCmdSpec(name, args(_args));
            }
        }

    }
}