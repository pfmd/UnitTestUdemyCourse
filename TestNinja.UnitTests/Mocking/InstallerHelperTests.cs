using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{

    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void setup()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper= new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        { 
            _fileDownloader.Setup(fd=>fd.DownloadFile("","")).Throws<WebException>();
           var result= _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result,Is.False);
        }
    }
}
