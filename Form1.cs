using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Reflex_Test {
    public partial class Form1:Form {
        private Random fakeRng = new Random(DateTime.Now.Millisecond);
        private int status = 0;
        private int StartTime;
        private Thread NiceMeme;
        public Form1() {
            InitializeComponent();
        }
        private void label1_MouseDown(object sender,MouseEventArgs e) {
            if(status == 0) {
                NiceMeme = new Thread(NiceMemeDelegate);
                NiceMeme.Start();
                label1.Text = "Click When The Background Turns Green";
                status = 1;
            } else if(status == 1) {
                NiceMeme.Abort();
                label1.Text = "You Clicked Too Early, Click to Try Again";
                status = 0;
            } else if(status == 2) {
                int FinishTime = Convert.ToInt32(DateTime.Now.TimeOfDay.TotalMilliseconds) - StartTime;
                label1.Text = "" + FinishTime + " milliseconds, Click To Try Again";
                status = 0;
                this.BackColor = Color.Red;
            }
        }
        private void NiceMemeDelegate() {
            Thread.Sleep(fakeRng.Next(4000, 9000));
            status = 2;
            this.BackColor = Color.Green;
            StartTime = Convert.ToInt32(DateTime.Now.TimeOfDay.TotalMilliseconds);
        }
    }
}
