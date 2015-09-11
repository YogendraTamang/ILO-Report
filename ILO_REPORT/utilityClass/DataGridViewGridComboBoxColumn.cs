using System;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace utilitClass
{
    [ToolboxBitmap(typeof(ComboBox))]
    public class DataGridViewGridComboBoxColumn : DataGridViewColumn
    {
        private int maxLength = 32767;
        private CharacterCasing characterCase = CharacterCasing.Normal;
        private ComboBoxStyle _dropDownStyle = ComboBoxStyle.DropDown;
       
        //private GridItemCollection _gridItem = GridItemCollection.Empty;
        
        public DataGridViewGridComboBoxColumn()
            : base(new DataGridViewGridComboBoxCell())
        {

        }

        public DataGridViewGridComboBoxColumn(string columnName)
            : base(new DataGridViewGridComboBoxCell())
        {
            this.Name = columnName;
        }

        public override DataGridViewCell CellTemplate
        {
            get
            { return base.CellTemplate; }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewGridComboBoxCell)))
                { throw new InvalidCastException("Must be a DataGridViewCustomCell"); }
                base.CellTemplate = value;

            }
        }

        public override object Clone()
        {
            DataGridViewGridComboBoxColumn column = (DataGridViewGridComboBoxColumn)base.Clone();
            column.MaxLength = this.MaxLength;
            column.CharacterCase = this.CharacterCase;
            column.DropDownStyle = this.DropDownStyle;
            
            return column;
            
        }

        [Browsable(true), Description("The maximum number of characters that can be entered into the edit control.")]
        public int MaxLength
        { 
            get{return this.maxLength;}
            set { this.maxLength = value; }        
        }


        [Browsable(true), Description("Changes the cell value to UpperCase if true.")]
        public CharacterCasing CharacterCase
        {
            get { return this.characterCase; }
            set
            {
                this.characterCase = value;

            }
            
        }

        [Browsable(true), Description("Dropdown style of the combobox.")]
        public ComboBoxStyle DropDownStyle
        {
            get { return this._dropDownStyle; }
            set { this._dropDownStyle = value; }
        }

       
    }

    public class DataGridViewGridComboBoxCell : DataGridViewTextBoxCell
    {
        public DataGridViewGridComboBoxCell()
            : base()
        {
            // Use the short date format.
            //this.Style.Format = "d";
        }

        public int MaxLength
        {
            get
            {
                if (base.OwningColumn is DataGridViewGridComboBoxColumn)
                    return ((DataGridViewGridComboBoxColumn)base.OwningColumn).MaxLength;
                return 32767;
            }
        }

        public ComboBoxStyle DropDownStyle
        {
            get
            {
                if (base.OwningColumn is DataGridViewGridComboBoxColumn)
                    return ((DataGridViewGridComboBoxColumn)base.OwningColumn).DropDownStyle;
                return ComboBoxStyle.DropDown; 
            }            
        }

        private DataGridViewGridComboBoxEditingControl _editingControl = null;

        public DataGridViewGridComboBoxEditingControl EditingControl
        {
            get { return _editingControl; }
        }

        private CharacterCasing CharacterCase
        {
            get
            {
                if (base.OwningColumn is DataGridViewGridComboBoxColumn)
                    return ((DataGridViewGridComboBoxColumn)base.OwningColumn).CharacterCase;
                return CharacterCasing.Normal;
            }       
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            try
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                DataGridViewGridComboBoxEditingControl ctl = DataGridView.EditingControl as DataGridViewGridComboBoxEditingControl;
                ctl.MaxLength = this.MaxLength;
                ctl.DropDownStyle = this.DropDownStyle;
                ctl.Text = this.FormattedValue != null ? this.FormattedValue.ToString() : "";
                this._editingControl = ctl;
            }
            catch (Exception)
            { }
        }

        protected override void OnLeave(int rowIndex, bool throughMouseClick)
        {
            try
            {
                if (this.EditingControl != null && this.EditingControl.Text !="")
                {
                    //if (this.EditingControl.UpperCaseOnLeave)
                    if (CharacterCase == CharacterCasing.Upper)
                        this.Value = this.EditingControl.Text.ToUpper();
                    else if (CharacterCase == CharacterCasing.Lower)
                        this.Value = this.EditingControl.Text.ToLower();
                    else
                    this.Value = this.EditingControl.Text;
                }

                base.OnLeave(rowIndex, throughMouseClick);
            }
            catch (Exception)
            { }
        }
        
        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that DataGridViewCustomCell uses.
                return typeof(DataGridViewGridComboBoxEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that DataGridViewCustomCell contains.
                return typeof(String);// typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the Empty string as the default value.
                return String.Empty; // DateTime.Now;
            }
        }

        public override object Clone()
        { return base.Clone(); }
    }


    [ClassInterfaceAttribute(ClassInterfaceType.AutoDispatch)]
    [ComVisibleAttribute(true)]
    public class DataGridViewGridComboBoxEditingControl : GridComboBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public DataGridViewGridComboBoxEditingControl()
        {
            //this.Format = DateTimePickerFormat.Short;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text; // this.Value.ToShortDateString();
            }
            set
            {
                String newValue = value as String;
                if (newValue != null)
                {
                    this.Text = newValue;
                }
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the Combobox handle the keys listed.
            try
            {
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                        {
                            String txt = this.Text;
                            if (txt.Length < 1)
                                return false;
                            int selIndex = this.SelectionStart;
                            if (selIndex == 0)
                                return false;
                            return true;
                        }
                    case Keys.Up:
                        {
                            if (this.DroppedDown == false)
                                return false;
                            return true;
                        }
                    case Keys.Down:
                        {
                            if (this.DroppedDown == false)
                                return false;
                            return true;
                        }
                    case Keys.Right:
                        {
                            String txt = this.Text;
                            if (txt.Length < 1)
                                return false;
                            int selIndex = this.SelectionStart;
                            if (selIndex >= txt.Length)
                                return false;
                            return true;
                        }
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                        return true;
                    default:
                        return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnSelectedIndexChanged(e);
        }

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    //if (this.Text.Trim().Length > 0)
        //    //{         
        //        valueChanged = true;
        //        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        //    //}
        //    base.OnLostFocus(e);
        //}

        protected override void OnLeave(EventArgs e)
        {
            if (this.Text.Length > 0)
            {
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            }
            base.OnLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text.Length > 0)
            {
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            }            
            base.OnTextChanged(e);
        }
      
    }
}