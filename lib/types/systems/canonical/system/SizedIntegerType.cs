//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Describes sized integer types of a given bit-width
    /// </summary>
    public class SizedIntegerType : ScalarType
    {
        public bool Signed {get;}

        [MethodImpl(Inline)]
        public SizedIntegerType(Identifier name, BitWidth content, BitWidth storage, bool signed)
            : base(name, signed ? ScalarClass.I : ScalarClass.U, content,storage)
        {

        }

        public override string Format()
        {
            var prefix = Signed ? Chars.i : Chars.u;
            return string.Format("{0}{1}", prefix, (uint)ContentWidth);
        }
    }
}