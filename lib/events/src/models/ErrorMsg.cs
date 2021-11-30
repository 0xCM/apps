//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    [ApiHost]
    public static class ErrorMsg
    {
        [MethodImpl(Inline), Op]
        public static string FormatCallsite(string caller, string file, int? line)
            => string.Format("{0} {1}:line {2}", caller, file, line);

        [Op]
        public static AppMsg FeatureUnsupported(object feature, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"Unsupported: {feature}", caller, file, line);

        public static AppMsg KindOpUnsupported<S,T>(S src, T dst, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where S : Enum
            where T : Enum
                => Fail($"fail(unsupported): {src} => {dst}", caller, file, line);

        public static AppMsg NotEqual<T>(T a, T b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"Equality fail, {a} != {b}", caller, file, line);

        public static AppMsg neq<T>(T a, T b)
            => AppMsg.colorize($"Equality fail, {a} != {b}", FlairKind.Error);

        public static AppMsg eq<T>(T a,T b)
            => AppMsg.colorize($"Inequality fail, {a} == {b}", FlairKind.Error);

        [Op]
        public static AppMsg NotClose(float a, float b, float err, float tolerance, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(relerr): relerr({a},{b}) = {err} > {tolerance}", caller, file, line) ;

        [Op]
        public static AppMsg NotClose(double a, double b, double err, double tolerance, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(relerr): relerr({a},{b}) = {err} > {tolerance}",  caller, file, line) ;

        [Op]
        public static AppMsg Equal<T>(T a,T b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(neq): {a} == {b}", caller, file, line) ;

        [Op]
        public static AppMsg NotLessThan(object a, object b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(nlt): !({a} < {b})", caller, file, line) ;

        [Op]
        public static AppMsg NotGreaterThan(object a, object b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(ngt): !({a} > {b})", caller, file, line) ;

        [Op]
        public static AppMsg NotGreaterThanOrEqual(object a, object b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(ngteq): !({a} >= {b})", caller, file, line) ;

        [Op]
        public static AppMsg NotLessThanOrEqual(object lhs, object rhs, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(nlteq): !({lhs} <= {rhs})", caller, file, line) ;

        [Op]
        public static AppMsg ItemsNotEqual(int index, object lhs, object rhs, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail(eq): lhs[{index}] = {lhs} != rhs[{index}] = {rhs}", caller, file, line);

        [Op]
        public static AppMsg NotNonzero([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: Value is not nonzero", caller, file, line);

        [Op]
        public static AppMsg NotTrue(string msg, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: {msg ?? "The source value is not true"}", caller, file, line);

        [Op]
        public static AppMsg NotFalse(string msg, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: {msg ?? "The source value is is not false"}", caller, file, line);

        [Op]
        public static AppMsg NotImplemented([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: {"The implementation does not exist"}", caller, file, line);

        [Op]
        public static AppMsg CountMismatch(int lhs, int rhs, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: Count mismatch: {lhs} != {rhs}", caller, file, line);

        [Op]
        public static AppMsg EmptySourceSpan([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: The source span was empty", caller, file, line);

        [Op]
        public static AppMsg NonGenericMethod(MethodInfo t, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"The method {t.Name} is nongeneric", caller, file, line);

        [Op]
        public static AppMsg GenericMethod(MethodInfo t, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"The method {t.Name} is generic", caller, file, line);

        [Op]
        public static AppMsg LengthMismatch(int lhs, int rhs, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"Length mismatch: {lhs} != {rhs}", caller, file, line);

        [Op]
        public static AppMsg InvariantFailure(object description, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail(description?.ToString() ?? "An invariant was unsatisfied", caller, file, line);

        [Op]
        public static AppMsg InvariantFailure([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail(string.Empty, caller, file, line);

        [Op]
        public static AppMsg NotBetween<T>(T x, T lhs, T rhs, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"The source value {x} is not between {lhs} and {rhs}", caller, file, line);

        [Op]
        public static AppMsg IndexOutOfRange(int index, int min, int max, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: The index {index} is not between {min} and {max}", caller, file, line);

        [Op]
        public static AppMsg TooManyBytes(int requested, int available, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: The number of bytes, {requested} exceeds the maximum available, {available}", caller, file, line);

        [Op]
        public static AppMsg FileDoesNotExist(string path, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Fail($"fail: The file {path} does not exist", caller, file, line);

        [Op, MethodImpl(Inline)]
        static AppMsg Fail(string msg, string caller, string file, int? line)
            => AppMsg.define($"{msg}; {FormatCallsite(caller,file,line)}", LogLevel.Error);
    }
}