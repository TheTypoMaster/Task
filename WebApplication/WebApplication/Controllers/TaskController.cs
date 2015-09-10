﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using WebApplication.Models;
using WebApplication.Infrastructure.Mappers;
using System.IO;
namespace WebApplication.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IAuthorizationService authorizationService;
        private readonly ITagService tagService;
        public TaskController(ITaskService taskService, IAuthorizationService authorizationService, ITagService tagService)
        {
            this.taskService = taskService;
            this.authorizationService = authorizationService;
            this.tagService = tagService;
        }
        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTask(CreateTaskModel model)
        {
            if (ModelState.IsValid)
            {
                var auth = authorizationService.Get(x => x.Email == User.Identity.Name);
                int id = auth.UserId;
                taskService.CreateTask(model.ToTaskEntity(id,tagService.CreateTags(model.Tag).ToList()));
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public string GetTags(string data)
        {
            List<string> tags = tagService.GetTags(data).ToList();
            string tagsToAjax = string.Empty;
            foreach (var tag in tags)
                tagsToAjax += tag + "#";
            return tagsToAjax;
        }
        [HttpPost]
        public void Upload()
        {
            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);
            var fileName = Request.Headers["X-File-Name"];
            var fileSize = Request.Headers["X-File-Size"];
            var fileType = Request.Headers["X-File-Type"];
            var bytList = bytes.ToList();
            bytList = bytList.Skip(bytes.Length - Int32.Parse(fileSize) - 46).ToList();
            using (FileStream fstream = new FileStream(@"d:\"+fileName, FileMode.OpenOrCreate))
            {
                fstream.Write(bytList.ToArray(), 0, Int32.Parse(fileSize));
            }
        }
	}
}