using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QrCodeGenrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         private short counter = 0;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator qrCodeGenerator = new QRCoder.QRCodeGenerator();   
            var QRCodeData = qrCodeGenerator.CreateQrCode(txtQrCode.Text, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var QRCode = new QRCoder.QRCode(QRCodeData);
            pcbQrCode.Image = QRCode.GetGraphic(20);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(pcbQrCode.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save QR Code";
                saveFileDialog.FileName = "QRCode-" + ++counter + ".png"; // Default file name with counter
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pcbQrCode.Image.Save(saveFileDialog.FileName);
                    MessageBox.Show("QR Code saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please generate a QR code first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
