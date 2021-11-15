//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RenderFence
    {
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
            get => Fence.Left;
        }

        public enum FenceKind : byte
        {
            None,

            Embraced,

            Bracketed,

            Angled
        }


        [MethodImpl(Inline)]
        public static implicit operator RenderFence(Fence<char> src)
            => new RenderFence(src);

        [MethodImpl(Inline)]
        public static implicit operator RenderFence((char left, char right) src)
            => new RenderFence(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator Fence<char>(RenderFence src)
            => src.Fence;

        public static RenderFence Embraced => (Chars.LBrace, Chars.RBrace);

        public static RenderFence Bracketed => (Chars.LBracket, Chars.RBracket);

        public static RenderFence Angled => (Chars.Lt, Chars.Gt);

        [MethodImpl(Inline)]
        public static Fence<char> define(char left, char right)
            => (left,right);
    }
}