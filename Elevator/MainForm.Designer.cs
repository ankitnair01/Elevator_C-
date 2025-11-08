namespace Elevator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureFirstFloor;
        private System.Windows.Forms.PictureBox pictureGroundFloor;
        private System.Windows.Forms.PictureBox pictureLift;
        private System.Windows.Forms.Button btnG;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnOpenDoor;
        private System.Windows.Forms.Button btnCloseDoor;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer liftTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureFirstFloor = new System.Windows.Forms.PictureBox();
            this.pictureGroundFloor = new System.Windows.Forms.PictureBox();
            this.pictureLift = new System.Windows.Forms.PictureBox();
            this.btnG = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnOpenDoor = new System.Windows.Forms.Button();
            this.btnCloseDoor = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.liftTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureFirstFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGroundFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLift)).BeginInit();
            this.SuspendLayout();

            // --- FIRST FLOOR ---
            this.pictureFirstFloor.Location = new System.Drawing.Point(60, 40);
            this.pictureFirstFloor.Size = new System.Drawing.Size(500, 330);
            this.pictureFirstFloor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFirstFloor.BackColor = System.Drawing.Color.Transparent;

            // --- GROUND FLOOR ---
            this.pictureGroundFloor.Location = new System.Drawing.Point(60, 420);
            this.pictureGroundFloor.Size = new System.Drawing.Size(500, 330);
            this.pictureGroundFloor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureGroundFloor.BackColor = System.Drawing.Color.Transparent;

            // --- LIFT (Shadow / Moving Elevator) ---
            this.pictureLift.BackColor = System.Drawing.Color.Transparent;
            this.pictureLift.Location = new System.Drawing.Point(160, 700); // start aligned near Ground
            this.pictureLift.Size = new System.Drawing.Size(340, 200);
            this.pictureLift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // --- BUTTON: Floor 1 ---
            this.btn1.Location = new System.Drawing.Point(600, 150);
            this.btn1.Size = new System.Drawing.Size(120, 50);
            this.btn1.Text = "1";
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn1.Click += new System.EventHandler(this.btn1_Click);

            // --- BUTTON: Ground Floor ---
            this.btnG.Location = new System.Drawing.Point(600, 220);
            this.btnG.Size = new System.Drawing.Size(120, 50);
            this.btnG.Text = "G";
            this.btnG.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnG.Click += new System.EventHandler(this.btnG_Click);

            // --- BUTTON: Open Door ---
            this.btnOpenDoor.Location = new System.Drawing.Point(600, 300);
            this.btnOpenDoor.Size = new System.Drawing.Size(120, 50);
            this.btnOpenDoor.Text = "Open Door";
            this.btnOpenDoor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOpenDoor.Click += new System.EventHandler(this.btnOpenDoor_Click);

            // --- BUTTON: Close Door ---
            this.btnCloseDoor.Location = new System.Drawing.Point(600, 360);
            this.btnCloseDoor.Size = new System.Drawing.Size(120, 50);
            this.btnCloseDoor.Text = "Close Door";
            this.btnCloseDoor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCloseDoor.Click += new System.EventHandler(this.btnCloseDoor_Click);

            // --- BUTTON: View Logs ---
            this.btnViewLogs.Location = new System.Drawing.Point(600, 440);
            this.btnViewLogs.Size = new System.Drawing.Size(120, 50);
            this.btnViewLogs.Text = "View Logs";
            this.btnViewLogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);

            // --- STATUS LABEL ---
            this.lblStatus.Location = new System.Drawing.Point(60, 770);
            this.lblStatus.Size = new System.Drawing.Size(660, 30);
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);

            // --- TIMER ---
            this.liftTimer.Interval = 40;
            this.liftTimer.Tick += new System.EventHandler(this.liftTimer_Tick);

            // --- MAIN FORM ---
            this.ClientSize = new System.Drawing.Size(760, 830);
            this.Controls.Add(this.pictureLift);
            this.Controls.Add(this.pictureFirstFloor);
            this.Controls.Add(this.pictureGroundFloor);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnG);
            this.Controls.Add(this.btnOpenDoor);
            this.Controls.Add(this.btnCloseDoor);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.lblStatus);
            this.Text = "Elevator Simulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // --- Z-ORDER FIX: Make sure lift stays behind ---
            this.pictureLift.SendToBack();
            this.pictureGroundFloor.BringToFront();
            this.pictureFirstFloor.BringToFront();

            ((System.ComponentModel.ISupportInitialize)(this.pictureFirstFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGroundFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLift)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
