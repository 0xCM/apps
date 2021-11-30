//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        [Op]
        public static string delimit(N2 n, string sep)
            => "{0}" + sep + "{1}";

        [Op]
        public static string delimit(N3 n, string sep)
            => "{0}" + sep + "{1}" + sep + "{2}";

        [Op]
        public static string delimit(N4 n, string sep)
            => "{0}" + sep + "{1}" + sep + "{2}" + sep + "{3}";

        [Op]
        public static string delimit(N5 n, string sep)
            => "{0}" + sep + "{1}" + sep + "{2}" + sep + "{3}" + sep + "{4}";
    }
}