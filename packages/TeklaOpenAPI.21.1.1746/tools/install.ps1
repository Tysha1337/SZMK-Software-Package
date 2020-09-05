param($installPath, $toolsPath, $package, $project)

$asms = $package.AssemblyReferences | %{$_.Name}
$test = "*Test"
ForEach ($item in $project.Object) { Write-Host $item.Name } 
Write-Host "AssemblyName:" $project.Name

if (($project.Name -NotLike "*Test") -and ($project.Name -NotLike "*Tests"))
{
    foreach ($reference in $project.Object.References)
    {
        if ($asms -contains $reference.Name + ".dll")
        {
            $reference.CopyLocal = $false;
        }
    }
}