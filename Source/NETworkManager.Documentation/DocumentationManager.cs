using NETworkManager.Models;
using NETworkManager.Settings;
using NETworkManager.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace NETworkManager.Documentation
{
    /// <summary>
    /// This class is designed to interact with the documentation at https://borntoberoot.net/NETworkManager/.
    /// </summary>
    public static class DocumentationManager
    {
        /// <summary>
        /// Base path of the documentation.
        /// </summary>
        public const string DocumentationBaseUrl = @"https://doc.stops.top/";

        /// <summary>
        /// List with all known documentation entries.
        /// </summary>
        private static List<DocumentationInfo> List => new()
        {
            new DocumentationInfo(DocumentationIdentifier.ApplicationDashboard, @"NetworkStudio/Dashboard"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationNetworkInterface, @"NetworkStudio/NetworkInterface"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationWiFi, @"NetworkStudio/WiFi"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationIPScanner, @"NetworkStudio/IPScanner"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationPortScanner, @"NetworkStudio/PortScanner"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationPingMonitor, @"NetworkStudio/PingMonitor"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationTraceroute, @"NetworkStudio/Traceroute"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationDnsLookup, @"NetworkStudio/DNSLookup"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationRemoteDesktop, @"NetworkStudio/RemoteDesktop"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationPowerShell, @"NetworkStudio/PowerShell"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationPutty, @"NetworkStudio/PuTTY"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationAWSSessionManager, @"NetworkStudio/AWSSessionManager"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationTigerVNC, @"NetworkStudio/TigerVNC"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationWebConsole, @"NetworkStudio/WebConsole"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationSnmp, @"NetworkStudio/SNMP"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationDiscoveryProtocol, @"NetworkStudio/DiscoveryProtocol"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationWakeOnLan, @"NetworkStudio/WakeOnLAN"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationWhois, @"NetworkStudio/Whois"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationSubnetCalculator, @"NetworkStudio/SubnetCalculator"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationLookup, @"NetworkStudio/Lookup"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationConnections, @"NetworkStudio/Connection"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationListeners, @"NetworkStudio/Listeners"),
            new DocumentationInfo(DocumentationIdentifier.ApplicationArpTable, @"NetworkStudio/ARPTable"),
            new DocumentationInfo(DocumentationIdentifier.SettingsGeneral, @"NetworkStudio/Settings/General"),
            new DocumentationInfo(DocumentationIdentifier.SettingsWindow, @"NetworkStudio/Settings/Window"),
            new DocumentationInfo(DocumentationIdentifier.SettingsAppearance, @"NetworkStudio/Settings/Appearance"),
            new DocumentationInfo(DocumentationIdentifier.SettingsLanguage, @"NetworkStudio/Settings/Language"),
            new DocumentationInfo(DocumentationIdentifier.SettingsStatus, @"NetworkStudio/Settings/Status"),
            new DocumentationInfo(DocumentationIdentifier.SettingsHotKeys, @"NetworkStudio/Settings/HotKeys"),
            new DocumentationInfo(DocumentationIdentifier.SettingsAutostart, @"NetworkStudio/Settings/Autostart"),
            new DocumentationInfo(DocumentationIdentifier.SettingsUpdate, @"NetworkStudio/Settings/Update"),
            new DocumentationInfo(DocumentationIdentifier.SettingsProfiles, @"NetworkStudio/Settings/Profiles"),
            new DocumentationInfo(DocumentationIdentifier.SettingsSettings, @"NetworkStudio/Settings/Settings"),
            new DocumentationInfo(DocumentationIdentifier.Profiles, @"NetworkStudio/Profiles"),
            new DocumentationInfo(DocumentationIdentifier.CommandLineArguments, @"NetworkStudio/CommandLineArguments"),
        };

        /// <summary>
        /// Method to create the documentation url from <see cref="DocumentationIdentifier"/>.
        /// </summary>
        /// <param name="documentationIdentifier"><see cref="DocumentationIdentifier"/> of the documentation page you want to open.</param>
        /// <returns>URL of the documentation page.</returns>
        private static string CreateUrl(DocumentationIdentifier documentationIdentifier)
        {
            var info = List.FirstOrDefault(x => x.Identifier == documentationIdentifier);

            var url = DocumentationBaseUrl;

            if (info != null)
                url += info.Path;

            return url;
        }

        /// <summary>
        /// Method for opening a documentation page with the default webbrowser based on the <see cref="DocumentationIdentifier"/> .
        /// </summary>
        /// <param name="documentationIdentifier"><see cref="DocumentationIdentifier"/> of the documentation page you want to open.</param>
        public static void OpenDocumentation(DocumentationIdentifier documentationIdentifier)
        {
            ExternalProcessStarter.OpenUrl(CreateUrl(documentationIdentifier));
        }

        /// <summary>
        /// Command to open a documentation page based on <see cref="DocumentationIdentifier"/>.
        /// </summary>
        public static ICommand OpenDocumentationCommand => new RelayCommand(OpenDocumentationAction);

        /// <summary>
        /// Method to open a documentation page based on <see cref="DocumentationIdentifier"/>.
        /// </summary>
        /// <param name="documentationIdentifier"></param>
        private static void OpenDocumentationAction(object documentationIdentifier)
        {
            if (documentationIdentifier != null)
                OpenDocumentation((DocumentationIdentifier)documentationIdentifier);
        }

        /// <summary>
        /// Method to get the <see cref="DocumentationIdentifier"/> from an <see cref="ApplicationName"/>.
        /// </summary>
        /// <param name="name"><see cref="ApplicationName"/> from which you want to get the <see cref="DocumentationIdentifier"/>.</param>
        /// <returns><see cref="DocumentationIdentifier"/> of the application.</returns>
        public static DocumentationIdentifier GetIdentifierByAppliactionName(ApplicationName name)
        {
            return name switch
            {
                ApplicationName.Dashboard => DocumentationIdentifier.ApplicationDashboard,
                ApplicationName.NetworkInterface => DocumentationIdentifier.ApplicationNetworkInterface,
                ApplicationName.WiFi => DocumentationIdentifier.ApplicationWiFi,
                ApplicationName.IPScanner => DocumentationIdentifier.ApplicationIPScanner,
                ApplicationName.PortScanner => DocumentationIdentifier.ApplicationPortScanner,
                ApplicationName.PingMonitor => DocumentationIdentifier.ApplicationPingMonitor,
                ApplicationName.Traceroute => DocumentationIdentifier.ApplicationTraceroute,
                ApplicationName.DNSLookup => DocumentationIdentifier.ApplicationDnsLookup,
                ApplicationName.RemoteDesktop => DocumentationIdentifier.ApplicationRemoteDesktop,
                ApplicationName.PowerShell => DocumentationIdentifier.ApplicationPowerShell,
                ApplicationName.PuTTY => DocumentationIdentifier.ApplicationPutty,
                ApplicationName.AWSSessionManager => DocumentationIdentifier.ApplicationAWSSessionManager,
                ApplicationName.TigerVNC => DocumentationIdentifier.ApplicationTigerVNC,
                ApplicationName.WebConsole => DocumentationIdentifier.ApplicationWebConsole,
                ApplicationName.SNMP => DocumentationIdentifier.ApplicationSnmp,
                ApplicationName.DiscoveryProtocol => DocumentationIdentifier.ApplicationDiscoveryProtocol,
                ApplicationName.WakeOnLAN => DocumentationIdentifier.ApplicationWakeOnLan,
                ApplicationName.Whois => DocumentationIdentifier.ApplicationWhois,
                ApplicationName.SubnetCalculator => DocumentationIdentifier.ApplicationSubnetCalculator,
                ApplicationName.Lookup => DocumentationIdentifier.ApplicationLookup,
                ApplicationName.Connections => DocumentationIdentifier.ApplicationConnections,
                ApplicationName.Listeners => DocumentationIdentifier.ApplicationListeners,
                ApplicationName.ARPTable => DocumentationIdentifier.ApplicationArpTable,
                ApplicationName.None => DocumentationIdentifier.Default,
                _ => DocumentationIdentifier.Default,
            };
        }

        /// <summary>
        /// Method to get the <see cref="DocumentationIdentifier"/> from an <see cref="SettingsViewName"/>.
        /// </summary>
        /// <param name="name"><see cref="SettingsViewName"/> from which you want to get the <see cref="DocumentationIdentifier"/>.</param>
        /// <returns><see cref="DocumentationIdentifier"/> of the application or settings page.</returns>
        public static DocumentationIdentifier GetIdentifierBySettingsName(SettingsViewName name)
        {
            return name switch
            {
                SettingsViewName.General => DocumentationIdentifier.SettingsGeneral,
                SettingsViewName.Window => DocumentationIdentifier.SettingsWindow,
                SettingsViewName.Appearance => DocumentationIdentifier.SettingsAppearance,
                SettingsViewName.Language => DocumentationIdentifier.SettingsLanguage,
                SettingsViewName.Status => DocumentationIdentifier.SettingsStatus,
                SettingsViewName.HotKeys => DocumentationIdentifier.SettingsHotKeys,
                SettingsViewName.Autostart => DocumentationIdentifier.SettingsAutostart,
                SettingsViewName.Update => DocumentationIdentifier.SettingsUpdate,
                SettingsViewName.Profiles => DocumentationIdentifier.SettingsProfiles,
                SettingsViewName.Settings => DocumentationIdentifier.SettingsSettings,
                SettingsViewName.Dashboard => GetIdentifierByAppliactionName(ApplicationName.Dashboard),
                SettingsViewName.IPScanner => GetIdentifierByAppliactionName(ApplicationName.IPScanner),
                SettingsViewName.PortScanner => GetIdentifierByAppliactionName(ApplicationName.PortScanner),
                SettingsViewName.PingMonitor => GetIdentifierByAppliactionName(ApplicationName.PingMonitor),
                SettingsViewName.Traceroute => GetIdentifierByAppliactionName(ApplicationName.Traceroute),
                SettingsViewName.DNSLookup => GetIdentifierByAppliactionName(ApplicationName.DNSLookup),
                SettingsViewName.RemoteDesktop => GetIdentifierByAppliactionName(ApplicationName.RemoteDesktop),
                SettingsViewName.PowerShell => GetIdentifierByAppliactionName(ApplicationName.PowerShell),
                SettingsViewName.PuTTY => GetIdentifierByAppliactionName(ApplicationName.PuTTY),
                SettingsViewName.AWSSessionManager => GetIdentifierByAppliactionName(ApplicationName.AWSSessionManager),
                SettingsViewName.TigerVNC => GetIdentifierByAppliactionName(ApplicationName.TigerVNC),
                SettingsViewName.SNMP => GetIdentifierByAppliactionName(ApplicationName.SNMP),
                SettingsViewName.WakeOnLAN => GetIdentifierByAppliactionName(ApplicationName.WakeOnLAN),
                SettingsViewName.Whois => GetIdentifierByAppliactionName(ApplicationName.Whois),
                _ => DocumentationIdentifier.Default,
            };
        }
    }
}
