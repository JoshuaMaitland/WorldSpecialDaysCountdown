// Other namespace
using Holidays;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WorldSpecialDaysCountdown
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "World Special Days Left in " + DateTime.Now.Year;
#if DEBUG
            Text += " [DEBUG]";
#endif
            // Check for new version
            if (Application.ProductVersion != VersionChecker.GetNewVersionNumberFromGithubAPI())
            {
                if (MessageBox.Show("A new version of World Special Days Countdown is available. Do you want to download a new version?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start("https://github.com/JoshuaMaitland/WorldSpecialDaysCountdown/releases");
                }
            }

            var thanksgivingDay = (from day in Enumerable.Range(1, 30)
                                where new DateTime(DateTime.Now.Year, 11, day).DayOfWeek == DayOfWeek.Thursday
                                select day).ElementAt(3);

            DateTime newYearDate = new DateTime(DateTime.Now.Year + 1, 1, 1);
            DateTime valentinesDate = new DateTime(DateTime.Now.Year, 2, 14);
            DateTime stPatricksDayDate = new DateTime(DateTime.Now.Year, 3, 17);
            DateTime easterDate = ChristianHolidays.EasterSunday(DateTime.Now.Year);
            DateTime halloweenDate = new DateTime(DateTime.Now.Year, 10, 31);
            DateTime armisticeDate = new DateTime(DateTime.Now.Year, 11, 11);
            DateTime thanksgivingDate = new DateTime(DateTime.Now.Year, 11, thanksgivingDay);
            DateTime christmasDate = ChristianHolidays.ChristmasDay(DateTime.Now.Year);

            double daysUntilNewYear = newYearDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilValentines = valentinesDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilStPatricksDay = stPatricksDayDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilEaster = easterDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilHalloween = halloweenDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilArmistice = armisticeDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilThanksgiving = thanksgivingDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilChristmas = christmasDate.Subtract(DateTime.Today).TotalDays;

            // Check if it's all over and these events will have to wait until next year
            if (daysUntilValentines <= 0)
            {
                daysUntilValentines = 0;
            }

            if (daysUntilStPatricksDay <= 0)
            {
                daysUntilStPatricksDay = 0;
            }

            if (daysUntilEaster <= 0)
            {
                daysUntilEaster = 0;
            }

            if (daysUntilHalloween <= 0)
            {
                daysUntilHalloween = 0;
            }

            if (daysUntilArmistice <= 0)
            {
                daysUntilArmistice = 0;
            }

            if (daysUntilThanksgiving <= 0)
            {
                daysUntilThanksgiving = 0;
            }

            if (daysUntilChristmas <= 0)
            {
                daysUntilChristmas = 0;
            }

            lblDaysLeftNewYear.Text += daysUntilNewYear.ToString();
            lblDaysLeftValentines.Text += daysUntilValentines.ToString();
            lblDaysLeftStPatricksDay.Text += daysUntilStPatricksDay.ToString();
            lblDaysLeftEaster.Text += daysUntilEaster.ToString();
            lblDaysLeftHalloween.Text += daysUntilHalloween.ToString();
            lblDaysLeftArmisticeDay.Text += daysUntilArmistice.ToString();
            lblDaysLeftThanksgiving.Text += daysUntilThanksgiving.ToString();
            lblDaysLeftChristmas.Text += daysUntilChristmas.ToString();
        }
    }
}
