using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using Microsoft.VisualBasic.FileIO;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml.Linq;

namespace DigicanCalendarTools
{
    public partial class Form1 : Form
    {
        private bool is_csv = false;
        private bool is_xlsx = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "出席状況確認ファイルを選択";
                ofd.Filter = "エクセルファイル(.xlsx)|*.xlsx|ＣＳＶファイル|*.csv";
                ofd.FilterIndex = 1;
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = System.IO.Path.GetFullPath(ofd.FileName);
                    string ext = System.IO.Path.GetExtension(filePath);
                    if (ext == ".xlsx")
                    {
                        openFile.Text = filePath;
                        is_xlsx = true;

                    }
                    else if (ext == ".csv")
                    {
                        openFile.Text = filePath;
                        is_csv = true;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("\"{0}\"'s filetype is not xlsx or csv."));
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            List<List<string>> eventlist = null;
            if (is_xlsx)
            {
                MessageBox.Show("xlsxファイルからcsvファイルへ変換します。", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var gdxlsx = new GetDataXlsx();
                eventlist = gdxlsx.GetData(System.IO.Path.GetFullPath(openFile.Text));
            }
            else if(is_csv)
            {
                MessageBox.Show("csvファイルからcsvファイルへ変換します。", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var gdcsv = new GetDataCsv();
                eventlist = gdcsv.GetData(System.IO.Path.GetFullPath(openFile.Text));
            }
            else
            {
                throw new ArgumentException("file not find");
            }
            // 保存するファイルを選択
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            sfd.Filter = "iCalendar(カレンダーデータ)|*.ics|ＣＳＶファイル|*.csv";
            sfd.Title = "ファイルを保存";
            sfd.FilterIndex = 1;
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = ".csv";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var save = new WriteData();
                save.WriteCSV(eventlist, sfd.FileName);
            }
            MessageBox.Show("処理が完了しました。", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class GetDataCsv
    {
        public GetDataCsv() { }

        public string name = string.Empty;
        public string faculty = string.Empty;
        public string year_str = string.Empty;
        public string getDate = string.Empty;

        public List<string[]> ReadCsv(string filepath)
        {
            TextFieldParser parser = new TextFieldParser(filepath, Encoding.UTF8);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            List<string[]> csvdata = new List<string[]>();
            while (parser.EndOfData == false)
            {
                string[] csvlinedata = parser.ReadFields();
                csvdata.Add(csvlinedata);
            }
            return csvdata;
        }

        public List<List<string>> GetData(string filepath)
        {
            string set_year = string.Empty;// 授業実施年
            string startDay = string.Empty;// 授業開始日付
            string stratTime = string.Empty;// 授業開始時間
            string finishDay = string.Empty;// 授業終了日付
            string finishTime = string.Empty;// 授業終了時間
            // データリスト作成
            var eventlist = new List<List<string>>();
            int v = 9; // 列番号
            int h = 33;// 行番号
            string subject = string.Empty;// 授業名
            string date = string.Empty;// 日付
            string lesson = string.Empty;// 時限
            // 授業時間を設定
            var lessons = new List<List<string>>() { new List<string>() { "8:40", "10:10" }, new List<string>() { "10:20", "11:50" }, new List<string>() { "12:40", "14:10" }, new List<string>() { "14:20", "15:50" }, new List<string>() { "16:00", "17:30" }, new List<string>() { "17:40", "19:10" } };
            var csvdata = ReadCsv(filepath);
            string[] csvheader = csvdata[0];
            if (csvheader[0] == "Subject" & csvheader[1] == "Start Date" & csvheader[2] == "Start Time" & csvheader[3] == "End Date" & csvheader[4] == "End Time" & csvheader[5] == "All Day Event" & csvheader[6] == "Private")
            {
                for (int i = 1; i < csvdata[0].Length; i++)
                {
                    var eventdata = new List<string>(csvdata[i]);
                    eventlist.Add(eventdata);
                }
            }
            else if (csvdata[2][32] == "学生出欠状況表")
            {
                // 名前のcellを検索
                name = csvdata[4][1];
                // 学年のcellを検索
                faculty = csvdata[5][1];
                // 年度・クォーターのcellを検索
                year_str = csvdata[6][1];
                // 取得日のcellを検索
                getDate = csvdata[38][65];
                string year = year_str.Substring(0, 4);// 授業年度
                // ループで授業を取得
                while (true)
                {
                    subject = string.Empty;// 授業名初期化
                    subject = csvdata[v][2];
                    MessageBox.Show(string.Format("subject = {0}", subject), "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (subject == null || subject == string.Empty)
                    {
                        break;
                    }
                    while (true)
                    {
                        // 初期化
                        date = string.Empty;// 日付
                        lesson = string.Empty;// 時限
                        set_year = string.Empty;// 授業実施年
                        startDay = string.Empty;// 授業開始日付
                        stratTime = string.Empty;// 授業開始時間
                        finishDay = string.Empty;// 授業終了日付
                        finishTime = string.Empty;// 授業終了時間
                        // 初期化終了
                        date = csvdata[v][h];
                        if (date == null || date == string.Empty) 
                        {
                            h = 33;
                            break;
                        }
                        lesson = csvdata[v + 1][h + 2];
                        List<string> lessontime = lessons[int.Parse(lesson) - 1];
                        if (int.Parse(date.Split('/')[0]) < 4)
                        {
                            int _set_year = int.Parse(year) + 1;
                            set_year = _set_year.ToString();
                        }
                        else
                        {
                            set_year = year;
                        }
                        startDay = set_year + "/" + date;
                        stratTime = lessontime[0];
                        finishDay = set_year + "/" + date;
                        finishTime = lessontime[1];
                        var eventdata = new List<string>() { subject, startDay, stratTime, finishDay, finishTime, "False", "True" };
                        eventlist.Add(eventdata);
                        h = h + 3;
                    }
                    v = v + 3;
                }
            }
            else
            {
                throw new ArgumentException("Unknown file format.");
            }
            return eventlist;
        }
    }

    public class GetDataXlsx
    {
        public GetDataXlsx() { }

        private WorkbookPart wbPart;
        private WorksheetPart wsPart;

        public string name = string.Empty;
        public string faculty = string.Empty;
        public string year_str = string.Empty;
        public string getDate = string.Empty;

        private string GetCellText(string cellAddress)
        {
            string rtn = null;
            Cell nameCell = wsPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference == cellAddress).FirstOrDefault();
            // cellがあれば処理を継続
            if (nameCell == null)
            {
                return null;
            }
            rtn = nameCell.InnerText;
            // データ型判定
            if (nameCell.DataType != null)
            {
                // 文字列型、または、Boolen型
                switch (nameCell.DataType.Value)
                {
                    case CellValues.SharedString:
                        var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                        if (stringTable != null)
                        {
                            rtn = stringTable.SharedStringTable.ElementAt(int.Parse(rtn)).InnerText;
                        }
                        else
                        {
                            throw new ArgumentException("This book is broken.");
                        }
                        break;
                    case CellValues.Boolean:
                        switch (rtn)
                        {
                            case "0":
                                rtn = "FALSE";
                                break;
                            default:
                                rtn = "TRUE";
                                break;
                        }
                        break;
                }
            }
            return rtn;
        }

        public string GetCellAddress(int v ,int h)
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string s = "";

            for (; h > 0; h = (h - 1) / 26)
            {
                int n = (h - 1) % 26;
                s = alpha.Substring(n, 1) + s;
            }
            s = string.Format("{0}{1}", s, v.ToString());
            return s;
        }

        public List<List<string>> GetData(string filename)
        {
            string set_year = string.Empty;// 授業実施年
            string startDay = string.Empty;// 授業開始日付
            string stratTime = string.Empty;// 授業開始時間
            string finishDay = string.Empty;// 授業終了日付
            string finishTime = string.Empty;// 授業終了時間
            // データリスト作成
            var eventlist = new List<List<string>>();
            int v = 10; // 列番号
            int h = 34;// 行番号
            string subject = string.Empty;// 授業名
            string date = string.Empty;// 日付
            string lesson = string.Empty;// 時限
            // 授業時間を設定
            var lessons = new List<List<string>>() { new List<string>() { "8:40", "10:10" }, new List<string>() { "10:20", "11:50" }, new List<string>() { "12:40", "14:10" }, new List<string>() { "14:20", "15:50" }, new List<string>() { "16:00", "17:30" }, new List<string>() { "17:40", "19:10" } };
            //変換するファイルを開く
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filename, false))
            {
                // bookの参照場所を作成
                wbPart = spreadsheetDocument.WorkbookPart;
                // sheetを検索
                string sheetName = "Sheet1";
                Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).FirstOrDefault();
                // sheetが存在しない場合はエラー
                if (sheet == null)
                {
                    throw new ArgumentException($"{sheetName} does not exist.");
                }
                // sheetの参照場所を作成
                wsPart = (WorksheetPart)(wbPart.GetPartById(sheet.Id));
                // 名前のcellを検索
                name = GetCellText("B5");
                // 学年のcellを検索
                faculty = GetCellText("B6");
                // 年度・クォーターのcellを検索
                year_str = GetCellText("B7");
                // 取得日のcellを検索
                getDate = GetCellText("BN39");
                string year = year_str.Substring(0, 4);// 授業年度
                // ループで授業を取得
                while (true)
                {
                    subject = string.Empty;// 授業名初期化
                    subject = GetCellText(GetCellAddress(v, 3));
                    if (subject == null || subject == string.Empty)
                    {
                        break;
                    }
                    while (true)
                    {
                        // 初期化
                        date = string.Empty;// 日付
                        lesson = string.Empty;// 時限
                        set_year = string.Empty;// 授業実施年
                        startDay = string.Empty;// 授業開始日付
                        stratTime = string.Empty;// 授業開始時間
                        finishDay = string.Empty;// 授業終了日付
                        finishTime = string.Empty;// 授業終了時間
                        // 初期化終了
                        date = GetCellText(GetCellAddress(v, h));
                        if (date == null || date == string.Empty)
                        {
                            h = 34;
                            break;
                        }
                        lesson = GetCellText(GetCellAddress(v + 1, h + 2));
                        List<string> lessontime = lessons[int.Parse(lesson) - 1];
                        if (int.Parse(date.Split('/')[0]) < 4)
                        {
                            int _set_year = int.Parse(year) + 1;
                            set_year = _set_year.ToString();
                        }
                        else
                        {
                            set_year = year;
                        }
                        startDay = set_year + "/" + date;
                        stratTime = lessontime[0];
                        finishDay = set_year + "/" + date;
                        finishTime = lessontime[1];
                        var eventdata = new List<string>() { subject, startDay, stratTime, finishDay, finishTime, "False", "True" };
                        eventlist.Add(eventdata);
                        h = h + 3;
                    }
                    v = v + 3;
                }
            }
            return eventlist;
        }
    }

    public class WriteData
    {
        public WriteData() { }
        public void WriteCSV(List<List<string>> eventlist, string filepath)
        {
            StreamWriter file = new StreamWriter(filepath, false, Encoding.UTF8);
            file.WriteLine("Subject,Start Date,Start Time,End Date,End Time,All Day Event,Private");
            for (int i = 0; i < eventlist.Count; i++)
            {
                var eventdata = eventlist[i];
                file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", eventdata[0], eventdata[1], eventdata[2], eventdata[3], eventdata[4], eventdata[5], eventdata[6]));
            }
            file.Close();
            return;
        }
    }
}
