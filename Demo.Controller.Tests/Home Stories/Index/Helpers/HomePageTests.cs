using Demo.Controllers.Mvc;
using TestStack.FluentMVCTesting;

namespace Demo.Controller.Tests.IndexStory
{
    public partial class HomePageTests
    {
        private ControllerResultTest<HomeController> _controllerResult;
        private HomeController _homeController;

        private void IfIPutRightAddressInBrowser()
        {
            this._homeController = new HomeController();
        }

        private void UserComesOnIndexView()
        {
            this._controllerResult = this._homeController.WithCallTo(h => h.Index());
        }

        private void UserSeesWelcomePage()
        {
            this._controllerResult.ShouldRenderDefaultView();
        }
    }
}
