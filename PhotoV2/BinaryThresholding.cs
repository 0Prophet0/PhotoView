using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoV2
{
    public partial class BinaryThresholding : Form
    {
        private Control form1 = new Control(); //宣告Control用以接收Form1本體  
        public BinaryThresholding(Control controlF1)
        {
            InitializeComponent();
            form1 = controlF1; //將Form1存入BinaryThresholding宣告控制項  
        }

        private void SubmitClick(object sender, EventArgs e)
        {
            //將Control轉型為Form1後使用Form1的function回傳資料  
            ((Form1)form1).Receive_BinaryThresholdingDATA((int)Cvalue.Value);
        }
    }
}
