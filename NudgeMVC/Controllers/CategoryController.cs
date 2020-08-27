﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NudgeMVC.Data;
using NudgeMVC.Models;

namespace NudgeMVC.Controllers {
    public class CategoryController : Controller {

        private NudgeContext db;

        public IActionResult Index() {
            var data = db.Notes.OrderBy(a => a.label_id);
            var categories = db.Categories.Where(c => c.user_id == 1);
            var notes = db.Notes.ToList();
            return View();
        }
    }
}
