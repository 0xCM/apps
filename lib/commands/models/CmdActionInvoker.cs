//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CmdActionKind;

    public class CmdActionInvoker : ICmdActionInvoker
    {
        public static CmdActionKind classify(MethodInfo src)
        {
            var dst = CmdActionKind.None;
            var arity = src.ArityValue();
            if(src.HasVoidReturn())
            {
                if(arity == 0)
                    dst = Arity0;
                else if(arity == 1)
                    dst = Arity1;
            }
            else
            {
                if(arity == 1)
                    dst = Func;
            }
            return dst;
        }

        public Name ActionName {get;}

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
            var result = Outcome.Success;
            try
            {
                switch(ActionKind)
                {
                    case Arity0:
                        Method.Invoke(Host, new object[]{});
                    break;
                    case Arity1:
                        Method.Invoke(Host, new object[1]{args});
                    break;
                    case Func:
                        result = (Outcome)Method.Invoke(Host, new object[1]{args});
                    break;
                    default:
                        result = (false, $"Unsupported {Method}");
                    break;
                }
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }
    }
}