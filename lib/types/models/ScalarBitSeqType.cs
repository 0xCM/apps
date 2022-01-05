//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    public class ScalarBitSeqType : ScalarType
    {
        [MethodImpl(Inline)]
        public ScalarBitSeqType(uint content, NativeSize storage)
            : base(EmptyString, ScalarClass.U, content, storage)
        {
            NativeWidth = storage;
        }

        public NativeSize NativeWidth {get;}

        public TypeSpec Specifier => TypeSyntax.bits(ContentWidth, TypeSyntax.native(NativeWidth, false));

        public override Identifier Name
             => Specifier.Format();
    }
}