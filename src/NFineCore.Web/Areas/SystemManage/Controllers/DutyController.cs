﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.Service.SystemManage;
using NFineCore.Web.Controllers;
using NFineCore.Web.Attributes;

namespace NFineCore.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class DutyController : BaseController
    {
        private readonly DutyService _dutyService;
        public DutyController(DutyService dutyService)
        {
            _dutyService = dutyService;
        }
        [PermissionCheck]
        public override IActionResult Index()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Form()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        [PermissionCheck("SystemManage_Duty_Index")]
        public ActionResult GetGridJson(string keyword)
        {
            var data = _dutyService.GetList(keyword);
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("SystemManage_Duty_Form")]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _dutyService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Duty_Form")]
        public ActionResult SubmitForm(DutyInputDto dutyInputDto, string keyValue)
        {
            _dutyService.SubmitForm(dutyInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Duty_Delete")]
        public ActionResult DeleteForm(string keyValue)
        {
            _dutyService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}