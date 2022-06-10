//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static WsAtoms;

    [ApiHost]
    public class Tooling : AppService<Tooling>
    {
        const NumericKind Closure = UnsignedInts;

        const byte FieldCount = ToolProfile.FieldCount;

        IToolWs ToolWs => new ToolWs(AppData.ToolBase);

        public static IToolWs configure(IToolWs ws)
        {
            var subdirs = ws.Root.SubDirs();
            var counter = 0u;
            var dst = ws.Inventory();
            var configs = list<ToolConfig>();
            foreach(var dir in subdirs)
            {
                var configCmd = dir + FS.file(config, FS.Cmd);
                if(configCmd.Exists)
                {
                    var src =  dir + FS.folder(logs) + FS.file(config, FS.Log);
                    if(src.Exists)
                    {
                        var result = parse(src.ReadText(), out ToolConfig c);
                        if(result)
                            configs.Add(c);
                    }
                }
            }
            return ws.Configure(configs.ToArray());
        }

        [Op]
        public static Outcome parse(string src, out ToolConfig dst)
            => ToolConfig.parse(src, out dst);

        [Op]
        public static ToolCmdSpec spec(FS.FilePath path, params ToolCmdArg[] args)
        {
            var dst = new ToolCmdSpec();
            dst.ToolPath = path;
            dst.Args = args.Select(x => x.Format());
            return dst;
        }

        public Settings LoadSettings()
        {
            var path = ToolWs.Toolbase.Path(FS.file("env", FS.Settings));
            return AppSettings.Load(path.ReadNumberedLines());
        }

        public void EmitEnvIncldes()
        {
            var result = Outcome.Success;
            var settings = LoadSettings();
            var env = ToolEnv.load(settings);
            var dst = ProjectDb.Log("env", FS.Log);
            var emitting = EmittingFile(dst);

            using var writer = dst.AsciWriter();
            var headers = env.HeaderIncludes();
            writer.WriteLine("Header Includes");
            writer.WriteLine(RP.PageBreak120);
            iter(headers, h => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Header", h.Exists ? "Found" : "Mising", h)));
            writer.WriteLine();

            var libs = env.LibIncludes();
            writer.WriteLine("Lib Includes");
            writer.WriteLine(RP.PageBreak120);
            iter(libs, lib => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Lib", lib.Exists ? "Found" : "Mising", lib)));

            EmittedFile(emitting, 2);
        }

        public Outcome EmitToolCatalog()
        {
            var subdirs = ToolWs.Root.SubDirs();
            var counter = 0u;
            var formatter = Tables.formatter<ToolConfig>(16,RecordFormatKind.KeyValuePairs);
            var dst = ToolWs.Inventory();
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            foreach(var dir in subdirs)
            {
                var configCmd = dir + FS.file(WsAtoms.config, FS.Cmd);
                if(configCmd.Exists)
                {
                    var config =  dir + FS.folder(WsAtoms.logs) + FS.file(WsAtoms.config, FS.Log);
                    if(config.Exists)
                    {
                        var result = Tooling.parse(config.ReadText(), out var c);
                        if(result.Fail)
                        {
                            Error(string.Format("{0}:{1}", config.ToUri(), result.Message));
                            continue;
                        }

                        var settings = formatter.Format(c);
                        var title = string.Format("# {0}", c.ToolId);
                        var sep = string.Format("# {0}", RP.PageBreak80);

                        Write(title, FlairKind.Status);
                        Write(sep);
                        Write(settings);
                        writer.WriteLine(title);
                        writer.WriteLine(sep);
                        writer.WriteLine(settings);
                        counter++;
                    }
                }
            }

            EmittedFile(emitting, counter);
            return true;
        }

        void LoadProfiles(FS.FilePath src, Lookup<ToolId,ToolProfile> dst)
        {
            var content = src.ReadUnicode();
            var result = TextGrids.parse(content, out var grid);
            if(result)
            {
                if(grid.ColCount != FieldCount)
                    Error(Tables.FieldCountMismatch.Format(FieldCount, grid.ColCount));
                else
                {
                    var count = grid.RowCount;
                    for(var i=0; i<count; i++)
                    {
                        result = parse(grid[i], out ToolProfile profile);
                        if(result)
                            dst.Include(profile.Id, profile);
                        else
                            break;
                    }
                }
            }
        }

        public static async Task<int> start(ToolCmdSpec spec, ToolCmdContext context, Action<string> status, Action<string> error)
        {
            var info = new ProcessStartInfo
            {
                FileName = spec.ToolPath.Name,
                Arguments = spec.Args.Format(),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            var process = new Process {StartInfo = info};

            if (!context.WorkingDir.IsNonEmpty)
                process.StartInfo.WorkingDirectory = context.WorkingDir.Name;

            iter(context.EnvVars.Storage, v => process.StartInfo.Environment.Add(v.Name, v.Value));
            process.OutputDataReceived += (s,d) => status(d.Data ?? EmptyString);
            process.ErrorDataReceived += (s,d) => error(d.Data ?? EmptyString);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return await wait(process);
        }

        static async Task<int> wait(Process process)
        {
            return await Task.Run(() => {
                process.WaitForExit();
                return Task.FromResult(process.ExitCode);
            });
        }

        public ConstLookup<ToolId,ToolProfile> LoadProfiles(FS.FolderPath dir)
        {
            var running = Running(string.Format("Loading tool profiles from {0}", dir));
            var sources = dir.Files("tool.profiles", FS.Csv, true);
            var dst = new Lookup<ToolId,ToolProfile>();
            iter(sources, src => LoadProfiles(src,dst));
            var lookup = dst.Seal();

            Ran(running, string.Format("Collected {0} profile definitions", lookup.EntryCount));
            return lookup;
        }

        static Outcome parse(in TextRow src, out ToolProfile dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(src.CellCount != FieldCount)
                result = (false,Tables.FieldCountMismatch.Format(FieldCount, src.CellCount));
            else
            {
                var i=0;
                dst.Id = src[i++].Text;
                dst.Modifier = src[i++].Text;
                dst.HelpCmd = src[i++].Text;
                dst.Memberhisp = src[i++].Text;
                dst.Path = FS.path(src[i++]);
            }
            return result;
        }
    }
}