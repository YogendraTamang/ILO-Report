using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace utilitClass
{
    [ToolboxBitmap(typeof(ComboBox))]
    public class GridComboBox : ComboBox
    {
        private bool _findItemMode = false;
        private Int32[] _columnWidthCollection;
        //private Color _headerBackColor = Color.BlanchedAlmond;
        private Color _headerBackColor = Color.FromArgb(123, 162, 206);
        private Color _gridColor = Color.FromKnownColor(KnownColor.Control);
        //private Color _hotTrackColor = Color.SeaShell;
        private Color _hotTrackColor = Color.FromArgb(123, 162, 206);
        
        private string _oldValue = String.Empty;
        private bool _upperCaseOnLeave = false;

        
        #region "API for ReadOnly"

        private bool _DroppedDown;
        private bool _ReadOnly;
        private int _SelectedIndex = -1;
        private const int CB_SHOWDROPDOWN = 0x14f;
        private const int EM_EMPTYUNDOBUFFER = 0xcd;
        private const int EM_SETREADONLY = 0xcf;
        private const int GW_CHILD = 5;

        // Methods
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hwnd, int wCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, bool wParam, int lParam);

        protected override void OnDropDown(EventArgs e)
        {
            this._DroppedDown = true;
            base.OnDropDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this._ReadOnly && (((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Prior))
                || ((e.KeyCode == Keys.Next) || ((e.KeyCode == Keys.Down) &
                ((Control.ModifierKeys & Keys.Alt) != Keys.Alt)))))
            {
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            if (!this._ReadOnly)
            {
                base.OnSelectionChangeCommitted(e);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if ((this._ReadOnly && this._DroppedDown) && (m.Msg == 0x111))
            {
                this._DroppedDown = false;
                SendMessage(this.Handle, 0x14f, Convert.ToInt32(false) > 0, 0);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        [DefaultValue(false), Browsable(true), Description("Controls where the control to be read only or not.")]
        public bool ReadOnly
        {
            get { return this._ReadOnly; }
            set
            {
                this._ReadOnly = value;
                SendMessage(GetWindow(this.Handle, 5), 0xcf, value, 0);
                this._DroppedDown = false;
                this.Refresh();
            }
        }

        //public override int SelectedIndex
        //{
        //    get
        //    {
        //        return this._SelectedIndex;
        //    }
        //    set
        //    {
        //        this._SelectedIndex = value;
        //        base.SelectedIndex = value;
        //    }
        //}

        #endregion

        public GridComboBox() : base()
        {
            base.DrawMode = DrawMode.OwnerDrawFixed;            
        }

        [Browsable(true), Description("Specifies the number of columns with specific width")]
        public Int32 []ColumnWidthCollection
        {
            get { return this._columnWidthCollection; }
            set
            {
                this._columnWidthCollection = value;
            }
        }

        [Browsable(true), Description("Gets or sets the Background Color of the Combobox Heading")]
        public Color HeaderBackColor
        {
            get { return this._headerBackColor; }
            set { this._headerBackColor = value; }
        }

        [Browsable(true), Description("Gets or sets the grid line color of the combobox")]
        public Color GridLineColor
        {
            get { return this._gridColor; }
            set { this._gridColor = value; }
        }

        [Browsable(true), Description("Gets or sets hot-track color, that is, the item is highlighted as the mouse pointer passes over it.")]
        public Color HotTrackColor
        {
            get { return this._hotTrackColor; }
            set { this._hotTrackColor = value; }        
        }

        [Browsable(true),DefaultValue(false), Description("Changes the letters to uppercase while losing the focus from the control.")]
        public bool UpperCaseOnLeave
        {
            get { return _upperCaseOnLeave; }
            set { _upperCaseOnLeave = value; }
        }

        /// <summary>
        /// Alows the user to find the matching string within the list when typing.\n It is same as autocomplete feature.
        /// </summary>
        [Browsable(true), Description("Gets or sets the find mode of the control. If the value is true, Items can be searched on key stroke.")]
        public bool FindItemMode
        {
            get { return this._findItemMode; }
            set { this._findItemMode = value; }
        }
        
        public String OldValue
        {
            get { return this._oldValue; }
            set { this._oldValue = value; }        
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            OldValue = this.Text;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                DrawGridInCombo(e, this.ColumnWidthCollection);
            }
            catch { }

            base.OnDrawItem(e);

        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            e.ItemHeight = 13;
        }

        private String[] GetComboValues(Int32 totalColumns, GridComboBoxItem obj)
        {
            String[] arr;
            if (totalColumns == 1)
            {
                arr = new String[1];
                arr[0] = obj.Column1;
            }
            else if (totalColumns == 2)
            {
                arr = new String[2];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
            }
            else if (totalColumns == 3)
            {
                arr = new String[3];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
            }
            else if (totalColumns == 4)
            {
                arr = new String[4];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
            }
            else if (totalColumns == 5)
            {
                arr = new String[5];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
                arr[4] = obj.Column5;
            }
            else if (totalColumns == 6)
            {
                arr = new String[6];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
                arr[4] = obj.Column5;
                arr[5] = obj.Column6;
            }
            else if (totalColumns == 6)
            {
                arr = new String[6];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
                arr[4] = obj.Column5;
                arr[5] = obj.Column6;
            }
            else if (totalColumns == 7)
            {
                arr = new String[7];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
                arr[4] = obj.Column5;
                arr[5] = obj.Column6;
                arr[6] = obj.Column7;
            }
            else if (totalColumns == 8)
            {
                arr = new String[8];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
                arr[4] = obj.Column5;
                arr[5] = obj.Column6;
                arr[6] = obj.Column7;
                arr[7] = obj.Column8;
            }
            else if (totalColumns == 9)
            {
                arr = new String[9];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
                arr[4] = obj.Column5;
                arr[5] = obj.Column6;
                arr[6] = obj.Column7;
                arr[7] = obj.Column8;
                arr[8] = obj.Column9;
            }
            else
            {
                arr = new String[10];
                arr[0] = obj.Column1;
                arr[1] = obj.Column2;
                arr[2] = obj.Column3;
                arr[3] = obj.Column4;
                arr[4] = obj.Column5;
                arr[5] = obj.Column6;
                arr[6] = obj.Column7;
                arr[7] = obj.Column8;
                arr[8] = obj.Column9;
                arr[9] = obj.Column10;
            }

            return arr;
        }

        private void DrawGridInCombo(DrawItemEventArgs e, Int32[] colWidths)
        {
            try
            {
                if (e.Index != -1)
                {
                    e.DrawBackground();

                    Rectangle hRect = new Rectangle(0, e.Bounds.Top, this.DropDownWidth, e.Bounds.Height);
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        SolidBrush brsh = new SolidBrush(this.HotTrackColor);
                        e.Graphics.FillRectangle(brsh, hRect);
                        brsh.Dispose();
                    }
                    
                    Int32 wd = -1;
                    for (Int32 i = 0; i < colWidths.Length; i++)
                    {
                        Rectangle rect = new Rectangle(wd, e.Bounds.Top-1, colWidths[i], e.Bounds.Height);
                        GridComboBoxItem obj = (GridComboBoxItem)this.Items[e.Index];
                        String[] arr = GetComboValues(colWidths.Length, obj);
                        Font fnt;
                        if (obj.IsHeader == true)
                        {
                            SolidBrush brsh = new SolidBrush(this.HeaderBackColor);
                            e.Graphics.FillRectangle(brsh, rect);
                            brsh.Dispose();
                            fnt = new Font(e.Font.Name, e.Font.Size, FontStyle.Bold);
                        }
                        else
                            fnt = e.Font;

                        Pen myPen = new Pen(this.GridLineColor);
                        e.Graphics.DrawRectangle(myPen, rect);
                        myPen.Dispose();
                        
                        SolidBrush fBrsh = new SolidBrush(this.ForeColor);
                        e.Graphics.DrawString(arr[i], fnt, fBrsh, rect.X+2, rect.Y+1);
                        fBrsh.Dispose();

                        wd += colWidths[i];
                    }

                    e.DrawFocusRectangle();
                }
            }
            catch { }

        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            try
            {
                if (this.SelectedIndex > -1)
                {
                    GridComboBoxItem obj = (GridComboBoxItem)this.Items[this.SelectedIndex];
                    if (obj.IsHeader == true)
                    {
                        if (this.Items.Count > 1 && this.SelectedIndex == 0)
                        {
                            this.SelectedIndex = 1;
                        }
                        else
                        {
                            this.Items.Clear();
                            this.Items.Add(obj);
                        }
                    }
                }
                this._SelectedIndex = this.SelectedIndex;
            }
            catch { }

            base.OnSelectedIndexChanged(e);

        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (this.FindItemMode == true)
            {
                int index;
                string actual;
                string found;
                // Do nothing for certain keys, such as navigation keys.
                if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) ||
                    (e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Delete) ||
                    (e.KeyCode == Keys.PageUp) || (e.KeyCode == Keys.PageDown) ||
                    (e.KeyCode == Keys.Home) || (e.KeyCode == Keys.End))
                {
                    return;
                }

                // Store the actual text that has been typed.
                actual = this.Text;

                // Find the first match for the typed value.
                index = this.FindString(actual);

                // Get the text of the first match.               
                if (index > -1)
                {
                    GridComboBoxItem obj = (GridComboBoxItem)this.Items[index];
                    if (obj.IsHeader == true)
                        return;
                    found = this.Items[index].ToString();

                    // Select this item from the list.
                    this.SelectedIndex = index;

                    // Select the portion of the text that was automatically
                    // added so that additional typing replaces it.
                    this.SelectionStart = actual.Length;
                    this.SelectionLength = found.Length;
                }
            }
            base.OnKeyUp(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (_upperCaseOnLeave)
            {
                this.Text = this.Text.ToUpper();
            }
            base.OnLeave(e);           
        }

    }

    public class GridComboBoxItem
    {
        private string _column1 = string.Empty;
        private string _column2 = string.Empty;
        private string _column3 = string.Empty;
        private string _column4 = string.Empty;
        private string _column5 = string.Empty;
        private string _column6 = string.Empty;
        private string _column7 = string.Empty;
        private string _column8 = string.Empty;
        private string _column9 = string.Empty;
        private string _column10 = string.Empty;
        private bool _isHeader = false;

        public GridComboBoxItem()
        {

        }
        public GridComboBoxItem(String _column1, bool _isHeader)
        {
            this._column1 = _column1;
            this._isHeader = _isHeader;
        }

        public GridComboBoxItem(String _column1, String _column2, bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._isHeader = _isHeader;
        }

        public GridComboBoxItem(String _column1, String _column2, String _column3, bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._isHeader = _isHeader;
        }

        public GridComboBoxItem(String _column1, String _column2, String _column3, String _column4, bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._column4 = _column4;
            this._isHeader = _isHeader;
        }

        public GridComboBoxItem(String _column1, String _column2, String _column3, String _column4, String _column5,
            bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._column4 = _column4;
            this._column5 = _column5;
            this._isHeader = _isHeader;
        }

        public GridComboBoxItem(String _column1, String _column2, String _column3, String _column4,
            String _column5, String _column6, bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._column4 = _column4;
            this._column5 = _column5;
            this._column6 = _column6;
            this._isHeader = _isHeader;
        }

        public GridComboBoxItem(String _column1, String _column2, String _column3, String _column4,
            String _column5, String _column6, String _column7, bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._column4 = _column4;
            this._column5 = _column5;
            this._column6 = _column6;
            this._column7 = _column7;
            this._isHeader = _isHeader;
        }
        public GridComboBoxItem(String _column1, String _column2, String _column3, String _column4,
            String _column5, String _column6, String _column7, String _column8, bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._column4 = _column4;
            this._column5 = _column5;
            this._column6 = _column6;
            this._column7 = _column7;
            this._column8 = _column8;
            this._isHeader = _isHeader;
        }
        public GridComboBoxItem(String _column1, String _column2, String _column3, String _column4,
            String _column5, String _column6, String _column7, String _column8, String _column9, bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._column4 = _column4;
            this._column5 = _column5;
            this._column6 = _column6;
            this._column7 = _column7;
            this._column8 = _column8;
            this._column9 = _column9;
            this._isHeader = _isHeader;
        }

        public GridComboBoxItem(String _column1, String _column2, String _column3, String _column4,
            String _column5, String _column6, String _column7, String _column8, String _column9, String _column10,
            bool _isHeader)
        {
            this._column1 = _column1;
            this._column2 = _column2;
            this._column3 = _column3;
            this._column4 = _column4;
            this._column5 = _column5;
            this._column6 = _column6;
            this._column7 = _column7;
            this._column8 = _column8;
            this._column9 = _column9;
            this._column10 = _column10;
            this._isHeader = _isHeader;
        }

        public string Column1
        {
            get { return this._column1; }
            set { this._column1 = value; }
        }
        public string Column2
        {
            get { return this._column2; }
            set { this._column2 = value; }
        }
        public string Column3
        {
            get { return this._column3; }
            set { this._column3 = value; }
        }
        public string Column4
        {
            get { return this._column4; }
            set { this._column4 = value; }
        }
        public string Column5
        {
            get { return this._column5; }
            set { this._column5 = value; }
        }
        public string Column6
        {
            get { return this._column6; }
            set { this._column6 = value; }
        }
        public string Column7
        {
            get { return this._column7; }
            set { this._column7 = value; }
        }
        public string Column8
        {
            get { return this._column8; }
            set { this._column8 = value; }
        }
        public string Column9
        {
            get { return this._column9; }
            set { this._column9 = value; }
        }
        public string Column10
        {
            get { return this._column10; }
            set { this._column10 = value; }
        }
        public bool IsHeader
        {
            get { return this._isHeader; }
            set { this._isHeader = value; }
        }
    }
}