
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
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHand = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPencil = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFreehand = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.panelColors = new System.Windows.Forms.Panel();
            this.groupBoxBackground = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxBackColor = new System.Windows.Forms.PictureBox();
            this.groupBoxFill = new System.Windows.Forms.GroupBox();
            this.checkBoxNoFill = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxFillColor = new System.Windows.Forms.PictureBox();
            this.groupBoxOutline = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelThicknessValue = new System.Windows.Forms.Label();
            this.checkBoxSmoothing = new System.Windows.Forms.CheckBox();
            this.pictureBoxToolColor = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStyle = new System.Windows.Forms.ComboBox();
            this.trackBarWidth = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelTool = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.containerHScroll = new System.Windows.Forms.HScrollBar();
            this.containerVScroll = new System.Windows.Forms.VScrollBar();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приблизитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уменьшитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сброситьМасштабToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawCanvas1 = new SimplePaint.DrawCanvas();
            this.menuStrip1.SuspendLayout();
            this.toolStripTools.SuspendLayout();
            this.panelColors.SuspendLayout();
            this.groupBoxBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackColor)).BeginInit();
            this.groupBoxFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFillColor)).BeginInit();
            this.groupBoxOutline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToolColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItemExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItemExit.Text = "Выход";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripTools
            // 
            this.toolStripTools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripSeparator3,
            this.toolStripButtonHand,
            this.toolStripButtonMove,
            this.toolStripButtonPencil,
            this.toolStripButtonFreehand,
            this.toolStripButtonRectangle,
            this.toolStripButtonEllipse,
            this.toolStripButtonEraser,
            this.toolStripButtonFill,
            this.toolStripSeparator1,
            this.toolStripButtonUndo,
            this.toolStripButtonClear,
            this.toolStripButtonRedo,
            this.toolStripSeparator2,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomReset,
            this.toolStripButtonZoomOut});
            this.toolStripTools.Location = new System.Drawing.Point(0, 24);
            this.toolStripTools.Name = "toolStripTools";
            this.toolStripTools.Size = new System.Drawing.Size(834, 39);
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
            this.toolStripButtonNew.Text = "Новый рисунок";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::SimplePaint.Properties.Resources.opened_folder_40px;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonOpen.Text = "Открыть файл";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::SimplePaint.Properties.Resources.save_40px;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSave.Text = "Сохранить рисунок как";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonHand
            // 
            this.toolStripButtonHand.CheckOnClick = true;
            this.toolStripButtonHand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHand.Image = global::SimplePaint.Properties.Resources.hand_40px;
            this.toolStripButtonHand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHand.Name = "toolStripButtonHand";
            this.toolStripButtonHand.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonHand.Tag = "выбор и перемещение объекта (Shift+Del: удалить выбранное)";
            this.toolStripButtonHand.Text = "Выбирать фигуры";
            this.toolStripButtonHand.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
            // 
            // toolStripButtonMove
            // 
            this.toolStripButtonMove.CheckOnClick = true;
            this.toolStripButtonMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMove.Image = global::SimplePaint.Properties.Resources.drag_40px;
            this.toolStripButtonMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMove.Name = "toolStripButtonMove";
            this.toolStripButtonMove.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonMove.Tag = "перемещение рисунка";
            this.toolStripButtonMove.Text = "Перемещать рисунок";
            this.toolStripButtonMove.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
            // 
            // toolStripButtonPencil
            // 
            this.toolStripButtonPencil.CheckOnClick = true;
            this.toolStripButtonPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPencil.Image = global::SimplePaint.Properties.Resources.pencil_40px;
            this.toolStripButtonPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPencil.Name = "toolStripButtonPencil";
            this.toolStripButtonPencil.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonPencil.Tag = "прямые линии (Shift+ЛКМ: прямой угол)";
            this.toolStripButtonPencil.Text = "Рисовать прямые линии";
            this.toolStripButtonPencil.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
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
            this.toolStripButtonFreehand.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
            // 
            // toolStripButtonRectangle
            // 
            this.toolStripButtonRectangle.CheckOnClick = true;
            this.toolStripButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRectangle.Image = global::SimplePaint.Properties.Resources.rectangle_40px;
            this.toolStripButtonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRectangle.Name = "toolStripButtonRectangle";
            this.toolStripButtonRectangle.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRectangle.Tag = "прямоугольник (Shift+ЛКМ: квадрат)";
            this.toolStripButtonRectangle.Text = "Рисовать прямоугольник";
            this.toolStripButtonRectangle.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
            // 
            // toolStripButtonEllipse
            // 
            this.toolStripButtonEllipse.CheckOnClick = true;
            this.toolStripButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEllipse.Image = global::SimplePaint.Properties.Resources.ellipse_40px;
            this.toolStripButtonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEllipse.Name = "toolStripButtonEllipse";
            this.toolStripButtonEllipse.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonEllipse.Tag = "эллипс (Shift+ЛКМ: круг)";
            this.toolStripButtonEllipse.Text = "Рисовать окружность";
            this.toolStripButtonEllipse.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
            // 
            // toolStripButtonEraser
            // 
            this.toolStripButtonEraser.CheckOnClick = true;
            this.toolStripButtonEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEraser.Image = global::SimplePaint.Properties.Resources.eraser_40px;
            this.toolStripButtonEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEraser.Name = "toolStripButtonEraser";
            this.toolStripButtonEraser.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonEraser.Tag = "ластик";
            this.toolStripButtonEraser.Text = "Стирать контуры";
            this.toolStripButtonEraser.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
            // 
            // toolStripButtonFill
            // 
            this.toolStripButtonFill.CheckOnClick = true;
            this.toolStripButtonFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFill.Image = global::SimplePaint.Properties.Resources.fill_color_40px;
            this.toolStripButtonFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFill.Name = "toolStripButtonFill";
            this.toolStripButtonFill.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonFill.Tag = "заливка фигуры";
            this.toolStripButtonFill.Text = "Залить фигуру";
            this.toolStripButtonFill.CheckedChanged += new System.EventHandler(this.toolStripButtonToolSelect_CheckedChanged);
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
            this.toolStripButtonZoomReset.Text = "Сбросить масштаб и положение";
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
            // panelColors
            // 
            this.panelColors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelColors.Controls.Add(this.groupBoxBackground);
            this.panelColors.Controls.Add(this.groupBoxFill);
            this.panelColors.Controls.Add(this.groupBoxOutline);
            this.panelColors.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelColors.Location = new System.Drawing.Point(682, 63);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(152, 521);
            this.panelColors.TabIndex = 3;
            // 
            // groupBoxBackground
            // 
            this.groupBoxBackground.Controls.Add(this.label1);
            this.groupBoxBackground.Controls.Add(this.pictureBoxBackColor);
            this.groupBoxBackground.Location = new System.Drawing.Point(3, 260);
            this.groupBoxBackground.Name = "groupBoxBackground";
            this.groupBoxBackground.Size = new System.Drawing.Size(142, 57);
            this.groupBoxBackground.TabIndex = 11;
            this.groupBoxBackground.TabStop = false;
            this.groupBoxBackground.Text = "Фон";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Цвет";
            // 
            // pictureBoxBackColor
            // 
            this.pictureBoxBackColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBackColor.Location = new System.Drawing.Point(80, 19);
            this.pictureBoxBackColor.Name = "pictureBoxBackColor";
            this.pictureBoxBackColor.Size = new System.Drawing.Size(54, 24);
            this.pictureBoxBackColor.TabIndex = 1;
            this.pictureBoxBackColor.TabStop = false;
            this.pictureBoxBackColor.Click += new System.EventHandler(this.pictureBoxBackColor_Click);
            // 
            // groupBoxFill
            // 
            this.groupBoxFill.Controls.Add(this.checkBoxNoFill);
            this.groupBoxFill.Controls.Add(this.label5);
            this.groupBoxFill.Controls.Add(this.pictureBoxFillColor);
            this.groupBoxFill.Location = new System.Drawing.Point(4, 179);
            this.groupBoxFill.Name = "groupBoxFill";
            this.groupBoxFill.Size = new System.Drawing.Size(142, 75);
            this.groupBoxFill.TabIndex = 10;
            this.groupBoxFill.TabStop = false;
            this.groupBoxFill.Text = "Заливка";
            // 
            // checkBoxNoFill
            // 
            this.checkBoxNoFill.AutoSize = true;
            this.checkBoxNoFill.Checked = true;
            this.checkBoxNoFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNoFill.Location = new System.Drawing.Point(6, 49);
            this.checkBoxNoFill.Name = "checkBoxNoFill";
            this.checkBoxNoFill.Size = new System.Drawing.Size(89, 17);
            this.checkBoxNoFill.TabIndex = 12;
            this.checkBoxNoFill.Text = "без заливки";
            this.checkBoxNoFill.UseVisualStyleBackColor = true;
            this.checkBoxNoFill.CheckedChanged += new System.EventHandler(this.checkBoxFill_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Цвет";
            // 
            // pictureBoxFillColor
            // 
            this.pictureBoxFillColor.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxFillColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFillColor.Location = new System.Drawing.Point(80, 19);
            this.pictureBoxFillColor.Name = "pictureBoxFillColor";
            this.pictureBoxFillColor.Size = new System.Drawing.Size(54, 24);
            this.pictureBoxFillColor.TabIndex = 2;
            this.pictureBoxFillColor.TabStop = false;
            this.pictureBoxFillColor.Click += new System.EventHandler(this.pictureBoxFillColor_Click);
            // 
            // groupBoxOutline
            // 
            this.groupBoxOutline.Controls.Add(this.label4);
            this.groupBoxOutline.Controls.Add(this.labelThicknessValue);
            this.groupBoxOutline.Controls.Add(this.checkBoxSmoothing);
            this.groupBoxOutline.Controls.Add(this.pictureBoxToolColor);
            this.groupBoxOutline.Controls.Add(this.label3);
            this.groupBoxOutline.Controls.Add(this.comboBoxStyle);
            this.groupBoxOutline.Controls.Add(this.trackBarWidth);
            this.groupBoxOutline.Controls.Add(this.label2);
            this.groupBoxOutline.Location = new System.Drawing.Point(4, 3);
            this.groupBoxOutline.Name = "groupBoxOutline";
            this.groupBoxOutline.Size = new System.Drawing.Size(141, 170);
            this.groupBoxOutline.TabIndex = 9;
            this.groupBoxOutline.TabStop = false;
            this.groupBoxOutline.Text = "Контур";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Цвет линии:";
            // 
            // labelThicknessValue
            // 
            this.labelThicknessValue.AutoSize = true;
            this.labelThicknessValue.Location = new System.Drawing.Point(107, 43);
            this.labelThicknessValue.Name = "labelThicknessValue";
            this.labelThicknessValue.Size = new System.Drawing.Size(27, 13);
            this.labelThicknessValue.TabIndex = 8;
            this.labelThicknessValue.Text = "1 px";
            // 
            // checkBoxSmoothing
            // 
            this.checkBoxSmoothing.AutoSize = true;
            this.checkBoxSmoothing.Location = new System.Drawing.Point(6, 137);
            this.checkBoxSmoothing.Name = "checkBoxSmoothing";
            this.checkBoxSmoothing.Size = new System.Drawing.Size(94, 17);
            this.checkBoxSmoothing.TabIndex = 7;
            this.checkBoxSmoothing.Text = "Сглаживание";
            this.checkBoxSmoothing.UseVisualStyleBackColor = true;
            this.checkBoxSmoothing.CheckedChanged += new System.EventHandler(this.checkBoxSmoothing_CheckedChanged);
            // 
            // pictureBoxToolColor
            // 
            this.pictureBoxToolColor.BackColor = System.Drawing.Color.Black;
            this.pictureBoxToolColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxToolColor.Location = new System.Drawing.Point(80, 16);
            this.pictureBoxToolColor.Name = "pictureBoxToolColor";
            this.pictureBoxToolColor.Size = new System.Drawing.Size(54, 24);
            this.pictureBoxToolColor.TabIndex = 2;
            this.pictureBoxToolColor.TabStop = false;
            this.pictureBoxToolColor.Click += new System.EventHandler(this.pictureBoxToolColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Стиль линии:";
            // 
            // comboBoxStyle
            // 
            this.comboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStyle.FormattingEnabled = true;
            this.comboBoxStyle.Location = new System.Drawing.Point(6, 110);
            this.comboBoxStyle.Name = "comboBoxStyle";
            this.comboBoxStyle.Size = new System.Drawing.Size(128, 21);
            this.comboBoxStyle.TabIndex = 6;
            this.comboBoxStyle.SelectedValueChanged += new System.EventHandler(this.comboBoxStyle_SelectedValueChanged);
            // 
            // trackBarWidth
            // 
            this.trackBarWidth.Location = new System.Drawing.Point(6, 59);
            this.trackBarWidth.Maximum = 20;
            this.trackBarWidth.Minimum = 1;
            this.trackBarWidth.Name = "trackBarWidth";
            this.trackBarWidth.Size = new System.Drawing.Size(129, 45);
            this.trackBarWidth.TabIndex = 4;
            this.trackBarWidth.Value = 1;
            this.trackBarWidth.ValueChanged += new System.EventHandler(this.trackBarWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ширина линии:";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelPosition
            // 
            this.statusLabelPosition.Name = "statusLabelPosition";
            this.statusLabelPosition.Size = new System.Drawing.Size(25, 17);
            this.statusLabelPosition.Text = "0; 0";
            // 
            // statusLabelScale
            // 
            this.statusLabelScale.Name = "statusLabelScale";
            this.statusLabelScale.Size = new System.Drawing.Size(34, 17);
            this.statusLabelScale.Text = "Scale";
            // 
            // statusLabelTool
            // 
            this.statusLabelTool.Name = "statusLabelTool";
            this.statusLabelTool.Size = new System.Drawing.Size(29, 17);
            this.statusLabelTool.Text = "Tool";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Bitmap|*.bmp|GIF|*.gif|JPEG|*.jpg|PNG|*.png|Все графические файлы|*.bmp;*.gif;*.j" +
    "pg;*.png";
            this.openFileDialog1.FilterIndex = 5;
            this.openFileDialog1.Title = "Открыть графический файл";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Растр BMP|*.bmp|Сжатый растр без потерь PNG|*.png|Сжатый растр JPG|*.jpg";
            this.saveFileDialog1.FilterIndex = 2;
            // 
            // panelContainer
            // 
            this.panelContainer.AutoSize = true;
            this.panelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContainer.Controls.Add(this.containerHScroll);
            this.panelContainer.Controls.Add(this.containerVScroll);
            this.panelContainer.Controls.Add(this.drawCanvas1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 63);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(682, 521);
            this.panelContainer.TabIndex = 2;
            // 
            // containerHScroll
            // 
            this.containerHScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.containerHScroll.Location = new System.Drawing.Point(0, 500);
            this.containerHScroll.Name = "containerHScroll";
            this.containerHScroll.Size = new System.Drawing.Size(661, 17);
            this.containerHScroll.TabIndex = 2;
            this.containerHScroll.ValueChanged += new System.EventHandler(this.containerHScroll_ValueChanged);
            // 
            // containerVScroll
            // 
            this.containerVScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.containerVScroll.Location = new System.Drawing.Point(661, 0);
            this.containerVScroll.Name = "containerVScroll";
            this.containerVScroll.Size = new System.Drawing.Size(17, 517);
            this.containerVScroll.TabIndex = 1;
            this.containerVScroll.ValueChanged += new System.EventHandler(this.containerVScroll_ValueChanged);
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьToolStripMenuItem,
            this.вернутьToolStripMenuItem,
            this.отменитьВсёToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приблизитьToolStripMenuItem,
            this.уменьшитьToolStripMenuItem,
            this.сброситьМасштабToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            this.отменитьToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // вернутьToolStripMenuItem
            // 
            this.вернутьToolStripMenuItem.Name = "вернутьToolStripMenuItem";
            this.вернутьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.вернутьToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.вернутьToolStripMenuItem.Text = "Вернуть";
            this.вернутьToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
            // 
            // отменитьВсёToolStripMenuItem
            // 
            this.отменитьВсёToolStripMenuItem.Name = "отменитьВсёToolStripMenuItem";
            this.отменитьВсёToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.отменитьВсёToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.отменитьВсёToolStripMenuItem.Text = "Отменить всё";
            this.отменитьВсёToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // приблизитьToolStripMenuItem
            // 
            this.приблизитьToolStripMenuItem.Name = "приблизитьToolStripMenuItem";
            this.приблизитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.приблизитьToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.приблизитьToolStripMenuItem.Text = "Увеличить";
            this.приблизитьToolStripMenuItem.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // уменьшитьToolStripMenuItem
            // 
            this.уменьшитьToolStripMenuItem.Name = "уменьшитьToolStripMenuItem";
            this.уменьшитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.уменьшитьToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.уменьшитьToolStripMenuItem.Text = "Уменьшить";
            this.уменьшитьToolStripMenuItem.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // сброситьМасштабToolStripMenuItem
            // 
            this.сброситьМасштабToolStripMenuItem.Name = "сброситьМасштабToolStripMenuItem";
            this.сброситьМасштабToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.сброситьМасштабToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.сброситьМасштабToolStripMenuItem.Text = "Сбросить масштаб";
            this.сброситьМасштабToolStripMenuItem.Click += new System.EventHandler(this.buttonZoomReset_Click);
            // 
            // drawCanvas1
            // 
            this.drawCanvas1.BackColor = System.Drawing.Color.White;
            this.drawCanvas1.CanvasSmoothing = System.Drawing.Drawing2D.SmoothingMode.None;
            this.drawCanvas1.CanvasZoomFactor = 1F;
            this.drawCanvas1.Location = new System.Drawing.Point(0, 0);
            this.drawCanvas1.Name = "drawCanvas1";
            this.drawCanvas1.Size = new System.Drawing.Size(150, 150);
            this.drawCanvas1.TabIndex = 0;
            this.drawCanvas1.ShapesDrawRequest += new System.Windows.Forms.PaintEventHandler(this.drawCanvas1_ShapesDrawRequest);
            this.drawCanvas1.OnMouseDownScaled += new System.Windows.Forms.MouseEventHandler(this.drawCanvas1_OnMouseDownScaled);
            this.drawCanvas1.OnMouseUpScaled += new System.Windows.Forms.MouseEventHandler(this.drawCanvas1_OnMouseUpScaled);
            this.drawCanvas1.OnMouseMoveScaled += new System.Windows.Forms.MouseEventHandler(this.drawCanvas1_OnMouseMoveScaled);
            this.drawCanvas1.SizeChanged += new System.EventHandler(this.drawCanvas1_SizeChanged);
            this.drawCanvas1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drawCanvas1_KeyDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 606);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.toolStripTools);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "SimplePaint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.panelColors.ResumeLayout(false);
            this.groupBoxBackground.ResumeLayout(false);
            this.groupBoxBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackColor)).EndInit();
            this.groupBoxFill.ResumeLayout(false);
            this.groupBoxFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFillColor)).EndInit();
            this.groupBoxOutline.ResumeLayout(false);
            this.groupBoxOutline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToolColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.ToolStripButton toolStripButtonPencil;
        private System.Windows.Forms.Panel panelColors;
        private System.Windows.Forms.ColorDialog colorDialog1;
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
        private System.Windows.Forms.ToolStripButton toolStripButtonMove;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomReset;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.PictureBox pictureBoxToolColor;
        private System.Windows.Forms.PictureBox pictureBoxBackColor;
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEraser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DrawCanvas drawCanvas1;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label labelThicknessValue;
        private System.Windows.Forms.ToolStripButton toolStripButtonRectangle;
        private System.Windows.Forms.ToolStripButton toolStripButtonEllipse;
        private System.Windows.Forms.ToolStripButton toolStripButtonFill;
        private System.Windows.Forms.ToolStripButton toolStripButtonHand;
        private System.Windows.Forms.GroupBox groupBoxFill;
        private System.Windows.Forms.GroupBox groupBoxOutline;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxNoFill;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxFillColor;
        private System.Windows.Forms.VScrollBar containerVScroll;
        private System.Windows.Forms.HScrollBar containerHScroll;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приблизитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уменьшитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сброситьМасштабToolStripMenuItem;
    }
}

