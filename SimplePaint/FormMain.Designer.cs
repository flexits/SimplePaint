﻿
namespace SimplePaint
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.panelColors = new System.Windows.Forms.Panel();
            this.checkBoxSmoothing = new System.Windows.Forms.CheckBox();
            this.comboBoxStyle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarWidth = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelTool = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBoxToolColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxBackColor = new System.Windows.Forms.PictureBox();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPencil = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFreehand = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStripTools.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panelColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToolColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackColor)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripTools
            // 
            this.toolStripTools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripSeparator3,
            this.toolStripButtonSelect,
            this.toolStripButtonPencil,
            this.toolStripButtonFreehand,
            this.toolStripSeparator1,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripButtonClear,
            this.toolStripSeparator2,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomReset,
            this.toolStripButtonZoomOut});
            this.toolStripTools.Location = new System.Drawing.Point(0, 24);
            this.toolStripTools.Name = "toolStripTools";
            this.toolStripTools.Size = new System.Drawing.Size(800, 39);
            this.toolStripTools.TabIndex = 1;
            this.toolStripTools.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContainer.Controls.Add(this.panelCanvas);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 63);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(648, 365);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Resize += new System.EventHandler(this.panelContainer_Resize);
            // 
            // panelCanvas
            // 
            this.panelCanvas.AutoSize = true;
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.Location = new System.Drawing.Point(65, 45);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(520, 281);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            this.panelCanvas.Resize += new System.EventHandler(this.panelCanvas_Resize);
            // 
            // panelColors
            // 
            this.panelColors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelColors.Controls.Add(this.checkBoxSmoothing);
            this.panelColors.Controls.Add(this.comboBoxStyle);
            this.panelColors.Controls.Add(this.label3);
            this.panelColors.Controls.Add(this.trackBarWidth);
            this.panelColors.Controls.Add(this.label2);
            this.panelColors.Controls.Add(this.pictureBoxToolColor);
            this.panelColors.Controls.Add(this.pictureBoxBackColor);
            this.panelColors.Controls.Add(this.label1);
            this.panelColors.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelColors.Location = new System.Drawing.Point(648, 63);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(152, 365);
            this.panelColors.TabIndex = 3;
            // 
            // checkBoxSmoothing
            // 
            this.checkBoxSmoothing.AutoSize = true;
            this.checkBoxSmoothing.Location = new System.Drawing.Point(9, 199);
            this.checkBoxSmoothing.Name = "checkBoxSmoothing";
            this.checkBoxSmoothing.Size = new System.Drawing.Size(94, 17);
            this.checkBoxSmoothing.TabIndex = 7;
            this.checkBoxSmoothing.Text = "Сглаживание";
            this.checkBoxSmoothing.UseVisualStyleBackColor = true;
            this.checkBoxSmoothing.CheckedChanged += new System.EventHandler(this.checkBoxSmoothing_CheckedChanged);
            // 
            // comboBoxStyle
            // 
            this.comboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStyle.FormattingEnabled = true;
            this.comboBoxStyle.Location = new System.Drawing.Point(9, 163);
            this.comboBoxStyle.Name = "comboBoxStyle";
            this.comboBoxStyle.Size = new System.Drawing.Size(137, 21);
            this.comboBoxStyle.TabIndex = 6;
            this.comboBoxStyle.SelectedValueChanged += new System.EventHandler(this.comboBoxStyle_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Стиль линии:";
            // 
            // trackBarWidth
            // 
            this.trackBarWidth.Location = new System.Drawing.Point(9, 99);
            this.trackBarWidth.Maximum = 20;
            this.trackBarWidth.Minimum = 1;
            this.trackBarWidth.Name = "trackBarWidth";
            this.trackBarWidth.Size = new System.Drawing.Size(137, 45);
            this.trackBarWidth.TabIndex = 4;
            this.trackBarWidth.Value = 1;
            this.trackBarWidth.ValueChanged += new System.EventHandler(this.trackBarWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ширина линии:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет инструмента / фона:";
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelPosition,
            this.statusLabelScale,
            this.statusLabelTool});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelPosition
            // 
            this.statusLabelPosition.Name = "statusLabelPosition";
            this.statusLabelPosition.Size = new System.Drawing.Size(25, 17);
            this.statusLabelPosition.Text = "0; 0";
            // 
            // statusLabelTool
            // 
            this.statusLabelTool.Name = "statusLabelTool";
            this.statusLabelTool.Size = new System.Drawing.Size(29, 17);
            this.statusLabelTool.Text = "Tool";
            // 
            // statusLabelScale
            // 
            this.statusLabelScale.Name = "statusLabelScale";
            this.statusLabelScale.Size = new System.Drawing.Size(34, 17);
            this.statusLabelScale.Text = "Scale";
            // 
            // pictureBoxToolColor
            // 
            this.pictureBoxToolColor.BackColor = System.Drawing.Color.Black;
            this.pictureBoxToolColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxToolColor.Location = new System.Drawing.Point(43, 25);
            this.pictureBoxToolColor.Name = "pictureBoxToolColor";
            this.pictureBoxToolColor.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxToolColor.TabIndex = 2;
            this.pictureBoxToolColor.TabStop = false;
            this.pictureBoxToolColor.Click += new System.EventHandler(this.pictureBoxToolColor_Click);
            // 
            // pictureBoxBackColor
            // 
            this.pictureBoxBackColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBackColor.Location = new System.Drawing.Point(58, 41);
            this.pictureBoxBackColor.Name = "pictureBoxBackColor";
            this.pictureBoxBackColor.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxBackColor.TabIndex = 1;
            this.pictureBoxBackColor.TabStop = false;
            this.pictureBoxBackColor.Click += new System.EventHandler(this.pictureBoxBackColor_Click);
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::SimplePaint.Properties.Resources.create_40px;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonNew.Text = "toolStripButton1";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::SimplePaint.Properties.Resources.opened_folder_40px;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonOpen.Text = "toolStripButton1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::SimplePaint.Properties.Resources.save_40px;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSave.Text = "toolStripButton1";
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.CheckOnClick = true;
            this.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelect.Image = global::SimplePaint.Properties.Resources.hand_40px;
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSelect.Tag = "селектор";
            this.toolStripButtonSelect.Text = "Перемещать";
            this.toolStripButtonSelect.CheckedChanged += new System.EventHandler(this.toolStripButtonSelect_CheckedChanged);
            this.toolStripButtonSelect.Click += new System.EventHandler(this.toolStripButtonToolSelect_Click);
            this.toolStripButtonSelect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonToolSelect_MouseDown);
            // 
            // toolStripButtonPencil
            // 
            this.toolStripButtonPencil.CheckOnClick = true;
            this.toolStripButtonPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPencil.Image = global::SimplePaint.Properties.Resources.pencil_40px;
            this.toolStripButtonPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPencil.Name = "toolStripButtonPencil";
            this.toolStripButtonPencil.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPencil.Tag = "прямые линии";
            this.toolStripButtonPencil.Text = "Рисовать прямые линии";
            this.toolStripButtonPencil.CheckedChanged += new System.EventHandler(this.toolStripButtonPencil_CheckedChanged);
            this.toolStripButtonPencil.Click += new System.EventHandler(this.toolStripButtonToolSelect_Click);
            this.toolStripButtonPencil.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonToolSelect_MouseDown);
            // 
            // toolStripButtonFreehand
            // 
            this.toolStripButtonFreehand.CheckOnClick = true;
            this.toolStripButtonFreehand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFreehand.Image = global::SimplePaint.Properties.Resources.freehand_40px;
            this.toolStripButtonFreehand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFreehand.Name = "toolStripButtonFreehand";
            this.toolStripButtonFreehand.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonFreehand.Tag = "произвольные контуры";
            this.toolStripButtonFreehand.Text = "Рисовать произвольный контур";
            this.toolStripButtonFreehand.CheckedChanged += new System.EventHandler(this.toolStripButtonFreehand_CheckedChanged);
            this.toolStripButtonFreehand.Click += new System.EventHandler(this.toolStripButtonToolSelect_Click);
            this.toolStripButtonFreehand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonToolSelect_MouseDown);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = global::SimplePaint.Properties.Resources.undo_40px;
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonUndo.Text = "Отменить";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = global::SimplePaint.Properties.Resources.redo_40px;
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRedo.Text = "Вернуть";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = global::SimplePaint.Properties.Resources.clear_40px;
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonClear.Text = "Отменить всё";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = global::SimplePaint.Properties.Resources.zoom_in_40px;
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonZoomIn.Text = "Увеличить масштаб";
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // toolStripButtonZoomReset
            // 
            this.toolStripButtonZoomReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomReset.Image = global::SimplePaint.Properties.Resources.find_and_replace_40px;
            this.toolStripButtonZoomReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomReset.Name = "toolStripButtonZoomReset";
            this.toolStripButtonZoomReset.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonZoomReset.Text = "Масштаб 100%";
            this.toolStripButtonZoomReset.Click += new System.EventHandler(this.buttonZoomReset_Click);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = global::SimplePaint.Properties.Resources.zoom_out_40px;
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonZoomOut.Text = "Уменьшить масштаб";
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemExit.Text = "Выход";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.toolStripTools);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "SimplePaint";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelColors.ResumeLayout(false);
            this.panelColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToolColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.ToolStripButton toolStripButtonPencil;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelColors;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripButton toolStripButtonFreehand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelect;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomReset;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.PictureBox pictureBoxToolColor;
        private System.Windows.Forms.PictureBox pictureBoxBackColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSmoothing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelPosition;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelTool;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelScale;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
    }
}

