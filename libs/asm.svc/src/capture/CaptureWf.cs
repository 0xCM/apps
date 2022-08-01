//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRepository<K,S,T>
    {
        void Store(S src, T dst);

        S Load(K key);
    }

    public abstract class Repository<K,S,T> : IRepository<K,S,T>
    {
        public abstract void Store(S src, T dst);

        public abstract S Load(K key);
    }

    public class CaptureSettingsStore : Repository<FS.FilePath, CaptureWfSettings, FS.FilePath>
    {
        public override CaptureWfSettings Load(FS.FilePath key)
        {
            throw new NotImplementedException();
        }

        public override void Store(CaptureWfSettings src, FS.FilePath dst)
        {
            
        }
    }

    public class CaptureWf : WfSvc<CaptureWf>
    {
        static CaptureSettingsStore Store = new();

        public static CaptureWfSettings settings()   
            => new();

        public static CaptureWfSettings settings(FS.FilePath src)   
            => Store.Load(src);

        public static void store(CaptureWfSettings src, FS.FilePath dst)
            => Store.Store(src,dst);
    }
}