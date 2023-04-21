using IronXL;
using PuppeteerSharp;
using System.Text.Json;

namespace fap_crawler
{
    public partial class Form1 : Form
    {
        private List<string> brwTle;
        private IPage page;
        private string seedLinkStaticPart;
        List<string> majorPrefixs;
        List<string> prefixs;
        Dictionary<string, string> cols;
        WorkBook resultWB;
        int progress = 0;
        int total = 0;
        Config? config;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            config = new Config();
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                config = JsonSerializer.Deserialize<Config>(json);
            }

            majorPrefixs = new List<string>
            {
                "SE", "SS", "DS", "QS", "SA", "SB", "CS", "HE", "HS"
            };

            prefixs = new List<string>
            {
                "6", "13", "14", "15", "16", "17", "18"
            };

            cols = new Dictionary<string, string>();
            cols.Add("Student Code", "A");
            cols.Add("Subject Code", "B");
            cols.Add("Subject Name", "C");
            cols.Add("Semester", "D");
            cols.Add("Group", "E");
            cols.Add("Start Date", "F");
            cols.Add("End Date", "G");
            cols.Add("Average Mark", "H");
            cols.Add("Status", "I");

            FileInfo file = new FileInfo(config?.ResultPath);
            file.Create();


            IBrowser browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false,
                IgnoreHTTPSErrors = true,
                IgnoredDefaultArgs = new string[] { "--disable-extensions" },
                ExecutablePath = config.ExecutablePath
            });

            var pages = await browser.PagesAsync();
            if (pages.Count() > 0)
            {
                page = pages[0];
            }
            else
            {
                page = browser.NewPageAsync().Result;
            }
            await page.GoToAsync("https://fap.fpt.edu.vn/");
            bool isLogin = await IsLoginFinishedSuccessfully(page);

            if (isLogin)
            {
                lblLoginStatus.Text = "Finished Successfully";
            }
        }

        private async Task<bool> IsLoginFinishedSuccessfully(IPage page)
        {
            bool isLogin = false;
            string logoutLink = @"https://fap.fpt.edu.vn/Default.aspx";
            string defaultLink = @"https://fap.fpt.edu.vn";
            string defaultLink1 = @"https://fap.fpt.edu.vn/";


            while (!isLogin)
            {
                string currentPage = page.Url.ToString();
                if (!(currentPage.StartsWith(logoutLink) || currentPage.ToLower().Equals(defaultLink.ToLower()) || currentPage.ToLower().Equals(defaultLink1.ToLower())))
                {
                    isLogin = true;
                }
                await Task.Delay(3000);
            }

            return isLogin;
        }

        private async void btnCrawlData_Click(object sender, EventArgs e)
        {
            resultWB = WorkBook.Load(config?.ResultPath);

            string seedLink = txtSeedLink.Text.Trim();
            string[] seedLinkPart = seedLink.Split(config?.SeedSeparator);
            seedLinkStaticPart = seedLinkPart[0];

            foreach (string major in majorPrefixs)
            {
                await CrawlDataForEachWorkSheet(major);
            }

            resultWB.SaveAs(config?.ResultPath);

            lblProcessStatus.Text = "Finished";
        }

        private async Task CrawlDataForEachStudent(string studentCode, WorkSheet destSheet)
        {
            progress = 0;
            total = 10000 * majorPrefixs.Count * prefixs.Count;


            string link = seedLinkStaticPart + studentCode;

            try
            {
                await page.GoToAsync(link);

                var jsCode = @"() => {
                    var table = document.getElementsByClassName('table')[0];
                    var tableData = [];
                    for(i = 1; i<table.rows.length; i++){
                        var objCells = table.rows.item(i).cells;
                        let data = {subjectCode: objCells.item(1).innerText, subjectName: objCells.item(2).innerText, semester: objCells.item(3).innerText, group: objCells.item(4).innerText, startDate: objCells.item(5).innerText, endDate: objCells.item(6).innerText, averageMark: objCells.item(7).innerText, status: objCells.item(8).innerText}; 
                        tableData.push(data);
                    }
                    return tableData;
                }";

                var results = await page.EvaluateFunctionAsync<Data[]>(jsCode);

                foreach (var result in results)
                {
                    int currentRow = destSheet.Rows.Count() + 1;

                    destSheet[cols.GetValueOrDefault("Student Code") + currentRow].Value = studentCode;
                    destSheet[cols.GetValueOrDefault("Subject Code") + currentRow].Value = result.SubjectCode;
                    destSheet[cols.GetValueOrDefault("Subject Name") + currentRow].Value = result.SubjectName;
                    destSheet[cols.GetValueOrDefault("Semester") + currentRow].Value = result.Semester;
                    destSheet[cols.GetValueOrDefault("Group") + currentRow].Value = result.Group;
                    destSheet[cols.GetValueOrDefault("Start Date") + currentRow].Value = result.StartDate;
                    destSheet[cols.GetValueOrDefault("End Date") + currentRow].Value = result.EndDate;
                    destSheet[cols.GetValueOrDefault("Average Mark") + currentRow].Value = result.AverageMark;
                    destSheet[cols.GetValueOrDefault("Status") + currentRow].Value = result.Status;

                    //textArea.AppendText(studentCode + ":" + result.SubjectCode + ":" + result.AverageMark + "\n");
                }

                progress++;
                lblProcessStatus.Text = "Processing... " + Math.Floor((decimal)progress / total * 100) + "%";
            }
            catch (Exception ex)
            {
                //textArea.AppendText("Error:" + studentCode + ": " + ex.Message + "\n");
            }
        }

        private async Task CrawlDataForEachWorkSheet(string majorPrefix)
        {
            WorkSheet workSheet = resultWB.CreateWorkSheet(majorPrefix);
            workSheet[cols.GetValueOrDefault("Student Code") + "1"].Value = "Student Code";
            workSheet[cols.GetValueOrDefault("Subject Code") + "1"].Value = "Subject Code";
            workSheet[cols.GetValueOrDefault("Subject Name") + "1"].Value = "Subject Name";
            workSheet[cols.GetValueOrDefault("Semester") + "1"].Value = "Semester";
            workSheet[cols.GetValueOrDefault("Group") + "1"].Value = "Group";
            workSheet[cols.GetValueOrDefault("Start Date") + "1"].Value = "Start Date";
            workSheet[cols.GetValueOrDefault("End Date") + "1"].Value = "End Date";
            workSheet[cols.GetValueOrDefault("Average Mark") + "1"].Value = "Average Mark";
            workSheet[cols.GetValueOrDefault("Status") + "1"].Value = "Status";
            foreach (string k in prefixs)
            {
                for (int i = 0; i < 10000; i++)
                {
                    await CrawlDataForEachStudent(majorPrefix + k + i.ToString("D4"), workSheet);
                }
            }
        }
    }
}