$c =  pwd;
$AllCsfiles = Get-ChildItem -Path $c -Filter *.cs  -Recurse -File -Name

$EidtCs = $AllCsfiles | Where-Object {$_.Contains("obj") -eq $false -or $_.Contains("bin") -eq $false  -or $_.Contains("Properties") -eq $false}

For ($i=0; $i -le 322; $i++) 
{
    $b += "!"
}

foreach($i in $EidtCs)
{
  $a = Get-Content -Path ((pwd).Path + "/" +  $i);
  $a = $a.Replace("/*troll*/","$b");
  $a | Out-File -FilePath $i;
}
Write-Host $c
