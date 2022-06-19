//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    partial struct FS
    {
        public static ITextEmitter emitter(FS.FilePath dst, FileWriteMode mode, TextEncodingKind encoding)
            => writer(dst,mode,encoding).Emitter();

        public static ITextEmitter emitter(FS.FilePath dst, TextEncodingKind encoding)
            => writer(dst, encoding).Emitter();

        public static ITextEmitter emitter(FS.FilePath dst, FileWriteMode mode, Encoding encoding)
            => writer(dst,mode,encoding).Emitter();
    }
}