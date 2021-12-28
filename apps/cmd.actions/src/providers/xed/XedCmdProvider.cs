//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class XedCmdProvider : AppCmdProvider<XedCmdProvider>
    {
        FS.FilePath XedQueryOut(string id)
            => ProjectDb.Subdir("xed/queries") + FS.file(text.replace(id, Chars.FSlash,Chars.Dot), FS.Csv);

        IntelXed Xed => Service(Wf.IntelXed);

        IntelSdm Sdm => Service(Wf.IntelSdm);
    }
}