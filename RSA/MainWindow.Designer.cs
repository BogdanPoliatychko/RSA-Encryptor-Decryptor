namespace RSA
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            labelText = new Label();
            labelEncryptedText = new Label();
            textBoxText = new TextBox();
            textBoxEncryptedText = new TextBox();
            buttonEncrypt = new Button();
            labelTitle = new Label();
            buttonDecrypt = new Button();
            splitContainerFields = new SplitContainer();
            labelPublicKey = new Label();
            textBoxPublicKey = new TextBox();
            textBoxPrivateKey = new TextBox();
            labelPrivateKey = new Label();
            buttonKeysGenerate = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainerFields).BeginInit();
            splitContainerFields.Panel1.SuspendLayout();
            splitContainerFields.Panel2.SuspendLayout();
            splitContainerFields.SuspendLayout();
            SuspendLayout();
            // 
            // labelText
            // 
            labelText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 11F);
            labelText.Location = new Point(11, 10);
            labelText.Name = "labelText";
            labelText.Size = new Size(52, 30);
            labelText.TabIndex = 0;
            labelText.Text = "Text";
            // 
            // labelEncryptedText
            // 
            labelEncryptedText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelEncryptedText.AutoSize = true;
            labelEncryptedText.Font = new Font("Segoe UI", 11F);
            labelEncryptedText.Location = new Point(11, 10);
            labelEncryptedText.Name = "labelEncryptedText";
            labelEncryptedText.Size = new Size(155, 30);
            labelEncryptedText.TabIndex = 1;
            labelEncryptedText.Text = "Encrypted Text";
            // 
            // textBoxText
            // 
            textBoxText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxText.Font = new Font("Segoe UI", 11F);
            textBoxText.Location = new Point(11, 49);
            textBoxText.Multiline = true;
            textBoxText.Name = "textBoxText";
            textBoxText.PlaceholderText = "Enter Text";
            textBoxText.ScrollBars = ScrollBars.Vertical;
            textBoxText.Size = new Size(426, 190);
            textBoxText.TabIndex = 2;
            textBoxText.Tag = "Text";
            // 
            // textBoxEncryptedText
            // 
            textBoxEncryptedText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxEncryptedText.Font = new Font("Segoe UI", 11F);
            textBoxEncryptedText.Location = new Point(11, 49);
            textBoxEncryptedText.Multiline = true;
            textBoxEncryptedText.Name = "textBoxEncryptedText";
            textBoxEncryptedText.PlaceholderText = "Enter Encrypted Text";
            textBoxEncryptedText.ScrollBars = ScrollBars.Vertical;
            textBoxEncryptedText.Size = new Size(439, 190);
            textBoxEncryptedText.TabIndex = 3;
            textBoxEncryptedText.Tag = "Encrypted Text";
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEncrypt.Cursor = Cursors.Hand;
            buttonEncrypt.Font = new Font("Segoe UI", 11F);
            buttonEncrypt.Location = new Point(51, 865);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(129, 50);
            buttonEncrypt.TabIndex = 4;
            buttonEncrypt.Text = "Encrypt";
            buttonEncrypt.UseVisualStyleBackColor = true;
            buttonEncrypt.Click += ButtonEncrypt_Click;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(360, 28);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(248, 32);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "RSA Encrypt / Decrypt";
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDecrypt.Cursor = Cursors.Hand;
            buttonDecrypt.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDecrypt.Location = new Point(814, 865);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(129, 50);
            buttonDecrypt.TabIndex = 6;
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += ButtonDecrypt_Click;
            // 
            // splitContainerFields
            // 
            splitContainerFields.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            splitContainerFields.Location = new Point(40, 85);
            splitContainerFields.Name = "splitContainerFields";
            // 
            // splitContainerFields.Panel1
            // 
            splitContainerFields.Panel1.Controls.Add(textBoxText);
            splitContainerFields.Panel1.Controls.Add(labelText);
            // 
            // splitContainerFields.Panel2
            // 
            splitContainerFields.Panel2.Controls.Add(textBoxEncryptedText);
            splitContainerFields.Panel2.Controls.Add(labelEncryptedText);
            splitContainerFields.Size = new Size(911, 250);
            splitContainerFields.SplitterDistance = 446;
            splitContainerFields.TabIndex = 7;
            // 
            // labelPublicKey
            // 
            labelPublicKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPublicKey.AutoSize = true;
            labelPublicKey.Font = new Font("Segoe UI", 11F);
            labelPublicKey.Location = new Point(51, 349);
            labelPublicKey.Name = "labelPublicKey";
            labelPublicKey.Size = new Size(112, 30);
            labelPublicKey.TabIndex = 8;
            labelPublicKey.Text = "Public Key";
            // 
            // textBoxPublicKey
            // 
            textBoxPublicKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPublicKey.Font = new Font("Segoe UI", 11F);
            textBoxPublicKey.Location = new Point(51, 388);
            textBoxPublicKey.Multiline = true;
            textBoxPublicKey.Name = "textBoxPublicKey";
            textBoxPublicKey.PlaceholderText = "Enter Public Key";
            textBoxPublicKey.ScrollBars = ScrollBars.Vertical;
            textBoxPublicKey.Size = new Size(892, 190);
            textBoxPublicKey.TabIndex = 9;
            textBoxPublicKey.Tag = "Public Key";
            // 
            // textBoxPrivateKey
            // 
            textBoxPrivateKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPrivateKey.Font = new Font("Segoe UI", 11F);
            textBoxPrivateKey.Location = new Point(51, 638);
            textBoxPrivateKey.Multiline = true;
            textBoxPrivateKey.Name = "textBoxPrivateKey";
            textBoxPrivateKey.PlaceholderText = "Enter Private Key";
            textBoxPrivateKey.ScrollBars = ScrollBars.Vertical;
            textBoxPrivateKey.Size = new Size(892, 190);
            textBoxPrivateKey.TabIndex = 11;
            textBoxPrivateKey.Tag = "Private Key";
            // 
            // labelPrivateKey
            // 
            labelPrivateKey.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPrivateKey.AutoSize = true;
            labelPrivateKey.Font = new Font("Segoe UI", 11F);
            labelPrivateKey.Location = new Point(51, 599);
            labelPrivateKey.Name = "labelPrivateKey";
            labelPrivateKey.Size = new Size(121, 30);
            labelPrivateKey.TabIndex = 10;
            labelPrivateKey.Text = "Private Key";
            // 
            // buttonKeysGenerate
            // 
            buttonKeysGenerate.Anchor = AnchorStyles.Bottom;
            buttonKeysGenerate.Cursor = Cursors.Hand;
            buttonKeysGenerate.Font = new Font("Segoe UI", 11F);
            buttonKeysGenerate.Location = new Point(402, 865);
            buttonKeysGenerate.Name = "buttonKeysGenerate";
            buttonKeysGenerate.Size = new Size(189, 50);
            buttonKeysGenerate.TabIndex = 12;
            buttonKeysGenerate.Text = "Generate Keys";
            buttonKeysGenerate.UseVisualStyleBackColor = true;
            buttonKeysGenerate.Click += ButtonKeysGenerate_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 952);
            Controls.Add(buttonKeysGenerate);
            Controls.Add(textBoxPrivateKey);
            Controls.Add(labelPrivateKey);
            Controls.Add(textBoxPublicKey);
            Controls.Add(labelPublicKey);
            Controls.Add(splitContainerFields);
            Controls.Add(buttonDecrypt);
            Controls.Add(labelTitle);
            Controls.Add(buttonEncrypt);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(675, 1008);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RSA (Rivest-Shamir-Adleman cryptography)";
            Load += MainWindow_Load;
            splitContainerFields.Panel1.ResumeLayout(false);
            splitContainerFields.Panel1.PerformLayout();
            splitContainerFields.Panel2.ResumeLayout(false);
            splitContainerFields.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerFields).EndInit();
            splitContainerFields.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelText;
        private Label labelEncryptedText;
        private TextBox textBoxText;
        private TextBox textBoxEncryptedText;
        private Button buttonEncrypt;
        private Label labelTitle;
        private Button buttonDecrypt;
        private SplitContainer splitContainerFields;
        private Label labelPublicKey;
        private TextBox textBoxPublicKey;
        private TextBox textBoxPrivateKey;
        private Label labelPrivateKey;
        private Button buttonKeysGenerate;
    }
}
