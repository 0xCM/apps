//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class AsmDocument
    {
        Index<AsmDirective> _Directives;

        Index<AsmBlockLabel> _BlockLabels;

        Index<LineNumber> _BlockOffsets;

        Index<AsmSourceLine> _SourceLines;

        internal AsmDocument(AsmDirective[] d, AsmBlockLabel[] b, LineNumber[] l, AsmSourceLine[] s)
        {
            _Directives = d;
            _BlockLabels = b;
            _BlockOffsets = l;
            _SourceLines = s;
        }

        public ReadOnlySpan<AsmDirective> Directives
        {
            [MethodImpl(Inline)]
            get => _Directives.View;
        }

        public ReadOnlySpan<AsmBlockLabel> BlockLabels
        {
            [MethodImpl(Inline)]
            get => _BlockLabels.View;
        }

        public ReadOnlySpan<LineNumber> BlockOffsets
        {
            [MethodImpl(Inline)]
            get => _BlockOffsets.View;
        }

        public ReadOnlySpan<AsmSourceLine> SourceLines
        {
            [MethodImpl(Inline)]
            get => _SourceLines.View;
        }
    }
}