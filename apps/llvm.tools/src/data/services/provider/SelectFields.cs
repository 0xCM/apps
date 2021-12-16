//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        Index<RecordField> SelectEmittedFields(string dsid)
            => (Index<RecordField>)DataSets.GetOrAdd(dsid + ".fields", key => DataLoader.LoadFields(dsid));
    }
}