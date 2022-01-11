//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    public class FileData<T> : Dictionary<FS.FilePath, T>
    {
        public FileData()
        {

        }
    }

    public class HexFileData : Dictionary<FS.FilePath,Index<HexDataRow>>
    {
        readonly Index<HexFileStats> _Stats;

        public HexFileData(Index<HexFileStats> stats)
        {
            _Stats = stats;
        }

        public ReadOnlySpan<HexFileStats> Stats
        {
            get => _Stats;
        }
    }
}