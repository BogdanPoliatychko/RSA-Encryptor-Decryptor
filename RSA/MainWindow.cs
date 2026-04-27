namespace RSA
{
    public partial class MainWindow : Form
    {
        private static string publicKeyPem = "";
        private static string privateKeyPem = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ActiveControl = labelTitle;
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            if (EmptyFieldWarning(textBoxText) ||
                EmptyFieldWarning(textBoxPublicKey))
                return;

            try {
                textBoxEncryptedText.Text = RsaEncryptText(textBoxText.Text ?? "");
            }
            catch {
                MessageBox.Show("Invalid Public Key", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            if (EmptyFieldWarning(textBoxEncryptedText) ||
                EmptyFieldWarning(textBoxPrivateKey))
                return;

            try {
                textBoxText.Text = RsaDecryptText(textBoxEncryptedText.Text ?? "");
            }
            catch {
                MessageBox.Show("Invalid Encrypted Text or Private Key", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string RsaEncryptText(string text)
        {
            publicKeyPem = textBoxPublicKey.Text;
            privateKeyPem = textBoxPrivateKey.Text;

            RsaAlgorithm rsa = new();
            rsa.ImportPublicKey(publicKeyPem);

            return rsa.Encrypt(text);
        }

        public string RsaDecryptText(string encryptedText)
        {
            publicKeyPem = textBoxPublicKey.Text;
            privateKeyPem = textBoxPrivateKey.Text;

            RsaAlgorithm rsa = new();
            rsa.ImportPrivateKey(privateKeyPem);

            return rsa.Decrypt(encryptedText);
        }

        public static bool EmptyFieldWarning(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text)) {
                MessageBox.Show($"{textBox.Tag} field cannot be empty", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else return false;
        }

        private async void ButtonKeysGenerate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string originalText = btn.Text;
            btn.Enabled = false;
            btn.Text = "Generating...";
            Cursor = Cursors.AppStarting;

            RsaAlgorithm rsa = new();
            await Task.Run(() => rsa.GenerateKeys(2048));

            if (rsa.PublicKey != null && rsa.PrivateKey != null) {
                publicKeyPem = rsa.PublicKey.ExportToBase64();
                textBoxPublicKey.Text = publicKeyPem;

                privateKeyPem = rsa.PrivateKey.ExportToBase64();
                textBoxPrivateKey.Text = privateKeyPem;
            }

            btn.Text = originalText;
            btn.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}

//using System.Security.Cryptography;
//using System.Text;

//namespace RSA
//{
//    public partial class MainWindow : Form
//    {
//        private static string publicKeyPem = "";
//        private static string privateKeyPem = "";

//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        private void MainWindow_Load(object sender, EventArgs e)
//        {
//            ActiveControl = labelTitle;
//        }

//        private void ButtonEncrypt_Click(object sender, EventArgs e)
//        {
//            if (EmptyFieldWarning(textBoxText) ||
//                EmptyFieldWarning(textBoxPublicKey))
//                return;

//            try {
//                textBoxEncryptedText.Text = RsaEncryptText(textBoxText.Text ?? "");
//            }
//            catch {
//                MessageBox.Show("Invalid Public Key", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void ButtonDecrypt_Click(object sender, EventArgs e)
//        {
//            if (EmptyFieldWarning(textBoxEncryptedText) ||
//                EmptyFieldWarning(textBoxPrivateKey))
//                return;

//            try {
//                textBoxText.Text = RsaDecryptText(textBoxEncryptedText.Text ?? "");
//            }
//            catch {
//                MessageBox.Show("Invalid Encrypted Text or Private Key", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        public string RsaEncryptText(string text)
//        {
//            publicKeyPem = textBoxPublicKey.Text;
//            privateKeyPem = textBoxPrivateKey.Text;

//            using System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();
//            rsa.ImportFromPem(publicKeyPem);

//            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(text);
//            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);

//            return Convert.ToBase64String(encryptedData);
//        }

//        public string RsaDecryptText(string encryptedText)
//        {
//            publicKeyPem = textBoxPublicKey.Text;
//            privateKeyPem = textBoxPrivateKey.Text;

//            using System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();
//            rsa.ImportFromPem(privateKeyPem);

//            byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
//            byte[] decryptedData = rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.Pkcs1);

//            return Encoding.UTF8.GetString(decryptedData);
//        }

//        public static bool EmptyFieldWarning(TextBox textBox)
//        {
//            if (string.IsNullOrWhiteSpace(textBox.Text)) {
//                MessageBox.Show($"{textBox.Tag} field cannot be empty", "Warning",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return true;
//            }
//            else return false;
//        }

//        private void ButtonKeysGenerate_Click(object sender, EventArgs e)
//        {
//            using System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create(2048);

//            publicKeyPem = rsa.ExportSubjectPublicKeyInfoPem();
//            textBoxPublicKey.Text = publicKeyPem;

//            privateKeyPem = rsa.ExportPkcs8PrivateKeyPem();
//            textBoxPrivateKey.Text = privateKeyPem;
//        }
//    }
//}
