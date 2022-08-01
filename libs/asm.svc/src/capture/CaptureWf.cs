//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CaptureWf : WfSvc<CaptureWf>
    {
        public class SettingsStore : Repository<FS.FilePath, CaptureWfSettings, FS.FilePath>
        {
            public override CaptureWfSettings Load(FS.FilePath key)
            {
                throw new NotImplementedException();
            }

            public override void Store(CaptureWfSettings src, FS.FilePath dst)
            {
                
            }
        }

        static SettingsStore Store = new();

        public static CaptureWfSettings settings()   
            => new();

        public static CaptureWfSettings settings(FS.FilePath src)   
            => Store.Load(src);

        public static void store(CaptureWfSettings src, FS.FilePath dst)
            => Store.Store(src,dst);
    }
}