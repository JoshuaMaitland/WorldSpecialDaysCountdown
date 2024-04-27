using System;
using System.Windows.Forms;
// Other namespace
using Holidays;

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
            DateTime newYearDate = new DateTime(DateTime.Now.Year + 1, 1, 1);
            DateTime valentinesDate = new DateTime(DateTime.Now.Year, 2, 14);
            DateTime stPatricksDayDate = new DateTime(DateTime.Now.Year, 3, 17);
            DateTime easterDate = ChristianHolidays.EasterSunday(DateTime.Now.Year);
            DateTime halloweenDate = new DateTime(DateTime.Now.Year, 10, 31);
            DateTime armisticeDate = new DateTime(DateTime.Now.Year, 11, 11);
            DateTime christmasDate = ChristianHolidays.ChristmasDay(DateTime.Now.Year);

            double daysUntilNewYear = newYearDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilValentines = valentinesDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilStPatricksDay = stPatricksDayDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilEaster = easterDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilHalloween = halloweenDate.Subtract(DateTime.Today).TotalDays;
            double daysUntilArmistice = armisticeDate.Subtract(DateTime.Today).TotalDays;
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
            lblDaysLeftChristmas.Text += daysUntilChristmas.ToString();
        }
    }
}
