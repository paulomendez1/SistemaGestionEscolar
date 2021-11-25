
namespace GUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNotificaciones = new System.Windows.Forms.Button();
            this.btnAvisos = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearBackUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearBackUpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recuperarVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manejarAdminsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEstudiantes = new System.Windows.Forms.Button();
            this.btnDocentes = new System.Windows.Forms.Button();
            this.btnFinanzas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sistema de Gestion Escolar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnNotificaciones);
            this.panel1.Controls.Add(this.btnAvisos);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 64);
            this.panel1.TabIndex = 1;
            // 
            // btnNotificaciones
            // 
            this.btnNotificaciones.BackColor = System.Drawing.Color.Red;
            this.btnNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotificaciones.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNotificaciones.Location = new System.Drawing.Point(668, 12);
            this.btnNotificaciones.Name = "btnNotificaciones";
            this.btnNotificaciones.Size = new System.Drawing.Size(20, 23);
            this.btnNotificaciones.TabIndex = 5;
            this.btnNotificaciones.Text = "-";
            this.btnNotificaciones.UseVisualStyleBackColor = false;
            // 
            // btnAvisos
            // 
            this.btnAvisos.BackColor = System.Drawing.Color.White;
            this.btnAvisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvisos.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAvisos.Image = ((System.Drawing.Image)(resources.GetObject("btnAvisos.Image")));
            this.btnAvisos.Location = new System.Drawing.Point(681, 1);
            this.btnAvisos.Name = "btnAvisos";
            this.btnAvisos.Size = new System.Drawing.Size(25, 23);
            this.btnAvisos.TabIndex = 4;
            this.btnAvisos.UseVisualStyleBackColor = false;
            this.btnAvisos.Click += new System.EventHandler(this.btnAvisos_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(712, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionToolStripMenuItem,
            this.crearBackUpToolStripMenuItem,
            this.manejarAdminsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.sToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sToolStripMenuItem.ImageTransparentColor = System.Drawing.SystemColors.MenuBar;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.sToolStripMenuItem.Text = "s";
            this.sToolStripMenuItem.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // crearBackUpToolStripMenuItem
            // 
            this.crearBackUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearBackUpToolStripMenuItem1,
            this.recuperarVersionToolStripMenuItem});
            this.crearBackUpToolStripMenuItem.Name = "crearBackUpToolStripMenuItem";
            this.crearBackUpToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.crearBackUpToolStripMenuItem.Text = "BackUp";
            this.crearBackUpToolStripMenuItem.Click += new System.EventHandler(this.crearBackUpToolStripMenuItem_Click);
            // 
            // crearBackUpToolStripMenuItem1
            // 
            this.crearBackUpToolStripMenuItem1.Name = "crearBackUpToolStripMenuItem1";
            this.crearBackUpToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.crearBackUpToolStripMenuItem1.Text = "Crear BackUp";
            this.crearBackUpToolStripMenuItem1.Click += new System.EventHandler(this.crearBackUpToolStripMenuItem1_Click);
            // 
            // recuperarVersionToolStripMenuItem
            // 
            this.recuperarVersionToolStripMenuItem.Name = "recuperarVersionToolStripMenuItem";
            this.recuperarVersionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.recuperarVersionToolStripMenuItem.Text = "Recuperar Version";
            this.recuperarVersionToolStripMenuItem.Click += new System.EventHandler(this.recuperarVersionToolStripMenuItem_Click);
            // 
            // manejarAdminsToolStripMenuItem
            // 
            this.manejarAdminsToolStripMenuItem.Name = "manejarAdminsToolStripMenuItem";
            this.manejarAdminsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.manejarAdminsToolStripMenuItem.Text = "Manejar Adminitradores";
            this.manejarAdminsToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.logoutToolStripMenuItem.Text = "Cerrar Sesión";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.BackColor = System.Drawing.Color.Black;
            this.btnEstudiantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstudiantes.ForeColor = System.Drawing.Color.White;
            this.btnEstudiantes.Location = new System.Drawing.Point(40, 213);
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.Size = new System.Drawing.Size(95, 36);
            this.btnEstudiantes.TabIndex = 7;
            this.btnEstudiantes.Text = "Estudiantes";
            this.btnEstudiantes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstudiantes.UseVisualStyleBackColor = false;
            this.btnEstudiantes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDocentes
            // 
            this.btnDocentes.BackColor = System.Drawing.Color.Black;
            this.btnDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocentes.ForeColor = System.Drawing.Color.White;
            this.btnDocentes.Location = new System.Drawing.Point(247, 213);
            this.btnDocentes.Name = "btnDocentes";
            this.btnDocentes.Size = new System.Drawing.Size(95, 36);
            this.btnDocentes.TabIndex = 8;
            this.btnDocentes.Text = "Docentes";
            this.btnDocentes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDocentes.UseVisualStyleBackColor = false;
            this.btnDocentes.Click += new System.EventHandler(this.btnDocentes_Click);
            // 
            // btnFinanzas
            // 
            this.btnFinanzas.BackColor = System.Drawing.Color.Black;
            this.btnFinanzas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanzas.ForeColor = System.Drawing.Color.White;
            this.btnFinanzas.Location = new System.Drawing.Point(610, 213);
            this.btnFinanzas.Name = "btnFinanzas";
            this.btnFinanzas.Size = new System.Drawing.Size(95, 47);
            this.btnFinanzas.TabIndex = 9;
            this.btnFinanzas.Text = "Finanzas y \r\nAvisos";
            this.btnFinanzas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinanzas.UseVisualStyleBackColor = false;
            this.btnFinanzas.Click += new System.EventHandler(this.btnFinanzas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(226, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(586, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 128);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(414, 79);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 128);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // btnMaterias
            // 
            this.btnMaterias.BackColor = System.Drawing.Color.Black;
            this.btnMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterias.ForeColor = System.Drawing.Color.White;
            this.btnMaterias.Location = new System.Drawing.Point(434, 213);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(95, 47);
            this.btnMaterias.TabIndex = 13;
            this.btnMaterias.Text = "Materias y \r\nAsistencia";
            this.btnMaterias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaterias.UseVisualStyleBackColor = false;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(624, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(27, 24);
            this.dataGridView1.TabIndex = 15;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 266);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnMaterias);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFinanzas);
            this.Controls.Add(this.btnDocentes);
            this.Controls.Add(this.btnEstudiantes);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEstudiantes;
        private System.Windows.Forms.Button btnDocentes;
        private System.Windows.Forms.Button btnFinanzas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manejarAdminsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearBackUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearBackUpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem recuperarVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Button btnNotificaciones;
        private System.Windows.Forms.Button btnAvisos;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}