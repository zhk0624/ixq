﻿using System;
using System.Web.Mvc;
using Ixq.Core.Repository;
using Ixq.Demo.Entities;

namespace Ixq.Demo.Web.Controllers
{
    [Authorize]
    public class TestController : BaseController
    {
        private readonly IRepository<ProductType> _productTypeRepository;

        public TestController(IRepository<ProductType> productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        } 

        // GET: Test
        public ActionResult Index()
        {
            var pt = _productTypeRepository.SqlQuerySingle(Guid.Parse("2FE82B0D-C421-484B-A9CC-8D6E4520EBBC"));


            return View();
        }

        public ActionResult Exception()
        {
            throw new Exception("Exp");
            return View();
        }
    }
}