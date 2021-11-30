//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RP
    {
        [Op]
        public static string digits(byte n)
            => embrace($"0:D{n}");
    }
}