
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SQLScriptExecutor.Controls
{
    class ToggleButton : CheckBox
    {
        //Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private Color inActiveTextColor = Color.Black;
        private Color activeTextColor = Color.Black;

        private bool solidStyle = true;
        private string activeText = "ON";
        private string inActiveText = "OFF";

        //Properties
        [Category("ToggleButton Code Advance")]
        public Color OnBackColor
        {
            get
            {
                return onBackColor;
            }

            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        [Category("ToggleButton Code Advance")]
        public Color OnToggleColor
        {
            get
            {
                return onToggleColor;
            }

            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }

        [Category("ToggleButton Code Advance")]
        public Color OffBackColor
        {
            get
            {
                return offBackColor;
            }

            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        [Category("ToggleButton Code Advance")]
        public Color OffToggleColor
        {
            get
            {
                return offToggleColor;
            }

            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }

        [Category("ToggleButton Code Advance")]
        public string ActiveText
        {
            get
            {
                return activeText;
            }
            set
            {
                activeText = value;
            }
        }
        [Category("ToggleButton Code Advance")]
        public string InActiveText
        {
            get
            {
                return inActiveText;
            }
            set
            {
                inActiveText = value;
            }
        }

        [Category("ToggleButton Code Advance")]
        public Color ActiveTextColor
        {
            get
            {
                return activeTextColor;
            }
            set
            {
                activeTextColor = value;
            }
        }
        [Category("ToggleButton Code Advance")]
        public Color InActiveTextColor
        {
            get
            {
                return inActiveTextColor;
            }
            set
            {
                inActiveTextColor = value;
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {

            }
        }

        [Category("ToggleButton Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get
            {
                return solidStyle;
            }

            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        //Constructor
        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle contentRectangle = Rectangle.Empty;
            contentRectangle = r;

            if (this.Checked) //ON
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                    new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));

                //pevent.Graphics.DrawString(this.ActiveText, Font, new SolidBrush(Color.Black), new PointF(r.Width / 4, contentRectangle.Y + (contentRectangle.Height / 4)));
                pevent.Graphics.DrawString(this.ActiveText, this.Font, new SolidBrush(this.ActiveTextColor), AlignDrawingPoint(pevent.Graphics.MeasureString(this.ActiveText, this.Font).ToSize(), this.ClientRectangle, ContentAlignment.MiddleLeft));
            }
            else //OFF
            {
                //Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));

                //pevent.Graphics.DrawString(this.InActiveText, Font, new SolidBrush(Color.Black), new PointF(r.Width / 2, contentRectangle.Y + (contentRectangle.Height / 4)));
                pevent.Graphics.DrawString(this.InActiveText, this.Font, new SolidBrush(this.InActiveTextColor), AlignDrawingPoint(pevent.Graphics.MeasureString(this.InActiveText, this.Font).ToSize(), this.ClientRectangle, ContentAlignment.MiddleRight));
            }
        }
        public Point AlignDrawingPoint(Size objectSize, Rectangle clientRectangle, ContentAlignment alignment)
        {
            int margin = 4;
            Point center = new Point((clientRectangle.Width >> 1) - (objectSize.Width >> 1), (clientRectangle.Height >> 1) - (objectSize.Height >> 1));
            int rightMargin = clientRectangle.Width - (objectSize.Width + margin);
            int bottomMargin = clientRectangle.Height - (objectSize.Height + margin);
            Point p = Point.Empty;
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    p = new Point(margin, margin);
                    break;
                case ContentAlignment.TopCenter:
                    p = new Point(center.X, margin);
                    break;
                case ContentAlignment.TopRight:
                    p = new Point(rightMargin, margin);
                    break;
                case ContentAlignment.MiddleLeft:
                    p = new Point(margin, center.Y);
                    break;
                case ContentAlignment.MiddleCenter:
                    p = new Point(center.X, center.Y);
                    break;
                case ContentAlignment.MiddleRight:
                    p = new Point(rightMargin, center.Y);
                    break;
                case ContentAlignment.BottomLeft:
                    p = new Point(margin, bottomMargin);
                    break;
                case ContentAlignment.BottomCenter:
                    p = new Point(center.X, bottomMargin);
                    break;
                case ContentAlignment.BottomRight:
                    p = new Point(rightMargin, bottomMargin);
                    break;
            }
            p.Offset(clientRectangle.X, clientRectangle.Y);
            return p;
        }
    }
}
