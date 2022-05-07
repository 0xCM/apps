//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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

        public static void gt<T>(T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{a} > {b}: [{caller}] {FS.path(file).ToUri()}:{line}");

        public static void gt<T>(string name, T a, T b, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Errors.Throw($"{name}({a} > {b}): [{caller}] {FS.path(file).ToUri()}:{line}");

    }
}