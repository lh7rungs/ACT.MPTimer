﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.34014
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ACT.MPTimer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2000-01-01")]
        public global::System.DateTime LastUpdateDatetime {
            get {
                return ((global::System.DateTime)(this["LastUpdateDatetime"]));
            }
            set {
                this["LastUpdateDatetime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int ProgressBarHeight {
            get {
                return ((int)(this["ProgressBarHeight"]));
            }
            set {
                this["ProgressBarHeight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("150")]
        public int ProgressBarWidth {
            get {
                return ((int)(this["ProgressBarWidth"]));
            }
            set {
                this["ProgressBarWidth"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OrangeRed")]
        public global::System.Drawing.Color OverlayColor {
            get {
                return ((global::System.Drawing.Color)(this["OverlayColor"]));
            }
            set {
                this["OverlayColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("メイリオ, 9.75pt")]
        public global::System.Drawing.Font OverlayFont {
            get {
                return ((global::System.Drawing.Font)(this["OverlayFont"]));
            }
            set {
                this["OverlayFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int OverlayLeft {
            get {
                return ((int)(this["OverlayLeft"]));
            }
            set {
                this["OverlayLeft"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int OverlayTop {
            get {
                return ((int)(this["OverlayTop"]));
            }
            set {
                this["OverlayTop"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DimGray")]
        public global::System.Drawing.Color OverlayFontColor {
            get {
                return ((global::System.Drawing.Color)(this["OverlayFontColor"]));
            }
            set {
                this["OverlayFontColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("35")]
        public int OverlayOpacity {
            get {
                return ((int)(this["OverlayOpacity"]));
            }
            set {
                this["OverlayOpacity"] = value;
            }
        }
    }
}
