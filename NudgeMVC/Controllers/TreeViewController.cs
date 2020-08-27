﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NudgeMVC.Data;
using NudgeMVC.Models;

namespace NudgeMVC.Controllers {
    
    public class TreeViewController : Microsoft.AspNetCore.Mvc.Controller {
        
        public string GetTree() {
            var categories = db.Categories.Where(c => c.user_id == 1);
            var myCategories = categories.ToList();
            var categoriesList = new List<JsTreeModel>();
            var root = new JsTreeModel {
                text = "Notes",
                id = 1,
                icon = "fas fa-folder-open text-dark pt-0",
                children = new List<JsTreeModel>()
            };
            categoriesList.Add(root);

            for (int i = 0; i < myCategories.Count; i++) {   //foreach root node call children recursively
                if (myCategories[i].parent_category == null && myCategories[i].category_id != 1) {
                    CallJsTree(myCategories[i], myCategories, root);
                }
            }
            var res = JsonConvert.SerializeObject(categoriesList);
            //var res = new System.Web.Mvc.JsonResult { Data = categoriesList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return res;
        }

        private NudgeContext db;

        public IActionResult Index() {
            //var data = db.Notes.OrderBy(a => a.label_id);
            //var notes = db.Notes.ToList();
            var res = GetTree();
            return View();
        }

        public TreeViewController(NudgeContext _db) {
            db = _db;
        }

        public void CallJsTree(Category node, List<Category> myCategories, JsTreeModel parent) {
            var parentToBe = AddNode(node, parent);
            var children = GetChildren(node, myCategories);
            for (var i = 0; i < children.Count; i++) {
                CallJsTree(children[i], myCategories, parentToBe); //call children of current node
            }
        }

        public JsTreeModel AddNode(Category child, JsTreeModel parent) {
            var newChild = new JsTreeModel();
            newChild.text = child.category_name;
            newChild.id = child.category_id;
            newChild.icon = "fas fa-folder-open text-dark pt-0";
            if (parent.children == null) {
                parent.children = new List<JsTreeModel>();
            }
            parent.children.Add(newChild);
            return newChild;
        }

        public List<Category> GetChildren(Category category, List<Category> myCategories) {
            var children = new List<Category>();
            foreach (var cat in myCategories) {
                if (cat.parent_category == category.category_id) {
                    children.Add(cat);
                }
            }
            return children;
        }

    }
}
