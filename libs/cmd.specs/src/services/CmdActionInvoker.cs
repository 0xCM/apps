//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CmdActionKind;
    using static core;

    public class CmdActionInvoker : ICmdActionInvoker
    {
        // [Op]
        // public static CmdActionInvoker action(string name, object host, MethodInfo method)
        //     => new CmdActionInvoker(name,host,method);

        // [Op]
        // public static Index<CmdActionInvoker> actions(object host)
        // {
        //     var methods = host.GetType().Methods().Tagged<CmdOpAttribute>();
        //     var buffer = alloc<CmdActionInvoker>(methods.Length);
        //     actions(host, methods,buffer);
        //     return buffer;
        // }

        // static void actions(object host, ReadOnlySpan<MethodInfo> src, Span<CmdActionInvoker> dst)
        // {
        //     var count = src.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var method = ref skip(src,i);
        //         var tag = method.Tag<CmdOpAttribute>().Require();
        //         seek(dst,i) = action(tag.CommandName, host, method);
        //     }
        // }

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

        public CmdActionInvoker(string name, object host, MethodInfo method)
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
            }
            catch(Exception e)
            {
                result = e;
            }

            if(output != null)
            {
                if(output is bool x)
                    result = x ? Outcome.Success : Outcome.Failure;
                else if(output is Outcome y)
                    result = y;
                else
                    result = Outcome.success(output);
            }

            return result;
        }
    }
}