//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RenderFence
    {
        public static RenderFence Embraced => (Chars.LBrace, Chars.RBrace);

        public static RenderFence Bracketed => (Chars.LBracket, Chars.RBracket);

        public static RenderFence Angled => (Chars.Lt, Chars.Gt);

        public static RenderFence Dirac => ((char)MathSym.LeftBra, (char)MathSym.RightKet);

        public static RenderFence Paren => (Chars.LParen, Chars.RParen);

        public static RenderFence SQuote => (Chars.SQuote, Chars.SQuote);

        [MethodImpl(Inline)]
        public static Fence<T> define<T>(T left, T right)
            => (left,right);

        readonly Fence<char> Fence;

        [MethodImpl(Inline)]
        public RenderFence(Fence<char> src)
        {
            Fence = src;
        }

        [MethodImpl(Inline)]
        public RenderFence(char left, char right)
        {
            Fence = (left,right);
        }

        public char Left
        {
            [MethodImpl(Inline)]
            get => Fence.Left;
        }

        public char Right
        {
            [MethodImpl(Inline)]
            get => Fence.Right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left == 0 || Right == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Left != 0 && Right != 0;
        }

        public static RenderFence Empty => ((char)0, (char)0);

        // public enum FenceKind : byte
        // {
        //     None,

        //     Embraced,

        //     Bracketed,

        //     Angled
        // }


        [MethodImpl(Inline)]
        public static implicit operator RenderFence(Fence<char> src)
            => new RenderFence(src);

        [MethodImpl(Inline)]
        public static implicit operator RenderFence((char left, char right) src)
            => new RenderFence(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator Fence<char>(RenderFence src)
            => src.Fence;

        [MethodImpl(Inline)]
        public static Fence<char> define(char left, char right)
            => (left,right);
    }
}