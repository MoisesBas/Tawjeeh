﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tawjeeh.Repositories.Resources {
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
    internal class ArticleMultimediaQuery {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ArticleMultimediaQuery() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tawjeeh.Repositories.Resources.ArticleMultimediaQuery", typeof(ArticleMultimediaQuery).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @&quot;Select * FROM tblArticleMultimedia am where am.IsDeleted=0;&quot;.
        /// </summary>
        internal static string GetArticleMultimediaAll {
            get {
                return ResourceManager.GetString("GetArticleMultimediaAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @&quot;Select * FROM tblArticleMultimedia am 
        ///                          WHERE am.ArticleId = @articleId and am.IsDeleted=0;&quot;.
        /// </summary>
        internal static string GetArticleMultimediaByArticleId {
            get {
                return ResourceManager.GetString("GetArticleMultimediaByArticleId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @&quot;Select * FROM tblArticleMultimedia am 
        ///                          WHERE am.ArticleId = @articleId and am.LangId=@langId and am.IsDeleted=0&quot;;.
        /// </summary>
        internal static string GetArticleMultimediaByArticleIdAndLangId {
            get {
                return ResourceManager.GetString("GetArticleMultimediaByArticleIdAndLangId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @&quot;Select * FROM tblArticleMultimedia am 
        ///                          WHERE am.Id = @Id and am.IsDeleted=0;&quot;.
        /// </summary>
        internal static string GetArticleMultimediaById {
            get {
                return ResourceManager.GetString("GetArticleMultimediaById", resourceCulture);
            }
        }
    }
}
