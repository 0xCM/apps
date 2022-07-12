//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CmdActionKind;

    public class ActionInvoker : ICmdActionInvoker
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

        public string ActionName {get;}

        public object Host {get;}

        public MethodInfo Method {get;}

        public CmdActionKind ActionKind {get;}

        public ActionInvoker(string name, object host, MethodInfo method)
        {
            ActionName = Require.nonempty(name);
            Host = Require.notnull(host);
            Method = Require.notnull(method);
            ActionKind = classify(method);
        }

        public Outcome Invoke(CmdArgs args)
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
                var uri = $"cmd://{type.Assembly.PartName()}/{type.DisplayName()}/{Method.DisplayName()}/{ActionName}";
                var header = $"{uri} invocation error";
                var message = AppMsg.format(header, e.InnerException);
                result = Outcome.fail(message);
            }

           return result;
        }
    }
}