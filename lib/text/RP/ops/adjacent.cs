//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RP
    {
        [Op]
        public static string adjacent(dynamic a, dynamic b)
            => string.Format(RP.Adjacent2, a, b);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c)
            => string.Format(RP.Adjacent3, a, b, c);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d)
            => string.Format(RP.Adjacent4, a, b, c, d);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e)
            => string.Format(RP.Adjacent5, a, b, c, d, e);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e, dynamic f)
            => string.Format(RP.Adjacent6, a, b, c, d, e, f);
    }
}