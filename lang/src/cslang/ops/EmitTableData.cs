//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CsLang
    {
        void EmitTableData(StringTable src, FS.FilePath dst)
            => AppSvc.TableEmit(src.Rows, dst);

        void EmitTableData<K>(SymTableSpec<K> src, FS.FilePath dst)
            where K : unmanaged
                => AppSvc.TableEmit(src.Rows, dst);
    }
}