//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-Extension-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        [DataType(Names.extension)]
        public struct Extension : IEnumCover<ExtensionKind>
        {
            public ExtensionKind Value {get;set;}

            [MethodImpl(Inline)]
            public Extension(ExtensionKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Symbols.format(Value) : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Extension(EnumCover<ExtensionKind> src)
                => new Extension(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator Extension(ExtensionKind src)
                => new Extension(src);

            [MethodImpl(Inline)]
            public static implicit operator ExtensionKind(Extension src)
                => src.Value;
        }
    }
}