using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4G.Helpers
{
    public class MultiResImageChooserUri
    {
        public Uri BestResolutionImage
        {
            get
            {
                switch (ResolutionHelper.CurrentResolution)
                {
                    case C4G.Helpers.ResolutionHelper.Resolutions.HD720p:
                        return new Uri("/Assets/Splash_wvga.png", UriKind.Relative);
                    case C4G.Helpers.ResolutionHelper.Resolutions.WXGA:
                        return new Uri("/Assets/Splash_wvga.png", UriKind.Relative);
                    case C4G.Helpers.ResolutionHelper.Resolutions.WVGA:
                        return new Uri("/Assets/Splash_wvga.png", UriKind.Relative);
                    default:
                        throw new InvalidOperationException("Unknown resolution type");
                }
            }
        }
    }
}
