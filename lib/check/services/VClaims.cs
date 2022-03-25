//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ErrorMsg;
    using static ClaimValidator;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    [ApiHost]
    public readonly struct VClaim
    {
        const NumericKind Closure = UnsignedInts;

        [Op,Closures(Closure),MethodImpl(Inline)]
        public static void veq<T>(Vector128<T> a, Vector128<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                sys.@throw(failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));
        }

        [Op,Closures(Closure),MethodImpl(Inline)]
        public static void veq<T>(Vector256<T> a, Vector256<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                sys.@throw(failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));
        }

        [Op,Closures(Closure),MethodImpl(Inline)]
        public static void veq<T>(Vector512<T> a, Vector512<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(!a.Equals(b))
                sys.@throw(failed(ClaimKind.Eq, NotEqual(a,b, caller, file, line)));
        }

        [Op,Closures(Closure),MethodImpl(Inline)]
        public static void vneq<T>(Vector128<T> a, Vector128<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                sys.@throw(failed(ClaimKind.NEq, Equal(a,b, caller, file, line)));
        }

        [Op,Closures(Closure),MethodImpl(Inline)]
        public static void vneq<T>(Vector256<T> a, Vector256<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                sys.@throw(failed(ClaimKind.NEq, Equal(a,b, caller, file, line)));
        }

        [Op,Closures(Closure),MethodImpl(Inline)]
        public static void vneq<T>(Vector512<T> a, Vector512<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
        {
            if(a.Equals(b))
                sys.@throw(failed(ClaimKind.NEq, Equal(a,b, caller, file, line)));
        }
    }

    public readonly struct VClaims
    {
        const NumericKind Closure = UnsignedInts;

        [Op,Closures(Closure)]
        public void veq<T>(Vector128<T> a, Vector128<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => VClaim.veq(a,b,caller,file,line);

        [Op,Closures(Closure)]
        public void veq<T>(Vector256<T> a, Vector256<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => VClaim.veq(a,b,caller,file,line);

        [Op,Closures(Closure)]
        public void veq<T>(Vector512<T> a, Vector512<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => VClaim.veq(a,b,caller,file,line);

        [Op,Closures(Closure)]
        public void vneq<T>(Vector128<T> a, Vector128<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => VClaim.vneq(a,b,caller,file,line);

        [Op,Closures(Closure)]
        public void vneq<T>(Vector256<T> a, Vector256<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => VClaim.vneq(a,b,caller,file,line);

        [Op,Closures(Closure)]
        public void vneq<T>(Vector512<T> a, Vector512<T> b, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => VClaim.vneq(a,b,caller,file,line);
    }
}