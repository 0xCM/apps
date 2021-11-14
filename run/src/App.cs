//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class App
    {
        public static void Main(params string[] args)
        {
            if(args.Length != 0)
            {
                term.inform(string.Format("Received:[{0}]", args.Delimit()));

                GlobalDispatcher.dispatch(args);
            }
            else
                term.inform("Nothing to do");
        }
    }
}