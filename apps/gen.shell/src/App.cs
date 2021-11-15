//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    sealed class GenX : AppService<GenX>
    {
        public void Generate(string[] args)
        {
            // var flow = Wf.Running("Generating");
            // var bitfields = Wf.BitfieldGenerator();
            // var specs = bitfields.LoadSpecs();

            //  Wf.Ran(flow);
        }
    }

    class App
    {

        public static void Main(params string[] args)
        {
            try
            {
                using var wf = WfAppLoader.load(args);
                GenX.create(wf).Generate(args);
            }
            catch(Exception e)
            {
                term.error(e);
            }
        }
    }
}