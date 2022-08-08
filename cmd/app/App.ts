import {} from "./cmd/app"

import {CmdSpecs} from "./cmd/app/ApiCmd"

import {api}  from "./cmd/tools/7z"

// console.log(JSON.stringify(CmdSpecs,null,' '))

const command = api.create("{src}", "{dst}");

console.log(command);

// 7z a -t7z <dst>.7z <src>

// set Src=%Views%\db\capture\2022-08-05.08.20.47.485\*.*
// set Dst=%Views%\archives\capture\capture.2022-08-05.08.20.47.485.7z
// set Action=a
// set Actor=7z
// set Options=-t7z
// set CmdSpec=%Actor% %Action% %Options% %Dst% %Src%