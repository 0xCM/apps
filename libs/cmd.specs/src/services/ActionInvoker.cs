
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CmdActionKind;

    public class ActionInvoker : IActionRunner
    {
        public static CmdActionKind classify(MethodInfo src)
        {
            var dst = CmdActionKind.None;
            var arity = src.ArityValue();
            var @void = (byte)(bit)src.HasVoidReturn();
            switch(arity)
            {
                case 0:
                    switch(@void)
                    {
                        case 0:
                            dst = CmdActionKind.Pure;
                        break;
                        case 1:
                            dst = CmdActionKind.Emitter;
                        break;
                    }
                break;
                case 1:
                    switch(@void)
                    {
                        case 0:
                            dst = CmdActionKind.Receiver;
                        break;
                        case 1:
                            dst = CmdActionKind.Func;
                        break;
                    }
                break;
            }
            return dst;
        }

        public readonly ShellCmdDef Def;

        public ActionInvoker(asci32 name, object host, MethodInfo method)
        {
            Def = new ShellCmdDef(name, classify(method), Require.notnull(method), Require.notnull(host));
        }

        public ref readonly asci32 CmdName
        {
            [MethodImpl(Inline)]
            get => ref Def.CmdName;
        }

        public ref readonly object Host
        {
            [MethodImpl(Inline)]
            get => ref Def.Host;
        }

        public ref readonly MethodInfo Method
        {
            [MethodImpl(Inline)]
            get => ref Def.Method;
        }

        public ref readonly CmdActionKind ActionKind
        {
            [MethodImpl(Inline)]
            get => ref Def.Kind;
        }

        public ref readonly CmdUri Uri
        {
            [MethodImpl(Inline)]
            get => ref Def.Uri;
        }

        ShellCmdDef IActionRunner.Def
            => Def;

        public Outcome Run(CmdArgs args)
        {
            var output = default(object);
            var result = Outcome.Success;
            try
            {
                switch(ActionKind)
                {
                    case Pure:
                        Method.Invoke(Host, new object[]{});
                        result = Outcome.Success;
                    break;
                    case Receiver:
                        Method.Invoke(Host, new object[1]{args});
                        result = Outcome.Success;
                    break;
                    case Emitter:
                        output = Method.Invoke(Host, new object[]{});
                    break;
                    case Func:
                        output = Method.Invoke(Host, new object[1]{args});
                    break;
                    default:
                        result = new Outcome(false, $"Unsupported {Method}");
                    break;
                }

                if(output != null)
                {
                    if(output is bool x)
                    {
                        result = Outcome.define(x, output, x ? "Win" : "Fail");
                    }
                    else if(output is Outcome y)
                    {
                        result = Outcome.success(y.Data, y.Message);
                    }
                    else
                    {
                        result = Outcome.success(output);
                    }
                }
            }
            catch(Exception e)
            {
                var type = Host.GetType();
                //var uri = $"cmd://{type.Assembly.PartName()}/{type.DisplayName()}/{Method.DisplayName()}/{ActionName}";
                var header = $"{Uri} invocation error";
                var message = AppMsg.format(header, e.InnerException);
                result = Outcome.fail(message);
            }

           return result;
        }
    }
}