//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static TextLine ReadLine(this StreamReader src, uint number)
            => new TextLine(number, src.ReadLine());

        [Op]
        public static bool ReadLine(this StringReader src, uint number, out TextLine dst)
        {
            var data = src.ReadLine();
            if(data == null)
            {
                dst = TextLine.Empty;
                return false;
            }
            else
            {
                dst = new TextLine(number, data);
                return true;
            }
        }

        public static ReadOnlySpan<TextLine> Lines(this string src, bool keepblank = false, bool trim = true)
            => Z0.Lines.read(src, keepblank, trim);

    }
}