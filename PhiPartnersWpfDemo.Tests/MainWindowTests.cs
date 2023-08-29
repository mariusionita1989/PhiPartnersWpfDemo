using Moq;
using PhiPartnersWpfDemo.Dto;
using PhiPartnersWpfDemo.Services;

namespace PhiPartnersWpfDemo.Tests
{
    [TestFixture]
    public class MainWindowTests
    {
        private Mock<IHackerNewsWebService> _webServiceMock;

        [SetUp]
        public void Setup()
        {
            _webServiceMock = new Mock<IHackerNewsWebService>();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void RefreshButton_Click_RefreshDataCalled()
        {
            var mainWindow = new MainWindow();
            mainWindow._webService = _webServiceMock.Object;

            // Setup mock behavior
            var mockResult = new List<StoryDto>();
            _webServiceMock.Setup(m => m.GetBestStoriesAsync()).ReturnsAsync(mockResult);

            // Act
            mainWindow.RefreshData();

            // Assert
            _webServiceMock.Verify(m => m.GetBestStoriesAsync(), Times.Once);
        }
    }
}