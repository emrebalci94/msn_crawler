using Moq;
using MsnCrawler.Business.DataAccess.Services;
using MsnCrawler.Test.Mocks;
using System;
using System.Collections.Generic;
using Xunit;

namespace MsnCrawler.Test
{
    public class DatabaseTest
    {
        #region Company

        [Fact]
        public void Company_GetCompanies_ShouldAssertsTrue_WhenListIsNotNull()
        {
            var mock = new Mock<ICompanyServices>();
            mock.Setup(p => p.GetCompanies()).Returns(new List<Domain.Company> { new Domain.Company { Name = "test" } });
            var mockManager = new CompanyRepository(mock.Object);
            var result = mockManager.GetCompanies();
            Assert.NotNull(result);
        }

        [Fact]
        public void Company_InsertOrId_ShouldAssertsTrue_WhenCompanyNameIsExists()
        {
            var mock = new Mock<ICompanyServices>();
            mock.Setup(p => p.InsertOrId("Hürriyet")).Returns(1);
            var mockManager = new CompanyRepository(mock.Object);
            var result = mockManager.InsertOrId("Hürriyet");
            Assert.Equal(1, result);
        }

        #endregion

        #region News

        [Fact]
        public void News_GetCompanyCounts_ShouldAssertsTrue_WhenListIsNotNull()
        {
            var mock = new Mock<INewsServices>();
            mock.Setup(p => p.GetCompanyCounts()).Returns(new List<Business.Dto.CompanyCountModel> { new Business.Dto.CompanyCountModel { Name = "test", Count = 100 } });
            var mockManager = new NewsRepository(mock.Object);
            var result = mockManager.GetCompanyCounts();
            Assert.NotNull(result);
        }

        [Fact]
        public void News_InsertOrUpdateCount_ShouldAssertsTrue_WhenTitleAndCompanyNotExists()
        {
            var mock = new Mock<INewsServices>();
            mock.Setup(p => p.InsertOrUpdateCount("test", 1)).Returns(0);
            var mockManager = new NewsRepository(mock.Object);
            var result = mockManager.InsertOrUpdateCount("test",1);
            Assert.Equal(0, result);
        }

        [Fact]
        public void News_InsertOrUpdateCount_ShouldAssertsTrue_WhenTitleExists()
        {
            var mock = new Mock<INewsServices>();
            mock.Setup(p => p.InsertOrUpdateCount("test2", 1)).Returns(80);
            var mockManager = new NewsRepository(mock.Object);
            var result = mockManager.InsertOrUpdateCount("test2", 1);
            Assert.Equal(80, result);
        }

        #endregion
    }
}
