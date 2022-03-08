//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataType(XedNames.extension)]
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