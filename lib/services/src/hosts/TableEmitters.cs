//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class TableEmitters : AppService<TableEmitters>
    {
        public FS.FilePath Emit(ReadOnlySpan<CompilationLiteral> src, FS.FolderPath dst)
            => Emit(src, CompilationLiteral.RenderWidths, dst);

        public FS.FilePath Emit<T>(ReadOnlySpan<T> src, FS.FolderPath dst)
            where T : struct
        {
            var path = dst + Tables.filename<T>();
            TableEmit(src, path);
            return path;
        }

        public FS.FilePath Emit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FolderPath dst)
            where T : struct
        {
            var path = dst + Tables.filename<T>();
            TableEmit(src, widths, path);
            return path;
        }
    }
}