using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;
using System;
using System.Windows.Forms;

/// <summary>
/// Name: ionTheme
/// Author: ion
/// Controls: Form, Close, Button, TextBox
/// </summary>

class Drawing
{
    public static void DrawRect(Graphics G, Brush InnerBrush, Brush OutlineBrush, Rectangle Rectangle)
    {
        G.FillRectangle(InnerBrush, Rectangle);
    }

    public static void DrawWithOutline(Graphics G, Brush InnerBrush, Brush OutlineBrush, Rectangle Rectangle)
    {
        G.FillRectangle(InnerBrush, Rectangle);
        G.DrawRectangle(new Pen(OutlineBrush), Rectangle);
    }

    public static Brush tehColor = new SolidBrush(Color.FromArgb(27, 136, 209));
    public static Brush underlineColor = new SolidBrush(Color.FromArgb(223, 238, 244));
}

class ionForm : ContainerControl
{

    #region "MouseStates"
    bool IsDown = false;
    int TitleHeight = 32;
    Point MouseCurrent = new Point(0, 0);

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, TitleHeight).Contains(e.Location))
        {
            MouseCurrent = e.Location;
            IsDown = true;
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        IsDown = false;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (IsDown == true)
        {
            Parent.Location = new Point(MousePosition.X - MouseCurrent.X, MousePosition.Y - MouseCurrent.Y);
        }
    }
    #endregion

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        ParentForm.FormBorderStyle = FormBorderStyle.None;
        ParentForm.AllowTransparency = false;
        ParentForm.TransparencyKey = Color.Fuchsia;
        Dock = DockStyle.Fill;
        Invalidate();
    }

    public ionForm()
    {
        Font = new Font("Tahoma", 11);
        Padding = new Padding(1, TitleHeight, 1, 1);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (Graphics g = e.Graphics)
        {
            g.Clear(Color.FromArgb(255, 255, 255));

            using (Pen thickness = new Pen(Color.FromArgb(51, 181, 229)))
            {
                thickness.Width = 6F;
                g.DrawLine(thickness, 0, 0, Width, 0); //titleline
            }


            g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(51, 182, 232)), new Rectangle(7, 0, Width, TitleHeight + 2), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });
        }
    }
}

public enum MouseState
{
    None = 0,
    Hover = 1,
    Down = 2,
    Block = 3
}

