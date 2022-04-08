//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Fail
    {
        public static void eq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} != {b}: [{caller}] {FS.path(file).ToUri().LineRef((uint)line.Value)}");

        public static void eq<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} != {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void nlt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} !< {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void ngt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} !> {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void nlt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} !< {b}: [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void ngt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} !> {b}: [{caller}] {FS.path(file).ToUri()}:{line}");

    }

    public readonly struct Demand
    {
        public static void eq<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IEquatable<T>
        {
            if(!a.Equals(b))
                Fail.eq(a,b,caller,file,line);
        }

        public static void eq<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IEquatable<T>
        {
            if(!a.Equals(b))
                Fail.eq(name, a,b,caller,file,line);
        }

        public static void lt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result >= 0)
                Fail.nlt(a,b,caller,file,line);
        }

        public static void lt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result >= 0)
                Fail.nlt(name,a,b,caller,file,line);
        }

        public static void gt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result <= 0)
                Fail.ngt(a,b,caller,file,line);
        }

        public static void gt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            where T : IComparable<T>
        {
            var result = a.CompareTo(b);
            if(result <= 0)
                Fail.ngt(name,a,b,caller,file,line);
        }
    }
}