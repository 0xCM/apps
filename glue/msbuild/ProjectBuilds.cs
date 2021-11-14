//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    [ApiHost]
    public static class ProjectBuilds
    {
        [Op]
        public static string Format(this BuildProjectCmd src)
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }

        [Op]
        static FS.FilePath ProjectPath(this IEnvPaths src, in BuildCmdVars vars)
            => src.Env.ZDev + FS.folder("src") + FS.folder(vars.ProjectId) + FS.file(string.Format("z0.{0}", vars.ProjectId), FS.CsProj);

        [Op]
        static FS.FilePath SolutionPath(this IEnvPaths src, in BuildCmdVars vars)
            => src.Env.ZDev + FS.file(string.Format("z0.{0}", vars.SlnId), FS.Sln);

        [Op]
        static FS.FilePath LogPath(this IEnvPaths src, in BuildCmdVars vars)
            => src.BuildLogPath(FS.file(string.Format("z0.{0}", vars.ProjectId), FS.Log));

        [Op]
        public static string Identifier(this BuildProjectCmd src)
            => string.Format("{0}_{1}",
                BuildProjectCmd.CmdName,
                src.SolutionPath.IsNonEmpty ? src.SolutionPath.FileName.Format() : src.ProjectPath.FileName.Format());

        [Op]
        public static Outcome<FS.FilePath> Save(this BuildProjectCmd src, FS.FolderPath dst)
        {
            var path = dst + FS.file(src.Identifier(), FS.Cmd);
            var result = path.Save(src.Format());
            if(result)
                return path;
            else
                return result;
        }

        [Op]
        public static BuildProjectCmd Build(this IEnvPaths src, BuildCmdVars vars)
        {
            var dst = new BuildProjectCmd();
            dst.Verbosity = BuildLogVerbosity.detailed;
            dst.Platform = "Any Cpu";
            dst.Configuration = "Release";
            dst.Graph = true;
            dst.MaxCpuCount = 6;
            dst.LogFile = src.LogPath(vars);
            dst.ProjectPath = src.ProjectPath(vars);
            dst.SolutionPath = src.SolutionPath(vars);
            return dst;
        }


        [Op]
        static void render(in BuildProjectCmd src, ITextBuffer dst)
        {
            dst.Append("dotnet build");

            dst.AppendSpace();
            dst.Append(src.SolutionPath.Format(PathSeparator.BS));

            dst.AppendSpace();
            dst.AppendFormat(PropertySpec, nameof(src.Configuration), src.Configuration);

            dst.AppendSpace();
            dst.AppendFormat(QuotedPropertySpec, nameof(src.Platform), src.Platform);

            if(src.LogFile.IsNonEmpty)
            {
                dst.AppendSpace();
                dst.AppendFormat(Flag, "fl");
                dst.AppendSpace();
                dst.AppendFormat(QuotedOptionAssign, "flp", nameof(src.LogFile), src.LogFile.Format(PathSeparator.BS));
                if(src.Verbosity != 0)
                    dst.AppendFormat(";{0}={1} ","verbosity", src.Verbosity);
            }

            if(src.MaxCpuCount != 0)
            {
                dst.AppendSpace();
                dst.AppendFormat(OptionValue, nameof(src.MaxCpuCount), src.MaxCpuCount);
            }

            if(src.Graph)
            {
                dst.AppendSpace();
                dst.AppendFormat(OptionValue, "graph", src.Graph);
            }
        }

        const string PropertySpec = "/p:{0}={1}";

        const string Flag = "-{0}";

        const string OptionValue = "-{0}:{1}";

        const string QuotedOptionAssign ="-{0}:{1}=" + RP.QuotedSlot2;

        const string QuotedPropertySpec = "/p:{0}=" + RP.QuotedSlot1;
    }
}