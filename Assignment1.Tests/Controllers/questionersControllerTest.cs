using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//add ref to web project controller
using Assignment1.Controllers;
using System.Web.Mvc;
using Moq;
using Assignment1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1.Tests.Controllers
{
    [TestClass]
    public class questionersControllerTest
    {
        //global variables
        questionersController controller;
        Mock<IquestionersMock> mock;
        List<questioner> questioners;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IquestionersMock>();
            //populate
            questioners = new List<questioner>
            {
                new questioner{questioner_id=1556,first_name="Tomoya", last_name="Kuroda",   phone_number="122-333-2222" ,email_address="aaa@aaa.com"},
                new questioner{questioner_id=333,first_name="Tomo", last_name="Kuro",   phone_number="222-333-2222" ,email_address="aaa@aaa.com"},
                new questioner{questioner_id=265,first_name="To", last_name="Ku",   phone_number="322-333-2222" ,email_address="aaa@aaa.com"}
            };
            mock.Setup(m => m.questioners).Returns(questioners.AsQueryable());
            controller = new questionersController(mock.Object);
        }
        // GET: questioners
        [TestMethod]
        public void IndexLoadsView()
        {
            //arrange
            //questionersController controller = new questionersController();

            //act
            ViewResult result=controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index",result.ViewName);
        }
        [TestMethod]
        public void IndexReturnsQuestioners()
        {
            //act
            var result = (List<questioner>)((ViewResult)controller.Index()).Model;
            //assert
            CollectionAssert.AreEqual(questioners, result);
        }

        // GET: questioners/Details/
        #region
        [TestMethod]
        public void DetailsNoIdLoadsError()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidIdLoadsError()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(534);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(333);

            // assert
            Assert.AreEqual("Details", result.ViewName);

        }

        [TestMethod]
        public void DetailsValidIdLoadsAlbum()
        {
            // act
            questioner result = (questioner)((ViewResult)controller.Details(333)).Model;

            // assert
            Assert.AreEqual(questioners[1], result);
            
        }
        #endregion

        // GET: questioners/Edit
        #region
        [TestMethod]
        public void EditNoId()
        {
            // arrange
            int? id = null;

            // act 
            var result = (ViewResult)controller.Edit(id);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditInvalidId()
        {
            // act
            var result = (ViewResult)controller.Edit(83);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditViewBagFirstName()
        {
            // act
            ViewResult actual = (ViewResult)controller.Edit(1556);

            // assert
            Assert.IsNotNull(actual.ViewBag.first_name);
        }

        [TestMethod]
        public void EditViewBagLastName()
        {
            // act
            ViewResult actual = (ViewResult)controller.Edit(1556);

            // assert
            Assert.IsNotNull(actual.ViewBag.last_name);
        }

        [TestMethod]
        public void EditViewLoads()
        {
            // act
            ViewResult actual = (ViewResult)controller.Edit(1556);

            // assert
            Assert.AreEqual("Edit", actual.ViewName);
        }

        [TestMethod]
        public void EditLoadsAlbum()
        {
            // act
            questioner actual = (questioner)((ViewResult)controller.Edit(1556)).Model;

            // assert
            Assert.AreEqual(questioners[0], actual);
        }
        #endregion
 

        // POST: questioners/Create
        #region
        [TestMethod]
        public void CreateValidQuestioners()
        {
            // arrange
            questioner newQuestioner = new questioner
            {
                questioner_id = 47,
                first_name = "Named",
                last_name = "Mick",
                phone_number = "111-222-3333",
                email_address="named@gmail.com"
            };

            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(newQuestioner);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateInvalidQuestioner()
        {
            // arrange
            questioner invalid = new questioner();

            // act
            controller.ModelState.AddModelError("Cannot create", "create exception");
            ViewResult result = (ViewResult)controller.Create(invalid);

            // assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateInvalidViewBagFirstName()
        {
            // arrange
            questioner invalid = new questioner();

            // act
            controller.ModelState.AddModelError("Cannot create", "create exception");
            ViewResult result = (ViewResult)controller.Create(invalid);

            // assert
            Assert.IsNotNull(result.ViewBag.first_name);
        }

        [TestMethod]
        public void CreateInvalidViewBagLastName()
        {
            // arrange
            questioner invalid = new questioner();

            // act
            controller.ModelState.AddModelError("Cannot create", "create exception");
            ViewResult result = (ViewResult)controller.Create(invalid);

            // assert
            Assert.IsNotNull(result.ViewBag.last_name);
        }
        #endregion

        // GET: questioners/Create
        #region

        [TestMethod]
        public void CreateViewLoads()
        {
            // act
            var result = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateViewBagFirstName()
        {
            // act
            ViewResult result = (ViewResult)controller.Create();

            // assert
            Assert.IsNotNull(result.ViewBag.first_name);
        }

        [TestMethod]
        public void CreateViewBagLastName()
        {
            // act
            ViewResult result = (ViewResult)controller.Create();

            // assert
            Assert.IsNotNull(result.ViewBag.last_name);
        }

        #endregion

        // POST: questioners/Edit/5
        #region

        [TestMethod]
        public void EditPostLoadsIndex()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(questioners[0]);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostViewBagFirstName()
        {
            // arrange
            questioner invalid = new questioner { questioner_id = 330 };
            controller.ModelState.AddModelError("Error", "Won't Save");

            // act
            ViewResult result = (ViewResult)controller.Edit(invalid);

            // assert
            Assert.IsNotNull(result.ViewBag.first_name);
        }

        [TestMethod]
        public void EditPostViewBagLastName()
        {
            // arrange
            questioner invalid = new questioner { questioner_id = 330 };
            controller.ModelState.AddModelError("Error", "Won't Save");

            // act
            ViewResult result = (ViewResult)controller.Edit(invalid);

            // assert
            Assert.IsNotNull(result.ViewBag.last_name);
        }

        [TestMethod]
        public void EditPostInvalidLoadsView()
        {
            // arrange
            questioner invalid = new questioner { questioner_id = 330 };
            controller.ModelState.AddModelError("Error", "Won't Save");

            // act
            ViewResult result = (ViewResult)controller.Edit(invalid);

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditPostInvalidLoadsAlbum()
        {
            // arrange
            questioner invalid = new questioner { questioner_id = 265 };
            controller.ModelState.AddModelError("Error", "Won't Save");

            // act
            questioner result = (questioner)((ViewResult)controller.Edit(invalid)).Model;

            // assert
            Assert.AreEqual(invalid, result);
        }

        #endregion
    }
}
