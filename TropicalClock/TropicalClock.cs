using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TropicalClock
{
    public partial class FormTropicalClock : Form
    {
        /// <summary>
        /// ドロップフレーム表示フラグ
        /// </summary>
        private bool dropFrame;

        public FormTropicalClock()
        {
            InitializeComponent();

            dropFrame = true;
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            if (dropFrame)
            {
                // ドロップフレーム表示

                // カウントミリ秒(10分周期)
                int countMiliSec = (Now.Minute % 10) * 60000 + Now.Second * 1000 + Now.Millisecond;

                // カウントフレーム(10分周期)
                int countFrame = (int)((double)countMiliSec / 600000 * 17982);

                // 表示フレーム(10分周期)
                int displayFrame = countFrame > 2 ? countFrame + ((countFrame - 2) / 1798) * 2 : countFrame;
                labelTime.Text = Now.ToString("HH;mm").Substring(0, 4) + (displayFrame / 1800).ToString("0") + ";" + ((displayFrame % 1800) / 30).ToString("00") + ";" + (displayFrame % 30).ToString("00");
            }
            else
            {
                // 通常1/100秒表示
                labelTime.Text = Now.ToString("HH:mm:ss.ff");
            }
        }

        private void labelTime_Click(object sender, EventArgs e)
        {
            // フラグ反転
            dropFrame = !dropFrame;
        }
    }
}
