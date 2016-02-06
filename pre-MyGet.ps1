$dnxRoot = [regex]::match($env:PATH,'([^;]+\\\.dnx\\runtimes\\[^;]+\\bin);').Groups[1].Value
$dnx = "$dnxRoot\dnx.exe"
$dnxTooling = "$dnxRoot\lib\Microsoft.Dnx.Tooling\Microsoft.Dnx.Tooling.dll"
 
& $dnx $dnxTooling restore ".\src\AutomaticSharp"
