//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    //using Gen;

    using Gen;

    public class ShellGen : AppService<ShellGen>
    {
        public void Generate(ShellSpec spec, FS.FolderPath dst)
        {
            var project = new NetCoreProject(spec.ProjectName, spec.AssemblyName);
            project.Props.WithOutputType("Exe").WithRuntimeIdentifier("win-x64");
            project.Items.WithPackageReference("z0.tools", "$(ZLibVersion)");
            var path = dst + FS.file(project.ProjectName, FS.CsProj);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            writer.WriteLine(project.Format());
            EmittedFile(emitting,1);
        }

    }

    public struct ShellSpec
    {
        public string ProjectName;

        public string AssemblyName;

        public ShellSpec(string proj, string ass)
        {
            ProjectName = proj;
            AssemblyName = ass;
        }
    }
}