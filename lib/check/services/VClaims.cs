//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static ErrorMsg;
    using static ClaimValidator;
    using static Root;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    [ApiHost]
    public readonly struct VClaims
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Asserts the equality of two vectors
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        [Op,Closures(Closure)]
        public void veq<T>(Vector128<T> a, Vector128<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                sys.@throw(failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));
        }

        /// <summary>
        /// Asserts the equality of two vectors
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        /// <param name="caller">The caller member name</param>
        /// <param name="file">The source file of the calling function</param>
        /// <param name="line">The source file line number where invocation ocurred</param>
        [Op,Closures(Closure)]
        public void veq<T>(Vector256<T> a, Vector256<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                sys.@throw(failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));
        }

        [Op,Closures(Closure)]
        public void veq<T>(Vector512<T> a, Vector512<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                sys.@throw(failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));
        }

        [Op,Closures(Closure)]
        public void vneq<T>(Vector128<T> a, Vector128<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                sys.@throw(failed(ClaimKind.NEq, Equal(a,b, caller, file, line)));
        }

        [Op,Closures(Closure)]
        public void vneq<T>(Vector256<T> a, Vector256<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                sys.@throw(failed(ClaimKind.NEq, Equal(a,b, caller, file, line)));
        }

        [Op,Closures(Closure)]
        public void vneq<T>(Vector512<T> a, Vector512<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                sys.@throw(failed(ClaimKind.NEq, Equal(a,b, caller, file, line)));
        }
    }
}