using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NudgeMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NudgeMVC.Controllers {
    public class NotesController : Controller {

        private NudgeContext db;

        public NotesController(NudgeContext _db) {
            db = _db;
        }
        [HttpPost]
        public JsonResult DisplayNotes([FromBody] string id) {
            var myCategories = db.Categories.Where(x => x.user_id == 1);
            int catId = Convert.ToInt32(id);

            GetChildrenByParentId(myCategories.First(i => i.category_id == catId), myCategories.ToList());
            string[] childrenList = HttpContext.Session.GetString("children").Split(',');

            Array.Resize(ref childrenList, childrenList.Length - 1);

            List <Models.Note> notesList = new List<Models.Note>();            
            foreach (var child in childrenList) {
                var category = Convert.ToInt32(child);
                var notesByCat = db.Notes.Where(x => x.user_id == 1 && x.category_id == category);
                foreach (var note in notesByCat) {
                    notesList.Add(note);
                }
            }
            return Json(notesList);
            //return JsonConvert.SerializeObject(notesList);
            /*return JsonConvert.SerializeObject(new {
                errorMsg = "SUCCESS",
                notesStringResponse = notesList.ToString(),
                categoryName = myCategories.First(i => i.category_id == catId).category_name,
                categoryId = catId
            });*/
        }

        public void GetChildrenByParentId(Models.Category node, List<Models.Category> myCategories) {
            if (HttpContext.Session.GetString("children") == null) {
                HttpContext.Session.SetString("children", "");
            }
            HttpContext.Session.SetString("children", node.category_id.ToString() + ", ");
            var getParentChildren = new TreeViewController(db).GetChildren(node.category_id, myCategories);
            foreach (var child in getParentChildren) {
                GetChildrenByParentId(child, myCategories);
            }
        }
    }
}
