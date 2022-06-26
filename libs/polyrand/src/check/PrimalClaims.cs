//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ErrorMsg;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;
    using api = ClaimValidator;

    [ApiHost]
    public readonly struct PrimalClaims
    {
        [Op]
        public static bool require(bool src, string msg = null, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => !src ? @throw<bool>(ClaimException.define(ClaimKind.Invariant,NotTrue(msg, caller, file,line).Format())) : true;

        [Op]
        public static bool eq(char a, char b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(string a, string b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => string.Equals(a,b) ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(byte a, byte b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));

        [Op]
        public static bool eq(sbyte a, sbyte b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));

        [Op]
        public static bool eq(short a, short b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(ushort a, ushort b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(int a, int b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(uint a, uint b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(long a, long b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));

        [Op]
        public static bool eq(ulong a, ulong b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(bool a, bool b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool eq(bit a, bit b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a == b ? true : @throw<bool>(Failed(ClaimKind.Eq, NotEqual(a, b, caller, file, line)));

        [Op]
        public static bool neq(bit a, bit b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.Eq, Equal(a, b, caller, file, line)));

        [Op]
        public static bool neq(char a, char b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.NEq, Equal(a, b, caller, file, line)));

        [Op]
        public static bool neq(string a, string b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.NEq, Equal(a, b, caller, file, line)));

        [Op]
        public static bool neq(long a, long b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => a != b ? true : @throw<bool>(Failed(ClaimKind.NEq, Equal(a, b, caller, file, line)));

        [Op]
        static ClaimException Failed(ClaimKind claim, IAppMsg msg)
            => api.failed(claim, msg);
    }
}