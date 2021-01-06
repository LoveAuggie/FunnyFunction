
namespace DemoForm
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnXL = new System.Windows.Forms.Button();
            this.btnXL2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnXL
            // 
            this.btnXL.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnXL.Location = new System.Drawing.Point(13, 13);
            this.btnXL.Name = "btnXL";
            this.btnXL.Size = new System.Drawing.Size(90, 40);
            this.btnXL.TabIndex = 0;
            this.btnXL.Text = "寻路演示";
            this.btnXL.UseVisualStyleBackColor = true;
            this.btnXL.Click += new System.EventHandler(this.btnXL_Click);
            // 
            // btnXL2
            // 
            this.btnXL2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnXL2.Location = new System.Drawing.Point(13, 59);
            this.btnXL2.Name = "btnXL2";
            this.btnXL2.Size = new System.Drawing.Size(90, 40);
            this.btnXL2.TabIndex = 1;
            this.btnXL2.Text = "寻路演示2";
            this.btnXL2.UseVisualStyleBackColor = true;
            this.btnXL2.Click += new System.EventHandler(this.btnXL2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 222);
            this.Controls.Add(this.btnXL2);
            this.Controls.Add(this.btnXL);
            this.Name = "Form1";
            this.Text = "界面演示";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXL;
        private System.Windows.Forms.Button btnXL2;
    }
}

