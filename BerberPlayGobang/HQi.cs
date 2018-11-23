using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BerberPlayGobang
{
    public partial class HQi : UserControl
    {
        public HQi()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath gPath = new GraphicsPath();
            
            // 绘制椭圆形区域
            gPath.AddEllipse(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            SolidBrush b = new SolidBrush(Color.Black);
            g.FillEllipse(b, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            //g.FillPath(b, gPath);
            // 将区域赋值给Region
            this.Region = new System.Drawing.Region(gPath);
            base.OnPaint(pevent);
        }

        private void Qi_Load(object sender, EventArgs e)
        {
        }
    }
}
