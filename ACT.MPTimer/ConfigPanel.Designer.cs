namespace ACT.MPTimer
{
    partial class ConfigPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.TokaRitsuNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ShokikaButton = new System.Windows.Forms.Button();
            this.CountInCombatCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TargetJobComboBox = new System.Windows.Forms.ComboBox();
            this.CountInCombatNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ClickThroughCheckBox = new System.Windows.Forms.CheckBox();
            this.TekiyoButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MPRefreshRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.LogRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressBarShiftTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ProgressBarShiftColorButton = new System.Windows.Forms.Button();
            this.ProgressBarShiftOutlineColorButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.VisualSetting = new ACT.MPTimer.VisualSettingControl();
            this.OverlayLocationXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.OverlayLocationYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPRefreshRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarShiftTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayLocationXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayLocationYNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "オーバーレイの見た目";
            // 
            // FontDialog
            // 
            this.FontDialog.AllowScriptChange = false;
            this.FontDialog.AllowVerticalFonts = false;
            this.FontDialog.ShowEffects = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "透過率";
            // 
            // TokaRitsuNumericUpDown
            // 
            this.TokaRitsuNumericUpDown.Location = new System.Drawing.Point(163, 147);
            this.TokaRitsuNumericUpDown.Name = "TokaRitsuNumericUpDown";
            this.TokaRitsuNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.TokaRitsuNumericUpDown.TabIndex = 6;
            this.TokaRitsuNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TokaRitsuNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ShokikaButton
            // 
            this.ShokikaButton.Location = new System.Drawing.Point(5, 301);
            this.ShokikaButton.Name = "ShokikaButton";
            this.ShokikaButton.Size = new System.Drawing.Size(68, 23);
            this.ShokikaButton.TabIndex = 13;
            this.ShokikaButton.Text = "初期化";
            this.ShokikaButton.UseVisualStyleBackColor = true;
            // 
            // CountInCombatCheckBox
            // 
            this.CountInCombatCheckBox.AutoSize = true;
            this.CountInCombatCheckBox.Location = new System.Drawing.Point(163, 172);
            this.CountInCombatCheckBox.Name = "CountInCombatCheckBox";
            this.CountInCombatCheckBox.Size = new System.Drawing.Size(48, 16);
            this.CountInCombatCheckBox.TabIndex = 7;
            this.CountInCombatCheckBox.Text = "有効";
            this.CountInCombatCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "戦闘中のみ稼働させる";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "特定ジョブのとき稼働させる";
            // 
            // TargetJobComboBox
            // 
            this.TargetJobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetJobComboBox.FormattingEnabled = true;
            this.TargetJobComboBox.Location = new System.Drawing.Point(163, 219);
            this.TargetJobComboBox.Name = "TargetJobComboBox";
            this.TargetJobComboBox.Size = new System.Drawing.Size(216, 20);
            this.TargetJobComboBox.TabIndex = 9;
            // 
            // CountInCombatNumericUpDown
            // 
            this.CountInCombatNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CountInCombatNumericUpDown.Location = new System.Drawing.Point(163, 194);
            this.CountInCombatNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.CountInCombatNumericUpDown.Name = "CountInCombatNumericUpDown";
            this.CountInCombatNumericUpDown.Size = new System.Drawing.Size(63, 19);
            this.CountInCombatNumericUpDown.TabIndex = 8;
            this.CountInCombatNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "秒経過で戦闘終了とみなす";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "クリックスルー";
            // 
            // ClickThroughCheckBox
            // 
            this.ClickThroughCheckBox.AutoSize = true;
            this.ClickThroughCheckBox.Location = new System.Drawing.Point(163, 245);
            this.ClickThroughCheckBox.Name = "ClickThroughCheckBox";
            this.ClickThroughCheckBox.Size = new System.Drawing.Size(48, 16);
            this.ClickThroughCheckBox.TabIndex = 10;
            this.ClickThroughCheckBox.Text = "有効";
            this.ClickThroughCheckBox.UseVisualStyleBackColor = true;
            // 
            // TekiyoButton
            // 
            this.TekiyoButton.Location = new System.Drawing.Point(401, 301);
            this.TekiyoButton.Name = "TekiyoButton";
            this.TekiyoButton.Size = new System.Drawing.Size(68, 23);
            this.TekiyoButton.TabIndex = 12;
            this.TekiyoButton.Text = "適用";
            this.TekiyoButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "ms";
            // 
            // MPRefreshRateNumericUpDown
            // 
            this.MPRefreshRateNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MPRefreshRateNumericUpDown.Location = new System.Drawing.Point(163, 267);
            this.MPRefreshRateNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.MPRefreshRateNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MPRefreshRateNumericUpDown.Name = "MPRefreshRateNumericUpDown";
            this.MPRefreshRateNumericUpDown.Size = new System.Drawing.Size(63, 19);
            this.MPRefreshRateNumericUpDown.TabIndex = 11;
            this.MPRefreshRateNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MPRefreshRateNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "MPの監視間隔";
            // 
            // LogRichTextBox
            // 
            this.LogRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogRichTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.LogRichTextBox.Location = new System.Drawing.Point(5, 330);
            this.LogRichTextBox.Name = "LogRichTextBox";
            this.LogRichTextBox.ReadOnly = true;
            this.LogRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.LogRichTextBox.Size = new System.Drawing.Size(791, 391);
            this.LogRichTextBox.TabIndex = 14;
            this.LogRichTextBox.TabStop = false;
            this.LogRichTextBox.Text = "";
            this.LogRichTextBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "回復までの秒数で色を変える";
            // 
            // ProgressBarShiftTimeNumericUpDown
            // 
            this.ProgressBarShiftTimeNumericUpDown.DecimalPlaces = 2;
            this.ProgressBarShiftTimeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ProgressBarShiftTimeNumericUpDown.Location = new System.Drawing.Point(206, 122);
            this.ProgressBarShiftTimeNumericUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ProgressBarShiftTimeNumericUpDown.Name = "ProgressBarShiftTimeNumericUpDown";
            this.ProgressBarShiftTimeNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.ProgressBarShiftTimeNumericUpDown.TabIndex = 3;
            this.ProgressBarShiftTimeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProgressBarShiftTimeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "回復の";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(277, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "秒前から";
            // 
            // ProgressBarShiftColorButton
            // 
            this.ProgressBarShiftColorButton.Location = new System.Drawing.Point(330, 119);
            this.ProgressBarShiftColorButton.Name = "ProgressBarShiftColorButton";
            this.ProgressBarShiftColorButton.Size = new System.Drawing.Size(53, 23);
            this.ProgressBarShiftColorButton.TabIndex = 4;
            this.ProgressBarShiftColorButton.Text = "バー";
            this.ProgressBarShiftColorButton.UseVisualStyleBackColor = true;
            // 
            // ProgressBarShiftOutlineColorButton
            // 
            this.ProgressBarShiftOutlineColorButton.Location = new System.Drawing.Point(389, 119);
            this.ProgressBarShiftOutlineColorButton.Name = "ProgressBarShiftOutlineColorButton";
            this.ProgressBarShiftOutlineColorButton.Size = new System.Drawing.Size(53, 23);
            this.ProgressBarShiftOutlineColorButton.TabIndex = 5;
            this.ProgressBarShiftOutlineColorButton.Text = "枠";
            this.ProgressBarShiftOutlineColorButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(448, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "色にする";
            // 
            // VisualSetting
            // 
            this.VisualSetting.BarColor = System.Drawing.Color.OrangeRed;
            this.VisualSetting.BarEnabled = true;
            this.VisualSetting.BarOutlineColor = System.Drawing.Color.OrangeRed;
            this.VisualSetting.BarSize = new System.Drawing.Size(110, 7);
            this.VisualSetting.FontColor = System.Drawing.Color.LightGoldenrodYellow;
            this.VisualSetting.FontOutlineColor = System.Drawing.Color.LightGoldenrodYellow;
            this.VisualSetting.Location = new System.Drawing.Point(163, 22);
            this.VisualSetting.Name = "VisualSetting";
            this.VisualSetting.Size = new System.Drawing.Size(306, 65);
            this.VisualSetting.TabIndex = 0;
            this.VisualSetting.TextFont = new System.Drawing.Font("メイリオ", 9.75F);
            // 
            // OverlayLocationXNumericUpDown
            // 
            this.OverlayLocationXNumericUpDown.Location = new System.Drawing.Point(179, 97);
            this.OverlayLocationXNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.OverlayLocationXNumericUpDown.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.OverlayLocationXNumericUpDown.Name = "OverlayLocationXNumericUpDown";
            this.OverlayLocationXNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.OverlayLocationXNumericUpDown.TabIndex = 1;
            this.OverlayLocationXNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OverlayLocationXNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OverlayLocationYNumericUpDown
            // 
            this.OverlayLocationYNumericUpDown.Location = new System.Drawing.Point(280, 97);
            this.OverlayLocationYNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.OverlayLocationYNumericUpDown.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.OverlayLocationYNumericUpDown.Name = "OverlayLocationYNumericUpDown";
            this.OverlayLocationYNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.OverlayLocationYNumericUpDown.TabIndex = 2;
            this.OverlayLocationYNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OverlayLocationYNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(161, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "X";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 12);
            this.label14.TabIndex = 40;
            this.label14.Text = "Y";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 12);
            this.label15.TabIndex = 41;
            this.label15.Text = "オーバーレイの位置";
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.OverlayLocationYNumericUpDown);
            this.Controls.Add(this.OverlayLocationXNumericUpDown);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ProgressBarShiftOutlineColorButton);
            this.Controls.Add(this.ProgressBarShiftColorButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBarShiftTimeNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MPRefreshRateNumericUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TekiyoButton);
            this.Controls.Add(this.VisualSetting);
            this.Controls.Add(this.ClickThroughCheckBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CountInCombatNumericUpDown);
            this.Controls.Add(this.TargetJobComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CountInCombatCheckBox);
            this.Controls.Add(this.ShokikaButton);
            this.Controls.Add(this.TokaRitsuNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LogRichTextBox);
            this.Name = "ConfigPanel";
            this.Size = new System.Drawing.Size(799, 724);
            this.Load += new System.EventHandler(this.ConfigPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPRefreshRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarShiftTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayLocationXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayLocationYNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TokaRitsuNumericUpDown;
        private System.Windows.Forms.Button ShokikaButton;
        private System.Windows.Forms.CheckBox CountInCombatCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TargetJobComboBox;
        private System.Windows.Forms.NumericUpDown CountInCombatNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ClickThroughCheckBox;
        private VisualSettingControl VisualSetting;
        private System.Windows.Forms.Button TekiyoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MPRefreshRateNumericUpDown;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.RichTextBox LogRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ProgressBarShiftTimeNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ProgressBarShiftColorButton;
        private System.Windows.Forms.Button ProgressBarShiftOutlineColorButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown OverlayLocationXNumericUpDown;
        private System.Windows.Forms.NumericUpDown OverlayLocationYNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}
