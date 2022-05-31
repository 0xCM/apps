//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XTend
    {
    }

    public static class XSvc
    {

        sealed class Svc : AppServices<Svc>
        {

        }

        static Svc Services => Svc.Instance;

    }
}