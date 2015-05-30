using Foundation;
using UIKit;

namespace FLEDemo.iOS
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		private UIWindow _window;
		private MainViewController _viewController;

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);

			_viewController = new MainViewController();
			_window.RootViewController = new UINavigationController(_viewController);
			_window.MakeKeyAndVisible();

			return true;
		}
	}
}