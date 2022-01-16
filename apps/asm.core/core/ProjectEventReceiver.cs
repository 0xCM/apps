//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class ProjectEventReceiver
    {
        FileIndex Files;

        Index<AsmCodeIndexRow> _IndexedCode;

        public ReadOnlySpan<AsmCodeIndexRow> IndexedCode
        {
            get => _IndexedCode;
        }


        public ProjectEventReceiver()
        {
            Files = new();
            _IndexedCode = sys.empty<AsmCodeIndexRow>();
        }

        public virtual void Indexed(in FileRef file)
        {

        }

        public virtual void Indexed(in AsmCodeIndexRow dst)
        {

        }

        public virtual void FilesIndexed(FileIndex src)
        {
            Files = src;
        }

        public virtual void Collected(in FileRef src, in ObjDumpRow row)
        {

        }

        public virtual void Collected(in FileRef src, in AsmInstructionRow row)
        {

        }

        public virtual void Collected(in FileRef src, in AsmSyntaxRow row)
        {

        }

        public virtual void Collected(in FileRef src, in AsmEncodingRow row)
        {

        }

        public virtual void Emitted(Index<AsmCodeIndexRow> src, FS.FilePath dst)
        {
            _IndexedCode = src;
        }
    }
}