namespace Presentacion
{
    partial class Tipos_Entidades
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
            this.dgvRegistrosTENT = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.Guardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.cbxEliminable = new System.Windows.Forms.ComboBox();
            this.cbxGrupoEntidad = new System.Windows.Forms.ComboBox();
            this.lblGrupoEntidad = new System.Windows.Forms.Label();
            this.lblEliminable = new System.Windows.Forms.Label();
            this.btnDeselect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosTENT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegistrosTENT
            // 
            this.dgvRegistrosTENT.AllowUserToAddRows = false;
            this.dgvRegistrosTENT.AllowUserToDeleteRows = false;
            this.dgvRegistrosTENT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRegistrosTENT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrosTENT.Location = new System.Drawing.Point(48, 82);
            this.dgvRegistrosTENT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRegistrosTENT.Name = "dgvRegistrosTENT";
            this.dgvRegistrosTENT.ReadOnly = true;
            this.dgvRegistrosTENT.RowHeadersWidth = 62;
            this.dgvRegistrosTENT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistrosTENT.Size = new System.Drawing.Size(799, 434);
            this.dgvRegistrosTENT.TabIndex = 0;
            this.dgvRegistrosTENT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistrosTENT_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(933, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripcion :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(1106, 78);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(324, 38);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(1106, 167);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(324, 101);
            this.txtComentario.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(931, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comentario :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(956, 361);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(101, 29);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Estado:";
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(1084, 569);
            this.Guardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(346, 57);
            this.Guardar.TabIndex = 11;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(48, 574);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(249, 57);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(317, 574);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(276, 52);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(1154, 648);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(276, 52);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.Text = "Volver al menu principal";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(1106, 365);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(324, 28);
            this.cbxStatus.TabIndex = 16;
            // 
            // cbxEliminable
            // 
            this.cbxEliminable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEliminable.FormattingEnabled = true;
            this.cbxEliminable.Location = new System.Drawing.Point(1106, 418);
            this.cbxEliminable.Name = "cbxEliminable";
            this.cbxEliminable.Size = new System.Drawing.Size(324, 28);
            this.cbxEliminable.TabIndex = 17;
            // 
            // cbxGrupoEntidad
            // 
            this.cbxGrupoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGrupoEntidad.FormattingEnabled = true;
            this.cbxGrupoEntidad.Location = new System.Drawing.Point(1106, 298);
            this.cbxGrupoEntidad.Name = "cbxGrupoEntidad";
            this.cbxGrupoEntidad.Size = new System.Drawing.Size(324, 28);
            this.cbxGrupoEntidad.TabIndex = 19;
            // 
            // lblGrupoEntidad
            // 
            this.lblGrupoEntidad.AutoSize = true;
            this.lblGrupoEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupoEntidad.Location = new System.Drawing.Point(905, 298);
            this.lblGrupoEntidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrupoEntidad.Name = "lblGrupoEntidad";
            this.lblGrupoEntidad.Size = new System.Drawing.Size(188, 29);
            this.lblGrupoEntidad.TabIndex = 18;
            this.lblGrupoEntidad.Text = "Grupo Entidad:";
            // 
            // lblEliminable
            // 
            this.lblEliminable.AutoSize = true;
            this.lblEliminable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEliminable.Location = new System.Drawing.Point(905, 418);
            this.lblEliminable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEliminable.Name = "lblEliminable";
            this.lblEliminable.Size = new System.Drawing.Size(179, 29);
            this.lblEliminable.TabIndex = 20;
            this.lblEliminable.Text = "Es eliminable:";
            // 
            // btnDeselect
            // 
            this.btnDeselect.Location = new System.Drawing.Point(601, 574);
            this.btnDeselect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(276, 52);
            this.btnDeselect.TabIndex = 21;
            this.btnDeselect.Text = "Desmarcar";
            this.btnDeselect.UseVisualStyleBackColor = true;
            this.btnDeselect.Click += new System.EventHandler(this.btnDeselect_Click);
            // 
            // Tipos_Entidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 714);
            this.Controls.Add(this.btnDeselect);
            this.Controls.Add(this.lblEliminable);
            this.Controls.Add(this.cbxGrupoEntidad);
            this.Controls.Add(this.lblGrupoEntidad);
            this.Controls.Add(this.cbxEliminable);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRegistrosTENT);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Tipos_Entidades";
            this.Text = "Tipos Entidades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tipos_Entidades_FormClosed);
            this.Load += new System.EventHandler(this.Tipos_Entidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosTENT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegistrosTENT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.ComboBox cbxEliminable;
        private System.Windows.Forms.ComboBox cbxGrupoEntidad;
        private System.Windows.Forms.Label lblGrupoEntidad;
        private System.Windows.Forms.Label lblEliminable;
        private System.Windows.Forms.Button btnDeselect;
    }
}