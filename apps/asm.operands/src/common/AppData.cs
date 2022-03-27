//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppData
    {
        [MethodImpl(Inline)]
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
                Instance._PllExec = true;
            }
        }

        public DevWs DevWs => _DevWs;

        public IProjectDb ProjectDb => _Db;

        [MethodImpl(Inline)]
        public bool PllExec() => _PllExec;

        [MethodImpl(Inline)]
        public void PllExec(bool pll)
        {
            _PllExec = pll;
        }

        bool _PllExec;

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