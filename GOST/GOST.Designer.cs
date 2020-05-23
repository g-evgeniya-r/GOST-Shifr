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
            this.toolStripCutOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripInfo = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemInfoAboutTheProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemInfoHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDemo = new System.Windows.Forms.ToolStripButton();
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.textBoxProcessed = new System.Windows.Forms.TextBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.labelProcessed = new System.Windows.Forms.Label();
            this.buttonCarryover = new System.Windows.Forms.Button();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayerOriginal = new AxWMPLib.AxWindowsMediaPlayer();
            this.labelDemoInfo1 = new System.Windows.Forms.Label();
            this.textBoxL01 = new System.Windows.Forms.TextBox();
            this.textBoxL03 = new System.Windows.Forms.TextBox();
            this.labelL0R1 = new System.Windows.Forms.Label();
            this.labelR0R0 = new System.Windows.Forms.Label();
            this.labelDemoInfo3 = new System.Windows.Forms.Label();
            this.labelX0 = new System.Windows.Forms.Label();
            this.textBoxL04 = new System.Windows.Forms.TextBox();
            this.textBoxL02 = new System.Windows.Forms.TextBox();
            this.textBoxR01 = new System.Windows.Forms.TextBox();
            this.textBoxR02 = new System.Windows.Forms.TextBox();
            this.textBoxR03 = new System.Windows.Forms.TextBox();
            this.textBoxR04 = new System.Windows.Forms.TextBox();
            this.textBoxX01 = new System.Windows.Forms.TextBox();
            this.textBoxX02 = new System.Windows.Forms.TextBox();
            this.textBoxX03 = new System.Windows.Forms.TextBox();
            this.textBoxX04 = new System.Windows.Forms.TextBox();
            this.textBoxR13 = new System.Windows.Forms.TextBox();
            this.textBoxR11 = new System.Windows.Forms.TextBox();
            this.textBoxR12 = new System.Windows.Forms.TextBox();
            this.labelDemoInfo2 = new System.Windows.Forms.Label();
            this.labelR0 = new System.Windows.Forms.Label();
            this.labelR1 = new System.Windows.Forms.Label();
            this.buttonFurther = new System.Windows.Forms.Button();
            this.pictureBoxDemoShifr0 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDemoShifr1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDemoShifr2 = new System.Windows.Forms.PictureBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.pictureBoxDemoDeshifr0 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDemoDeshifr1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDemoDeshifr2 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoShifr0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoShifr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoShifr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoDeshifr0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoDeshifr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoDeshifr2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShifr,
            this.toolStripDeshifr,
            this.toolStripAttach,
            this.toolStripCutOut,
            this.toolStripInfo,
            this.toolStripSeparator1,
            this.toolStripDemo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(798, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripShifr
            // 
            this.toolStripShifr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripShifr.Image = ((System.Drawing.Image)(resources.GetObject("toolStripShifr.Image")));
            this.toolStripShifr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripShifr.Name = "toolStripShifr";
            this.toolStripShifr.Size = new System.Drawing.Size(24, 24);
            this.toolStripShifr.Text = "Зашифровать";
            this.toolStripShifr.Click += new System.EventHandler(this.toolStripShifr_Click);
            // 
            // toolStripDeshifr
            // 
            this.toolStripDeshifr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDeshifr.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeshifr.Image")));
            this.toolStripDeshifr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeshifr.Name = "toolStripDeshifr";
            this.toolStripDeshifr.Size = new System.Drawing.Size(24, 24);
            this.toolStripDeshifr.Text = "Расшифровать";
            this.toolStripDeshifr.Click += new System.EventHandler(this.toolStripDeshifr_Click);
            // 
            // toolStripAttach
            // 
            this.toolStripAttach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAttach.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAttach.Image")));
            this.toolStripAttach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAttach.Name = "toolStripAttach";
            this.toolStripAttach.Size = new System.Drawing.Size(24, 24);
            this.toolStripAttach.Text = "Прикрепить файл";
            this.toolStripAttach.Click += new System.EventHandler(this.toolStripAttach_Click);
            // 
            // toolStripCutOut
            // 
            this.toolStripCutOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCutOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCutOut.Image")));
            this.toolStripCutOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCutOut.Name = "toolStripCutOut";
            this.toolStripCutOut.Size = new System.Drawing.Size(24, 24);
            this.toolStripCutOut.Text = "Очистить поля";
            this.toolStripCutOut.Click += new System.EventHandler(this.toolStripCutOut_Click);
            // 
            // toolStripInfo
            // 
            this.toolStripInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemInfoAboutTheProgramm,
            this.ToolStripMenuItemInfoHelp});
            this.toolStripInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripInfo.Image")));
            this.toolStripInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInfo.Name = "toolStripInfo";
            this.toolStripInfo.Size = new System.Drawing.Size(33, 24);
            this.toolStripInfo.Text = "О программе";
            // 
            // ToolStripMenuItemInfoAboutTheProgramm
            // 
            this.ToolStripMenuItemInfoAboutTheProgramm.Name = "ToolStripMenuItemInfoAboutTheProgramm";
            this.ToolStripMenuItemInfoAboutTheProgramm.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemInfoAboutTheProgramm.Text = "О программе";
            this.ToolStripMenuItemInfoAboutTheProgramm.Click += new System.EventHandler(this.ToolStripMenuItemInfoAboutTheProgramm_Click);
            // 
            // ToolStripMenuItemInfoHelp
            // 
            this.ToolStripMenuItemInfoHelp.Name = "ToolStripMenuItemInfoHelp";
            this.ToolStripMenuItemInfoHelp.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemInfoHelp.Text = "Справка";
            this.ToolStripMenuItemInfoHelp.Click += new System.EventHandler(this.ToolStripMenuItemInfoHelp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDemo
            // 
            this.toolStripDemo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDemo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDemo.Image")));
            this.toolStripDemo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDemo.Name = "toolStripDemo";
            this.toolStripDemo.Size = new System.Drawing.Size(24, 24);
            this.toolStripDemo.Text = "Демонстрационный режим";
            this.toolStripDemo.Click += new System.EventHandler(this.toolStripDemo_Click);
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOriginal.Location = new System.Drawing.Point(12, 58);
            this.textBoxOriginal.Multiline = true;
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.Size = new System.Drawing.Size(355, 380);
            this.textBoxOriginal.TabIndex = 1;
            // 
            // textBoxProcessed
            // 
            this.textBoxProcessed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProcessed.Location = new System.Drawing.Point(429, 58);
            this.textBoxProcessed.Multiline = true;
            this.textBoxProcessed.Name = "textBoxProcessed";
            this.textBoxProcessed.ReadOnly = true;
            this.textBoxProcessed.Size = new System.Drawing.Size(357, 380);
            this.textBoxProcessed.TabIndex = 2;
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOriginal.Location = new System.Drawing.Point(12, 37);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(140, 19);
            this.labelOriginal.TabIndex = 3;
            this.labelOriginal.Text = "Исходные данные";
            // 
            // labelProcessed
            // 
            this.labelProcessed.AutoSize = true;
            this.labelProcessed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProcessed.Location = new System.Drawing.Point(427, 37);
            this.labelProcessed.Name = "labelProcessed";
            this.labelProcessed.Size = new System.Drawing.Size(184, 19);
            this.labelProcessed.TabIndex = 4;
            this.labelProcessed.Text = "Информация о процессе";
            // 
            // buttonCarryover
            // 
            this.buttonCarryover.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCarryover.BackgroundImage")));
            this.buttonCarryover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCarryover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCarryover.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCarryover.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCarryover.ForeColor = System.Drawing.Color.Black;
            this.buttonCarryover.Location = new System.Drawing.Point(373, 219);
            this.buttonCarryover.Name = "buttonCarryover";
            this.buttonCarryover.Size = new System.Drawing.Size(52, 45);
            this.buttonCarryover.TabIndex = 5;
            this.buttonCarryover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCarryover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCarryover.UseVisualStyleBackColor = true;
            this.buttonCarryover.Visible = false;
            this.buttonCarryover.Click += new System.EventHandler(this.buttonCarryover_Click);
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 59);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(355, 379);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOriginal.TabIndex = 6;
            this.pictureBoxOriginal.TabStop = false;
            this.pictureBoxOriginal.Visible = false;
            // 
            // axWindowsMediaPlayerOriginal
            // 
            this.axWindowsMediaPlayerOriginal.Enabled = true;
            this.axWindowsMediaPlayerOriginal.Location = new System.Drawing.Point(12, 59);
            this.axWindowsMediaPlayerOriginal.Name = "axWindowsMediaPlayerOriginal";
            this.axWindowsMediaPlayerOriginal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayerOriginal.OcxState")));
            this.axWindowsMediaPlayerOriginal.Size = new System.Drawing.Size(355, 379);
            this.axWindowsMediaPlayerOriginal.TabIndex = 7;
            this.axWindowsMediaPlayerOriginal.Visible = false;
            // 
            // labelDemoInfo1
            // 
            this.labelDemoInfo1.AutoSize = true;
            this.labelDemoInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDemoInfo1.Location = new System.Drawing.Point(432, 65);
            this.labelDemoInfo1.Name = "labelDemoInfo1";
            this.labelDemoInfo1.Size = new System.Drawing.Size(182, 19);
            this.labelDemoInfo1.TabIndex = 8;
            this.labelDemoInfo1.Text = "Данные для шифрования:";
            this.labelDemoInfo1.Visible = false;
            // 
            // textBoxL01
            // 
            this.textBoxL01.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxL01.Location = new System.Drawing.Point(464, 89);
            this.textBoxL01.Name = "textBoxL01";
            this.textBoxL01.ReadOnly = true;
            this.textBoxL01.Size = new System.Drawing.Size(135, 26);
            this.textBoxL01.TabIndex = 9;
            this.textBoxL01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxL01.Visible = false;
            // 
            // textBoxL03
            // 
            this.textBoxL03.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxL03.Location = new System.Drawing.Point(464, 121);
            this.textBoxL03.Name = "textBoxL03";
            this.textBoxL03.ReadOnly = true;
            this.textBoxL03.Size = new System.Drawing.Size(135, 26);
            this.textBoxL03.TabIndex = 11;
            this.textBoxL03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxL03.Visible = false;
            // 
            // labelL0R1
            // 
            this.labelL0R1.AutoSize = true;
            this.labelL0R1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelL0R1.Location = new System.Drawing.Point(431, 89);
            this.labelL0R1.Name = "labelL0R1";
            this.labelL0R1.Size = new System.Drawing.Size(26, 19);
            this.labelL0R1.TabIndex = 23;
            this.labelL0R1.Text = "L0";
            this.labelL0R1.Visible = false;
            // 
            // labelR0R0
            // 
            this.labelR0R0.AutoSize = true;
            this.labelR0R0.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelR0R0.Location = new System.Drawing.Point(430, 170);
            this.labelR0R0.Name = "labelR0R0";
            this.labelR0R0.Size = new System.Drawing.Size(27, 19);
            this.labelR0R0.TabIndex = 24;
            this.labelR0R0.Text = "R0";
            this.labelR0R0.Visible = false;
            // 
            // labelDemoInfo3
            // 
            this.labelDemoInfo3.AutoSize = true;
            this.labelDemoInfo3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDemoInfo3.Location = new System.Drawing.Point(432, 245);
            this.labelDemoInfo3.Name = "labelDemoInfo3";
            this.labelDemoInfo3.Size = new System.Drawing.Size(73, 19);
            this.labelDemoInfo3.TabIndex = 25;
            this.labelDemoInfo3.Text = "Подключ:";
            this.labelDemoInfo3.Visible = false;
            // 
            // labelX0
            // 
            this.labelX0.AutoSize = true;
            this.labelX0.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX0.Location = new System.Drawing.Point(432, 277);
            this.labelX0.Name = "labelX0";
            this.labelX0.Size = new System.Drawing.Size(28, 19);
            this.labelX0.TabIndex = 26;
            this.labelX0.Text = "X0";
            this.labelX0.Visible = false;
            // 
            // textBoxL04
            // 
            this.textBoxL04.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxL04.Location = new System.Drawing.Point(605, 121);
            this.textBoxL04.Name = "textBoxL04";
            this.textBoxL04.ReadOnly = true;
            this.textBoxL04.Size = new System.Drawing.Size(135, 26);
            this.textBoxL04.TabIndex = 27;
            this.textBoxL04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxL04.Visible = false;
            // 
            // textBoxL02
            // 
            this.textBoxL02.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxL02.Location = new System.Drawing.Point(605, 89);
            this.textBoxL02.Name = "textBoxL02";
            this.textBoxL02.ReadOnly = true;
            this.textBoxL02.Size = new System.Drawing.Size(135, 26);
            this.textBoxL02.TabIndex = 28;
            this.textBoxL02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxL02.Visible = false;
            // 
            // textBoxR01
            // 
            this.textBoxR01.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxR01.Location = new System.Drawing.Point(464, 170);
            this.textBoxR01.Name = "textBoxR01";
            this.textBoxR01.ReadOnly = true;
            this.textBoxR01.Size = new System.Drawing.Size(135, 26);
            this.textBoxR01.TabIndex = 29;
            this.textBoxR01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR01.Visible = false;
            // 
            // textBoxR02
            // 
            this.textBoxR02.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxR02.Location = new System.Drawing.Point(605, 170);
            this.textBoxR02.Name = "textBoxR02";
            this.textBoxR02.ReadOnly = true;
            this.textBoxR02.Size = new System.Drawing.Size(135, 26);
            this.textBoxR02.TabIndex = 30;
            this.textBoxR02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR02.Visible = false;
            // 
            // textBoxR03
            // 
            this.textBoxR03.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxR03.Location = new System.Drawing.Point(464, 202);
            this.textBoxR03.Name = "textBoxR03";
            this.textBoxR03.ReadOnly = true;
            this.textBoxR03.Size = new System.Drawing.Size(135, 26);
            this.textBoxR03.TabIndex = 31;
            this.textBoxR03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR03.Visible = false;
            // 
            // textBoxR04
            // 
            this.textBoxR04.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxR04.Location = new System.Drawing.Point(605, 202);
            this.textBoxR04.Name = "textBoxR04";
            this.textBoxR04.ReadOnly = true;
            this.textBoxR04.Size = new System.Drawing.Size(135, 26);
            this.textBoxR04.TabIndex = 32;
            this.textBoxR04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR04.Visible = false;
            // 
            // textBoxX01
            // 
            this.textBoxX01.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxX01.Location = new System.Drawing.Point(464, 277);
            this.textBoxX01.Name = "textBoxX01";
            this.textBoxX01.ReadOnly = true;
            this.textBoxX01.Size = new System.Drawing.Size(135, 26);
            this.textBoxX01.TabIndex = 33;
            this.textBoxX01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxX01.Visible = false;
            // 
            // textBoxX02
            // 
            this.textBoxX02.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxX02.Location = new System.Drawing.Point(605, 277);
            this.textBoxX02.Name = "textBoxX02";
            this.textBoxX02.ReadOnly = true;
            this.textBoxX02.Size = new System.Drawing.Size(135, 26);
            this.textBoxX02.TabIndex = 34;
            this.textBoxX02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxX02.Visible = false;
            // 
            // textBoxX03
            // 
            this.textBoxX03.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxX03.Location = new System.Drawing.Point(464, 309);
            this.textBoxX03.Name = "textBoxX03";
            this.textBoxX03.ReadOnly = true;
            this.textBoxX03.Size = new System.Drawing.Size(135, 26);
            this.textBoxX03.TabIndex = 35;
            this.textBoxX03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxX03.Visible = false;
            // 
            // textBoxX04
            // 
            this.textBoxX04.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxX04.Location = new System.Drawing.Point(605, 309);
            this.textBoxX04.Name = "textBoxX04";
            this.textBoxX04.ReadOnly = true;
            this.textBoxX04.Size = new System.Drawing.Size(135, 26);
            this.textBoxX04.TabIndex = 36;
            this.textBoxX04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxX04.Visible = false;
            // 
            // textBoxR13
            // 
            this.textBoxR13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxR13.Location = new System.Drawing.Point(463, 277);
            this.textBoxR13.Name = "textBoxR13";
            this.textBoxR13.ReadOnly = true;
            this.textBoxR13.Size = new System.Drawing.Size(276, 26);
            this.textBoxR13.TabIndex = 38;
            this.textBoxR13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR13.Visible = false;
            // 
            // textBoxR11
            // 
            this.textBoxR11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxR11.Location = new System.Drawing.Point(463, 89);
            this.textBoxR11.Name = "textBoxR11";
            this.textBoxR11.ReadOnly = true;
            this.textBoxR11.Size = new System.Drawing.Size(276, 26);
            this.textBoxR11.TabIndex = 39;
            this.textBoxR11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR11.Visible = false;
            // 
            // textBoxR12
            // 
            this.textBoxR12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxR12.Location = new System.Drawing.Point(463, 170);
            this.textBoxR12.Name = "textBoxR12";
            this.textBoxR12.ReadOnly = true;
            this.textBoxR12.Size = new System.Drawing.Size(276, 26);
            this.textBoxR12.TabIndex = 40;
            this.textBoxR12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR12.Visible = false;
            // 
            // labelDemoInfo2
            // 
            this.labelDemoInfo2.AutoSize = true;
            this.labelDemoInfo2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDemoInfo2.Location = new System.Drawing.Point(430, 148);
            this.labelDemoInfo2.Name = "labelDemoInfo2";
            this.labelDemoInfo2.Size = new System.Drawing.Size(268, 19);
            this.labelDemoInfo2.TabIndex = 41;
            this.labelDemoInfo2.Text = "Преобразование в блоке подстановки:";
            this.labelDemoInfo2.Visible = false;
            // 
            // labelR0
            // 
            this.labelR0.AutoSize = true;
            this.labelR0.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelR0.Location = new System.Drawing.Point(516, 306);
            this.labelR0.Name = "labelR0";
            this.labelR0.Size = new System.Drawing.Size(27, 19);
            this.labelR0.TabIndex = 42;
            this.labelR0.Text = "R0";
            this.labelR0.Visible = false;
            // 
            // labelR1
            // 
            this.labelR1.AutoSize = true;
            this.labelR1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelR1.Location = new System.Drawing.Point(657, 306);
            this.labelR1.Name = "labelR1";
            this.labelR1.Size = new System.Drawing.Size(27, 19);
            this.labelR1.TabIndex = 43;
            this.labelR1.Text = "R1";
            this.labelR1.Visible = false;
            // 
            // buttonFurther
            // 
            this.buttonFurther.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFurther.Location = new System.Drawing.Point(700, 399);
            this.buttonFurther.Name = "buttonFurther";
            this.buttonFurther.Size = new System.Drawing.Size(75, 28);
            this.buttonFurther.TabIndex = 44;
            this.buttonFurther.Text = "Далее";
            this.buttonFurther.UseVisualStyleBackColor = true;
            this.buttonFurther.Visible = false;
            this.buttonFurther.Click += new System.EventHandler(this.buttonFurther_Click);
            // 
            // pictureBoxDemoShifr0
            // 
            this.pictureBoxDemoShifr0.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDemoShifr0.Image")));
            this.pictureBoxDemoShifr0.Location = new System.Drawing.Point(12, 37);
            this.pictureBoxDemoShifr0.Name = "pictureBoxDemoShifr0";
            this.pictureBoxDemoShifr0.Size = new System.Drawing.Size(355, 336);
            this.pictureBoxDemoShifr0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDemoShifr0.TabIndex = 45;
            this.pictureBoxDemoShifr0.TabStop = false;
            this.pictureBoxDemoShifr0.Visible = false;
            // 
            // pictureBoxDemoShifr1
            // 
            this.pictureBoxDemoShifr1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDemoShifr1.Image")));
            this.pictureBoxDemoShifr1.Location = new System.Drawing.Point(12, 37);
            this.pictureBoxDemoShifr1.Name = "pictureBoxDemoShifr1";
            this.pictureBoxDemoShifr1.Size = new System.Drawing.Size(355, 336);
            this.pictureBoxDemoShifr1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDemoShifr1.TabIndex = 46;
            this.pictureBoxDemoShifr1.TabStop = false;
            this.pictureBoxDemoShifr1.Visible = false;
            // 
            // pictureBoxDemoShifr2
            // 
            this.pictureBoxDemoShifr2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDemoShifr2.Image")));
            this.pictureBoxDemoShifr2.Location = new System.Drawing.Point(12, 37);
            this.pictureBoxDemoShifr2.Name = "pictureBoxDemoShifr2";
            this.pictureBoxDemoShifr2.Size = new System.Drawing.Size(355, 336);
            this.pictureBoxDemoShifr2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDemoShifr2.TabIndex = 47;
            this.pictureBoxDemoShifr2.TabStop = false;
            this.pictureBoxDemoShifr2.Visible = false;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKey.Location = new System.Drawing.Point(12, 399);
            this.textBoxKey.Multiline = true;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.ReadOnly = true;
            this.textBoxKey.Size = new System.Drawing.Size(355, 39);
            this.textBoxKey.TabIndex = 48;
            this.textBoxKey.Text = "ДЕДЛАЙН ближе спасайся кто может";
            this.textBoxKey.Visible = false;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKey.Location = new System.Drawing.Point(12, 376);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(55, 19);
            this.labelKey.TabIndex = 49;
            this.labelKey.Text = "Ключ:";
            this.labelKey.Visible = false;
            // 
            // pictureBoxDemoDeshifr0
            // 
            this.pictureBoxDemoDeshifr0.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDemoDeshifr0.Image")));
            this.pictureBoxDemoDeshifr0.Location = new System.Drawing.Point(12, 37);
            this.pictureBoxDemoDeshifr0.Name = "pictureBoxDemoDeshifr0";
            this.pictureBoxDemoDeshifr0.Size = new System.Drawing.Size(355, 336);
            this.pictureBoxDemoDeshifr0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDemoDeshifr0.TabIndex = 50;
            this.pictureBoxDemoDeshifr0.TabStop = false;
            this.pictureBoxDemoDeshifr0.Visible = false;
            // 
            // pictureBoxDemoDeshifr1
            // 
            this.pictureBoxDemoDeshifr1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDemoDeshifr1.Image")));
            this.pictureBoxDemoDeshifr1.Location = new System.Drawing.Point(12, 37);
            this.pictureBoxDemoDeshifr1.Name = "pictureBoxDemoDeshifr1";
            this.pictureBoxDemoDeshifr1.Size = new System.Drawing.Size(355, 336);
            this.pictureBoxDemoDeshifr1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDemoDeshifr1.TabIndex = 51;
            this.pictureBoxDemoDeshifr1.TabStop = false;
            this.pictureBoxDemoDeshifr1.Visible = false;
            // 
            // pictureBoxDemoDeshifr2
            // 
            this.pictureBoxDemoDeshifr2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDemoDeshifr2.Image")));
            this.pictureBoxDemoDeshifr2.Location = new System.Drawing.Point(12, 37);
            this.pictureBoxDemoDeshifr2.Name = "pictureBoxDemoDeshifr2";
            this.pictureBoxDemoDeshifr2.Size = new System.Drawing.Size(355, 336);
            this.pictureBoxDemoDeshifr2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDemoDeshifr2.TabIndex = 52;
            this.pictureBoxDemoDeshifr2.TabStop = false;
            this.pictureBoxDemoDeshifr2.Visible = false;
            // 
            // GOST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.pictureBoxDemoDeshifr2);
            this.Controls.Add(this.pictureBoxDemoDeshifr1);
            this.Controls.Add(this.pictureBoxDemoDeshifr0);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.pictureBoxDemoShifr2);
            this.Controls.Add(this.pictureBoxDemoShifr1);
            this.Controls.Add(this.pictureBoxDemoShifr0);
            this.Controls.Add(this.buttonFurther);
            this.Controls.Add(this.labelR1);
            this.Controls.Add(this.labelR0);
            this.Controls.Add(this.labelDemoInfo2);
            this.Controls.Add(this.textBoxR12);
            this.Controls.Add(this.textBoxR11);
            this.Controls.Add(this.textBoxR13);
            this.Controls.Add(this.textBoxX04);
            this.Controls.Add(this.textBoxX03);
            this.Controls.Add(this.textBoxX02);
            this.Controls.Add(this.textBoxX01);
            this.Controls.Add(this.textBoxR04);
            this.Controls.Add(this.textBoxR03);
            this.Controls.Add(this.textBoxR02);
            this.Controls.Add(this.textBoxR01);
            this.Controls.Add(this.textBoxL02);
            this.Controls.Add(this.textBoxL04);
            this.Controls.Add(this.labelX0);
            this.Controls.Add(this.labelDemoInfo3);
            this.Controls.Add(this.labelR0R0);
            this.Controls.Add(this.labelL0R1);
            this.Controls.Add(this.textBoxL03);
            this.Controls.Add(this.textBoxL01);
            this.Controls.Add(this.labelDemoInfo1);
            this.Controls.Add(this.axWindowsMediaPlayerOriginal);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.buttonCarryover);
            this.Controls.Add(this.labelProcessed);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.textBoxProcessed);
            this.Controls.Add(this.textBoxOriginal);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GOST";
            this.Text = "Шифрование ГОСТ";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoShifr0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoShifr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoShifr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoDeshifr0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoDeshifr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDemoDeshifr2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripShifr;
        private System.Windows.Forms.ToolStripButton toolStripDeshifr;
        private System.Windows.Forms.ToolStripButton toolStripAttach;
        private System.Windows.Forms.ToolStripButton toolStripCutOut;
        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.TextBox textBoxProcessed;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelProcessed;
        private System.Windows.Forms.Button buttonCarryover;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayerOriginal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripDemo;
        private System.Windows.Forms.Label labelDemoInfo1;
        private System.Windows.Forms.TextBox textBoxL01;
        private System.Windows.Forms.TextBox textBoxL03;
        private System.Windows.Forms.Label labelL0R1;
        private System.Windows.Forms.Label labelR0R0;
        private System.Windows.Forms.Label labelDemoInfo3;
        private System.Windows.Forms.Label labelX0;
        private System.Windows.Forms.TextBox textBoxL04;
        private System.Windows.Forms.TextBox textBoxL02;
        private System.Windows.Forms.TextBox textBoxR01;
        private System.Windows.Forms.TextBox textBoxR02;
        private System.Windows.Forms.TextBox textBoxR03;
        private System.Windows.Forms.TextBox textBoxR04;
        private System.Windows.Forms.TextBox textBoxX01;
        private System.Windows.Forms.TextBox textBoxX02;
        private System.Windows.Forms.TextBox textBoxX03;
        private System.Windows.Forms.TextBox textBoxX04;
        private System.Windows.Forms.TextBox textBoxR13;
        private System.Windows.Forms.TextBox textBoxR11;
        private System.Windows.Forms.TextBox textBoxR12;
        private System.Windows.Forms.Label labelDemoInfo2;
        private System.Windows.Forms.Label labelR0;
        private System.Windows.Forms.Label labelR1;
        private System.Windows.Forms.Button buttonFurther;
        private System.Windows.Forms.PictureBox pictureBoxDemoShifr0;
        private System.Windows.Forms.PictureBox pictureBoxDemoShifr1;
        private System.Windows.Forms.PictureBox pictureBoxDemoShifr2;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.PictureBox pictureBoxDemoDeshifr0;
        private System.Windows.Forms.PictureBox pictureBoxDemoDeshifr1;
        private System.Windows.Forms.PictureBox pictureBoxDemoDeshifr2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInfoAboutTheProgramm;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInfoHelp;
    }
}

