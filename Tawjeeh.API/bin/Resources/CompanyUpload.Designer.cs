﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlobalHelper.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CompanyUpload {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CompanyUpload() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GlobalHelper.Resources.CompanyUpload", typeof(CompanyUpload).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Company : &lt;/strong&gt;Company at row {0} is null..
        /// </summary>
        public static string errorCompanyNameNullValue {
            get {
                return ResourceManager.GetString("errorCompanyNameNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Contact Email Address: &lt;/strong&gt;Contact Email Address at row {0} is null..
        /// </summary>
        public static string errorContactEmailAddressNullValue {
            get {
                return ResourceManager.GetString("errorContactEmailAddressNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Email: &lt;/strong&gt;Email at row {0} is null..
        /// </summary>
        public static string errorContactEmailNullValue {
            get {
                return ResourceManager.GetString("errorContactEmailNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Job Title: &lt;/strong&gt;Contact Job Title at row {0} is null..
        /// </summary>
        public static string errorContactJobTitleNullValue {
            get {
                return ResourceManager.GetString("errorContactJobTitleNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Contact : &lt;/strong&gt;Representative Nameat row {0} is null..
        /// </summary>
        public static string errorContactNameNullValue {
            get {
                return ResourceManager.GetString("errorContactNameNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please choose  .xlsx file..
        /// </summary>
        public static string errorFileUpload {
            get {
                return ResourceManager.GetString("errorFileUpload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Mobile No: &lt;/strong&gt;Mobile Number at row {0} is null..
        /// </summary>
        public static string errorMobileNullValue {
            get {
                return ResourceManager.GetString("errorMobileNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;No: &lt;/strong&gt;No at row {0} is null..
        /// </summary>
        public static string errorNoNullValue {
            get {
                return ResourceManager.GetString("errorNoNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Company Sector: &lt;/strong&gt;Company Sector at row {0} is null..
        /// </summary>
        public static string errorSectorNullValue {
            get {
                return ResourceManager.GetString("errorSectorNullValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Company Template: &lt;/strong&gt;Company Template is empty..
        /// </summary>
        public static string msgEmptyTemplate {
            get {
                return ResourceManager.GetString("msgEmptyTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This Company is already exists..
        /// </summary>
        public static string msgExistCompany {
            get {
                return ResourceManager.GetString("msgExistCompany", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Company Contact: &lt;/strong&gt;Company and Contact is already exists at row {0} is null..
        /// </summary>
        public static string msgExistContact {
            get {
                return ResourceManager.GetString("msgExistContact", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;span&gt;&lt;strong&gt;Header :&lt;/strong&gt; Invalid Header at column {0} expected &quot;{1}&quot;.&lt;/span&gt;&lt;br/&gt;.
        /// </summary>
        public static string msgInvalidHeader {
            get {
                return ResourceManager.GetString("msgInvalidHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;strong&gt;Max Contact: &lt;/strong&gt;The Company are already have two contact at row {0} is null..
        /// </summary>
        public static string msgMaxContact {
            get {
                return ResourceManager.GetString("msgMaxContact", resourceCulture);
            }
        }
    }
}