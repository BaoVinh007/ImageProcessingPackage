namespace imageCsharp
{
    partial class MainWindow
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFTInverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFTInverseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dFTRealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFTImaginaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTMagnitudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTPhaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTInverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTRealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTImaginaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kMeanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuzzyCMeanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomitaFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nagaoFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sigmaFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeCornerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleEdgeDetectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.superResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transformationToolStripMenuItem,
            this.segmentationsToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.edgeCornerToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1113, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.saveToolStripMenuItem.Text = "&Save as";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // transformationToolStripMenuItem
            // 
            this.transformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mirrorToolStripMenuItem,
            this.grayScaleToolStripMenuItem,
            this.copyImageToolStripMenuItem,
            this.negateImageToolStripMenuItem,
            this.fourierToolStripMenuItem,
            this.dFTInverseToolStripMenuItem,
            this.dFTInverseToolStripMenuItem1,
            this.dFTRealToolStripMenuItem,
            this.dFTImaginaryToolStripMenuItem,
            this.fFTMagnitudeToolStripMenuItem,
            this.fFTPhaseToolStripMenuItem,
            this.fFTInverseToolStripMenuItem,
            this.fFTRealToolStripMenuItem,
            this.fFTImaginaryToolStripMenuItem});
            this.transformationToolStripMenuItem.Name = "transformationToolStripMenuItem";
            this.transformationToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.transformationToolStripMenuItem.Text = "Transformations";
            // 
            // mirrorToolStripMenuItem
            // 
            this.mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
            this.mirrorToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.mirrorToolStripMenuItem.Text = "Mirror";
            this.mirrorToolStripMenuItem.Click += new System.EventHandler(this.mirrorToolStripMenuItem_Click);
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.grayScaleToolStripMenuItem.Text = "GrayScale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
            // 
            // copyImageToolStripMenuItem
            // 
            this.copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            this.copyImageToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.copyImageToolStripMenuItem.Text = "CopyImage";
            this.copyImageToolStripMenuItem.Click += new System.EventHandler(this.copyImageToolStripMenuItem_Click);
            // 
            // negateImageToolStripMenuItem
            // 
            this.negateImageToolStripMenuItem.Name = "negateImageToolStripMenuItem";
            this.negateImageToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.negateImageToolStripMenuItem.Text = "NegateImage";
            this.negateImageToolStripMenuItem.Click += new System.EventHandler(this.negateImageToolStripMenuItem_Click);
            // 
            // fourierToolStripMenuItem
            // 
            this.fourierToolStripMenuItem.Name = "fourierToolStripMenuItem";
            this.fourierToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.fourierToolStripMenuItem.Text = "DFT-Magnitude";
            this.fourierToolStripMenuItem.Click += new System.EventHandler(this.fourierToolStripMenuItem_Click);
            // 
            // dFTInverseToolStripMenuItem
            // 
            this.dFTInverseToolStripMenuItem.Name = "dFTInverseToolStripMenuItem";
            this.dFTInverseToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.dFTInverseToolStripMenuItem.Text = "DFT-Phase";
            this.dFTInverseToolStripMenuItem.Click += new System.EventHandler(this.dFTInverseToolStripMenuItem_Click);
            // 
            // dFTInverseToolStripMenuItem1
            // 
            this.dFTInverseToolStripMenuItem1.Name = "dFTInverseToolStripMenuItem1";
            this.dFTInverseToolStripMenuItem1.Size = new System.Drawing.Size(182, 24);
            this.dFTInverseToolStripMenuItem1.Text = "DFT-Inverse";
            this.dFTInverseToolStripMenuItem1.Click += new System.EventHandler(this.dFTInverseToolStripMenuItem1_Click);
            // 
            // dFTRealToolStripMenuItem
            // 
            this.dFTRealToolStripMenuItem.Name = "dFTRealToolStripMenuItem";
            this.dFTRealToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.dFTRealToolStripMenuItem.Text = "DFT-Real";
            this.dFTRealToolStripMenuItem.Click += new System.EventHandler(this.dFTRealToolStripMenuItem_Click);
            // 
            // dFTImaginaryToolStripMenuItem
            // 
            this.dFTImaginaryToolStripMenuItem.Name = "dFTImaginaryToolStripMenuItem";
            this.dFTImaginaryToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.dFTImaginaryToolStripMenuItem.Text = "DFT-Imaginary";
            this.dFTImaginaryToolStripMenuItem.Click += new System.EventHandler(this.dFTImaginaryToolStripMenuItem_Click);
            // 
            // fFTMagnitudeToolStripMenuItem
            // 
            this.fFTMagnitudeToolStripMenuItem.Name = "fFTMagnitudeToolStripMenuItem";
            this.fFTMagnitudeToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.fFTMagnitudeToolStripMenuItem.Text = "FFT-Magnitude";
            // 
            // fFTPhaseToolStripMenuItem
            // 
            this.fFTPhaseToolStripMenuItem.Name = "fFTPhaseToolStripMenuItem";
            this.fFTPhaseToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.fFTPhaseToolStripMenuItem.Text = "FFT-Phase";
            // 
            // fFTInverseToolStripMenuItem
            // 
            this.fFTInverseToolStripMenuItem.Name = "fFTInverseToolStripMenuItem";
            this.fFTInverseToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.fFTInverseToolStripMenuItem.Text = "FFT-Inverse";
            // 
            // fFTRealToolStripMenuItem
            // 
            this.fFTRealToolStripMenuItem.Name = "fFTRealToolStripMenuItem";
            this.fFTRealToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.fFTRealToolStripMenuItem.Text = "FFT-Real";
            this.fFTRealToolStripMenuItem.Click += new System.EventHandler(this.fFTRealToolStripMenuItem_Click);
            // 
            // fFTImaginaryToolStripMenuItem
            // 
            this.fFTImaginaryToolStripMenuItem.Name = "fFTImaginaryToolStripMenuItem";
            this.fFTImaginaryToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.fFTImaginaryToolStripMenuItem.Text = "FFT-Imaginary";
            // 
            // segmentationsToolStripMenuItem
            // 
            this.segmentationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kMeanToolStripMenuItem,
            this.fuzzyCMeanToolStripMenuItem,
            this.superResolutionToolStripMenuItem});
            this.segmentationsToolStripMenuItem.Name = "segmentationsToolStripMenuItem";
            this.segmentationsToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.segmentationsToolStripMenuItem.Text = "Segmentations";
            // 
            // kMeanToolStripMenuItem
            // 
            this.kMeanToolStripMenuItem.Name = "kMeanToolStripMenuItem";
            this.kMeanToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.kMeanToolStripMenuItem.Text = "K-Means";
            this.kMeanToolStripMenuItem.Click += new System.EventHandler(this.kMeanToolStripMenuItem_Click);
            // 
            // fuzzyCMeanToolStripMenuItem
            // 
            this.fuzzyCMeanToolStripMenuItem.Name = "fuzzyCMeanToolStripMenuItem";
            this.fuzzyCMeanToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.fuzzyCMeanToolStripMenuItem.Text = "Fuzzy C-Means";
            this.fuzzyCMeanToolStripMenuItem.Click += new System.EventHandler(this.fuzzyCMeanToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tomitaFilterToolStripMenuItem,
            this.nagaoFilterToolStripMenuItem,
            this.sigmaFilterToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // tomitaFilterToolStripMenuItem
            // 
            this.tomitaFilterToolStripMenuItem.Name = "tomitaFilterToolStripMenuItem";
            this.tomitaFilterToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.tomitaFilterToolStripMenuItem.Text = "Tomita Filter";
            this.tomitaFilterToolStripMenuItem.Click += new System.EventHandler(this.tomitaFilterToolStripMenuItem_Click);
            // 
            // nagaoFilterToolStripMenuItem
            // 
            this.nagaoFilterToolStripMenuItem.Name = "nagaoFilterToolStripMenuItem";
            this.nagaoFilterToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.nagaoFilterToolStripMenuItem.Text = "Nagao Filter";
            this.nagaoFilterToolStripMenuItem.Click += new System.EventHandler(this.nagaoFilterToolStripMenuItem_Click);
            // 
            // sigmaFilterToolStripMenuItem
            // 
            this.sigmaFilterToolStripMenuItem.Name = "sigmaFilterToolStripMenuItem";
            this.sigmaFilterToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.sigmaFilterToolStripMenuItem.Text = "Sigma Filter";
            this.sigmaFilterToolStripMenuItem.Click += new System.EventHandler(this.sigmaFilterToolStripMenuItem_Click);
            // 
            // edgeCornerToolStripMenuItem
            // 
            this.edgeCornerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleEdgeDetectToolStripMenuItem});
            this.edgeCornerToolStripMenuItem.Name = "edgeCornerToolStripMenuItem";
            this.edgeCornerToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.edgeCornerToolStripMenuItem.Text = "EdgeCorner";
            // 
            // simpleEdgeDetectToolStripMenuItem
            // 
            this.simpleEdgeDetectToolStripMenuItem.Name = "simpleEdgeDetectToolStripMenuItem";
            this.simpleEdgeDetectToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.simpleEdgeDetectToolStripMenuItem.Text = "SimpleEdgeDetect";
            this.simpleEdgeDetectToolStripMenuItem.Click += new System.EventHandler(this.simpleEdgeDetectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            this.openFileDialog1.Filter = "JPEG Files|*.jpg|Bitmap Files|*.bmp|GIF Files|*.gif|All files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "jpg";
            this.saveFileDialog1.Filter = "JPEG Files|*.jpg|Bitmap Files|*.bmp|GIF Files|*.gif";
            // 
            // superResolutionToolStripMenuItem
            // 
            this.superResolutionToolStripMenuItem.Name = "superResolutionToolStripMenuItem";
            this.superResolutionToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.superResolutionToolStripMenuItem.Text = "Super-Resolution";
            this.superResolutionToolStripMenuItem.Click += new System.EventHandler(this.superResolutionToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 694);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "DIGITAL IMAGE PROCESSING - CS6563";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformationToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mirrorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeCornerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleEdgeDetectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negateImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tomitaFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nagaoFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sigmaFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kMeanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuzzyCMeanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fourierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFTInverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFTInverseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dFTRealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFTImaginaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTMagnitudeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTPhaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTInverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTRealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTImaginaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superResolutionToolStripMenuItem;
    }
}

