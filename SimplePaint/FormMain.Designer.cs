
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPencil = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFreehand = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.panelColors = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStripTools.SuspendLayout();
            this.panelContainer.SuspendLayout();
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
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::SimplePaint.Properties.Resources.create_40px;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonNew.Text = "toolStripButton1";
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.CheckOnClick = true;
            this.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelect.Image = global::SimplePaint.Properties.Resources.hand_40px;
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSelect.Text = "Перемещать";
            this.toolStripButtonSelect.CheckedChanged += new System.EventHandler(this.toolStripButtonSelect_CheckedChanged);
            this.toolStripButtonSelect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_MouseDown);
            // 
            // toolStripButtonPencil
            // 
            this.toolStripButtonPencil.CheckOnClick = true;
            this.toolStripButtonPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPencil.Image = global::SimplePaint.Properties.Resources.pencil_40px;
            this.toolStripButtonPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPencil.Name = "toolStripButtonPencil";
            this.toolStripButtonPencil.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPencil.Text = "Рисовать прямые линии";
            this.toolStripButtonPencil.CheckedChanged += new System.EventHandler(this.toolStripButtonPencil_CheckedChanged);
            this.toolStripButtonPencil.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_MouseDown);
            // 
            // toolStripButtonFreehand
            // 
            this.toolStripButtonFreehand.CheckOnClick = true;
            this.toolStripButtonFreehand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFreehand.Image = global::SimplePaint.Properties.Resources.freehand_40px;
            this.toolStripButtonFreehand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFreehand.Name = "toolStripButtonFreehand";
            this.toolStripButtonFreehand.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonFreehand.Text = "Рисовать произвольный контур";
            this.toolStripButtonFreehand.CheckedChanged += new System.EventHandler(this.toolStripButtonFreehand_CheckedChanged);
            this.toolStripButtonFreehand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton_MouseDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
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
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Controls.Add(this.panelCanvas);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 63);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(655, 387);
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
            this.panelColors.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelColors.Location = new System.Drawing.Point(655, 63);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(145, 387);
            this.panelColors.TabIndex = 3;
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "SimplePaint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
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
    }
}

