using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;

namespace WheelOfDoom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = new Icon("gornwheel_final.ico");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string relativePath = Path.Combine("wheel", "settings.xml");
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            loadXML(fullPath, false);
        }
        private void label2_Click(object sender, EventArgs e) { }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            savingXML(false, false);
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            savingXML(true, false);
        }
        public void savingXML(bool export, bool import)
        {
            //EINSTELLUNGEN
            int countdown = Int32.Parse(countdownNum.Text);
            string[] prizes = PrizesTxt.Text.Split(',');

            //XML PARSER
            string relativePath = Path.Combine("wheel", "settings.xml");
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            XDocument xml = XDocument.Load(fullPath);

            xml.Element("SETTINGS").Element("COUNTDOWN").Value = countdown.ToString();
            xml.Element("SETTINGS").Element("PRIZES").RemoveNodes();
            for (int i = 0; i < prizes.Length; i++)
            {
                XElement newPrize = new XElement("PRIZE", prizes[i]);
                xml.Element("SETTINGS").Element("PRIZES").Add(newPrize);
            }
            if (export == false)
            {
                xml.Save(fullPath);
                if (import == false)
                {
                    systemLbl.Text = "saved successfully";
                    systemLbl.ForeColor = Color.Green;
                }
                else if (import == true)
                {
                    systemLbl.Text = "imported successfully";
                    systemLbl.ForeColor = Color.Green;
                }
            }
            else if (export == true)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Export Settings";
                    saveFileDialog.Filter = "XML-Files (*.xml)|*.xml";
                    saveFileDialog.FileName = "mySettings.xml";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try 
                        {
                            xml.Save(saveFileDialog.FileName);
                            systemLbl.Text = "exported successfully to " + saveFileDialog.FileName;
                            systemLbl.ForeColor = Color.Green;
                        }
                        catch(Exception ex) 
                        { 
                            systemLbl.Text = ex.Message;
                            systemLbl.ForeColor = Color.Red;
                        }

                    }
                }
            }
            fetchIntoJS();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "import settings";
                openFileDialog.Filter = "XML-File (*.xml)|*.xml";
                if (openFileDialog.ShowDialog() == DialogResult.OK) { loadXML(openFileDialog.FileName, true); }
            }
        }

        public void loadXML(string filepath, bool import)
        {
            try
            {
                XDocument xml = XDocument.Load(filepath);
                countdownNum.Text = xml.Element("SETTINGS").Element("COUNTDOWN").Value;
                PrizesTxt.Text = "";
                foreach (XElement prize in xml.Element("SETTINGS").Element("PRIZES").Elements("PRIZE")){PrizesTxt.Text = PrizesTxt.Text + prize.Value + ",";}
                PrizesTxt.Text = PrizesTxt.Text.Substring(0, PrizesTxt.TextLength - 1);
                if (import == true) { savingXML(false, import);}
                else if (import == false) 
                {
                    systemLbl.Text = "ready";
                    systemLbl.ForeColor = Color.Green;
                }
            }
            catch(Exception ex)
            {
                systemLbl.Text = ex.Message;
                systemLbl.ForeColor = Color.Red;
            }
        }

        private void WheelUrlCopyBtn_Click(object sender, EventArgs e)
        {
            string relativePath = Path.Combine("wheel", "index.html");
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            Clipboard.SetText(fullPath);
            systemLbl.Text = "copied to clipboard";
            systemLbl.ForeColor = Color.Green;
        }

        public void fetchIntoJS() 
        {
            string relativePathJS = Path.Combine("wheel", "script.js");
            string fullPathJS = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePathJS);
            string relativePathXML = Path.Combine("wheel", "settings.xml");
            string fullPathXML = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePathXML);
            XDocument xml = XDocument.Load(fullPathXML);
            string countdown = xml.Element("SETTINGS").Element("COUNTDOWN").Value;
            List<string> prizes = new List<string>();
            foreach (XElement prize in xml.Element("SETTINGS").Element("PRIZES").Elements("PRIZE"))
            {
                prizes.Add(prize.Value.Trim());
            }
            string[] prizesArray = prizes.ToArray();
            string sliceLine = $"var slices = ['{string.Join("','", prizesArray)}'];";
            string countdownLine = $"var countdown = {countdown};";
            var lines = File.ReadAllLines(fullPathJS);
            lines[0] = countdownLine;
            lines[1] = sliceLine;
            File.WriteAllLines(fullPathJS, lines);
        }
    }
}
