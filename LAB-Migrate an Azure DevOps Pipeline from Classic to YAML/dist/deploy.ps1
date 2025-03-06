
$appServiceName = 'TODO';
$password = 'TODO'
$packageLocation = "c:\tmp\WeatherForecast.Api.zip";

########################################################
########################################################
# Don't change anything below this line!!!
# Really don't, it took me three days to figure this out
########################################################
########################################################

$msdeploy = "C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe";
$source = '-source:package='+$packageLocation
$destination = '-dest:auto,computerName=https://'+ $appServiceName +'.scm.azurewebsites.net:443/msdeploy.axd?site='+ $appServiceName +',userName=$tryagain22,password=' + $password + ',authtype=basic,includeAcls=False';

$siteNameValue = 'Name'',value='''+$appServiceName+'''';

$msdeployArguments = 
    $source,
    $destination,
    '-verb:sync',
    '-enableRule:AppOffline',
    '-disableLink:AppPoolExtension',
    '-disableLink:ContentExtension',
    '-disableLink:CertificateExtension',
    '-setParam:name=''IIS', 
    'Web', 
    'Application', 
    $siteNameValue

Write-Host($msdeployArguments);

Write-Host($siteNameValue)

& $msdeploy $msdeployArguments