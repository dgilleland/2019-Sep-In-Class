using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ParseHtmlInput_Click(object sender, EventArgs e)
        {
            PostBackOutput.InnerHtml = "<h4>HTML Input Controls</h4><ul>";

            PostBackOutput.InnerHtml += ListItemResultOfParse("Date", HtmlDate.Value);
            PostBackOutput.InnerHtml += ListItemResultOfParse("DateTime", HtmlDateTime.Value);
            PostBackOutput.InnerHtml += ListItemResultOfParse("DateTime-Local", HtmlDateTimeLocal.Value);
            PostBackOutput.InnerHtml += ListItemResultOfParse("Time", HtmlTime.Value);
            PostBackOutput.InnerHtml += ListItemResultOfParse("Week", HtmlWeek.Value);
            PostBackOutput.InnerHtml += ListItemResultOfParse("Month", HtmlMonth.Value);

            PostBackOutput.InnerHtml += "</ul>";
        }

        private string ListItemResultOfParse(string message, string dateValue)
        {
            DateTime parseResult;
            if (DateTime.TryParse(dateValue, out parseResult))
                dateValue = parseResult.ToString();
            else
                dateValue = "~cannot parse as DateTime~";
            return $"<li>{message} - <b>{dateValue}</b></li>";
        }

        protected void ParseTextBoxInput_Click(object sender, EventArgs e)
        {

        }
    }
}