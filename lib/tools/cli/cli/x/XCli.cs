//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;

    public static partial class XCli
    {
        [MethodImpl(Inline)]
        public static CliHandleData Data(this Handle src)
            => CliHandleData.from(src);

        [MethodImpl(Inline)]
        public static bool IsValid(this CliTableKind src)
            => src != CliTableKind.Invalid;

        [MethodImpl(Inline)]
        public static void IfValid(this CliTableKind src, Action f)
        {
            if(src.IsValid())
                f();
        }

        [MethodImpl(Inline)]
        public static T MapValid<S,T>(this CliTableKind src, S input, Func<S,T> f, Func<T> @else)
            => src.IsValid() ? f(input) : @else();

    }
}