using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testBtn.Click += TestBtn_Click;

        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}