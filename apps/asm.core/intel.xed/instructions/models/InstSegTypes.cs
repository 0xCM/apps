//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class InstSegTypes
        {
            public static InstSegType type(string pattern)
                => new(SegTypeId(pattern));

            public static InstSegType type(char c)
                => new(SegTypeId(c));

            public static InstSegType type(char c0, char c1)
                => new(SegTypeId(new asci8(c0,c1)));

            public static InstSegType type(char c0, char c1, char c2)
                => new(SegTypeId(new asci8(c0, c1, c2)));

            public static InstSegType type(char c0, char c1, char c2, char c3)
                => new(SegTypeId(new asci8(c0, c1, c2, c3)));

            [MethodImpl(Inline), Op]
            public static InstSegType type(byte n, byte value)
                => new InstSegType(n, value);

            [MethodImpl(Inline)]
            public static string pattern(InstSegType src)
            {
                var dst = EmptyString;
                if(src.Id < SegTypeIndex.Count)
                    dst = SegTypeIndex[src.Id].Right;
                return dst;
            }

            static byte SegTypeId(string src)
            {
                var dst = z8;
                SegTypeLookup.Find(src, out dst);
                return dst;
            }

            static byte SegTypeId(char src)
            {
                var dst = z8;
                SegTypeLookup.Find(src.ToLower().ToString(), out dst);
                return dst;
            }

            static readonly Index<Paired<byte,string>> SegTypeIndex;

            static readonly ConstLookup<string,byte> SegTypeLookup;

            static InstSegTypes()
            {
                SegTypeIndex = InstSegLiterals.Index();
                SegTypeLookup = SegTypeIndex.Map(x => (x.Right,x.Left)).ToDictionary();
            }
        }
    }
}