class ionClose : Control
{
    private MouseState State = MouseState.None;

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = MouseState.Hover;
        Invalidate();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = MouseState.Down;
        Invalidate();
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = MouseState.None;
        Invalidate();
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = MouseState.Hover;
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        Environment.Exit(0);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(25, 25);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        Location = new Point(FindForm().Width-25, 0);
    }

    public ionClose()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
        DoubleBuffered = true;
        BackColor = Color.FromArgb(51, 181, 229);
        Size = new Size(25, 25);
        Anchor = AnchorStyles.Top | AnchorStyles.Right;
        Font = new Font("Marlett", 12);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap b = new Bitmap(Width, Height);
        using (Graphics g = Graphics.FromImage(b))
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(0, 0, Width, Height);

            switch (State)
            {
                case MouseState.Hover:
                    {
                        g.DrawString("r", Font, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(1, 1, Width, Height), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    }
                case MouseState.None:
                    {
                        g.DrawString("r", Font, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(1, 1, Width, Height), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    }
                default:
                    g.DrawString("r", Font, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(1, 1, Width, Height), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            e.Graphics.DrawImage(b, 0, 0);
        }

        b.Dispose();

        base.OnPaint(e);
    }
}

class ionButton : Control
{
    MouseState _MouseState;
    Font _font;

    public ionButton()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Size = new Size(210, 35);

        _MouseState = MouseState.None;
        _font = new Font("Tahoma", 8, FontStyle.Regular);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap b = new Bitmap(Width, Height);
        Brush _inner = new SolidBrush(Color.FromArgb(51, 181, 229));

        base.OnPaint(e);

        using (Graphics g = Graphics.FromImage(b))
        {
            switch (_MouseState)
            {
                case MouseState.Hover:
                    {
                        //-27, -42, -48 => 4x -6.75, -10.5, -12
                        _inner = new SolidBrush(Color.FromArgb(44, 170, 217));
                        _inner = new SolidBrush(Color.FromArgb(37, 159, 205));
                        _inner = new SolidBrush(Color.FromArgb(31, 148, 193));
                        _inner = new SolidBrush(Color.FromArgb(24, 139, 181));
                        break;
                    };

                default:
                    _inner = new SolidBrush(Color.FromArgb(51, 181, 229));
                    break;
            }


            Drawing.DrawRect(g, _inner, new SolidBrush(Color.FromArgb(51, 181, 229)), new Rectangle(0, 0, Width, Height));

            if (_MouseState == MouseState.Hover)
            {
                g.DrawString(Text, _font, new SolidBrush(Color.FromArgb(255,255,255)), new Rectangle(0, 1, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });

            }
            else
            {
                g.DrawString(Text, _font, new SolidBrush(Color.FromArgb(255,255,255)), new Rectangle(0, 1, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            e.Graphics.DrawImage(b, 0, 0);
        }

        b.Dispose();
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseDown(e);
        _MouseState = MouseState.Down;
        Invalidate();
    }

    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseUp(e);
        _MouseState = MouseState.Hover;
        Invalidate();
    }

    protected override void OnMouseEnter(System.EventArgs e)
    {
        base.OnMouseEnter(e);
        _MouseState = MouseState.Hover;
        Invalidate();
    }

    protected override void OnMouseLeave(System.EventArgs e)
    {
        base.OnMouseLeave(e);
        _MouseState = MouseState.None;
        Invalidate();
    }
}

[DefaultEvent("TextChanged")]
public class ionTextBox : Control
{
    public TextBox ionTB = new TextBox();

    private HorizontalAlignment _textAlignment;
    public HorizontalAlignment TextAlignment
    {
        get
        {
            return _textAlignment;
        }
        set
        {
            _textAlignment = value;
            Invalidate();
        }
    }

    private int _maxLength;
    public int MaxLength
    {
        get
        {
            return _maxLength;
        }
        set
        {
            _maxLength = value;
            ionTB.MaxLength = MaxLength;
            Invalidate();
        }
    }

    private bool _bPasswordMask;
    public bool UseSystemPasswordChar
    {
        get
        {
            return _bPasswordMask;
        }
        set
        {
            ionTB.UseSystemPasswordChar = UseSystemPasswordChar;
            _bPasswordMask = value;
            Invalidate();
        }
    }

    private bool _readOnly;
    public bool ReadOnly
    {
        get
        {
            return _readOnly;
        }
        set
        {
            _readOnly = value;
            if (ionTB != null)
            {
                ionTB.ReadOnly = value;
            }
        }
    }

    private bool _multiLine;
    public bool Multiline
    {
        get
        {
            return _multiLine;
        }
        set
        {
            _multiLine = value;
            if (ionTB != null)
            {
                ionTB.Multiline = _multiLine;
                if (_multiLine)
                {
                    Size = new Size(Width, Height + 10);
                }
                else
                {
                    Size = new Size(Width, 22);
                }
            }
        }
    }

    private void OnBaseTextChanged(object s, EventArgs e)
    {
        Text = ionTB.Text;
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        base.OnTextChanged(e);
        ionTB.Text = Text;
        Invalidate();
    }

    protected override void OnForeColorChanged(System.EventArgs e)
    {
        base.OnForeColorChanged(e);
        ionTB.ForeColor = ForeColor;
        Invalidate();
    }

    protected override void OnFontChanged(System.EventArgs e)
    {
        base.OnFontChanged(e);
        ionTB.Font = Font;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
    }

    private void _OnKeyDown(object Obj, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            ionTB.SelectAll();
            e.SuppressKeyPress = true;
        }
        if (e.Control && e.KeyCode == Keys.C)
        {
            ionTB.Copy();
            e.SuppressKeyPress = true;
        }
    }

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);

        if (_multiLine)
        {
            ionTB.Size = new Size(Width - 5, Height - 5);
        }
        else
        {
            ionTB.Size = new Size(Width - 8, 22);
        }

        Invalidate();
    }

    protected override void OnGotFocus(System.EventArgs e)
    {
        base.OnGotFocus(e);
        ionTB.Focus();
    }
    public ionTextBox()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

        Font = new Font("Tahoma", 10);
        Size = new Size(210, 35);
        DoubleBuffered = true;

        ionTB.Location = new Point(9, 9);
        ionTB.Text = String.Empty;
        ionTB.BorderStyle = BorderStyle.None;
        ionTB.Font = Font;
        ionTB.Size = new Size(Width - 5, 22);
        ionTB.BackColor = Color.FromArgb(255, 255, 255);
        ionTB.ForeColor = Color.Black;
        ionTB.UseSystemPasswordChar = UseSystemPasswordChar;
        ionTB.Multiline = false;
        ionTB.ScrollBars = ScrollBars.None;
        ionTB.KeyDown += _OnKeyDown;
        ionTB.TextChanged += OnBaseTextChanged;
        ionTB.TextAlign = TextAlignment;
        this.Controls.Add(ionTB);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Bitmap b = new Bitmap(Width, Height);
        using (Graphics g = Graphics.FromImage(b))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(255, 255, 255));

            Drawing.DrawWithOutline(g, new SolidBrush(Color.FromArgb(255, 255, 255)), new SolidBrush(Color.FromArgb(217, 217, 217)), new Rectangle(0, 0, Width - 1, Height - 1));
            e.Graphics.DrawImage(b, 0, 0);
        }
        b.Dispose();
    }
}