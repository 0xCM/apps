//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static uint crlf(ref uint i, Span<char> dst)
        {
            var i0 = i;
            core.seek(dst,i++) = (char)AsciControlSym.CR;
            core.seek(dst,i++) = (char)AsciControlSym.LF;
            return i - i0;
        }
    }
}