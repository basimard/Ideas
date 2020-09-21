using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using Ideas.Cms;
using Ideas.Cms.Dtos;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ideas.Tests.Cms
{
    public class CmsAppService_Tests : IdeasTestBase
    {
        ICmsContentAppService _cmsAppService;

        public CmsAppService_Tests()
        {
            _cmsAppService = Resolve<ICmsContentAppService>();
        }
        [Fact]
        public async Task GetAll_Test()
        {
            //Assert

            // Act
            var output = await _cmsAppService.GetAll();

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }
        [Fact]
        public async Task GetOne_Test()
        {
            //Assert
            EntityDto input = new EntityDto();
            input.Id = 2;
            // Act
            var output = await _cmsAppService.GetCMSContent(input);

            // Assert
            UsingDbContext(context =>
            {

                var page = context.CmsContents.FirstOrDefault(e => e.Id == input.Id);
                page.EntityEquals(output);
            });

        }

        [Fact]
        public async Task Should_Create_Page()
        {
            //Arrange
            var pageTitle = "Test Title 4";
            var pageContent = "A description for title 4";
            //Act
            await _cmsAppService.InsertOrUpdateCMSContent(new InsertOrUpdateCmsInput
            {
                Id = 0,
                PageTitle = pageTitle,
                PageContent = pageContent,

            });

            //Assert
            UsingDbContext(context =>
              {

                  var page = context.CmsContents.FirstOrDefault(e => e.PageTitle == pageTitle &&
                  e.PageContent == pageContent);
                  page.ShouldNotBeNull();
              });
        }

        [Fact]
        public async Task Should_Update_Page()
        {
            var updatedTitle = "Title 1 Updated";
            var updatedContent = "Content 1 Updated";
            int updatedPageId = 1;
            CmsContent updatingPage = new CmsContent();


            var updated = await _cmsAppService.InsertOrUpdateCMSContent(new InsertOrUpdateCmsInput
            {
                Id = 1,
                PageTitle = updatedTitle,
                PageContent = updatedContent,

            });

            //Assert
            UsingDbContext(context =>
            {

                var page = context.CmsContents.
                FirstOrDefault(e => e.Id == updatedPageId &&
                e.PageContent == updatedContent && e.PageTitle == updatedTitle);
                page.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task Input_Title_Max_Char()
        {
            //Assert

            var page = new InsertOrUpdateCmsInput();
            page.Id = 0;
            page.PageTitle = RandomString(151);
            page.PageContent = RandomString(11);

            // Assert
            await Assert.ThrowsAsync<AbpValidationException>(async () => await _cmsAppService.InsertOrUpdateCMSContent(page));

        }

        [Fact]
        public async Task Input_Title_Min_Char()
        {
            //Assert
            var page = new InsertOrUpdateCmsInput();
            page.Id = 0;
            page.PageTitle = RandomString(1);
            page.PageContent = RandomString(11);

            // Assert
            await Assert.ThrowsAsync<AbpValidationException>(async () => await _cmsAppService.InsertOrUpdateCMSContent(page));

        }

        [Fact]
        public async Task Input_Content_Min_Char()
        {
            //Assert

            var page = new InsertOrUpdateCmsInput();
            page.Id = 0;
            page.PageTitle = RandomString(12);
            page.PageContent = RandomString(3);

            // Assert
            await Assert.ThrowsAsync<AbpValidationException>(async () => await _cmsAppService.InsertOrUpdateCMSContent(page));

        }

        [Fact]
        public async Task Input_Content_Max_Char()
        {
            //Assert
            var page = new InsertOrUpdateCmsInput();
            page.Id = 0;
            page.PageTitle = RandomString(10);
            page.PageContent = RandomString(2001);

            // Assert
            await Assert.ThrowsAsync<AbpValidationException>(async () => await _cmsAppService.InsertOrUpdateCMSContent(page));

        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
