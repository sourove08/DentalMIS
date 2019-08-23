(function ($) {    

    $.fn.Messaging = function (message, title, type, callback) {
        var alertWindow = null;
        var body = null;
        var btnOk = null;
        var btnYes = null;
        var btnNo = null;
        var result = false;
        var id = "alert_" + Math.random();
        var totalLineBreak = 0;

        var yes = "Yes";
        var no = "No";
        var ok = "Ok";

        message = message || "";
        callback = callback || null;

        Show();

        function lineBreakCount(str) {
            /* counts \n */
            try {
                return ((str.match(/[^\n]*\n[^\n]*/gi).length));
            } catch (e) {
                return 0;
            }
        }

        function Init() {
            alertWindow = $('<div id="' + id + '" class="alert-confirm"><table border="0" cellpadding="0" cellspacing="0"><tr><td valign="top"><div class="icon"></div></td><td><div class="message"></div></td></tr><tr><td colspan="2"><div class="buttons"><center><span class="ok default" title="' + ok + '"></span><span class="yes default" title="' + yes + '"></span><span class="no" title="' + no + '"></span><center></div></td></tr></table></div>').appendTo("body");
            body = alertWindow.find("div.message");
            btnOk = alertWindow.find("div.buttons .ok");
            btnYes = alertWindow.find("div.buttons .yes");
            btnNo = alertWindow.find("div.buttons .no");

            body.html("");
            btnOk.unbind("click").hide();
            btnYes.unbind("click").hide();
            btnNo.unbind("click").hide();
        };

        function Show() {
            $(document).ready(function () {

                if (typeof (message) != "string") {
                    message = message.toString();
                }

                title = title || document.title;
                type = type || "info";

                Init();

                switch (type) {
                    case "question":
                        btnYes.show();
                        btnNo.show();
                        break;
                    default:
                        btnOk.show();
                        break;
                }

                body.html(message.replace(/\n/g, "<br />"));
                totalLineBreak = body.find("br").length;

                btnOk.bind("click", function () { result = true; alertWindow.dialog("close"); });
                btnYes.bind("click", function () { result = true; alertWindow.dialog("close"); });
                btnNo.bind("click", function () { result = false; alertWindow.dialog("close"); });

                if (type == "confirm") {
                    btnYes.show();
                    btnNo.show();
                }

                alertWindow.find("div.icon").attr("class", "icon " + type);

                var width = Math.min(Math.max(body.width(), 250), 400);
                var height = Math.max(body.outerHeight(), 40);
                if (height < 300) {
                    height = height + totalLineBreak * 4;
                }
                height = Math.min(height, 300);

                if (height >= 300) {
                    body.height(height);
                }

                body.width(width);

                alertWindow.dialog(
                {
                    modal: true,
                    title: title,
                    closeOnEscape: true,
                    resizable: false,
                    draggable: true,
                    close: function (event, ui) { alertWindow.remove(); if (callback) { callback(result); } },
                    position: {
                        my: "center",
                        at: "center",
                        of: $("body"),
                        within: $("body")
                    },
                
                    autoOpen: true,
                    stack: true,
                    height: "auto",
                    width: "auto",
                    minHeight: 0,
                    show: "fadeIn",
                    hide: "fadeOut",
                    open: function (event, ui) {
                        var dialog = $(this);
                        //if (jQuery.browser.msie) {
                        //    var titlebar = dialog.parent().find(".ui-dialog-titlebar");
                        //    titlebar.width(dialog.width());
                        //}
                    },
                    dialogClass: 'dlgfixed',
                });
                $(document).keyup(function (event) {
                    var keyCode = event.keyCode;
                    if (keyCode == '13' || keyCode == '32') {
                        if (alertWindow.dialog("isOpen")) {
                            var button;
                            alertWindow.find("div.buttons .default").each(function () {
                                if ($(this).is(':visible')) {
                                    button = $(this);
                                }
                            });
                            if (button) {
                                button.click();
                            }
                        }
                    }
                });
            });
        }
        return this;
    };

    jQuery.extend({
        Info: function (message, callback) {
            $(window).Messaging(message, null, "info", callback);
        },
        Warning: function (message, callback) {
            $(window).Messaging(message, null, "warning", callback);
        },
        Error: function (message, callback) {
            $(window).Messaging(message, null, "error", callback);
        },
        Confirm: function (message, callback) {
            $(window).Messaging(message, null, "question", callback);
        }
    });
    window.alert = function(message) {
        jQuery.Info(message);
    };
})(jQuery);