namespace GOST
{
    partial class GOST
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GOST));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripShifr = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeshifr = new System.Windows.Forms.ToolStripButton();
            this.toolStripAttach = new System.Windows.Forms.ToolStripButton();
            this.toolStripCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripCutOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripInfo = new System.Windows.Forms.ToolStripButton();
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.textBoxProcessed = new System.Windows.Forms.TextBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelProcessed = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShifr,
            this.toolStripDeshifr,
            this.toolStripAttach,
            this.toolStripCopy,
            this.toolStripCutOut,
            this.toolStripSave,
            this.toolStripInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(798, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripShifr
            // 
            this.toolStripShifr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripShifr.Image = ((System.Drawing.Image)(resources.GetObject("toolStripShifr.Image")));
            this.toolStripShifr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripShifr.Name = "toolStripShifr";
            this.toolStripShifr.Size = new System.Drawing.Size(23, 22);
            this.toolStripShifr.Text = "toolStripButton1";
            this.toolStripShifr.Click += new System.EventHandler(this.toolStripShifr_Click);
            // 
            // toolStripDeshifr
            // 
            this.toolStripDeshifr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDeshifr.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeshifr.Image")));
            this.toolStripDeshifr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeshifr.Name = "toolStripDeshifr";
            this.toolStripDeshifr.Size = new System.Drawing.Size(23, 22);
            this.toolStripDeshifr.Text = "toolStripButton2";
            // 
            // toolStripAttach
            // 
            this.toolStripAttach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAttach.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAttach.Image")));
            this.toolStripAttach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAttach.Name = "toolStripAttach";
            this.toolStripAttach.Size = new System.Drawing.Size(23, 22);
            this.toolStripAttach.Text = "toolStripButton3";
            // 
            // toolStripCopy
            // 
            this.toolStripCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopy.Image")));
            this.toolStripCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCopy.Name = "toolStripCopy";
            this.toolStripCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripCopy.Text = "toolStripButton4";
            this.toolStripCopy.Click += new System.EventHandler(this.toolStripCopy_Click);
            // 
            // toolStripCutOut
            // 
            this.toolStripCutOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCutOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCutOut.Image")));
            this.toolStripCutOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCutOut.Name = "toolStripCutOut";
            this.toolStripCutOut.Size = new System.Drawing.Size(23, 22);
            this.toolStripCutOut.Text = "toolStripButton5";
            this.toolStripCutOut.Click += new System.EventHandler(this.toolStripCutOut_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSave.Image")));
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripSave.Text = "toolStripButton6";
            // 
            // toolStripInfo
            // 
            this.toolStripInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripInfo.Image")));
            this.toolStripInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInfo.Name = "toolStripInfo";
            this.toolStripInfo.Size = new System.Drawing.Size(23, 22);
            this.toolStripInfo.Text = "toolStripButton7";
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOriginal.Location = new System.Drawing.Point(12, 58);
            this.textBoxOriginal.Multiline = true;
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.Size = new System.Drawing.Size(370, 380);
            this.textBoxOriginal.TabIndex = 1;
            // 
            // textBoxProcessed
            // 
            this.textBoxProcessed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProcessed.Location = new System.Drawing.Point(415, 58);
            this.textBoxProcessed.Multiline = true;
            this.textBoxProcessed.Name = "textBoxProcessed";
            this.textBoxProcessed.ReadOnly = true;
            this.textBoxProcessed.Size = new System.Drawing.Size(370, 380);
            this.textBoxProcessed.TabIndex = 2;
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOriginal.Location = new System.Drawing.Point(12, 37);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(131, 19);
            this.labelOriginal.TabIndex = 3;
            this.labelOriginal.Text = "Исходные данные";
            // 
            // labelProcessed
            // 
            this.labelProcessed.AutoSize = true;
            this.labelProcessed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProcessed.Location = new System.Drawing.Point(411, 37);
            this.labelProcessed.Name = "labelProcessed";
            this.labelProcessed.Size = new System.Drawing.Size(165, 19);
            this.labelProcessed.TabIndex = 4;
            this.labelProcessed.Text = "Обработанные данные";
            // 
            // GOST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.labelProcessed);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.textBoxProcessed);
            this.Controls.Add(this.textBoxOriginal);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GOST";
            this.Text = "Шифрование ГОСТ";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripShifr;
        private System.Windows.Forms.ToolStripButton toolStripDeshifr;
        private System.Windows.Forms.ToolStripButton toolStripAttach;
        private System.Windows.Forms.ToolStripButton toolStripCopy;
        private System.Windows.Forms.ToolStripButton toolStripCutOut;
        private System.Windows.Forms.ToolStripButton toolStripSave;
        private System.Windows.Forms.ToolStripButton toolStripInfo;
        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.TextBox textBoxProcessed;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelProcessed;
    }
}

