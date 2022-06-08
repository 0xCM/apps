//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppData
    {
        public static ref readonly EnvData AppEnv => ref Instance._AppEnv;

        /// <summary>
        /// $(DvWs)/projects
        /// </summary>
        public static ref readonly DbTargets Projects => ref Instance._Projects;

        /// <summary>
        /// $(DvWs)/projects/db
        /// </summary>
        public static ref readonly DbTargets ProjectDb => ref Instance._ProjectDb;

        /// <summary>
        /// $(DvWs)/projects/db/projects/<paramref name='id'/>
        /// </summary>
        /// <param name="id">The project name</param>
        public static DbTargets ProjectData(ProjectId id)
            => new DbTargets(ProjectDb.Targets("projects"), id);

        public static DbTargets ProjectTargets(ProjectId id)
            => ProjectDb.Targets(id);

        public static DbSources ProjectSources(ProjectId id)
            => DataSources.Sources(id);

        /// <summary>
        /// $(DevWs)/projects/db/sources
        /// </summary>
        public static ref readonly DbSources DataSources => ref Instance._DataSources;

        /// <summary>
        /// $(DevWs)/control
        /// </summary>
        public static ref readonly DbSources Control => ref Instance._Control;

        /// <summary>
        /// $(DevWs)/control/.cmd
        /// </summary>
        public static ref readonly DbSources ControlCmd => ref Instance._ControlCmd;

        /// <summary>
        /// $(ZDev)/codegen
        /// </summary>
        public static ref readonly DbTargets CgProjects => ref Instance._CgProjects;

        /// <summary>
        /// $(ZDev)/libs
        /// </summary>
        public static ref readonly DbTargets LibProjects => ref Instance._LibProjects;

        public static ref readonly DbSources ToolBase => ref Instance._Toolbase;

        public static ref readonly DbTargets ApiTargets => ref Instance._ApiTargets;

        [MethodImpl(Inline)]
        public static AppData get() => Instance;

        [MethodImpl(Inline)]
        public bool PllExec() => _PllExec;

        bool _PllExec;

        EnvData _AppEnv;

        DbTargets _ProjectData;

        DbTargets _ProjectDb;

        DbTargets _Projects;

        DbTargets _CgProjects;

        DbTargets _LibProjects;

        DbTargets _ApiTargets;

        DbSources _Control;

        DbSources _ControlCmd;

        DbSources _DataSources;

        DbSources _Toolbase;

        AppData()
        {
        }

        static AppData()
        {
            var env = EnvData.load();
            var dst = new AppData();
            dst._AppEnv = env;
            dst._PllExec = true;
            dst._Projects = new DbTargets(env.DevWs, "projects");
            dst._ProjectDb = new DbTargets(env.DevWs, "projects/db");
            dst._ProjectData = new DbTargets(env.DevWs, "projects/db/projects");
            dst._CgProjects = new DbTargets(env.ZDev,"codegen");
            dst._LibProjects = new DbTargets(env.ZDev, "libs");
            dst._ApiTargets = dst._ProjectDb.Targets("api");
            dst._Control = new DbSources(env.Control);
            dst._ControlCmd = new DbSources(env.Control, ".cmd");
            dst._DataSources = new DbSources(env.DevWs, "projects/db/sources");
            dst._Toolbase = new DbSources(env.Toolbase);
            Instance = dst;
        }

        static AppData Instance;
    }
}