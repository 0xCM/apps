//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct Extension
        {
            public ExtensionKind Value {get;}

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
            public static implicit operator Extension(ExtensionKind src)
                => new Extension(src);

            [MethodImpl(Inline)]
            public static implicit operator ExtensionKind(Extension src)
                => src.Value;
        }
    }
}