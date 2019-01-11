using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Tesseract;
using Tesseract;

namespace OcrTest
{
    public partial class Form1 : Form
    {
        private static string startPath = Application.StartupPath;

        //引用的nuget IronOcr
        //Tesseract  
        //https://github.com/tesseract-ocr/tesseract/wiki/Data-Files#data-files-for-version-302
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{startPath}/PIC/OCR英文.jpg";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //用的是IRONOCR
            var Ocr = new AutoOcr();
            var Result = Ocr.Read(textBox1.Text);
            textBox4.Text = Result.Text;
            Result = Ocr.Read(textBox2.Text);
            textBox5.Text = Result.Text;


            var img = new Bitmap($"{startPath}/PIC/OCR英文.jpg");
            var ocr = new TesseractEngine(
                $"{startPath}/x64/tessdata",
                "eng", EngineMode.TesseractOnly);
            var page = ocr.Process(img);
            textBox6.Text = page.GetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = $"{startPath}/PIC/OCR中英文.png";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = $"{startPath}/PIC/OCR中文.png";

        }
    }
}
