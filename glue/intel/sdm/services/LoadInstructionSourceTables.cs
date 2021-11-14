//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    partial class IntelSdm
    {
        public ReadOnlySpan<Table> LoadInstructionSourceTables()
            => LoadCsvTables((SdmPaths.Sources() + FS.folder("sdm.instructions")).Files(FS.Csv).ToReadOnlySpan());

    }
}