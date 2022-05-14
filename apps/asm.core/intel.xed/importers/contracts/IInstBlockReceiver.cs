//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedImport
    {
        [Free]
        public interface IInstBlockReceiver
        {
            void Accept(InstBlock block);

            void Emit();
        }
    }
}