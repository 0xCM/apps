//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringTables
    {
        public static string format(uint margin, in StringTable src)
        {
            var dst = text.buffer();
            render(margin, src, dst);
            return dst.Emit();
        }
    }
}