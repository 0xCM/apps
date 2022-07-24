//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppData
    {
        [MethodImpl(Inline)]
        public static AppData get() => Instance;

        [MethodImpl(Inline)]
        public bool PllExec() => _PllExec;

        bool _PllExec;

        AppData()
        {
        }

        static AppData()
        {
            var dst = new AppData();
            dst._PllExec = true;
            Instance = dst;
        }

        static AppData Instance;
    }
}