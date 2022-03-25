//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppData
    {
        public static AppData get()
            => Instance;

        public static void init()
        {
            if(Instance.IsEmpty)
            {
                var env = Env.load();
                var ws = DevWs.create(env.DevWs);
                Instance._Env = env;
                Instance._EnvData = env.Data;
                Instance._DevWs = ws;
                Instance._Db = ws.ProjectDb();
            }
        }

        public DevWs DevWs => _DevWs;

        public IProjectDb ProjectDb => _Db;

        AppData()
        {
        }

        Env _Env;

        EnvData _EnvData;

        DevWs _DevWs;

        IProjectDb _Db;

        static AppData()
        {


        }

        bool IsEmpty
        {
            get => _Db == null;
        }

        static AppData Instance = new();
    }
}