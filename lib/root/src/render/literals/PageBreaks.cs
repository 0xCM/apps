//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RP
    {
        [RenderLiteral(PageBreak4, 2)]
        public const string PageBreak2 = Dash2;

        [RenderLiteral(PageBreak4, 4)]
        public const string PageBreak4 = Dash4;

        [RenderLiteral(PageBreak5, 5)]
        public const string PageBreak5 = Dash5;

        [RenderLiteral(PageBreak6, 6)]
        public const string PageBreak6 = PageBreak4 + PageBreak2;

        [RenderLiteral(PageBreak10, 10)]
        public const string PageBreak10 = PageBreak5 + PageBreak5;

        [RenderLiteral(PageBreak20, 20)]
        public const string PageBreak20 = PageBreak10 + PageBreak10;

        [RenderLiteral(PageBreak24, 24)]
        public const string PageBreak24 = PageBreak20 + PageBreak4;

        [RenderLiteral(PageBreak30, 30)]
        public const string PageBreak30 = PageBreak24 + PageBreak6;

        [RenderLiteral(PageBreak32, 32)]
        public const string PageBreak32 = PageBreak30 + PageBreak2;

        [RenderLiteral(PageBreak40)]
        public const string PageBreak40 = PageBreak20 + PageBreak20;

        [RenderLiteral(PageBreak80, 80)]
        public const string PageBreak80 = PageBreak40 + PageBreak40;

        [RenderLiteral(PageBreak120, 120)]
        public const string PageBreak120 = PageBreak80 + PageBreak40;

        [RenderLiteral(PageBreak160, 160)]
        public const string PageBreak160 = PageBreak80 + PageBreak80;

        [RenderLiteral(PageBreak240, 240)]
        public const string PageBreak240 = PageBreak120 + PageBreak120;
    }
}