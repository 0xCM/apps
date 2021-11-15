//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class ClrEnumSouce : SourceText<ClrEnumSouce>
    {
        public ClrEnumSouce(TextBlock src)
            : base(src)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumSouce(string src)
            => new ClrEnumSouce(src);
    }
}