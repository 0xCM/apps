//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        const string scope = "xed.disasm";

        WsProjects Projects => Wf.WsProjects();

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        XedPaths XedPaths => Xed.Paths;

        XedRuntime Xed;

        public XedDisasmSvc With(XedRuntime xed)
        {
            Xed = xed;

            return this;
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => Xed.PllExec;
        }

        FS.FilePath DisasmFieldsPath(WsContext context, in FileRef src)
            => XedPaths.DisasmTargets(context.Project) + FS.file(string.Format("{0}.fields", src.Path.FileName.WithoutExtension), FS.Txt);

        FS.FilePath DisasmChecksPath(WsContext context, in FileRef src)
            => XedPaths.DisasmTargets(context.Project) + FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt);

        FS.FilePath DisasmOpsPath(WsContext context, in FileRef src)
            => XedPaths.DisasmTargets(context.Project) + FS.file(string.Format("{0}.ops", src.Path.FileName.WithoutExtension.Format()), FS.Txt);
    }
}