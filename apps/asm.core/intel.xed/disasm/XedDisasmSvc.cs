//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        WsProjects Projects => Service(Wf.WsProjects);

        XedPaths XedPaths => Service(Wf.XedPaths);

        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        public FS.FolderPath DisasmTargets(WsContext context)
            => Projects.XedDisasmDir(context.Project);

        FS.FilePath DisasmFieldsPath(WsContext context, in FileRef src)
            => DisasmTargets(context) + FS.file(string.Format("{0}.fields", src.Path.FileName.WithoutExtension), FS.Txt);

        FS.FilePath DisasmChecksPath(WsContext context, in FileRef src)
            => DisasmTargets(context) + FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt);

        FS.FilePath DisasmOpsPath(WsContext context, in FileRef src)
            => DisasmTargets(context) + FS.file(string.Format("{0}.ops", src.Path.FileName.WithoutExtension.Format()), FS.Txt);
    }
}