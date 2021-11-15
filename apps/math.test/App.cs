//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MathTestApp : TestApp<MathTestApp>
    {
        static PartId[] Parts => core.array(PartId.Calc, PartId.Math, PartId.GMath);

        static void Main(params string[] args)
            => Run(Parts, args);
    }
}
