//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmBlockSpec
    {
        [MethodImpl(Inline)]
        public static AsmBlockSpec define(AsmBlockLabel label)
            => new AsmBlockSpec(AsmComment.Empty, label, TextBlock.Empty);

        [MethodImpl(Inline)]
        public static AsmBlockSpec define(AsmBlockLabel label, TextBlock content)
            => new AsmBlockSpec(AsmComment.Empty, label, content);

        [MethodImpl(Inline)]
        public static AsmBlockSpec define(AsmComment comment, AsmBlockLabel label, TextBlock content)
            => new AsmBlockSpec(comment, label, content);

        public AsmComment Comment {get;}
        public AsmBlockLabel Label {get;}

        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public AsmBlockSpec(AsmComment comment, AsmBlockLabel label, TextBlock content)
        {
            Comment = comment;
            Label = label;
            Content = content;
        }

        public string Format()
        {
            var dst = text.buffer();

            if(Comment.IsNonEmpty)
                dst.AppendLine(Comment.Format());

            if(Label.IsNonEmpty)
                dst.AppendLine(Label);

            if(Content.IsNonEmpty)
                dst.AppendLine(Content);

            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}