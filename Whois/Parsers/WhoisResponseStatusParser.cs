﻿using System;
using Whois.Models;

namespace Whois.Parsers
{
    /// <summary>
    /// Converts per WHOIS server domain statuses into a <see cref="WhoisResponseStatus"/>.
    /// </summary>
    public class WhoisResponseStatusParser
    {
        public WhoisResponseStatus Parse(string whoisServerUrl, string tld, string status, WhoisResponseStatus existing)
        {
            if (Equals(status, "auto-renew grace")) return WhoisResponseStatus.NotAssigned;
            if (Equals(status, "pending delete")) return WhoisResponseStatus.PendingDelete;
            if (Equals(status, "pendingdelete")) return WhoisResponseStatus.PendingDelete;
            if (Equals(status, "redemption")) return WhoisResponseStatus.Redemption;
            if (Equals(status, "UNCONFIRMED")) return WhoisResponseStatus.Unconfirmed;
            if (Equals(status, "Deactivated")) return WhoisResponseStatus.Deactivated;
            if (Equals(status, "failed")) return WhoisResponseStatus.Failed;
            if (Equals(status, "Reserved")) return WhoisResponseStatus.Reserved;
            if (Equals(status, "inactive")) return WhoisResponseStatus.NotAssigned;
            if (Equals(status, "in quarantine")) return WhoisResponseStatus.Quarantined;
            if (Equals(status, "Grace Period")) return WhoisResponseStatus.Other;
            if (Equals(status, "Available")) return WhoisResponseStatus.NotFound;
            if (Equals(status, "Transfer Locked")) return WhoisResponseStatus.Locked;
            if (Equals(status, "Deleted")) return WhoisResponseStatus.PendingDelete;
            if (Equals(status, "To be suspended")) return WhoisResponseStatus.Suspended;
            if (Equals(status, "Suspended")) return WhoisResponseStatus.Suspended;
            if (Equals(status, "RedemptionPeriod")) return WhoisResponseStatus.Redemption;
            if (Equals(status, "AutoRenewGracePeriod")) return WhoisResponseStatus.Other;

            if (whoisServerUrl == "whois.dns.pt")
            {
                if (Equals(status, "TECH-PRO")) return WhoisResponseStatus.Other;
            }

            if (whoisServerUrl == "whois.iis.se")
            {
                if (Equals(status, "system")) return WhoisResponseStatus.NotAssigned;
            }


            return existing;
        }

        private static bool Equals(string status, string value)
        {
            return string.Compare(status, value, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}
