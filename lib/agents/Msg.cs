namespace Z0
{
    partial struct Msg
    {
        public static MsgPattern<ToolId> ToolHelpNotFound => "Tool {0} help not found";

        public static MsgPattern<FS.FileUri> EmittingFile => "Emitting {0}";

        public static MsgPattern<FS.FileUri> EmittedFile => "Emitted {0}";

        public static MsgPattern<TableId,FS.FileUri> EmittingTable => "Emitting {0} to {1}";

        public static MsgPattern<TableId,Count,FS.FileUri> EmittedTable => "Emitted {1} {0} rows to {2}";
    }
}
