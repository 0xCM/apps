//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Fail
    {
        public static void Equality<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} != {b}: [{caller}] {FS.path(file).ToUri().LineRef((uint)line.Value)}");

        public static void Equality<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} != {b}): [{caller}] {FS.path(file).ToUri()}:{line}");
    }

    public readonly struct Demand
    {
        public static void Equality<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IEquatable<T>
        {
            if(!a.Equals(b))
                Fail.Equality(a,b,caller,file,line);
        }

        public static void Equality<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IEquatable<T>
        {
            if(!a.Equals(b))
                Fail.Equality(name, a,b,caller,file,line);
        }
    }
}