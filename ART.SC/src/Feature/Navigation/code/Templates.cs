namespace ART.SC.Feature.Navigation
{
    using Sitecore.Data;

    public struct Templates
    {
        public struct NavigationRoot
        {
            public static readonly ID ID = new ID("{CA8DE1F0-FD75-4E45-89B8-37E61B7931D0}");
        }

        public struct Navigable
        {
            public static readonly ID ID = new ID("{0065E916-9A26-4177-B31D-DC6831D61FC8}");

            public struct Fields
            {
                public static readonly ID ShowInNavigation = new ID("{9F1438C2-F722-4E50-B7B8-79A74ED09D01}");
                public static readonly ID NavigationTitle = new ID("{47DA1ED4-B263-4E00-AF8C-E23586E0CAB4}");
                public static readonly ID ShowChildren = new ID("{AC5FEE43-1719-4320-AFA2-234759B0BB92}");
            }
        }

        public struct Link
        {
            public static readonly ID ID = new ID("{25698DAF-2BBE-4E0C-8532-D55E18E9EEBA}");

            public struct Fields
            {
                public static readonly ID Link = new ID("{A9E9B96E-5D76-4214-834B-77EC0BD58C80}");
            }
        }

        public struct LinkMenuItem
        {
            public static readonly ID ID = new ID("{98F2BCEC-C4FC-4E28-8DDF-F264D9D22A78}");

            public struct Fields
            {
                public static readonly ID Icon = new ID("{A1B68E15-06F4-4D58-B507-0C1B298E01F5}");
                //public static readonly ID DividerBefore = new ID("{4231CD60-47C1-42AD-B838-0A6F8F1C4CFB}");
            }
        }
    }
}