namespace Neflis
{
    partial class Reproducir
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolume = new System.Windows.Forms.Button();
            this.lblInicio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.VolumeControl = new System.Windows.Forms.TrackBar();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnVolume);
            this.panel1.Controls.Add(this.lblInicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblFin);
            this.panel1.Controls.Add(this.txtFinal);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 81);
            this.panel1.TabIndex = 2;
            // 
            // btnVolume
            // 
            this.btnVolume.BackgroundImage = global::Neflis.Properties.Resources.alto_volumen_318_10728;
            this.btnVolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVolume.Location = new System.Drawing.Point(885, 46);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(29, 27);
            this.btnVolume.TabIndex = 4;
            this.btnVolume.UseVisualStyleBackColor = true;
            this.btnVolume.Click += new System.EventHandler(this.btnVolume_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(21, 49);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(80, 24);
            this.lblInicio.TabIndex = 3;
            this.lblInicio.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(919, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "0";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(789, 49);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(80, 24);
            this.lblFin.TabIndex = 3;
            this.lblFin.Text = "00:00:00";
            // 
            // txtFinal
            // 
            this.txtFinal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFinal.Location = new System.Drawing.Point(1247, 3);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.ReadOnly = true;
            this.txtFinal.Size = new System.Drawing.Size(100, 22);
            this.txtFinal.TabIndex = 1;
            // 
            // btnPause
            // 
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPause.Location = new System.Drawing.Point(430, 43);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(35, 31);
            this.btnPause.TabIndex = 0;
            this.btnPause.TabStop = false;
            this.btnPause.Text = " ▌ ▌ ";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnStop.Location = new System.Drawing.Point(471, 43);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(35, 31);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = " ▌▌ ";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPlay.Location = new System.Drawing.Point(389, 43);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(35, 31);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "▸";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AllowDrop = true;
            this.trackBar1.Location = new System.Drawing.Point(10, 22);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(843, 56);
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // VolumeControl
            // 
            this.VolumeControl.AllowDrop = true;
            this.VolumeControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.VolumeControl.Location = new System.Drawing.Point(876, 240);
            this.VolumeControl.Maximum = 1000;
            this.VolumeControl.Name = "VolumeControl";
            this.VolumeControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VolumeControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VolumeControl.Size = new System.Drawing.Size(56, 149);
            this.VolumeControl.SmallChange = 2;
            this.VolumeControl.TabIndex = 2;
            this.VolumeControl.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.VolumeControl.Visible = false;
            // 
            // time
            // 
            this.time.Interval = 1000;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // Reproducir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(950, 420);
            this.Controls.Add(this.VolumeControl);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reproducir";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reproducir";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.TrackBar VolumeControl;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Button btnVolume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer time;
    }
}