//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    sealed class Machine : WfApp<Machine>
    {
        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load();
            using var shell = create(wf);
            shell.Run();
        }

        void Push(object content)
        {
            term.cyan(string.Format(">>   {0}", content));
        }


        protected override void Run()
        {
            try
            {
                while(true)
                {

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