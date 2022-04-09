//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct SegSpecLiterals
        {
            const string sep = "_";

            const string over = "/";

            public const string n0 = "0";

            public const string n1 = "1";

            public const string n8 = "8";

            public const string n16 = "16";

            public const string n32 = "32";

            public const string n64 = "64";

            public const string a = nameof(a);

            public const string aaa = a + a + a;

            public const string b = nameof(b);

            public const string bbb = b + b + b;

            public const string d = nameof(d);

            public const string dd = d + d;

            public const string ddd = dd + d;

            public const string dddd = dd + dd;

            public const string i = nameof(i);

            public const string n = nameof(n);

            public const string nn = n + n;

            public const string r = nameof(r);

            public const string s = nameof(s);

            public const string u = nameof(u);

            public const string w = nameof(w);

            public const string x = nameof(x);

            public const string z = nameof(z);

            public const string d8 = d + over + n8;

            public const string d16 = d + over + n16;

            public const string d32 = d + over + n32;

            public const string d64 = d + over + n64;

            public const string a8 = a + over + n8;

            public const string a16 = a + over + n16;

            public const string a32 = a + over + n32;

            public const string a64 = a + over + n64;

            public const string iii = i + i + i;

            public const string i8 = i + over + n8;

            public const string i16 = i + over + n16;

            public const string i32 = i + over + n32;

            public const string i64 = i + over + n64;

            public const string ss = s + s;

            public const string ssss = ss + ss;

            public const string ssss_dddd = ssss + sep + dddd;

            public const string ss_iii_bbb = ss + iii + bbb;

            public const string u_dddd = u + ddd;

            public const string z_nn_b = z + nn + b;
        }
    }
}