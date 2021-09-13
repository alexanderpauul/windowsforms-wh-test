
namespace WinCSVTest
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmbClassification = new System.Windows.Forms.ComboBox();
            this.btnLoader = new System.Windows.Forms.Button();
            this.btnReplaceValue = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnPortuguese = new System.Windows.Forms.Button();
            this.btnShowValue = new System.Windows.Forms.Button();
            this.lblClassification = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            resources.ApplyResources(this.lblPath, "lblPath");
            this.lblPath.Name = "lblPath";
            // 
            // txtPath
            // 
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtPath.Name = "txtPath";
            // 
            // cmbClassification
            // 
            resources.ApplyResources(this.cmbClassification, "cmbClassification");
            this.cmbClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Name = "cmbClassification";
            // 
            // btnLoader
            // 
            resources.ApplyResources(this.btnLoader, "btnLoader");
            this.btnLoader.Name = "btnLoader";
            this.btnLoader.UseVisualStyleBackColor = true;
            // 
            // btnReplaceValue
            // 
            resources.ApplyResources(this.btnReplaceValue, "btnReplaceValue");
            this.btnReplaceValue.Name = "btnReplaceValue";
            this.btnReplaceValue.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            resources.ApplyResources(this.btnSaveChanges, "btnSaveChanges");
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnEnglish
            // 
            resources.ApplyResources(this.btnEnglish, "btnEnglish");
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.UseVisualStyleBackColor = true;
            // 
            // btnPortuguese
            // 
            resources.ApplyResources(this.btnPortuguese, "btnPortuguese");
            this.btnPortuguese.Name = "btnPortuguese";
            this.btnPortuguese.UseVisualStyleBackColor = true;
            // 
            // btnShowValue
            // 
            resources.ApplyResources(this.btnShowValue, "btnShowValue");
            this.btnShowValue.Name = "btnShowValue";
            this.btnShowValue.UseVisualStyleBackColor = true;
            // 
            // lblClassification
            // 
            resources.ApplyResources(this.lblClassification, "lblClassification");
            this.lblClassification.Name = "lblClassification";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // dgvData
            // 
            resources.ApplyResources(this.dgvData, "dgvData");
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Name = "dgvData";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnShowValue);
            this.Controls.Add(this.btnPortuguese);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnReplaceValue);
            this.Controls.Add(this.btnLoader);
            this.Controls.Add(this.cmbClassification);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblClassification);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ComboBox cmbClassification;
        private System.Windows.Forms.Button btnLoader;
        private System.Windows.Forms.Button btnReplaceValue;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnPortuguese;
        private System.Windows.Forms.Button btnShowValue;
        private System.Windows.Forms.Label lblClassification;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.DataGridView dgvData;
    }
}