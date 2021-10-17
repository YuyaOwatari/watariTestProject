using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watariTestProject
{
    public partial class Form1 : Form
    {
        public Boolean Testbool;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Testbool)
            {
                Testbool = false;
            }
            else {
                Testbool = true;
            }
            textBox1.Text = Testbool.ToString();

            dataGridView1.Rows.Add("ワタリ", Testbool.ToString());

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



//            String template = @"C:\WORK\test\template.pdf";
//            String output = @"C:\WORK\test\output.pdf";

            //A4サイズを横向きで
            Document pdfDocument = new Document(PageSize.A4.Rotate(), 0, 0, 0, 0);

            //出力先のファイル名
            string makePdfFilePath = @"C:\WORK\test\output.pdf";
            FileStream fileStream = new FileStream(makePdfFilePath, FileMode.Create);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, fileStream);


            //PDFドキュメントを開く
            pdfDocument.Open();

            //フォント名
            string fontName = "ＭＳ ゴシック";

            //フォントサイズ
            float fontSize = 10.0f;

            //フォントスタイル。 複合するときは、&amp;で。
            int fontStyle = iTextSharp.text.Font.BOLD;// &amp;iTextSharp.text.Font.ITALIC;

            //フォントカラー
            BaseColor baseColor = BaseColor.BLACK;

            //Fontフォルダを指定
            FontFactory.RegisterDirectory(Environment.SystemDirectory.Replace("system32", "fonts"));

            //フォントの設定
            iTextSharp.text.Font font =
                FontFactory.GetFont(fontName,
                BaseFont.IDENTITY_H,            //横書き
                BaseFont.NOT_EMBEDDED,          //フォントを組み込まない
                fontSize,
                fontStyle,
                baseColor);

            PdfContentByte pdfContentByte = pdfWriter.DirectContent;

            ColumnText columnText = new ColumnText(pdfContentByte);

            //SetSimpleColumnで出力
            columnText.SetSimpleColumn(
                new Phrase("あいうえおかきくけこ", font)
                , 50    // X1位置
                , 50    // Y1位置
                , 100   // X2位置
                , 70    // Y2位置
                , fontSize
                , Element.ALIGN_LEFT    //ちなみに、SetSimpleColumnでは、ALIGN_MIDDLE（縦方向の中寄せ）は使えない
                );

            //テキスト描画
            columnText.Go();

            //PDFドキュメントを閉じる
            pdfDocument.Close();

        }
    }
}
