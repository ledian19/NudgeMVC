using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NudgeMVC.Models {
    
    public class JsTreeModel {
        public decimal? id { get; set; }
        public string? text { get; set; }
        public string? icon { get; set; }
        //public NodeState? state { get; set; }
        public List<JsTreeModel>? children { get; set; }
    }

    //public class NodeState {
    //    public bool? opened { get; set; }
    //    public bool? disabled { get; set; }
    //    public bool? selected { get; set; }

    //    public NodeState(bool opened = true,
    //                     bool disabled = false,
    //                     bool selected = false) {
    //        this.opened = opened;
    //        this.disabled = disabled;
    //        this.selected = selected;
    //    }
    //}

}
