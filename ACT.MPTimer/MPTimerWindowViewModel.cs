namespace ACT.MPTimer
{
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Media;

    using ACT.MPTimer.Properties;
    using ACT.MPTimer.Utility;

    [Export(typeof(MPTimerWindowViewModel))]
    public class MPTimerWindowViewModel : INotifyPropertyChanged
    {
        private double opacity;
        private double timeToRecovery = default(double);
        private SolidColorBrush progressBarForeground;
        private SolidColorBrush progressBarBackground;
        private SolidColorBrush progressBarStroke;
        private SolidColorBrush fontFill;
        private SolidColorBrush fontStroke;
        private double progressBarForegroundWidth;
        private string timeToRecoveryText;
        private bool inCombat;
        private bool visible;

        private SolidColorBrush progressBarForegroundDefault;
        private SolidColorBrush progressBarBackgroundDefault;
        private SolidColorBrush progressBarStrokeDefault;
        private SolidColorBrush progressBarForegroundShift;
        private SolidColorBrush progressBarBackgroundShift;
        private SolidColorBrush progressBarStrokeShift;

        public MPTimerWindowViewModel()
        {
            this.ReloadSettings();

#if DEBUG
            this.visible = true;
            this.inCombat = true;
#endif
        }


        public double Left
        {
            get { return (double)Settings.Default.OverlayLeft; }
            set
            {
                Settings.Default.OverlayLeft = (int)value;
                this.RaisePropertyChanged();
            }
        }

        public double Top
        {
            get { return (double)Settings.Default.OverlayTop; }
            set
            {
                Settings.Default.OverlayTop = (int)value;
                this.RaisePropertyChanged();
            }
        }

        public double Opacity
        {
            get
            {
                if (!this.visible)
                {
                    return 0.0d;
                }

                if (Settings.Default.CountInCombat &&
                    !this.inCombat)
                {
                    return 0.0d;
                }

                return this.opacity;
            }
        }

        public bool InCombat
        {
            get { return this.inCombat; }
            set
            {
                if (this.inCombat != value)
                {
                    this.inCombat = value;
                    this.RaisePropertyChanged("Opacity");
                }
            }
        }

        public bool Visible
        {
            get { return this.visible; }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;
                    this.RaisePropertyChanged("Opacity");
                }
            }
        }

        public double TimeToRecovery
        {
            get { return this.timeToRecovery; }
            set
            {
                if (this.timeToRecovery != value)
                {
                    this.timeToRecovery = value;

                    // プログレスバーの幅を計算する
                    var rateOfRecovery =
                        ((Constants.MPRecoverySpan * 1000d) - this.timeToRecovery) /
                        (Constants.MPRecoverySpan * 1000d);

                    this.ProgressBarForegroundWidth =
                        (double)Settings.Default.ProgressBarSize.Width * rateOfRecovery;

                    // 残り秒数の表示を編集する
                    this.TimeToRecoveryText =
                        (this.timeToRecovery / 1000d).ToString("N1");

                    // 残り秒数でプログレスバーの色を変更する
                    if (Settings.Default.ProgressBarShiftTime > 0.0d)
                    {
                        if (this.timeToRecovery <= (Settings.Default.ProgressBarShiftTime * 1000d))
                        {
                            this.progressBarForeground = this.progressBarForegroundShift;
                            this.progressBarBackground = this.progressBarBackgroundShift;
                            this.progressBarStroke = this.progressBarStrokeShift;
                        }
                        else
                        {
                            this.progressBarForeground = this.progressBarForegroundDefault;
                            this.progressBarBackground = this.progressBarBackgroundDefault;
                            this.progressBarStroke = this.progressBarStrokeDefault;
                        }

                        this.RaisePropertyChanged("ProgressBarForeground");
                        this.RaisePropertyChanged("ProgressBarBackground");
                        this.RaisePropertyChanged("ProgressBarStroke");
                    }
                }
            }
        }

        public SolidColorBrush ProgressBarForeground
        {
            get { return this.progressBarForeground; }
        }


        public SolidColorBrush ProgressBarBackground
        {
            get { return this.progressBarBackground; }
        }

        public SolidColorBrush ProgressBarStroke
        {
            get { return this.progressBarStroke; }
        }

        public double ProgressBarWidth
        {
            get { return Settings.Default.ProgressBarSize.Width; }
        }

        public double ProgressBarHeight
        {
            get { return Settings.Default.ProgressBarSize.Height; }
        }

        public double ProgressBarForegroundWidth
        {
            get { return this.progressBarForegroundWidth; }
            set
            {
                if (this.progressBarForegroundWidth != value)
                {
                    this.progressBarForegroundWidth = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public FontFamily FontFamily
        {
            get { return Settings.Default.Font.ToFontFamilyWPF(); }
        }

        public double FontSize
        {
            get { return Settings.Default.Font.ToFontSizeWPF(); }
        }

        public FontStyle FontStyle
        {
            get { return Settings.Default.Font.ToFontStyleWPF(); }
        }

        public FontWeight FontWeight
        {
            get { return Settings.Default.Font.ToFontWeightWPF(); }
        }

        public SolidColorBrush FontFill
        {
            get { return this.fontFill; }
        }

        public SolidColorBrush FontStroke
        {
            get { return this.fontStroke; }
        }

        public double FontStrokeThickness
        {
            get { return 0.5d * this.FontSize / 13.0d; }
        }

        public string TimeToRecoveryText
        {
            get { return this.timeToRecoveryText; }
            set
            {
                if (this.timeToRecoveryText != value)
                {
                    this.timeToRecoveryText = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public void ReloadSettings()
        {
            this.opacity = (100.0d - Settings.Default.OverlayOpacity) / 100.0d;

            this.progressBarForegroundDefault = new SolidColorBrush(Settings.Default.ProgressBarColor.ToWPF());
            this.progressBarBackgroundDefault = new SolidColorBrush(this.progressBarForegroundDefault.Color.ChangeBrightness(0.4d));
            this.progressBarStrokeDefault = new SolidColorBrush(Settings.Default.ProgressBarOutlineColor.ToWPF());
            this.progressBarForegroundShift = new SolidColorBrush(Settings.Default.ProgressBarShiftColor.ToWPF());
            this.progressBarBackgroundShift = new SolidColorBrush(this.progressBarForegroundShift.Color.ChangeBrightness(0.4d));
            this.progressBarStrokeShift = new SolidColorBrush(Settings.Default.ProgressBarOutlineShiftColor.ToWPF());

            this.fontFill = new SolidColorBrush(Settings.Default.FontColor.ToWPF());
            this.fontStroke = new SolidColorBrush(Settings.Default.FontOutlineColor.ToWPF());

            this.progressBarForegroundDefault.Freeze();
            this.progressBarBackgroundDefault.Freeze();
            this.progressBarStrokeDefault.Freeze();
            this.progressBarForegroundShift.Freeze();
            this.progressBarBackgroundShift.Freeze();
            this.progressBarStrokeShift.Freeze();
            this.fontFill.Freeze();
            this.fontStroke.Freeze();

            this.progressBarForeground = this.progressBarForegroundDefault;
            this.progressBarBackground = this.progressBarBackgroundDefault;
            this.progressBarStroke = this.progressBarStrokeDefault;

            this.RaisePropertyChanged("Opacity");
            this.RaisePropertyChanged("ProgressBarForegroundWidth");
            this.RaisePropertyChanged("ProgressBarForeground");
            this.RaisePropertyChanged("ProgressBarBackground");
            this.RaisePropertyChanged("ProgressBarStroke");
            this.RaisePropertyChanged("ProgressBarWidth");
            this.RaisePropertyChanged("ProgressBarHeight");
            this.RaisePropertyChanged("ProgressBarForeWidth");
            this.RaisePropertyChanged("FontFamily");
            this.RaisePropertyChanged("FontSize");
            this.RaisePropertyChanged("FontStyle");
            this.RaisePropertyChanged("FontWeight");
            this.RaisePropertyChanged("FontFill");
            this.RaisePropertyChanged("FontStroke");
            this.RaisePropertyChanged("FontStrokeThickness");
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion
    }
}
