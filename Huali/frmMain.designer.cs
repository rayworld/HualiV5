namespace Huali
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.AppCommandTheme = new DevComponents.DotNetBar.Command(this.components);
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem10 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem11 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem12 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem13 = new DevComponents.DotNetBar.ButtonItem();
            this.colorPickerDropDown1 = new DevComponents.DotNetBar.ColorPickerDropDown();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonChangeStyle = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem17 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleMetro = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Blue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Silver = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleVS2010 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem62 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Blue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Silver = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem60 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem16 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleCustom = new DevComponents.DotNetBar.ColorPickerDropDown();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.NavTabControl = new DevComponents.DotNetBar.SuperTabControl();
            this.ribbonControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavTabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1,
            this.buttonItem1});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.Size = new System.Drawing.Size(696, 154);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 0;
            this.ribbonControl1.Text = "ribbonControl1";
            this.ribbonControl1.TitleText = "风格与恢复规划规划";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(696, 98);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            this.ribbonPanel1.Visible = true;
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "EDI2";
            // 
            // buttonItem1
            // 
            this.buttonItem1.AutoExpandOnClick = true;
            this.buttonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem6,
            this.buttonItem7,
            this.buttonItem8,
            this.buttonItem9,
            this.buttonItem10,
            this.buttonItem11,
            this.buttonItem12,
            this.buttonItem13,
            this.colorPickerDropDown1});
            this.buttonItem1.Text = "样式";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Checked = true;
            this.buttonItem2.Command = this.AppCommandTheme;
            this.buttonItem2.CommandParameter = "Office2016";
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.OptionGroup = "style";
            this.buttonItem2.Text = "Office 2016";
            // 
            // AppCommandTheme
            // 
            this.AppCommandTheme.Name = "AppCommandTheme";
            this.AppCommandTheme.Executed += new System.EventHandler(this.AppCommandTheme_Executed);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Command = this.AppCommandTheme;
            this.buttonItem3.CommandParameter = "Metro";
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.OptionGroup = "style";
            this.buttonItem3.Text = "Metro/Office 2013";
            // 
            // buttonItem4
            // 
            this.buttonItem4.Command = this.AppCommandTheme;
            this.buttonItem4.CommandParameter = "Office2010Blue";
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.OptionGroup = "style";
            this.buttonItem4.Text = "Office 2010 Blue";
            // 
            // buttonItem5
            // 
            this.buttonItem5.Command = this.AppCommandTheme;
            this.buttonItem5.CommandParameter = "Office2010Silver";
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.OptionGroup = "style";
            this.buttonItem5.Text = "Office 2010 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonItem6
            // 
            this.buttonItem6.Command = this.AppCommandTheme;
            this.buttonItem6.CommandParameter = "Office2010Black";
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.OptionGroup = "style";
            this.buttonItem6.Text = "Office 2010 Black";
            // 
            // buttonItem7
            // 
            this.buttonItem7.Command = this.AppCommandTheme;
            this.buttonItem7.CommandParameter = "VisualStudio2010Blue";
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.OptionGroup = "style";
            this.buttonItem7.Text = "Visual Studio 2010";
            // 
            // buttonItem8
            // 
            this.buttonItem8.Command = this.AppCommandTheme;
            this.buttonItem8.CommandParameter = "Windows7Blue";
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.OptionGroup = "style";
            this.buttonItem8.Text = "Windows 7";
            // 
            // buttonItem9
            // 
            this.buttonItem9.Command = this.AppCommandTheme;
            this.buttonItem9.CommandParameter = "Office2007Blue";
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.OptionGroup = "style";
            this.buttonItem9.Text = "Office 2007 <font color=\"Blue\"><b>Blue</b></font>";
            // 
            // buttonItem10
            // 
            this.buttonItem10.Command = this.AppCommandTheme;
            this.buttonItem10.CommandParameter = "Office2007Black";
            this.buttonItem10.Name = "buttonItem10";
            this.buttonItem10.OptionGroup = "style";
            this.buttonItem10.Text = "Office 2007 <font color=\"black\"><b>Black</b></font>";
            // 
            // buttonItem11
            // 
            this.buttonItem11.Command = this.AppCommandTheme;
            this.buttonItem11.CommandParameter = "Office2007Silver";
            this.buttonItem11.Name = "buttonItem11";
            this.buttonItem11.OptionGroup = "style";
            this.buttonItem11.Text = "Office 2007 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonItem12
            // 
            this.buttonItem12.Command = this.AppCommandTheme;
            this.buttonItem12.CommandParameter = "Office2007VistaGlass";
            this.buttonItem12.Name = "buttonItem12";
            this.buttonItem12.OptionGroup = "style";
            this.buttonItem12.Text = "Vista Glass";
            // 
            // buttonItem13
            // 
            this.buttonItem13.Command = this.AppCommandTheme;
            this.buttonItem13.CommandParameter = "VisualStudio2012Light";
            this.buttonItem13.Name = "buttonItem13";
            this.buttonItem13.OptionGroup = "style";
            this.buttonItem13.Text = "Visual Studio 2012 Light";
            // 
            // colorPickerDropDown1
            // 
            this.colorPickerDropDown1.BeginGroup = true;
            this.colorPickerDropDown1.Name = "colorPickerDropDown1";
            this.colorPickerDropDown1.Text = "Custom scheme";
            this.colorPickerDropDown1.Tooltip = "Custom color scheme is created based on currently selected color table. Try selec" +
    "ting Silver or Blue color table and then creating custom color scheme.";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxX1.Location = new System.Drawing.Point(4, 30);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(93, 21);
            this.textBoxX1.TabIndex = 0;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204))))));
            // 
            // buttonChangeStyle
            // 
            this.buttonChangeStyle.AutoExpandOnClick = true;
            this.buttonChangeStyle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonChangeStyle.Name = "buttonChangeStyle";
            this.buttonChangeStyle.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem17,
            this.buttonStyleMetro,
            this.buttonStyleOffice2010Blue,
            this.buttonStyleOffice2010Silver,
            this.buttonStyleOffice2010Black,
            this.buttonStyleVS2010,
            this.buttonItem62,
            this.buttonStyleOffice2007Blue,
            this.buttonStyleOffice2007Black,
            this.buttonStyleOffice2007Silver,
            this.buttonItem60,
            this.buttonItem16,
            this.buttonStyleCustom});
            this.buttonChangeStyle.Text = "Style";
            // 
            // buttonItem17
            // 
            this.buttonItem17.Checked = true;
            this.buttonItem17.CommandParameter = "Office2016";
            this.buttonItem17.Name = "buttonItem17";
            this.buttonItem17.OptionGroup = "style";
            this.buttonItem17.Text = "Office 2016";
            // 
            // buttonStyleMetro
            // 
            this.buttonStyleMetro.CommandParameter = "Metro";
            this.buttonStyleMetro.Name = "buttonStyleMetro";
            this.buttonStyleMetro.OptionGroup = "style";
            this.buttonStyleMetro.Text = "Metro/Office 2013";
            // 
            // buttonStyleOffice2010Blue
            // 
            this.buttonStyleOffice2010Blue.CommandParameter = "Office2010Blue";
            this.buttonStyleOffice2010Blue.Name = "buttonStyleOffice2010Blue";
            this.buttonStyleOffice2010Blue.OptionGroup = "style";
            this.buttonStyleOffice2010Blue.Text = "Office 2010 Blue";
            // 
            // buttonStyleOffice2010Silver
            // 
            this.buttonStyleOffice2010Silver.CommandParameter = "Office2010Silver";
            this.buttonStyleOffice2010Silver.Name = "buttonStyleOffice2010Silver";
            this.buttonStyleOffice2010Silver.OptionGroup = "style";
            this.buttonStyleOffice2010Silver.Text = "Office 2010 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonStyleOffice2010Black
            // 
            this.buttonStyleOffice2010Black.CommandParameter = "Office2010Black";
            this.buttonStyleOffice2010Black.Name = "buttonStyleOffice2010Black";
            this.buttonStyleOffice2010Black.OptionGroup = "style";
            this.buttonStyleOffice2010Black.Text = "Office 2010 Black";
            // 
            // buttonStyleVS2010
            // 
            this.buttonStyleVS2010.CommandParameter = "VisualStudio2010Blue";
            this.buttonStyleVS2010.Name = "buttonStyleVS2010";
            this.buttonStyleVS2010.OptionGroup = "style";
            this.buttonStyleVS2010.Text = "Visual Studio 2010";
            // 
            // buttonItem62
            // 
            this.buttonItem62.CommandParameter = "Windows7Blue";
            this.buttonItem62.Name = "buttonItem62";
            this.buttonItem62.OptionGroup = "style";
            this.buttonItem62.Text = "Windows 7";
            // 
            // buttonStyleOffice2007Blue
            // 
            this.buttonStyleOffice2007Blue.CommandParameter = "Office2007Blue";
            this.buttonStyleOffice2007Blue.Name = "buttonStyleOffice2007Blue";
            this.buttonStyleOffice2007Blue.OptionGroup = "style";
            this.buttonStyleOffice2007Blue.Text = "Office 2007 <font color=\"Blue\"><b>Blue</b></font>";
            // 
            // buttonStyleOffice2007Black
            // 
            this.buttonStyleOffice2007Black.CommandParameter = "Office2007Black";
            this.buttonStyleOffice2007Black.Name = "buttonStyleOffice2007Black";
            this.buttonStyleOffice2007Black.OptionGroup = "style";
            this.buttonStyleOffice2007Black.Text = "Office 2007 <font color=\"black\"><b>Black</b></font>";
            // 
            // buttonStyleOffice2007Silver
            // 
            this.buttonStyleOffice2007Silver.CommandParameter = "Office2007Silver";
            this.buttonStyleOffice2007Silver.Name = "buttonStyleOffice2007Silver";
            this.buttonStyleOffice2007Silver.OptionGroup = "style";
            this.buttonStyleOffice2007Silver.Text = "Office 2007 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonItem60
            // 
            this.buttonItem60.CommandParameter = "Office2007VistaGlass";
            this.buttonItem60.Name = "buttonItem60";
            this.buttonItem60.OptionGroup = "style";
            this.buttonItem60.Text = "Vista Glass";
            // 
            // buttonItem16
            // 
            this.buttonItem16.CommandParameter = "VisualStudio2012Light";
            this.buttonItem16.Name = "buttonItem16";
            this.buttonItem16.OptionGroup = "style";
            this.buttonItem16.Text = "Visual Studio 2012 Light";
            // 
            // buttonStyleCustom
            // 
            this.buttonStyleCustom.BeginGroup = true;
            this.buttonStyleCustom.Name = "buttonStyleCustom";
            this.buttonStyleCustom.Text = "Custom scheme";
            this.buttonStyleCustom.Tooltip = "Custom color scheme is created based on currently selected color table. Try selec" +
    "ting Silver or Blue color table and then creating custom color scheme.";
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
            this.bar1.IsMaximized = false;
            this.bar1.ItemSpacing = 2;
            this.bar1.Location = new System.Drawing.Point(0, 433);
            this.bar1.Name = "bar1";
            this.bar1.PaddingBottom = 0;
            this.bar1.PaddingTop = 0;
            this.bar1.Size = new System.Drawing.Size(696, 24);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 8;
            this.bar1.TabStop = false;
            this.bar1.Text = "barStatus";
            // 
            // NavTabControl
            // 
            this.NavTabControl.BackColor = System.Drawing.Color.White;
            this.NavTabControl.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.NavTabControl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.NavTabControl.ControlBox.MenuBox.Name = "";
            this.NavTabControl.ControlBox.Name = "";
            this.NavTabControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NavTabControl.ControlBox.MenuBox,
            this.NavTabControl.ControlBox.CloseBox});
            this.NavTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavTabControl.ForeColor = System.Drawing.Color.Black;
            this.NavTabControl.Location = new System.Drawing.Point(0, 154);
            this.NavTabControl.Name = "NavTabControl";
            this.NavTabControl.ReorderTabsEnabled = true;
            this.NavTabControl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.NavTabControl.SelectedTabIndex = -1;
            this.NavTabControl.Size = new System.Drawing.Size(696, 279);
            this.NavTabControl.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NavTabControl.TabIndex = 11;
            this.NavTabControl.Text = "superTabControl1";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 457);
            this.Controls.Add(this.NavTabControl);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.ribbonControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavTabControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem buttonChangeStyle;
        private DevComponents.DotNetBar.ButtonItem buttonItem17;
        private DevComponents.DotNetBar.ButtonItem buttonStyleMetro;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Blue;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Silver;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2010Black;
        private DevComponents.DotNetBar.ButtonItem buttonStyleVS2010;
        private DevComponents.DotNetBar.ButtonItem buttonItem62;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Blue;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Black;
        private DevComponents.DotNetBar.ButtonItem buttonStyleOffice2007Silver;
        private DevComponents.DotNetBar.ButtonItem buttonItem60;
        private DevComponents.DotNetBar.ButtonItem buttonItem16;
        private DevComponents.DotNetBar.ColorPickerDropDown buttonStyleCustom;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonItem buttonItem10;
        private DevComponents.DotNetBar.ButtonItem buttonItem11;
        private DevComponents.DotNetBar.ButtonItem buttonItem12;
        private DevComponents.DotNetBar.ButtonItem buttonItem13;
        private DevComponents.DotNetBar.ColorPickerDropDown colorPickerDropDown1;
        private DevComponents.DotNetBar.Command AppCommandTheme;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.SuperTabControl NavTabControl;
    }
}