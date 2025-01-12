Configuration NoWebserver {
    Import-DscResource -ModuleName PsDesiredStateConfiguration

    Node 'nowebserver' {

        WindowsFeature WebServer {
            Ensure = "Absent"
            Name   = "Web-Server"
        }
    }
}