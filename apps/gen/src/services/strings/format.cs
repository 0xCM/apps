//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringTables
    {
        public static string format(in StringTable src, uint margin = 0)
        {
            var dst = text.buffer();
            render(margin, src, dst);
            return dst.Emit();
        }
    }
}