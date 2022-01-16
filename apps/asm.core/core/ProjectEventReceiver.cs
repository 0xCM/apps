//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IProjectEventReceiver
    {
        void Consolidated(in FileRef file, in ObjDumpRow row);

        void Correlated(in AsmEncodingRow enc, in AsmSyntaxRow syn, in AsmInstructionRow inst, in AsmDocCorrelation result);

        void FileIndexed(in FileRef file);

        void FilesIndexed(FileIndex src);

        void CodeIndexed(in AsmCodeIndexRow dst);
    }

    public class ProjectEventReceiver : IProjectEventReceiver
    {
        FileIndex Files;

        public ProjectEventReceiver()
        {
            Files = new();
        }

        public virtual void FileIndexed(in FileRef file)
        {

        }

        public virtual void CodeIndexed(in AsmCodeIndexRow dst)
        {

        }

        public virtual void FilesIndexed(FileIndex src)
        {
            Files = src;
        }

        public virtual void Consolidated(in FileRef file, in ObjDumpRow row)
        {

        }

        public virtual void Correlated(in AsmEncodingRow enc, in AsmSyntaxRow syn, in AsmInstructionRow inst, in AsmDocCorrelation result)
        {

        }
    }
}