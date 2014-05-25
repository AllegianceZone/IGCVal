using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IgcVal
{
	/// <summary>
	/// The Main Form of the IGC Validator
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		#region Controls

		private System.Windows.Forms.TextBox CoreFileTextBox;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.Label CoreFileLabel;
		private System.Windows.Forms.Button ValidateButton;
		private System.Windows.Forms.OpenFileDialog CoreOpenFileDialog;
		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Panel ButtonPanel;
		private System.Windows.Forms.DataGrid InvalidMarkersDataGrid;
		private System.Windows.Forms.DataGridTableStyle DefaultDataGridTableStyle;
		private System.Windows.Forms.DataGridTextBoxColumn AddressDataGridTextBoxColumn;
		private System.Windows.Forms.DataGridTextBoxColumn ObjectIDDataGridTextBoxColumn;
		private System.Windows.Forms.DataGridTextBoxColumn ObjectNameataGridTextBoxColumn;
		private System.Windows.Forms.DataGridTextBoxColumn ObjectTypeataGridTextBoxColumn;
		private System.Windows.Forms.DataGridTextBoxColumn PrecedingPropertyDataGridTextBoxColumn;
		private System.Windows.Forms.DataGridTextBoxColumn ExpectedValueDataGridTextBoxColumn;
		private System.Windows.Forms.DataGridTextBoxColumn ActualValueDataGridTextBoxColumn;
		private System.Windows.Forms.DataGridBoolColumn FixDataGridBoolColumn;
		private System.Windows.Forms.Button CheckAllButton;
		private System.Windows.Forms.Button SelectNoneButton;
		private System.Windows.Forms.Button FixButton;
		private System.Windows.Forms.Panel SettingsPanel;
		private System.Windows.Forms.Label FixInfoLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		private DataTable _invalidMarkerTable;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public MainForm ()
		{
			InitializeComponent();
			CreateTable();
			DataReader.InvalidMarkerEvent += new InvalidMarkerDelegate(DataReader_InvalidMarkerEvent);
			ClearForm();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.ClearButton = new System.Windows.Forms.Button();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.ValidateButton = new System.Windows.Forms.Button();
			this.CoreFileLabel = new System.Windows.Forms.Label();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.CoreFileTextBox = new System.Windows.Forms.TextBox();
			this.CoreOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ButtonPanel = new System.Windows.Forms.Panel();
			this.FixInfoLabel = new System.Windows.Forms.Label();
			this.FixButton = new System.Windows.Forms.Button();
			this.SelectNoneButton = new System.Windows.Forms.Button();
			this.CheckAllButton = new System.Windows.Forms.Button();
			this.InvalidMarkersDataGrid = new System.Windows.Forms.DataGrid();
			this.DefaultDataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
			this.AddressDataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ObjectIDDataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ObjectNameataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ObjectTypeataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PrecedingPropertyDataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ExpectedValueDataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ActualValueDataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
			this.FixDataGridBoolColumn = new System.Windows.Forms.DataGridBoolColumn();
			this.SettingsPanel = new System.Windows.Forms.Panel();
			this.ButtonPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InvalidMarkersDataGrid)).BeginInit();
			this.SettingsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ClearButton
			// 
			this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearButton.Location = new System.Drawing.Point(406, 32);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(64, 23);
			this.ClearButton.TabIndex = 4;
			this.ClearButton.Text = "Clear";
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// StatusLabel
			// 
			this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.StatusLabel.Location = new System.Drawing.Point(4, 36);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(388, 14);
			this.StatusLabel.TabIndex = 3;
			this.StatusLabel.Text = "Validating...";
			// 
			// ValidateButton
			// 
			this.ValidateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ValidateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ValidateButton.Location = new System.Drawing.Point(476, 32);
			this.ValidateButton.Name = "ValidateButton";
			this.ValidateButton.Size = new System.Drawing.Size(64, 23);
			this.ValidateButton.TabIndex = 5;
			this.ValidateButton.Text = "Validate";
			this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
			// 
			// CoreFileLabel
			// 
			this.CoreFileLabel.Location = new System.Drawing.Point(4, 10);
			this.CoreFileLabel.Name = "CoreFileLabel";
			this.CoreFileLabel.Size = new System.Drawing.Size(53, 15);
			this.CoreFileLabel.TabIndex = 0;
			this.CoreFileLabel.Text = "Core File:";
			// 
			// BrowseButton
			// 
			this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BrowseButton.Location = new System.Drawing.Point(516, 8);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(24, 21);
			this.BrowseButton.TabIndex = 2;
			this.BrowseButton.Text = "...";
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
			// 
			// CoreFileTextBox
			// 
			this.CoreFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.CoreFileTextBox.Location = new System.Drawing.Point(58, 8);
			this.CoreFileTextBox.Name = "CoreFileTextBox";
			this.CoreFileTextBox.Size = new System.Drawing.Size(452, 21);
			this.CoreFileTextBox.TabIndex = 1;
			this.CoreFileTextBox.Text = "";
			this.CoreFileTextBox.TextChanged += new System.EventHandler(this.CoreFileTextBox_TextChanged);
			// 
			// CoreOpenFileDialog
			// 
			this.CoreOpenFileDialog.DefaultExt = "igc";
			this.CoreOpenFileDialog.Filter = "IGC Core Files|*.igc|All Files|*.*";
			this.CoreOpenFileDialog.Title = "Choose Core file to Validate";
			// 
			// ButtonPanel
			// 
			this.ButtonPanel.Controls.Add(this.FixButton);
			this.ButtonPanel.Controls.Add(this.SelectNoneButton);
			this.ButtonPanel.Controls.Add(this.CheckAllButton);
			this.ButtonPanel.Controls.Add(this.FixInfoLabel);
			this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ButtonPanel.Location = new System.Drawing.Point(0, 58);
			this.ButtonPanel.Name = "ButtonPanel";
			this.ButtonPanel.Size = new System.Drawing.Size(544, 28);
			this.ButtonPanel.TabIndex = 2;
			// 
			// FixInfoLabel
			// 
			this.FixInfoLabel.Location = new System.Drawing.Point(4, 4);
			this.FixInfoLabel.Name = "FixInfoLabel";
			this.FixInfoLabel.Size = new System.Drawing.Size(276, 16);
			this.FixInfoLabel.TabIndex = 0;
			this.FixInfoLabel.Text = "Check the markers to fix, then press \"Fix\" to fix them!";
			// 
			// FixButton
			// 
			this.FixButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.FixButton.Location = new System.Drawing.Point(476, 0);
			this.FixButton.Name = "FixButton";
			this.FixButton.Size = new System.Drawing.Size(64, 23);
			this.FixButton.TabIndex = 3;
			this.FixButton.Text = "Fix";
			this.FixButton.Click += new System.EventHandler(this.FixButton_Click);
			// 
			// SelectNoneButton
			// 
			this.SelectNoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectNoneButton.Location = new System.Drawing.Point(324, 0);
			this.SelectNoneButton.Name = "SelectNoneButton";
			this.SelectNoneButton.TabIndex = 1;
			this.SelectNoneButton.Text = "Check None";
			this.SelectNoneButton.Click += new System.EventHandler(this.SelectNoneButton_Click);
			// 
			// CheckAllButton
			// 
			this.CheckAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CheckAllButton.Location = new System.Drawing.Point(406, 0);
			this.CheckAllButton.Name = "CheckAllButton";
			this.CheckAllButton.Size = new System.Drawing.Size(64, 23);
			this.CheckAllButton.TabIndex = 2;
			this.CheckAllButton.Text = "Check All";
			this.CheckAllButton.Click += new System.EventHandler(this.CheckAllButton_Click);
			// 
			// InvalidMarkersDataGrid
			// 
			this.InvalidMarkersDataGrid.CaptionText = "Invalid Markers";
			this.InvalidMarkersDataGrid.CausesValidation = false;
			this.InvalidMarkersDataGrid.DataMember = "";
			this.InvalidMarkersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InvalidMarkersDataGrid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.InvalidMarkersDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.InvalidMarkersDataGrid.Location = new System.Drawing.Point(0, 86);
			this.InvalidMarkersDataGrid.Name = "InvalidMarkersDataGrid";
			this.InvalidMarkersDataGrid.ParentRowsVisible = false;
			this.InvalidMarkersDataGrid.RowHeadersVisible = false;
			this.InvalidMarkersDataGrid.Size = new System.Drawing.Size(544, 193);
			this.InvalidMarkersDataGrid.TabIndex = 2;
			this.InvalidMarkersDataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																											   this.DefaultDataGridTableStyle});
			this.InvalidMarkersDataGrid.DoubleClick += new System.EventHandler(this.InvalidMarkersDataGrid_DoubleClick);
			// 
			// DefaultDataGridTableStyle
			// 
			this.DefaultDataGridTableStyle.DataGrid = this.InvalidMarkersDataGrid;
			this.DefaultDataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																														this.AddressDataGridTextBoxColumn,
																														this.ObjectIDDataGridTextBoxColumn,
																														this.ObjectNameataGridTextBoxColumn,
																														this.ObjectTypeataGridTextBoxColumn,
																														this.PrecedingPropertyDataGridTextBoxColumn,
																														this.ExpectedValueDataGridTextBoxColumn,
																														this.ActualValueDataGridTextBoxColumn,
																														this.FixDataGridBoolColumn});
			this.DefaultDataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DefaultDataGridTableStyle.MappingName = "InvalidMarkers";
			this.DefaultDataGridTableStyle.RowHeadersVisible = false;
			this.DefaultDataGridTableStyle.RowHeaderWidth = 15;
			// 
			// AddressDataGridTextBoxColumn
			// 
			this.AddressDataGridTextBoxColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.AddressDataGridTextBoxColumn.Format = "X";
			this.AddressDataGridTextBoxColumn.FormatInfo = null;
			this.AddressDataGridTextBoxColumn.HeaderText = "Address  .";
			this.AddressDataGridTextBoxColumn.MappingName = "Address";
			this.AddressDataGridTextBoxColumn.ReadOnly = true;
			this.AddressDataGridTextBoxColumn.Width = 50;
			// 
			// ObjectIDDataGridTextBoxColumn
			// 
			this.ObjectIDDataGridTextBoxColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ObjectIDDataGridTextBoxColumn.Format = "";
			this.ObjectIDDataGridTextBoxColumn.FormatInfo = null;
			this.ObjectIDDataGridTextBoxColumn.HeaderText = "ID .";
			this.ObjectIDDataGridTextBoxColumn.MappingName = "ObjectID";
			this.ObjectIDDataGridTextBoxColumn.ReadOnly = true;
			this.ObjectIDDataGridTextBoxColumn.Width = 30;
			// 
			// ObjectNameataGridTextBoxColumn
			// 
			this.ObjectNameataGridTextBoxColumn.Format = "";
			this.ObjectNameataGridTextBoxColumn.FormatInfo = null;
			this.ObjectNameataGridTextBoxColumn.HeaderText = "Name";
			this.ObjectNameataGridTextBoxColumn.MappingName = "ObjectName";
			this.ObjectNameataGridTextBoxColumn.ReadOnly = true;
			this.ObjectNameataGridTextBoxColumn.Width = 140;
			// 
			// ObjectTypeataGridTextBoxColumn
			// 
			this.ObjectTypeataGridTextBoxColumn.Format = "";
			this.ObjectTypeataGridTextBoxColumn.FormatInfo = null;
			this.ObjectTypeataGridTextBoxColumn.HeaderText = "Type";
			this.ObjectTypeataGridTextBoxColumn.MappingName = "ObjectType";
			this.ObjectTypeataGridTextBoxColumn.ReadOnly = true;
			this.ObjectTypeataGridTextBoxColumn.Width = 75;
			// 
			// PrecedingPropertyDataGridTextBoxColumn
			// 
			this.PrecedingPropertyDataGridTextBoxColumn.Format = "";
			this.PrecedingPropertyDataGridTextBoxColumn.FormatInfo = null;
			this.PrecedingPropertyDataGridTextBoxColumn.HeaderText = "Property";
			this.PrecedingPropertyDataGridTextBoxColumn.MappingName = "PrecedingProperty";
			this.PrecedingPropertyDataGridTextBoxColumn.ReadOnly = true;
			this.PrecedingPropertyDataGridTextBoxColumn.Width = 75;
			// 
			// ExpectedValueDataGridTextBoxColumn
			// 
			this.ExpectedValueDataGridTextBoxColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ExpectedValueDataGridTextBoxColumn.Format = "X";
			this.ExpectedValueDataGridTextBoxColumn.FormatInfo = null;
			this.ExpectedValueDataGridTextBoxColumn.HeaderText = "Expected .";
			this.ExpectedValueDataGridTextBoxColumn.MappingName = "ExpectedValue";
			this.ExpectedValueDataGridTextBoxColumn.ReadOnly = true;
			this.ExpectedValueDataGridTextBoxColumn.Width = 60;
			// 
			// ActualValueDataGridTextBoxColumn
			// 
			this.ActualValueDataGridTextBoxColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ActualValueDataGridTextBoxColumn.Format = "X";
			this.ActualValueDataGridTextBoxColumn.FormatInfo = null;
			this.ActualValueDataGridTextBoxColumn.HeaderText = "Actual .";
			this.ActualValueDataGridTextBoxColumn.MappingName = "ActualValue";
			this.ActualValueDataGridTextBoxColumn.ReadOnly = true;
			this.ActualValueDataGridTextBoxColumn.Width = 60;
			// 
			// FixDataGridBoolColumn
			// 
			this.FixDataGridBoolColumn.AllowNull = false;
			this.FixDataGridBoolColumn.FalseValue = false;
			this.FixDataGridBoolColumn.HeaderText = "Fix";
			this.FixDataGridBoolColumn.MappingName = "Fix";
			this.FixDataGridBoolColumn.NullValue = "False";
			this.FixDataGridBoolColumn.TrueValue = true;
			this.FixDataGridBoolColumn.Width = 30;
			// 
			// SettingsPanel
			// 
			this.SettingsPanel.Controls.Add(this.BrowseButton);
			this.SettingsPanel.Controls.Add(this.CoreFileTextBox);
			this.SettingsPanel.Controls.Add(this.ValidateButton);
			this.SettingsPanel.Controls.Add(this.StatusLabel);
			this.SettingsPanel.Controls.Add(this.ClearButton);
			this.SettingsPanel.Controls.Add(this.CoreFileLabel);
			this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
			this.SettingsPanel.Name = "SettingsPanel";
			this.SettingsPanel.Size = new System.Drawing.Size(544, 58);
			this.SettingsPanel.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AcceptButton = this.ValidateButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(544, 279);
			this.Controls.Add(this.InvalidMarkersDataGrid);
			this.Controls.Add(this.ButtonPanel);
			this.Controls.Add(this.SettingsPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(300, 104);
			this.Name = "MainForm";
			this.Text = "IGCVal";
			this.ButtonPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.InvalidMarkersDataGrid)).EndInit();
			this.SettingsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		#region Event Handlers
		/// <summary>
		/// Fires when a user clicks the "Browse" button. Browses for a core.
		/// </summary>
		/// <param name="sender">The button being clicked</param>
		/// <param name="e">The click event's arguments</param>
		private void BrowseButton_Click (object sender, System.EventArgs e)
		{
			BrowseCore();
		}

		/// <summary>
		/// Executes when the CoreFile Textbox's text has changed
		/// </summary>
		/// <param name="sender">The TextBox that fired this event</param>
		/// <param name="e">The TextChanged Event's arguments</param>
		private void CoreFileTextBox_TextChanged (object sender, System.EventArgs e)
		{
			ValidateButton.Enabled = (CoreFileTextBox.Text == string.Empty) ? false : true;
		}

		/// <summary>
		/// Fires when a user clicks the "Clear" button. Clears the form.
		/// </summary>
		/// <param name="sender">The button being clicked</param>
		/// <param name="e">The click event's arguments</param>
		private void ClearButton_Click (object sender, System.EventArgs e)
		{
			ClearForm();
		}

		/// <summary>
		/// Fires when a user clicks the "Validate" button. Validates the chosen core.
		/// </summary>
		/// <param name="sender">The button being clicked</param>
		/// <param name="e">The click event's arguments</param>
		private void ValidateButton_Click (object sender, System.EventArgs e)
		{
			if (!File.Exists(CoreFileTextBox.Text))
			{
				MessageBox.Show(this, "You must choose a core that exists!", "IGC Core Validator", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DisableForm();
			ValidateCore();
		}

		/// <summary>
		/// Executes when the user clicks the "Check All" button. Checks all "Fix" checkboxes.
		/// </summary>
		/// <param name="sender">The button being clicked</param>
		/// <param name="e">The Click event's arguments</param>
		private void CheckAllButton_Click (object sender, System.EventArgs e)
		{
			foreach (DataRow Row in _invalidMarkerTable.Rows)
			{
				Row["Fix"] = true;
			}
		}

		/// <summary>
		/// Executes when the user clicks the "Check None" button. Checks all "Fix" checkboxes.
		/// </summary>
		/// <param name="sender">The button being clicked</param>
		/// <param name="e">The Click event's arguments</param>
		private void SelectNoneButton_Click (object sender, System.EventArgs e)
		{
			foreach (DataRow Row in _invalidMarkerTable.Rows)
			{
				Row["Fix"] = false;
			}
		}

		/// <summary>
		/// Executes when the user clicks the "Fix" button. Fixes all invalid markers found in the core
		/// </summary>
		/// <param name="sender">The button being clicked</param>
		/// <param name="e">The Click event's arguments</param>
		private void FixButton_Click (object sender, System.EventArgs e)
		{
			FixCore();
		}

		/// <summary>
		/// Executes when the user doubleclicks the datagrid. Shows the About message
		/// </summary>
		/// <param name="sender">The datagrid being doubleclicked</param>
		/// <param name="e">The doubleclick event's arguments</param>
		private void InvalidMarkersDataGrid_DoubleClick (object sender, System.EventArgs e)
		{
			MessageBox.Show("IgcVal was written by Tigereye.\r\nSpecial thanks to Noir for his input!", "IgcVal", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		#endregion

		/// <summary>
		/// Creates the InvalidMarkers DataTable
		/// </summary>
		private void CreateTable ()
		{
			// Create the table
			DataTable TempTable = new DataTable("InvalidMarkers");

			// Add the columns
			TempTable.Columns.Add("Address", typeof(long));
			TempTable.Columns.Add("ObjectID", typeof(ushort));
			TempTable.Columns.Add("ObjectName", typeof(string));
			TempTable.Columns.Add("ObjectType", typeof(string));
			TempTable.Columns.Add("PrecedingProperty", typeof(string));
			TempTable.Columns.Add("ExpectedValue", typeof(object));
			TempTable.Columns.Add("ActualValue", typeof(object));

			DataColumn Column;
			Column = TempTable.Columns.Add("Fix", typeof(bool));

			// Assign it into local variable
			_invalidMarkerTable = TempTable;

			// Bind to DataGrid
			InvalidMarkersDataGrid.DataSource = _invalidMarkerTable;
		}

		/// <summary>
		/// Clears the progress bar for the next test
		/// </summary>
		private void ClearForm ()
		{
			_invalidMarkerTable.Clear();

			ValidateButton.Enabled = true;
			this.AcceptButton = ValidateButton;
			CoreFileTextBox.Enabled = true;
			BrowseButton.Enabled = true;
			ButtonPanel.Visible = false;

			StatusLabel.Text = "Ready";
		}

		/// <summary>
		/// Disables the form, preventing the user from interfering with the core while being read
		/// </summary>
		private void DisableForm ()
		{
			ValidateButton.Enabled = false;
			CoreFileTextBox.Enabled = false;
			BrowseButton.Enabled = false;
			StatusLabel.Text = "Validating...";
		}

		/// <summary>
		/// Prompts the user to browse for a corefile, and writes it in the textbox
		/// </summary>
		private void BrowseCore ()
		{
			DialogResult Result = CoreOpenFileDialog.ShowDialog();
			switch (Result)
			{
				case DialogResult.OK:
					CoreFileTextBox.Text = CoreOpenFileDialog.FileName;
					CoreFileTextBox.SelectionStart = CoreFileTextBox.Text.Length - 1;
					StatusLabel.Text = "File chosen";
					break;
				case DialogResult.Cancel:
				default:
					break;
			}
		}

		/// <summary>
		/// Validates the chosen CoreFile
		/// </summary>
		private void ValidateCore ()
		{
			// Confirm the file exists
			string CoreFile = CoreFileTextBox.Text;
			if (File.Exists(CoreFile))
			{
				try
				{
					Core NewCore = new Core(CoreFile);
					StatusLabel.Text = "Validation Complete. Results are shown below.";

					if (_invalidMarkerTable.Rows.Count == 0)
					{
						MessageBox.Show("Core is 100% valid", "IGCCore Validator", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ClearForm();
					}
					else
					{
						this.AcceptButton = FixButton;
						ButtonPanel.Visible = true;
						ButtonPanel.Refresh();
					}
				}
				catch (Exception e)
				{
					StatusLabel.Text = "Error loading core!";
					MessageBox.Show(this, "Error loading core! " + e.Message, "IGC Core Validator", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Fixes all Invalid Markers found in the specified core
		/// </summary>
		private void FixCore ()
		{
			if (_invalidMarkerTable.Rows.Count > 0)
			{
				bool FixIsPresent = false;
				string OldMessage = StatusLabel.Text;

				FileStream CoreStream = null;
				try
				{
					StatusLabel.Text = "Fixing Core...";
					// Open CoreFile
					CoreStream = File.Open(CoreFileTextBox.Text, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
					// Loop through Markers
					foreach (DataRow Row in _invalidMarkerTable.Rows)
					{
						// Skip unchecked markers
						if ((bool)Row["Fix"] == false)
							continue;

						FixIsPresent = true;

						long Address = (long)Row["Address"];
						byte[] Data = null;
						object Expected = Row["ExpectedValue"];

						// Grab the bytes of the expected value
						if (Expected is byte)
						{
							Data = new byte[1] {(byte)Expected};
						}
						else if (Expected is short)
						{
							Data = ByteConversion.ToBytes((short)Expected);
						}
						else if (Expected is ushort)
						{
							Data = ByteConversion.ToBytes((ushort)Expected);
						}
						else if (Expected is int)
						{
							Data = ByteConversion.ToBytes((int)Expected);
						}
						else if (Expected is uint)
						{
							Data = ByteConversion.ToBytes((uint)Expected);
						}
						else if (Expected is long)
						{
							Data = ByteConversion.ToBytes((long)Expected);
						}

						// Seek to Address
						CoreStream.Seek(Address, SeekOrigin.Begin);

						// Write value
						CoreStream.Write(Data, 0, Data.Length);
					}
					if (FixIsPresent)
					{
						StatusLabel.Text = "Core fixing complete";
						MessageBox.Show(this, "All selected Invalid Markers have been corrected", "IGC Core Validator", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ClearForm();
					}
					else
					{
						StatusLabel.Text = OldMessage;
						MessageBox.Show(this, "There is nothing to fix! Please check markers to fix", "IGC Core Validator", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (Exception e)
				{
					StatusLabel.Text = "Error fixing core!";
					MessageBox.Show("Error fixing core!\r\n" + e.Message, "IGCCore Validator", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					// Close CoreFile
					if (CoreStream != null)
					{
						CoreStream.Close();
					}
				}
			}
		}

		/// <summary>
		/// Executes when an InvalidMarkerEvent is fired. Adds the event arguments to the DataGrid
		/// </summary>
		/// <param name="sender">The object firing the event</param>
		/// <param name="e">The InvaliMarkerEvent's arguments</param>
		private void DataReader_InvalidMarkerEvent (object sender, InvalidMarkerEventArgs e)
		{
			DataRow Row = _invalidMarkerTable.NewRow();
			Row["Address"] = e.Address;
			Row["ObjectID"] = e.ObjectID;
			Row["ObjectName"] = e.ObjectName;
			Row["ObjectType"] = e.ObjectType;
			Row["PrecedingProperty"] = e.PrecedingProperty;
			Row["ExpectedValue"] = e.AssertedValue;
			Row["ActualValue"] = e.ActualValue;
			Row["Fix"] = false;

			_invalidMarkerTable.Rows.Add(Row);
		}
	}
}
