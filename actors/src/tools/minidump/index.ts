const ToolId = `minidump`
const ToolGroup = `tools`
const ToolExe = `${ToolId}.exe`
const InstallBase = "f:\\drives\\y\\sdks\\python\\scripts"
const ToolPath = `${InstallBase}\\${ToolExe}`

export interface Tool {
    Id:string
    Group:string
    Path:string
}

function register() : Tool
{
    return {
        Id:ToolId,
        Group:ToolGroup,
        Path:ToolPath
    }
}

console.log(JSON.stringify(register(), null,' '))