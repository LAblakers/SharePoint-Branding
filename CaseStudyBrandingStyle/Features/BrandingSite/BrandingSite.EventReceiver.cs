using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace CaseStudyBrandingStyle.Features.BrandingSite
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("4049bffd-adb1-46c9-9200-fcb94c5cb054")]
    public class BrandingSiteEventReceiver : SPFeatureReceiver
    {
        const string DefaultMasterUrlPath = "_catalogs/masterpage/seattle.master";

        const string MasterUrlPath = "_catalogs/masterpage/Starter Team.master";
        const string CustomMasterUrlPath = "_catalogs/masterpage/Starter Team.master";
        const string AlternateCssUrlPath = "_catalogs/masterpage/StarterBranding/style.css";
        const string SiteLogoUrlPath = "_catalogs/masterpage/StarterBranding/custombanner.png";
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite siteCollection = properties.Feature.Parent as SPSite;
            if (siteCollection != null)
            {
                SPWeb topLevelSite = siteCollection.RootWeb;

                string WebAppRelativePath = topLevelSite.ServerRelativeUrl;
                if (!WebAppRelativePath.EndsWith(@"/"))
                {
                    WebAppRelativePath += @"/";
                }

                foreach (SPWeb site in siteCollection.AllWebs)
                {
                    site.MasterUrl = WebAppRelativePath + MasterUrlPath;
                    site.CustomMasterUrl = WebAppRelativePath + CustomMasterUrlPath;
                    site.AlternateCssUrl = WebAppRelativePath + AlternateCssUrlPath;
                    site.SiteLogoUrl = WebAppRelativePath + SiteLogoUrlPath;
                    site.UIVersion = 5;
                    site.Update();
                }
            }
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite siteCollection = properties.Feature.Parent as SPSite;
            if (siteCollection != null)
            {
                SPWeb topLevelSite = siteCollection.RootWeb;

                string WebAppRelativePath = topLevelSite.ServerRelativeUrl;
                if (!WebAppRelativePath.EndsWith(@"/"))
                {
                    WebAppRelativePath += @"/";
                }

                foreach (SPWeb site in siteCollection.AllWebs)
                {
                    site.MasterUrl = WebAppRelativePath + DefaultMasterUrlPath;
                    site.CustomMasterUrl = WebAppRelativePath + DefaultMasterUrlPath;
                    site.AlternateCssUrl = "";
                    site.SiteLogoUrl = "";
                    site.UIVersion = 5;
                    site.Update();
                }
            }


            // Uncomment the method below to handle the event raised after a feature has been installed.

            //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
            //{
            //}


            // Uncomment the method below to handle the event raised before a feature is uninstalled.

            //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
            //{
            //}

            // Uncomment the method below to handle the event raised when a feature is upgrading.

            //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
            //{
            //}
        }
    }
}
