//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    partial class text
    {
        /// <summary>
        /// Returns the text left of, but not including, a specified index; or empty if invalid index is provided
        /// </summary>
        /// <param name="src"></param>
        /// <param name="index"></param>
        [Op]
        public static string left(string src, int index)
        {
            if(empty(src) || index < 0)
                return EmptyString;

            var length = src.Length;
            if(length == 0)
                return EmptyString;

            if(index > length - 1)
                return EmptyString;

            return slice(src, 0, index);
        }

        [Op]
        public static string left(string src, char c)
        {
            var i = index(src,c);
            if(i>0)
                return left(src,i);
            else
                return EmptyString;
        }
    }
}