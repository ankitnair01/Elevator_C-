using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elevator
{
    public partial class MainForm : Form
    {
        private string currentFloor = "G";
        private string targetFloor = "";
        private bool isMoving = false;
        private readonly Database db = new Database();

        // Images
        private Image imgGroundClosed, imgGroundOpen;
        private Image imgFirstClosed, imgFirstOpen;
        private Image imgLiftShadow;

        // Movement vars
        private int liftSpeed = 8;
        private int liftTargetY;

        public MainForm()
        {
            InitializeComponent();

            imgGroundClosed = Properties.Resources.Ground_Floor;
            imgFirstClosed = Properties.Resources.First_Floor;
            imgGroundOpen = Properties.Resources.LiftOpen; // open door image
            imgFirstOpen = Properties.Resources.LiftOpen1;   // open door image
            imgLiftShadow = Properties.Resources.LiftClosed;      // the moving image

            pictureGroundFloor.Image = imgGroundClosed;
            pictureFirstFloor.Image = imgFirstClosed;
            pictureLift.Image = imgLiftShadow;

            lblStatus.Text = "Lift idle at Ground Floor.";
        }

        private async void btnG_Click(object sender, EventArgs e)
        {
            if (isMoving || currentFloor == "G") return;
            await MoveToFloor("G");
        }

        private async void btn1_Click(object sender, EventArgs e)
        {
            if (isMoving || currentFloor == "1") return;
            await MoveToFloor("1");
        }

        private async Task MoveToFloor(string floor)
        {
            isMoving = true;
            targetFloor = floor;
            lblStatus.Text = $"Moving to floor {floor}...";

            liftTargetY = (floor == "1") ? pictureFirstFloor.Top + 120 : pictureGroundFloor.Top + 120;
            liftTimer.Start();
        }

        private void liftTimer_Tick(object sender, EventArgs e)
        {
            if (targetFloor == "1" && pictureLift.Top > liftTargetY)
            {
                pictureLift.Top -= liftSpeed;
            }
            else if (targetFloor == "G" && pictureLift.Top < liftTargetY)
            {
                pictureLift.Top += liftSpeed;
            }
            else
            {
                liftTimer.Stop();
                _ = ArrivedAtFloor();
            }
        }

        private async Task ArrivedAtFloor()
        {
            lblStatus.Text = $"Lift arrived at floor {targetFloor}. Opening doors...";
            if (targetFloor == "1")
            {
                pictureFirstFloor.Image = imgFirstOpen;
            }
            else
            {
                pictureGroundFloor.Image = imgGroundOpen;
            }

            await Task.Delay(1500);

            if (targetFloor == "1")
                pictureFirstFloor.Image = imgFirstClosed;
            else
                pictureGroundFloor.Image = imgGroundClosed;

            currentFloor = targetFloor;
            isMoving = false;
            lblStatus.Text = $"Lift idle at floor {currentFloor}.";
            db.LogAsync(1, currentFloor == "G" ? 0 : 1, $"Lift arrived at floor {currentFloor}");
        }

        private async void btnOpenDoor_Click(object sender, EventArgs e)
        {
            if (isMoving) return;
            lblStatus.Text = "Doors opening...";

            if (currentFloor == "1")
                pictureFirstFloor.Image = imgFirstOpen;
            else
                pictureGroundFloor.Image = imgGroundOpen;

            await Task.Delay(1500);
            lblStatus.Text = "Doors opened.";
        }

        private async void btnCloseDoor_Click(object sender, EventArgs e)
        {
            if (isMoving) return;
            lblStatus.Text = "Doors closing...";

            if (currentFloor == "1")
                pictureFirstFloor.Image = imgFirstClosed;
            else
                pictureGroundFloor.Image = imgGroundClosed;

            await Task.Delay(600);
            lblStatus.Text = "Doors closed.";
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            LogsForm logs = new LogsForm(db);
            logs.ShowDialog();
        }
    }
}
