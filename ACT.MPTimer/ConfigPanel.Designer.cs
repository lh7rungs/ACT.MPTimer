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
            this.VisualSetting = new ACT.MPTimer.VisualSettingControl();
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPRefreshRateNumericUpDown)).BeginInit();
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
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "透過率";
            // 
            // TokaRitsuNumericUpDown
            // 
            this.TokaRitsuNumericUpDown.Location = new System.Drawing.Point(163, 94);
            this.TokaRitsuNumericUpDown.Name = "TokaRitsuNumericUpDown";
            this.TokaRitsuNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.TokaRitsuNumericUpDown.TabIndex = 5;
            this.TokaRitsuNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TokaRitsuNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ShokikaButton
            // 
            this.ShokikaButton.Location = new System.Drawing.Point(5, 286);
            this.ShokikaButton.Name = "ShokikaButton";
            this.ShokikaButton.Size = new System.Drawing.Size(68, 23);
            this.ShokikaButton.TabIndex = 10;
            this.ShokikaButton.Text = "初期化";
            this.ShokikaButton.UseVisualStyleBackColor = true;
            // 
            // CountInCombatCheckBox
            // 
            this.CountInCombatCheckBox.AutoSize = true;
            this.CountInCombatCheckBox.Location = new System.Drawing.Point(163, 119);
            this.CountInCombatCheckBox.Name = "CountInCombatCheckBox";
            this.CountInCombatCheckBox.Size = new System.Drawing.Size(48, 16);
            this.CountInCombatCheckBox.TabIndex = 6;
            this.CountInCombatCheckBox.Text = "有効";
            this.CountInCombatCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "戦闘中のみ稼働させる";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "特定ジョブのとき稼働させる";
            // 
            // TargetJobComboBox
            // 
            this.TargetJobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetJobComboBox.FormattingEnabled = true;
            this.TargetJobComboBox.Location = new System.Drawing.Point(163, 166);
            this.TargetJobComboBox.Name = "TargetJobComboBox";
            this.TargetJobComboBox.Size = new System.Drawing.Size(216, 20);
            this.TargetJobComboBox.TabIndex = 8;
            // 
            // CountInCombatNumericUpDown
            // 
            this.CountInCombatNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CountInCombatNumericUpDown.Location = new System.Drawing.Point(163, 141);
            this.CountInCombatNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.CountInCombatNumericUpDown.Name = "CountInCombatNumericUpDown";
            this.CountInCombatNumericUpDown.Size = new System.Drawing.Size(63, 19);
            this.CountInCombatNumericUpDown.TabIndex = 7;
            this.CountInCombatNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "秒経過で戦闘終了とみなす";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "クリックスルー";
            // 
            // ClickThroughCheckBox
            // 
            this.ClickThroughCheckBox.AutoSize = true;
            this.ClickThroughCheckBox.Location = new System.Drawing.Point(163, 192);
            this.ClickThroughCheckBox.Name = "ClickThroughCheckBox";
            this.ClickThroughCheckBox.Size = new System.Drawing.Size(48, 16);
            this.ClickThroughCheckBox.TabIndex = 9;
            this.ClickThroughCheckBox.Text = "有効";
            this.ClickThroughCheckBox.UseVisualStyleBackColor = true;
            // 
            // TekiyoButton
            // 
            this.TekiyoButton.Location = new System.Drawing.Point(401, 286);
            this.TekiyoButton.Name = "TekiyoButton";
            this.TekiyoButton.Size = new System.Drawing.Size(68, 23);
            this.TekiyoButton.TabIndex = 22;
            this.TekiyoButton.Text = "適用";
            this.TekiyoButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "ms";
            // 
            // MPRefreshRateNumericUpDown
            // 
            this.MPRefreshRateNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MPRefreshRateNumericUpDown.Location = new System.Drawing.Point(163, 214);
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
            this.MPRefreshRateNumericUpDown.TabIndex = 27;
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
            this.label10.Location = new System.Drawing.Point(3, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "MPの監視間隔";
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
            this.VisualSetting.TabIndex = 21;
            this.VisualSetting.TextFont = new System.Drawing.Font("メイリオ", 9.75F);
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "ConfigPanel";
            this.Size = new System.Drawing.Size(483, 323);
            this.Load += new System.EventHandler(this.ConfigPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MPRefreshRateNumericUpDown)).EndInit();
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
    }
}
