//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public static class Unsupported
    {
        /// <summary>
        /// Populates a <see cref="NotSupportedException"/> complaining that a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static NotSupportedException define<T>([Caller] string caller = null, [File]string file = null, [Line] int? line = null)
            => define($"The type {typeof(T).Name}, it is a mystery", caller, file, line);

        /// <summary>
        /// Populates a <see cref="NotSupportedException"/>, populated with a custom message describing why a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static NotSupportedException define<T>(string description, [Caller] string caller = null, [File]string file = null, [Line] int? line = null)
            => define(description, caller, file, line);

        /// <summary>
        /// Populates a <see cref="NotSupportedException"/> complaining that a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static NotSupportedException define(Type t, [Caller] string caller = null, [File]string file = null, [Line] int? line = null)
            => define($"The type {t}, it is a mystery", caller, file, line);

        /// <summary>
        /// Defines a <see cref="NotSupportedException"/> with a message complaining that a value is not supported
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        public static NotSupportedException value(object src, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => define($"The value {src}, it is bad", caller, file, line);

        /// <summary>
        /// Raises <see cref="NotSupportedException"/> complaining that a
        /// parametrically-identified type is not supported
        /// </summary>
        /// <typeparam name="T">The unsupported type</typeparam>
        public static T raise<T>([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => throw define($"The type {typeof(T).Name} it is a mystery", caller, file, line);

        public static T raise<S,T>([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => throw define($"The transformation {typeof(S).Name} -> {typeof(T).Name} is undefined", caller, file, line);

        public static ArgumentException badarg<T>(T arg)
            => new ArgumentException(arg?.ToString() ?? "<null>");

        [Op]
        public static Exception DuplicateKeyException(IEnumerable<object> keys, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => new Exception(string.Concat($"Duplicate keys were detected {string.Join(Chars.Comma, keys)}",  caller,file, line));
        static NotSupportedException define(string msg, string caller, string file, int? line)
            => new NotSupportedException(string.Format("{0}; caller:{1}; line:{2}; file:{3}", msg, caller, line, file));
    }
}