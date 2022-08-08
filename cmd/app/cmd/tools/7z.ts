import {CmdActionSpec} from "../core"

type ToolGroup = "tools"

const group:ToolGroup = "tools"

export type ToolId = "7z"

export type Flag = "a" | "b" | "d" | "e" | "h" | "i" | "l" | "l" | "rn" | "t" | "u" | "x"

export type FlagName = "add" | "benchmark" | "delete" |  "extractUnpathed" | "hash" | "info" | "list" | "rename" | "test" | "update" | "extract"


export interface ToolActionSpec extends CmdActionSpec<Flag,FlagName>
{

}

export type ToolActionSpecs = Array<ToolActionSpec>


export const ToolActions : ToolActionSpecs = [
    {
        Flag:"a",
        Name:"add",
        Intent:"Add files to archive"
    },
    {
        Flag:"b",
        Name:"benchmark",
        Intent:"Benchmark"
    },
    {
        Flag:"d",
        Name:"delete",
        Intent:"Delete files from archive"
    },
    {
        Flag:"e",
        Name:"extractUnpathed",
        Intent:"Extract files from archive (without using directory names)"
    },
    {
        Flag:"h",
        Name:"hash",
        Intent:"Calculate hash values for files"
    },
    {
        Flag:"i",
        Name:"info",
        Intent:"Show information about supported formats"
    },
    {
        Flag:"l",
        Name:"list",
        Intent:"List contents of archive"
    },
    {
        Flag:"rn",
        Name:"rename",
        Intent:"Rename files in archive"
    },
    {
        Flag:"t",
        Name:"test",
        Intent:"Test integrity of archive"
    },
    {
        Flag:"u",
        Name:"update",
        Intent:"Update files to archive"
    },
    {
        Flag:"x",
        Name:"extract",
        Intent:"eXtract files with full paths"
    },
]

export type Option = "-ai" | "ax" | "ao" | "an"

export type Options = Array<Option>

export type ArchiveName = string

export type FileNames = Array<string>

export type Usage = [
    tool:ToolId,
    command:Flag,
    options:Options,
    archive:ArchiveName,
    files:FileNames
];

function archive(src:string, dst:string) : string
{
    const actor = '7z'
    const action= 'a'
    return `${actor} ${action} ${dst} ${src}`
}

export const api = {
    create: archive
}

// export const tool:Tool<ToolName,ToolCommand,CommandName> = {
//     tool: "7z",
//     commands: commands
// }

// // Usage: 7z <command> [<switches>...] <archive_name> [<file_names>...] [@listfile]

// function emit(){
    
//     console.log(JSON.stringify(commands,null,' '))
// }

// //const json = JSON.stringify(commands,null,' ')

// emit();

/*
<Switches>
  -- : Stop switches and @listfile parsing
  -ai[r[-|0]]{@listfile|!wildcard} : Include archives
  -ax[r[-|0]]{@listfile|!wildcard} : eXclude archives
  -ao{a|s|t|u} : set Overwrite mode
  -an : disable archive_name field
  -bb[0-3] : set output log level
  -bd : disable progress indicator
  -bs{o|e|p}{0|1|2} : set output stream for output/error/progress line
  -bt : show execution time statistics
  -i[r[-|0]]{@listfile|!wildcard} : Include filenames
  -m{Parameters} : set compression Method
    -mmt[N] : set number of CPU threads
    -mx[N] : set compression level: -mx1 (fastest) ... -mx9 (ultra)
  -o{Directory} : set Output directory
  -p{Password} : set Password
  -r[-|0] : Recurse subdirectories
  -sa{a|e|s} : set Archive name mode
  -scc{UTF-8|WIN|DOS} : set charset for for console input/output
  -scs{UTF-8|UTF-16LE|UTF-16BE|WIN|DOS|{id}} : set charset for list files
  -scrc[CRC32|CRC64|SHA1|SHA256|*] : set hash function for x, e, h commands
  -sdel : delete files after compression
  -seml[.] : send archive by email
  -sfx[{name}] : Create SFX archive
  -si[{name}] : read data from stdin
  -slp : set Large Pages mode
  -slt : show technical information for l (List) command
  -snh : store hard links as links
  -snl : store symbolic links as links
  -sni : store NT security information
  -sns[-] : store NTFS alternate streams
  -so : write data to stdout
  -spd : disable wildcard matching for file names
  -spe : eliminate duplication of root folder for extract command
  -spf : use fully qualified file paths
  -ssc[-] : set sensitive case mode
  -sse : stop archive creating, if it can't open some input file
  -ssw : compress shared files
  -stl : set archive timestamp from the most recently modified file
  -stm{HexMask} : set CPU thread affinity mask (hexadecimal number)
  -stx{Type} : exclude archive type
  -t{Type} : Set type of archive
  -u[-][p#][q#][r#][x#][y#][z#][!newArchiveName] : Update options
  -v{Size}[b|k|m|g] : Create volumes
  -w[{path}] : assign Work directory. Empty path means a temporary directory
  -x[r[-|0]]{@listfile|!wildcard} : eXclude filenames
  -y : assume Yes on all queries

*/