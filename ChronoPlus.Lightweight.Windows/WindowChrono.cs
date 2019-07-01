using System.Threading.Tasks;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        private async void InitializeChronoComponents()
        {
            this.progressSpinner.Visible = true;
            for (int i = 0; i < 100; i += 2)
            {
                this.progressSpinner.Value = i;
                await Task.Delay(50);
            }

            this.progressSpinner.Value = 100;
            await Task.Delay(50);
            this.progressSpinner.Hide();
        }

        private void HideLoadingComponents()
        {
            this.progressSpinner.Visible = false;
        }
    }
}
