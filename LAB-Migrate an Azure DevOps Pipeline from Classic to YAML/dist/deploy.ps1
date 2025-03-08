
$appServiceName = 'TODO';
$password = 'TODO'
$packageLocation = '$(System.DefaultWorkingDirectory)/api-package/api-package/WeatherForecast.Api.zip';

########################################################
########################################################
# Don't change anything below this line!!!
# Really don't, it took me three days to figure this out
########################################################
########################################################

$msdeploy = "C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe";
$source = '-source:package='+$packageLocation
$destination = '-dest:auto,computerName=https://'+ $appServiceName +'.scm.azurewebsites.net:443/msdeploy.axd?site='+ $appServiceName +',userName=$'+ $appServiceName +',password=' + $password + ',authtype=basic,includeAcls=False';

$msdeployArguments = 
    $source,
    $destination,
    '-verb:sync',
    '-disableLink:AppPoolExtension',
    '-disableLink:ContentExtension',
    '-disableLink:CertificateExtension'
    '-enableRule:AppOffline';

Write-Host($msdeployArguments);

Write-Host($siteNameValue)

& $msdeploy $msdeployArguments
