//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline)]
        public static AsmBlockSpec block(AsmBlockLabel label)
            => new AsmBlockSpec(AsmComment.Empty, label, TextBlock.Empty);

        [MethodImpl(Inline)]
        public static AsmBlockSpec block(AsmBlockLabel label, TextBlock content)
            => new AsmBlockSpec(AsmComment.Empty, label, content);

        [MethodImpl(Inline)]
        public static AsmBlockSpec block(AsmComment comment, AsmBlockLabel label, TextBlock content)
            => new AsmBlockSpec(comment, label, content);
    }
}