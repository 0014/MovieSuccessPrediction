namespace IMDB.View
{
    partial class PredictionEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPredict = new DevExpress.XtraEditors.SimpleButton();
            this.cmbActors = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbAgeGap = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbWriter = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbGenre = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbActors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgeGap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWriter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGenre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Actor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Age Gap:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Writer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select Genre:";
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(86, 359);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(102, 23);
            this.btnPredict.TabIndex = 13;
            this.btnPredict.Text = "Predict";
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // cmbActors
            // 
            this.cmbActors.Location = new System.Drawing.Point(26, 85);
            this.cmbActors.Name = "cmbActors";
            this.cmbActors.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbActors.Size = new System.Drawing.Size(119, 20);
            this.cmbActors.TabIndex = 14;
            // 
            // cmbAgeGap
            // 
            this.cmbAgeGap.Location = new System.Drawing.Point(26, 154);
            this.cmbAgeGap.Name = "cmbAgeGap";
            this.cmbAgeGap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAgeGap.Size = new System.Drawing.Size(119, 20);
            this.cmbAgeGap.TabIndex = 15;
            // 
            // cmbWriter
            // 
            this.cmbWriter.Location = new System.Drawing.Point(26, 216);
            this.cmbWriter.Name = "cmbWriter";
            this.cmbWriter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWriter.Size = new System.Drawing.Size(119, 20);
            this.cmbWriter.TabIndex = 16;
            // 
            // cmbGenre
            // 
            this.cmbGenre.Location = new System.Drawing.Point(23, 281);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGenre.Size = new System.Drawing.Size(119, 20);
            this.cmbGenre.TabIndex = 17;
            // 
            // PredictionEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.cmbWriter);
            this.Controls.Add(this.cmbAgeGap);
            this.Controls.Add(this.cmbActors);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PredictionEntry";
            this.Text = "PredictionEntry";
            this.Load += new System.EventHandler(this.PredictionEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbActors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgeGap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWriter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGenre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnPredict;
        private DevExpress.XtraEditors.LookUpEdit cmbActors;
        private DevExpress.XtraEditors.LookUpEdit cmbAgeGap;
        private DevExpress.XtraEditors.LookUpEdit cmbWriter;
        private DevExpress.XtraEditors.LookUpEdit cmbGenre;
    }
}