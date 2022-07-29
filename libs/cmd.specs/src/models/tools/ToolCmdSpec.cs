//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a tool execution specification
    /// </summary>
    public class ToolCmdSpec : IToolCmd
    {
        public static string format(IToolCmd src)
        {
            var count = src.Args.Count;
            var dst = text.emitter();
            dst.AppendFormat("{0}{1}", src.CmdName.Format(), Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                dst.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    dst.Append(", ");
            }

            dst.Append(Chars.RParen);
            return dst.Emit();
        }

        public readonly Tool Tool;

        public readonly Name CmdName;

        public readonly ToolCmdArgs Args;

        [MethodImpl(Inline)]
        public ToolCmdSpec(Tool tool, Name cmd, params ToolCmdArg[] args)
        {
            Tool = tool;
            CmdName = cmd;
            Args = args;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public static ToolCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdSpec(Actor.Empty, EmptyString);
        }

        Name IToolCmd.CmdName
            => CmdName;

        ToolCmdArgs IToolCmd.Args
            => Args;
    }
}