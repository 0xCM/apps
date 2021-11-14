//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    sealed class Machine : WfApp<Machine>
    {
        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load();
            using var shell = create(wf);
            shell.Run();
        }

        CmdImplMap<string> CommandMap;

        void Push(object content)
        {
            term.cyan(string.Format(">>   {0}", content));
        }

        bool Pull(out MethodInfo method)
        {
            var input = term.prompt("cmd> ");
            if(CommandMap.Find(input, out method))
            {
                return true;
            }
            else
            {
                Push(string.Format("The command {0} is not recognized", input));
                return false;
            }
        }

        protected override void Initialized()
        {
            CommandMap = Cmd.implmap(Wf.Components);
        }

        protected override void Run()
        {
            try
            {
                while(true)
                {
                    if(Pull(out var method))
                    {

                    }
                }
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }
    }

    public static partial class XTend {}
}