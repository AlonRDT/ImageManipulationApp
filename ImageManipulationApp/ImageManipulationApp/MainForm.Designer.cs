namespace ImageManipulationApp
{
    partial class MainForm
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
            this.tabControlImageManiplation = new System.Windows.Forms.TabControl();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.labelImageAppExplanation = new System.Windows.Forms.Label();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.labelBrowseImageResult = new System.Windows.Forms.Label();
            this.buttonGetImage = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.tabPageKernel = new System.Windows.Forms.TabPage();
            this.buttonDeleteKernel = new System.Windows.Forms.Button();
            this.textBoxNewKernelName = new System.Windows.Forms.TextBox();
            this.labelNewKernelName = new System.Windows.Forms.Label();
            this.buttonSaveKernel = new System.Windows.Forms.Button();
            this.listBoxKernel = new System.Windows.Forms.ListBox();
            this.textBoxKernelWidth = new System.Windows.Forms.TextBox();
            this.labelKernelWidth = new System.Windows.Forms.Label();
            this.labelKernelHeight = new System.Windows.Forms.Label();
            this.textBoxKernelHeight = new System.Windows.Forms.TextBox();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelInProgress = new System.Windows.Forms.Label();
            this.tabControlImageManiplation.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.tabPageKernel.SuspendLayout();
            this.tabPageResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlImageManiplation
            // 
            this.tabControlImageManiplation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlImageManiplation.Controls.Add(this.tabPageAbout);
            this.tabControlImageManiplation.Controls.Add(this.tabPageImage);
            this.tabControlImageManiplation.Controls.Add(this.tabPageKernel);
            this.tabControlImageManiplation.Controls.Add(this.tabPageResult);
            this.tabControlImageManiplation.Location = new System.Drawing.Point(8, 1);
            this.tabControlImageManiplation.Name = "tabControlImageManiplation";
            this.tabControlImageManiplation.SelectedIndex = 0;
            this.tabControlImageManiplation.Size = new System.Drawing.Size(785, 448);
            this.tabControlImageManiplation.TabIndex = 8;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.labelImageAppExplanation);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 25);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(777, 419);
            this.tabPageAbout.TabIndex = 0;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // labelImageAppExplanation
            // 
            this.labelImageAppExplanation.AutoSize = true;
            this.labelImageAppExplanation.Location = new System.Drawing.Point(6, 3);
            this.labelImageAppExplanation.Name = "labelImageAppExplanation";
            this.labelImageAppExplanation.Size = new System.Drawing.Size(130, 17);
            this.labelImageAppExplanation.TabIndex = 0;
            this.labelImageAppExplanation.Text = "OnStartExplenation";
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.labelBrowseImageResult);
            this.tabPageImage.Controls.Add(this.buttonGetImage);
            this.tabPageImage.Controls.Add(this.pictureBoxImage);
            this.tabPageImage.Location = new System.Drawing.Point(4, 25);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(777, 419);
            this.tabPageImage.TabIndex = 2;
            this.tabPageImage.Text = "Choose Image";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // labelBrowseImageResult
            // 
            this.labelBrowseImageResult.AutoSize = true;
            this.labelBrowseImageResult.Location = new System.Drawing.Point(500, 224);
            this.labelBrowseImageResult.Name = "labelBrowseImageResult";
            this.labelBrowseImageResult.Size = new System.Drawing.Size(46, 17);
            this.labelBrowseImageResult.TabIndex = 2;
            this.labelBrowseImageResult.Text = "label1";
            // 
            // buttonGetImage
            // 
            this.buttonGetImage.Location = new System.Drawing.Point(523, 118);
            this.buttonGetImage.Name = "buttonGetImage";
            this.buttonGetImage.Size = new System.Drawing.Size(93, 77);
            this.buttonGetImage.TabIndex = 1;
            this.buttonGetImage.Text = "Get Image from Directory";
            this.buttonGetImage.UseVisualStyleBackColor = true;
            this.buttonGetImage.Click += new System.EventHandler(this.buttonGetImage_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(360, 407);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // tabPageKernel
            // 
            this.tabPageKernel.Controls.Add(this.buttonDeleteKernel);
            this.tabPageKernel.Controls.Add(this.textBoxNewKernelName);
            this.tabPageKernel.Controls.Add(this.labelNewKernelName);
            this.tabPageKernel.Controls.Add(this.buttonSaveKernel);
            this.tabPageKernel.Controls.Add(this.listBoxKernel);
            this.tabPageKernel.Controls.Add(this.textBoxKernelWidth);
            this.tabPageKernel.Controls.Add(this.labelKernelWidth);
            this.tabPageKernel.Controls.Add(this.labelKernelHeight);
            this.tabPageKernel.Controls.Add(this.textBoxKernelHeight);
            this.tabPageKernel.Location = new System.Drawing.Point(4, 25);
            this.tabPageKernel.Name = "tabPageKernel";
            this.tabPageKernel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKernel.Size = new System.Drawing.Size(777, 419);
            this.tabPageKernel.TabIndex = 1;
            this.tabPageKernel.Text = "Choose Kernel";
            this.tabPageKernel.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteKernel
            // 
            this.buttonDeleteKernel.Location = new System.Drawing.Point(606, 387);
            this.buttonDeleteKernel.Name = "buttonDeleteKernel";
            this.buttonDeleteKernel.Size = new System.Drawing.Size(165, 26);
            this.buttonDeleteKernel.TabIndex = 214;
            this.buttonDeleteKernel.Text = "Delete Kernel";
            this.buttonDeleteKernel.UseVisualStyleBackColor = true;
            this.buttonDeleteKernel.Click += new System.EventHandler(this.ButtonDeleteKernel_Click);
            // 
            // textBoxNewKernelName
            // 
            this.textBoxNewKernelName.Location = new System.Drawing.Point(558, 12);
            this.textBoxNewKernelName.Name = "textBoxNewKernelName";
            this.textBoxNewKernelName.Size = new System.Drawing.Size(207, 22);
            this.textBoxNewKernelName.TabIndex = 213;
            // 
            // labelNewKernelName
            // 
            this.labelNewKernelName.AutoSize = true;
            this.labelNewKernelName.Location = new System.Drawing.Point(431, 12);
            this.labelNewKernelName.Name = "labelNewKernelName";
            this.labelNewKernelName.Size = new System.Drawing.Size(121, 17);
            this.labelNewKernelName.TabIndex = 212;
            this.labelNewKernelName.Text = "New Kernel Name";
            // 
            // buttonSaveKernel
            // 
            this.buttonSaveKernel.Location = new System.Drawing.Point(434, 387);
            this.buttonSaveKernel.Name = "buttonSaveKernel";
            this.buttonSaveKernel.Size = new System.Drawing.Size(166, 26);
            this.buttonSaveKernel.TabIndex = 211;
            this.buttonSaveKernel.Text = "Save Kernel";
            this.buttonSaveKernel.UseVisualStyleBackColor = true;
            this.buttonSaveKernel.Click += new System.EventHandler(this.ButtonSaveKernel_Click);
            // 
            // listBoxKernel
            // 
            this.listBoxKernel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxKernel.FormattingEnabled = true;
            this.listBoxKernel.ItemHeight = 16;
            this.listBoxKernel.Location = new System.Drawing.Point(440, 41);
            this.listBoxKernel.Name = "listBoxKernel";
            this.listBoxKernel.Size = new System.Drawing.Size(331, 340);
            this.listBoxKernel.TabIndex = 4;
            this.listBoxKernel.SelectedIndexChanged += new System.EventHandler(this.listBoxKernel_SelectedIndexChanged);
            // 
            // textBoxKernelWidth
            // 
            this.textBoxKernelWidth.Location = new System.Drawing.Point(373, 9);
            this.textBoxKernelWidth.Name = "textBoxKernelWidth";
            this.textBoxKernelWidth.Size = new System.Drawing.Size(52, 22);
            this.textBoxKernelWidth.TabIndex = 210;
            // 
            // labelKernelWidth
            // 
            this.labelKernelWidth.AutoSize = true;
            this.labelKernelWidth.Location = new System.Drawing.Point(222, 12);
            this.labelKernelWidth.Name = "labelKernelWidth";
            this.labelKernelWidth.Size = new System.Drawing.Size(145, 17);
            this.labelKernelWidth.TabIndex = 2;
            this.labelKernelWidth.Text = "Choose Kernel Width:";
            // 
            // labelKernelHeight
            // 
            this.labelKernelHeight.AutoSize = true;
            this.labelKernelHeight.Location = new System.Drawing.Point(6, 12);
            this.labelKernelHeight.Name = "labelKernelHeight";
            this.labelKernelHeight.Size = new System.Drawing.Size(150, 17);
            this.labelKernelHeight.TabIndex = 1;
            this.labelKernelHeight.Text = "Choose Kernel Height:";
            // 
            // textBoxKernelHeight
            // 
            this.textBoxKernelHeight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxKernelHeight.Location = new System.Drawing.Point(162, 9);
            this.textBoxKernelHeight.Name = "textBoxKernelHeight";
            this.textBoxKernelHeight.Size = new System.Drawing.Size(54, 22);
            this.textBoxKernelHeight.TabIndex = 200;
            // 
            // tabPageResult
            // 
            this.tabPageResult.Controls.Add(this.labelInProgress);
            this.tabPageResult.Controls.Add(this.pictureBoxResult);
            this.tabPageResult.Location = new System.Drawing.Point(4, 25);
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResult.Size = new System.Drawing.Size(777, 419);
            this.tabPageResult.TabIndex = 3;
            this.tabPageResult.Text = "Result";
            this.tabPageResult.UseVisualStyleBackColor = true;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(392, 6);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(360, 407);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 2;
            this.pictureBoxResult.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelInProgress
            // 
            this.labelInProgress.AutoSize = true;
            this.labelInProgress.Location = new System.Drawing.Point(179, 153);
            this.labelInProgress.Name = "labelInProgress";
            this.labelInProgress.Size = new System.Drawing.Size(46, 17);
            this.labelInProgress.TabIndex = 3;
            this.labelInProgress.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlImageManiplation);
            this.Name = "MainForm";
            this.Text = "Image Manipulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageManipulationForm_FormClosing);
            this.tabControlImageManiplation.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.tabPageKernel.ResumeLayout(false);
            this.tabPageKernel.PerformLayout();
            this.tabPageResult.ResumeLayout(false);
            this.tabPageResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlImageManiplation;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Label labelImageAppExplanation;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TabPage tabPageKernel;
        private System.Windows.Forms.Button buttonDeleteKernel;
        private System.Windows.Forms.TextBox textBoxNewKernelName;
        private System.Windows.Forms.Label labelNewKernelName;
        private System.Windows.Forms.Button buttonSaveKernel;
        private System.Windows.Forms.ListBox listBoxKernel;
        private System.Windows.Forms.TextBox textBoxKernelWidth;
        private System.Windows.Forms.Label labelKernelWidth;
        private System.Windows.Forms.Label labelKernelHeight;
        private System.Windows.Forms.TextBox textBoxKernelHeight;
        private System.Windows.Forms.TabPage tabPageResult;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonGetImage;
        private System.Windows.Forms.Label labelBrowseImageResult;
        private System.Windows.Forms.Label labelInProgress;
    }
}

