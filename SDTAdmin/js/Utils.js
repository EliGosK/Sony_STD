﻿function allownumbers(e) {
    var key = window.event ? e.keyCode : e.which;
    var keychar = String.fromCharCode(key);
    var reg = new RegExp("[0-9.]");
    if (key == 8) {
        keychar = String.fromCharCode(key);
    }
    if (key == 13) {
        key = 8;
        keychar = String.fromCharCode(key);
    }
    return reg.test(keychar);
} 