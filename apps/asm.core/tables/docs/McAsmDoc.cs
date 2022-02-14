//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    /// <summary>
    /// Represents an asm source document
    /// </summary>
    public class McAsmDoc
    {
        public FS.FilePath Path {get;}

        Index<AsmDirective> _Directives;

        Index<AsmBlockLabel> _BlockLabels;

        Index<LineNumber> _BlockOffsets;

        Index<AsmSourceLine> _SourceLines;

        Index<AsmInstRef> _Instructions;

        public McAsmDoc(in FileRef fref, AsmDirective[] d, AsmBlockLabel[] b, LineNumber[] l, AsmSourceLine[] s, AsmInstRef[] inst)
        {
            Path = fref.Path;
            _Directives = d;
            _BlockLabels = b;
            _BlockOffsets = l;
            _SourceLines = s;
            _Instructions = inst;
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

        public ReadOnlySpan<AsmInstRef> Instructions
        {
            [MethodImpl(Inline)]
            get => _Instructions.View;
        }
    }
}