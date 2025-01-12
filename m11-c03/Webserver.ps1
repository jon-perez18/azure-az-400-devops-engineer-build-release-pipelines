Configuration Webserver {
    Import-DscResource -ModuleName PsDesiredStateConfiguration

    Node 'webserver' {

        WindowsFeature WebServer {
            Ensure = "Present"
            Name   = "Web-Server"
        }

        File WebsiteContent {
            Ensure = 'Present'
            Contents = 'Hello World'
            DestinationPath = 'c:\inetpub\wwwroot\index.html'
        }
    }
}