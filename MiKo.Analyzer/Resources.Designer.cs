﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiKoSolutions.Analyzers {
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
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MiKoSolutions.Analyzers.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Methods should be short to ease reading and maintenance (SRP)..
        /// </summary>
        public static string MiKo_0001_Description {
            get {
                return ResourceManager.GetString("MiKo_0001_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; has {1} LoC (allowed: {2}).
        /// </summary>
        public static string MiKo_0001_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_0001_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method is too long.
        /// </summary>
        public static string MiKo_0001_Title {
            get {
                return ResourceManager.GetString("MiKo_0001_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Methods should be simple to ease maintenance (KISS).
        ///Following code constructs increase the Cyclomatic Complexity (CC) by +1:
        ///    if | while | for | foreach | case | continue | goto | &amp;&amp; | || | catch | ternary operator ?: | ?? | ?..
        /// </summary>
        public static string MiKo_0002_Description {
            get {
                return ResourceManager.GetString("MiKo_0002_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; has a CC of {1} (allowed: {2}).
        /// </summary>
        public static string MiKo_0002_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_0002_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method is too complex..
        /// </summary>
        public static string MiKo_0002_Title {
            get {
                return ResourceManager.GetString("MiKo_0002_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Types should be limited in their size to ease reading and maintenance (SRP)..
        /// </summary>
        public static string MiKo_0003_Description {
            get {
                return ResourceManager.GetString("MiKo_0003_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type &apos;{0}&apos; has {1} LoC (allowed: {2}).
        /// </summary>
        public static string MiKo_0003_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_0003_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type is too long.
        /// </summary>
        public static string MiKo_0003_Title {
            get {
                return ResourceManager.GetString("MiKo_0003_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To ease maintenance, parameters that inherit from &apos;System.EventArgs&apos; should be named &apos;e&apos; ..
        /// </summary>
        public static string MiKo_1001_Description {
            get {
                return ResourceManager.GetString("MiKo_1001_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{1}&apos; should be named &apos;{2}&apos;.
        /// </summary>
        public static string MiKo_1001_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1001_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;System.EventArgs&apos; parameters on methods should be named properly..
        /// </summary>
        public static string MiKo_1001_Title {
            get {
                return ResourceManager.GetString("MiKo_1001_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To follow the .NET Framework Guidelines, parameters of event handlers should be named &apos;sender&apos; and &apos;e&apos;..
        /// </summary>
        public static string MiKo_1002_Description {
            get {
                return ResourceManager.GetString("MiKo_1002_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{1}&apos; should be named &apos;{2}&apos;.
        /// </summary>
        public static string MiKo_1002_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1002_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter names do not follow .NET Framework Guidelines for event handlers..
        /// </summary>
        public static string MiKo_1002_Title {
            get {
                return ResourceManager.GetString("MiKo_1002_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Event handlers should start with &apos;On&apos; to indicate that they handle events..
        /// </summary>
        public static string MiKo_1003_Description {
            get {
                return ResourceManager.GetString("MiKo_1003_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1003_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1003_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name of event handler does not follow the .NET Framework Best Practices..
        /// </summary>
        public static string MiKo_1003_Title {
            get {
                return ResourceManager.GetString("MiKo_1003_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;Event&apos; as suffix in event names are noise and should be avoided..
        /// </summary>
        public static string MiKo_1004_Description {
            get {
                return ResourceManager.GetString("MiKo_1004_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1004_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1004_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Events should not contain term &apos;Event&apos; in their names.
        /// </summary>
        public static string MiKo_1004_Title {
            get {
                return ResourceManager.GetString("MiKo_1004_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The purpose of methods is to execute code, so it&apos;s useless and repetitive to have &apos;CanExecute&apos; or &apos;Execute&apos; in their names..
        /// </summary>
        public static string MiKo_1010_Description {
            get {
                return ResourceManager.GetString("MiKo_1010_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1010_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1010_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Methods should not contain &apos;Do&apos; in their names..
        /// </summary>
        public static string MiKo_1010_Title {
            get {
                return ResourceManager.GetString("MiKo_1010_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The purpose of methods is to execute code, so it&apos;s useless and repetitive to have &apos;Do&apos; in their names..
        /// </summary>
        public static string MiKo_1011_Description {
            get {
                return ResourceManager.GetString("MiKo_1011_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1011_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1011_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Methods should not contain &apos;CanExecute&apos; or &apos;Execute&apos; in their names..
        /// </summary>
        public static string MiKo_1011_Title {
            get {
                return ResourceManager.GetString("MiKo_1011_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The term &apos;Fire&apos; is a negative term. Employees get fired (or guns), but not events. Events get raised. So use &apos;Raise&apos; instead..
        /// </summary>
        public static string MiKo_1012_Description {
            get {
                return ResourceManager.GetString("MiKo_1012_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1012_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1012_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Methods should not be named &apos;Fire&apos;.
        /// </summary>
        public static string MiKo_1012_Title {
            get {
                return ResourceManager.GetString("MiKo_1012_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Names that have a lot of characters are hard to read when being used. This makes writing code and doing code reviews much harder..
        /// </summary>
        public static string MiKo_1020_Description {
            get {
                return ResourceManager.GetString("MiKo_1020_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type &apos;{0}&apos; exceeds limit of {2} characters (by {1}).
        /// </summary>
        public static string MiKo_1020_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1020_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type names should be limited in length.
        /// </summary>
        public static string MiKo_1020_Title {
            get {
                return ResourceManager.GetString("MiKo_1020_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Names that have a lot of characters are hard to read when being used. This makes writing code and doing code reviews much harder..
        /// </summary>
        public static string MiKo_1021_Description {
            get {
                return ResourceManager.GetString("MiKo_1021_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method &apos;{0}&apos; exceeds limit of {2} characters (by {1}).
        /// </summary>
        public static string MiKo_1021_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1021_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method names should be limited in length.
        /// </summary>
        public static string MiKo_1021_Title {
            get {
                return ResourceManager.GetString("MiKo_1021_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Names that have a lot of characters are hard to read when being used. This makes writing code and doing code reviews much harder..
        /// </summary>
        public static string MiKo_1022_Description {
            get {
                return ResourceManager.GetString("MiKo_1022_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter &apos;{0}&apos; exceeds limit of {2} characters (by {1}).
        /// </summary>
        public static string MiKo_1022_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1022_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter names should be limited in length.
        /// </summary>
        public static string MiKo_1022_Title {
            get {
                return ResourceManager.GetString("MiKo_1022_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Names that have a lot of characters are hard to read when being used. This makes writing code and doing code reviews much harder..
        /// </summary>
        public static string MiKo_1023_Description {
            get {
                return ResourceManager.GetString("MiKo_1023_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Field &apos;{0}&apos; exceeds limit of {2} characters (by {1}).
        /// </summary>
        public static string MiKo_1023_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1023_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Field names should be limited in length.
        /// </summary>
        public static string MiKo_1023_Title {
            get {
                return ResourceManager.GetString("MiKo_1023_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Names that have a lot of characters are hard to read when being used. This makes writing code and doing code reviews much harder..
        /// </summary>
        public static string MiKo_1024_Description {
            get {
                return ResourceManager.GetString("MiKo_1024_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; exceeds limit of {2} characters (by {1}).
        /// </summary>
        public static string MiKo_1024_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1024_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property names should be limited in length.
        /// </summary>
        public static string MiKo_1024_Title {
            get {
                return ResourceManager.GetString("MiKo_1024_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Names that have a lot of characters are hard to read when being used. This makes writing code and doing code reviews much harder..
        /// </summary>
        public static string MiKo_1025_Description {
            get {
                return ResourceManager.GetString("MiKo_1025_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Event &apos;{0}&apos; exceeds limit of {2} characters (by {1}).
        /// </summary>
        public static string MiKo_1025_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1025_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Event names should be limited in length.
        /// </summary>
        public static string MiKo_1025_Title {
            get {
                return ResourceManager.GetString("MiKo_1025_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Indicating that a type is a base type by putting &apos;Base&apos; in its name does not make sense. Every interface or class that is not sealed can act as a base class..
        /// </summary>
        public static string MiKo_1030_Description {
            get {
                return ResourceManager.GetString("MiKo_1030_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1030_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1030_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Types should not have a &apos;Base&apos; marker to indicate that they are base types.
        /// </summary>
        public static string MiKo_1030_Title {
            get {
                return ResourceManager.GetString("MiKo_1030_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Indicating that a type is an entity by using &apos;Model&apos; as its suffix does not make sense. Entities should not be suffixed at all (eg. &apos;User&apos; instead of &apos;UserModel&apos;).
        /// </summary>
        public static string MiKo_1031_Description {
            get {
                return ResourceManager.GetString("MiKo_1031_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1031_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1031_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entity types should not use a &apos;Model&apos; suffix.
        /// </summary>
        public static string MiKo_1031_Title {
            get {
                return ResourceManager.GetString("MiKo_1031_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Suffixes on parameter names (such as &apos;List&apos;) are noise and should be avoided..
        /// </summary>
        public static string MiKo_1040_Description {
            get {
                return ResourceManager.GetString("MiKo_1040_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1040_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1040_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameters should not be suffixed with implementation details..
        /// </summary>
        public static string MiKo_1040_Title {
            get {
                return ResourceManager.GetString("MiKo_1040_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Suffixes on field names (such as &apos;List&apos;) are noise and should be avoided..
        /// </summary>
        public static string MiKo_1041_Description {
            get {
                return ResourceManager.GetString("MiKo_1041_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be named &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_1041_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_1041_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fields should not be suffixed with implementation details..
        /// </summary>
        public static string MiKo_1041_Title {
            get {
                return ResourceManager.GetString("MiKo_1041_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The XML documentation should be valid XML so that it can be generated to support the developers..
        /// </summary>
        public static string MiKo_2000_Description {
            get {
                return ResourceManager.GetString("MiKo_2000_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XML documention is malformed (contains invalid characters, eg. &apos;&amp;&apos;).
        /// </summary>
        public static string MiKo_2000_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_2000_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XML documentation should be valid XML..
        /// </summary>
        public static string MiKo_2000_Title {
            get {
                return ResourceManager.GetString("MiKo_2000_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Documentation of events should start with &apos;Occurs&apos; to indicate that events occur..
        /// </summary>
        public static string MiKo_2001_Description {
            get {
                return ResourceManager.GetString("MiKo_2001_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XML summary should start with: &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_2001_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_2001_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Events should be documented properly..
        /// </summary>
        public static string MiKo_2001_Title {
            get {
                return ResourceManager.GetString("MiKo_2001_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Event method parameters should define what exactly they are..
        /// </summary>
        public static string MiKo_2002_Description {
            get {
                return ResourceManager.GetString("MiKo_2002_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XML comment for &apos;{1}&apos; should be : &apos;{2}&apos;.
        /// </summary>
        public static string MiKo_2002_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_2002_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Documentation of parameter name does not follow .NET Framework Guidelines for event handlers..
        /// </summary>
        public static string MiKo_2002_Title {
            get {
                return ResourceManager.GetString("MiKo_2002_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To ease their usage when it comes to inheritance, sealed classes should document the fact that they are sealed..
        /// </summary>
        public static string MiKo_2010_Description {
            get {
                return ResourceManager.GetString("MiKo_2010_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XML summary should end with: &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_2010_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_2010_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sealed classes should document being sealed.
        /// </summary>
        public static string MiKo_2010_Title {
            get {
                return ResourceManager.GetString("MiKo_2010_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsealed classes should not report that they are sealed..
        /// </summary>
        public static string MiKo_2011_Description {
            get {
                return ResourceManager.GetString("MiKo_2011_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XML summary should not contain: &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_2011_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_2011_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsealed classes should not lie about sealing..
        /// </summary>
        public static string MiKo_2011_Title {
            get {
                return ResourceManager.GetString("MiKo_2011_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The term &apos;Fire&apos; is a negative term. Employees get fired (or guns), but not events. Events get raised. So use &apos;Raise&apos; instead..
        /// </summary>
        public static string MiKo_2012_Description {
            get {
                return ResourceManager.GetString("MiKo_2012_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should be &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_2012_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_2012_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Documentation should use &apos;raise&apos; instead of &apos;fire&apos;..
        /// </summary>
        public static string MiKo_2012_Title {
            get {
                return ResourceManager.GetString("MiKo_2012_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To ease their usage, enums should specify what kind of values they define..
        /// </summary>
        public static string MiKo_2013_Description {
            get {
                return ResourceManager.GetString("MiKo_2013_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XML summary should start with: &apos;{1}&apos;.
        /// </summary>
        public static string MiKo_2013_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_2013_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enums XML summary should have a default starting phrase.
        /// </summary>
        public static string MiKo_2013_Title {
            get {
                return ResourceManager.GetString("MiKo_2013_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To follow the SRP, methods should have as few parameters as possible..
        /// </summary>
        public static string MiKo_3001_Description {
            get {
                return ResourceManager.GetString("MiKo_3001_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; has {1} parameters (allowed: {2}).
        /// </summary>
        public static string MiKo_3001_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_3001_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Methods should not have too many parameters..
        /// </summary>
        public static string MiKo_3001_Title {
            get {
                return ResourceManager.GetString("MiKo_3001_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If a class has too many dependencies, that class is doing too much and does not follow the SRP..
        /// </summary>
        public static string MiKo_3002_Description {
            get {
                return ResourceManager.GetString("MiKo_3002_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; has {1} MEF dependencies (allowed: {2}).
        /// </summary>
        public static string MiKo_3002_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_3002_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Classes should not have too many dependencies.
        /// </summary>
        public static string MiKo_3002_Title {
            get {
                return ResourceManager.GetString("MiKo_3002_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To ease usage, events should follow the .NET Framework Guidelines..
        /// </summary>
        public static string MiKo_3003_Description {
            get {
                return ResourceManager.GetString("MiKo_3003_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; should use &apos;EventHandler&apos; or &apos;EventHandler&lt;T&gt;&apos;.
        /// </summary>
        public static string MiKo_3003_MessageFormat {
            get {
                return ResourceManager.GetString("MiKo_3003_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Events should follow .NET Framework Guidelines for events..
        /// </summary>
        public static string MiKo_3003_Title {
            get {
                return ResourceManager.GetString("MiKo_3003_Title", resourceCulture);
            }
        }
    }
}
