﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmoleReportPortal {
    using System;
    using System.ComponentModel;
    using CrystalDecisions.Shared;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.CrystalReports.Engine;
    
    
    public class CrystalReport1 : ReportClass {
        
        public CrystalReport1() {
        }
        
        public override string ResourceName {
            get {
                return "CrystalReport1.rpt";
            }
            set {
                // Do nothing
            }
        }
        
        public override bool NewGenerator {
            get {
                return true;
            }
            set {
                // Do nothing
            }
        }
        
        public override string FullResourceName {
            get {
                return "AmoleReportPortal.CrystalReport1.rpt";
            }
            set {
                // Do nothing
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section1 {
            get {
                return this.ReportDefinition.Sections[0];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section2 {
            get {
                return this.ReportDefinition.Sections[1];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section GroupHeaderSection1 {
            get {
                return this.ReportDefinition.Sections[2];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section GroupHeaderSection2 {
            get {
                return this.ReportDefinition.Sections[3];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section3 {
            get {
                return this.ReportDefinition.Sections[4];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section GroupFooterSection2 {
            get {
                return this.ReportDefinition.Sections[5];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section GroupFooterSection1 {
            get {
                return this.ReportDefinition.Sections[6];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section4 {
            get {
                return this.ReportDefinition.Sections[7];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section5 {
            get {
                return this.ReportDefinition.Sections[8];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_From {
            get {
                return this.DataDefinition.ParameterFields[0];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_To {
            get {
                return this.DataDefinition.ParameterFields[1];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_ReportHeading1 {
            get {
                return this.DataDefinition.ParameterFields[2];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_ReportHeading2 {
            get {
                return this.DataDefinition.ParameterFields[3];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_ReportHeading3 {
            get {
                return this.DataDefinition.ParameterFields[4];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_time {
            get {
                return this.DataDefinition.ParameterFields[5];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_date {
            get {
                return this.DataDefinition.ParameterFields[6];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_ReportName {
            get {
                return this.DataDefinition.ParameterFields[7];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_LoginID {
            get {
                return this.DataDefinition.ParameterFields[8];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_ReportNumber {
            get {
                return this.DataDefinition.ParameterFields[9];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_String1 {
            get {
                return this.DataDefinition.ParameterFields[10];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_String2 {
            get {
                return this.DataDefinition.ParameterFields[11];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_String3 {
            get {
                return this.DataDefinition.ParameterFields[12];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Date1 {
            get {
                return this.DataDefinition.ParameterFields[13];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Date2 {
            get {
                return this.DataDefinition.ParameterFields[14];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Date3 {
            get {
                return this.DataDefinition.ParameterFields[15];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Integer1 {
            get {
                return this.DataDefinition.ParameterFields[16];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Integer2 {
            get {
                return this.DataDefinition.ParameterFields[17];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Integer3 {
            get {
                return this.DataDefinition.ParameterFields[18];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Decimal1 {
            get {
                return this.DataDefinition.ParameterFields[19];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Decimal2 {
            get {
                return this.DataDefinition.ParameterFields[20];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Decimal3 {
            get {
                return this.DataDefinition.ParameterFields[21];
            }
        }
    }
    
    [System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
    public class CachedCrystalReport1 : Component, ICachedReport {
        
        public CachedCrystalReport1() {
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable {
            get {
                return true;
            }
            set {
                // 
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool ShareDBLogonInfo {
            get {
                return false;
            }
            set {
                // 
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual System.TimeSpan CacheTimeOut {
            get {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set {
                // 
            }
        }
        
        public virtual CrystalDecisions.CrystalReports.Engine.ReportDocument CreateReport() {
            CrystalReport1 rpt = new CrystalReport1();
            rpt.Site = this.Site;
            return rpt;
        }
        
        public virtual string GetCustomizedCacheKey(RequestContext request) {
            String key = null;
            // // The following is the code used to generate the default
            // // cache key for caching report jobs in the ASP.NET Cache.
            // // Feel free to modify this code to suit your needs.
            // // Returning key == null causes the default cache key to
            // // be generated.
            // 
            // key = RequestContext.BuildCompleteCacheKey(
            //     request,
            //     null,       // sReportFilename
            //     this.GetType(),
            //     this.ShareDBLogonInfo );
            return key;
        }
    }
}
