﻿namespace Hitechsoft.CRM.Web.Areas.App.Startup
{
    public class AppPageNames
    {
        public static class Common
        {
            public const string MedicalSpecialties = "Models.MedicalSpecialties";
            public const string Icd10s = "Models.Icd10s";
            public const string Constants = "Models.Constants";
            public const string Gender = "Administration.Models.Gender";
            public const string MedicinalTypes = "Administration.Models.MedicinalTypes";
            public const string Ethnicities = "Administration.Models.Ethnicities";
            public const string Administration = "Administration";
            public const string Roles = "Administration.Roles";
            public const string Users = "Administration.Users";
            public const string AuditLogs = "Administration.AuditLogs";
            public const string OrganizationUnits = "Administration.OrganizationUnits";
            public const string Languages = "Administration.Languages";
            public const string DemoUiComponents = "Administration.DemoUiComponents";
            public const string UiCustomization = "Administration.UiCustomization";
            public const string WebhookSubscriptions = "Administration.WebhookSubscriptions";
            public const string DynamicProperties = "Administration.DynamicProperties";
            public const string DynamicEntityProperties = "Administration.DynamicEntityProperties";
        }

        public static class Host
        {
            public const string Tenants = "Tenants";
            public const string Editions = "Editions";
            public const string Maintenance = "Administration.Maintenance";
            public const string Settings = "Administration.Settings.Host";
            public const string Dashboard = "Dashboard";
        }

        public static class Tenant
        {
            public const string Dashboard = "Dashboard.Tenant";
            public const string Settings = "Administration.Settings.Tenant";
            public const string SubscriptionManagement = "Administration.SubscriptionManagement.Tenant";
        }
    }
}