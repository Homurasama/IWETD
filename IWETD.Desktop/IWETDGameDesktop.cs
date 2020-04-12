using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IWETD.Game;
using osu.Framework.Platform;
using osuTK.Input;

namespace IWETD.Desktop
{
    public class IWETDGameDesktop : IWETDGame
    {
        public IWETDGameDesktop(string[] args) 
            : base(args)
        {
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            if (host.Window is DesktopGameWindow desktopWindow)
            {
                desktopWindow.Title = "I Wanna End The Delirium";

                desktopWindow.FileDrop += FileDrop;
            }
        }

        private void FileDrop(object sender, FileDropEventArgs e)
        {
            var filePaths = e.FileNames;

            var firstExtension = Path.GetExtension(filePaths.First());
            
            if (filePaths.Any(f => Path.GetExtension(f) != firstExtension)) return;

            Task.Factory.StartNew(() => Import(filePaths), TaskCreationOptions.LongRunning);
        }
    }
}