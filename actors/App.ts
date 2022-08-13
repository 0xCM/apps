import {} from "./src/app"

import {CmdSpecs} from "./src/app/ApiCmd"

import {api}  from "./src/tools/7z"


const command = api.create("{src}", "{dst}");

console.log(command);

