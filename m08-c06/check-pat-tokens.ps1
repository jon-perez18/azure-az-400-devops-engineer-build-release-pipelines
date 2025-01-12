##Install-Module AzureDevOps

write-host "Login As User That Is Azure DevOps Admin"

##az login
$azureDevopsResourceId = "499b84ac-1321-427f-aa17-267ca6975798"
$token = "" ##replace with own generated pat token in azure devops
$authValue = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes(":$token"))
##Write-Host $authValue

$headers = @{
    Authorization = "Basic $authValue";
    'X-VSS-ForceMsaPassThrough' = $true
}

##write-host $authValue
$organization = "your-organization-name"
$UserAPIRunUrl = "https://vssps.dev.azure.com/$organization/_apis/graph/users?api-version=5.1-preview.1"

[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
$Users=Invoke-RestMethod -Uri $UserAPIRunUrl -Method GET -Headers $headers -ContentType 'application/json' -Verbose # | ConvertFrom-Json

$CombinedPatList=@()
Write-Host $users

foreach ($User in $users.value) {
    $displayname= $user.displayname.ToString()
    $descriptor = $user.descriptor.ToString()
    $principalName = $User.principalName
    $mailaddress = $User.mailAddress
    write-host "User Name: $displayname" 
    $UsersPATAPIRunUrl = "https://vssps.dev.azure.com/$organization/_apis/tokenadmin/personalaccesstokens/$descriptor"
    if ($User.domain -notlike "*LOCAL AUTHORITY*") {
        $UserPATTokensList = Invoke-RestMethod -Uri $UsersPATAPIRunUrl -Method GET -Headers $headers -ContentType 'application/json'
    
        write-host "Getting PAT keys for user account $displayname"
        $UserPATTokensList.value | Add-Member -NotePropertyName "AzurePrincipalName" -NotePropertyValue $principalName
        $UserPATTokensList.value | Add-Member -NotePropertyName "AzureMailAddress" -NotePropertyValue $mailaddress
        $UserPATTokensList.value | Add-Member -NotePropertyName "AzureDisplayName" -NotePropertyValue $displayname
        
        $NewPat=$UserPATTokensList.value
        $CombinedPatList+=$NewPat
        
    }
}
Write-Host "Writing Details To c:\temp\pat_details.log"
$CombinedPatList | Out-File -FilePath "C:\temp\pat_details.log"