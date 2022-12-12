namespace ViewForm
{
    partial class PanelPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelPrincipal));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dificultad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Basico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialNecesario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MusculosInvolucrados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelinfo = new System.Windows.Forms.Label();
            this.btnRestablecer = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnMostrarPorFecha = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxModos = new System.Windows.Forms.ComboBox();
            this.labelModo = new System.Windows.Forms.Label();
            this.btnServer = new System.Windows.Forms.Button();
            this.textLogs = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(37, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id:";
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCrear.Location = new System.Drawing.Point(165, 44);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(164, 23);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear ejercicio";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(1098, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Mostrar todos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.Location = new System.Drawing.Point(165, 15);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(77, 23);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Descripcion,
            this.Dificultad,
            this.Basico,
            this.MaterialNecesario,
            this.MusculosInvolucrados,
            this.FechaModificacion});
            this.dataGridView1.Location = new System.Drawing.Point(345, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(867, 360);
            this.dataGridView1.TabIndex = 7;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Dificultad
            // 
            this.Dificultad.HeaderText = "Dificultad";
            this.Dificultad.Name = "Dificultad";
            this.Dificultad.ReadOnly = true;
            // 
            // Basico
            // 
            this.Basico.HeaderText = "Basico";
            this.Basico.Name = "Basico";
            this.Basico.ReadOnly = true;
            // 
            // MaterialNecesario
            // 
            this.MaterialNecesario.HeaderText = "Material necesario";
            this.MaterialNecesario.Name = "MaterialNecesario";
            this.MaterialNecesario.ReadOnly = true;
            // 
            // MusculosInvolucrados
            // 
            this.MusculosInvolucrados.HeaderText = "Musculos involucrados";
            this.MusculosInvolucrados.Name = "MusculosInvolucrados";
            this.MusculosInvolucrados.ReadOnly = true;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.HeaderText = "Fecha de modificación";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(248, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(81, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // labelinfo
            // 
            this.labelinfo.AutoSize = true;
            this.labelinfo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.labelinfo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelinfo.ForeColor = System.Drawing.SystemColors.Info;
            this.labelinfo.Location = new System.Drawing.Point(14, 86);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new System.Drawing.Size(30, 14);
            this.labelinfo.TabIndex = 10;
            this.labelinfo.Text = "info";
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRestablecer.Location = new System.Drawing.Point(69, 380);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(120, 23);
            this.btnRestablecer.TabIndex = 12;
            this.btnRestablecer.Text = "Restablecer fichero";
            this.btnRestablecer.UseVisualStyleBackColor = true;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(6, 380);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(57, 23);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(345, 380);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(228, 23);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnMostrarPorFecha
            // 
            this.btnMostrarPorFecha.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMostrarPorFecha.Location = new System.Drawing.Point(579, 380);
            this.btnMostrarPorFecha.Name = "btnMostrarPorFecha";
            this.btnMostrarPorFecha.Size = new System.Drawing.Size(131, 23);
            this.btnMostrarPorFecha.TabIndex = 17;
            this.btnMostrarPorFecha.Text = "Mostrar por fecha";
            this.btnMostrarPorFecha.UseVisualStyleBackColor = true;
            this.btnMostrarPorFecha.Click += new System.EventHandler(this.btnMostrarPorFecha_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(177, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Cambiar modo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxModos
            // 
            this.comboBoxModos.FormattingEnabled = true;
            this.comboBoxModos.Items.AddRange(new object[] {
            "Modo memoria",
            "Modo JSON",
            "Modo a pelo",
            "Modo bytes",
            "Modo XML"});
            this.comboBoxModos.Location = new System.Drawing.Point(6, 310);
            this.comboBoxModos.Name = "comboBoxModos";
            this.comboBoxModos.Size = new System.Drawing.Size(165, 23);
            this.comboBoxModos.TabIndex = 19;
            // 
            // labelModo
            // 
            this.labelModo.AutoSize = true;
            this.labelModo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.labelModo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelModo.ForeColor = System.Drawing.SystemColors.Info;
            this.labelModo.Location = new System.Drawing.Point(177, 336);
            this.labelModo.Name = "labelModo";
            this.labelModo.Size = new System.Drawing.Size(74, 14);
            this.labelModo.TabIndex = 20;
            this.labelModo.Text = "Modo XML.";
            // 
            // btnServer
            // 
            this.btnServer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnServer.Location = new System.Drawing.Point(195, 380);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(144, 23);
            this.btnServer.TabIndex = 21;
            this.btnServer.Text = "Iniciar servidor";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // textLogs
            // 
            this.textLogs.Location = new System.Drawing.Point(6, 416);
            this.textLogs.Multiline = true;
            this.textLogs.Name = "textLogs";
            this.textLogs.ReadOnly = true;
            this.textLogs.Size = new System.Drawing.Size(1206, 189);
            this.textLogs.TabIndex = 22;
            this.textLogs.Visible = false;
            // 
            // PanelPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1224, 409);
            this.Controls.Add(this.textLogs);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.labelModo);
            this.Controls.Add(this.comboBoxModos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMostrarPorFecha);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRestablecer);
            this.Controls.Add(this.labelinfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PanelPrincipal";
            this.Text = "Panel principal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button btnCrear;
        private Button button3;
        private Button btnEditar;
        private DataGridView dataGridView1;
        private Button btnEliminar;
        private PictureBox pictureBox1;
        private Label labelinfo;
        private Button btnRestablecer;
        private Button btnSalir;
        private DateTimePicker dateTimePicker1;
        private Button btnMostrarPorFecha;
        private Button button1;
        private ComboBox comboBoxModos;
        private Label labelModo;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Dificultad;
        private DataGridViewTextBoxColumn Basico;
        private DataGridViewTextBoxColumn MaterialNecesario;
        private DataGridViewTextBoxColumn MusculosInvolucrados;
        private DataGridViewTextBoxColumn FechaModificacion;
        private Button btnServer;
        private TextBox textLogs;
    }
}