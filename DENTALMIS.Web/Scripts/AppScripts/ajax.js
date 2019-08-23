function AjaxResponse(data, XMLHttpRequest) {

    var ajaxResponse = { IsHtml: false, IsJavaScript: false, IsJson: false, Content: data, Success: null, Message: null, HasError: false, Reload: false };

    if (jQuery.IsContentHtml(XMLHttpRequest)) {
        ajaxResponse.IsHtml = true;
    }
    else if (jQuery.IsContentJS(XMLHttpRequest)) {
        ajaxResponse.IsJavaScript = true;
    }
    else if (jQuery.IsContentJSON(XMLHttpRequest)) {
        ajaxResponse.IsJson = true;
        ajaxResponse.Success = data.Success || null;
        ajaxResponse.Message = data.Message || null;

        jQuery.extend(ajaxResponse, data);

        if (ajaxResponse.HasError && ajaxResponse.Message && ajaxResponse.Message != "") {
            jQuery.Error(ajaxResponse.Message);
        }
        if (ajaxResponse.Reload) {
            location.reload();
        }
    }
    //console.log(ajaxResponse);

    return ajaxResponse;
};

var VykortAjaxOptions = new function () {
    this.Dialog = { Hide: null, Show: null };
};

(function ($) {
    jQuery.extend({
        GetContentType: function (XMLHttpRequest) {
            return XMLHttpRequest ? (XMLHttpRequest.getResponseHeader("content-type") || "").toLowerCase() : "";
        }
    });

    jQuery.extend({
        IsContentJS: function (XMLHttpRequest) {
            var contentType = jQuery.GetContentType(XMLHttpRequest);
            var filter = /.*javascript.*/gi
            return filter.test(contentType);
        }
    });
    jQuery.extend({
        IsContentJSON: function (XMLHttpRequest) {
            var contentType = jQuery.GetContentType(XMLHttpRequest);
            var filter = /.*json.*/gi
            return filter.test(contentType);
        }
    });
    jQuery.extend({
        IsContentHtml: function (XMLHttpRequest) {
            var contentType = jQuery.GetContentType(XMLHttpRequest);
            return contentType.indexOf("html") >= 0;
        }
    });

    jQuery.extend({
        Ajax: function (options) {
            // Force options to be an object
            options = options || { beforeSend: null, success: null, complete: null, error: null, container: null, loader: null, dialog: null };
            var url = options.url, data = options.data || {}, type = options.type || "GET", dataType = options.dataType || "text/html", onSuccess = options.onSuccess || null, onComplete = options.onComplete || null, onError = options.onError || null;
            var beforeSend = options.beforeSend || null;
            if (type == null || type === undefined) {
                type = "GET";
            }

            var loaderOptions = { loader: "body", id: "loader" + (new Date().getTime()), text: "" };
            if (options.loader) {
                if (typeof (options.loader) == "string") {
                    loaderOptions.loader = options.loader;
                }
                else {
                    loaderOptions = jQuery.extend(loaderOptions, options.loader);
                }
            }

            var ajaxRequest = $.ajax(url, {
                type: type
                //, url: url
                 , data: data
                 , cache: false
                 , beforeSend: function () {
                     if (options.beforeSend) {
                         options.beforeSend();
                     }
                     if (options.loader) {
                         //$(window).ProgressStart(loaderOptions);
                         $(loaderOptions.loader).showLoading();
                     }
                 }
                 , success: function (data, textStatus, XMLHttpRequest) {
                     var response = new AjaxResponse(data, XMLHttpRequest);

                     if (options.loader) {
                         //$(window).ProgressEnd(loaderOptions);
                     }

                     if (response.IsHtml) {
                         if (options.dialog) {
                             var maxHeight = options.dialog.maxHeight || ($(window).height() - 100);
                             var minHeight = options.dialog.minHeight || 0;

                             var maxWidth = options.dialog.maxWidth || ($(window).width() - 200);
                             var minWidth = options.dialog.minWidth || 0;

                             var dialogOptions = jQuery.extend(
                                 {
                                     modal: true
                                     , title: ""
                                     , closeOnEscape: true
                                     , resizable: false
                                     , draggable: true
                                     , hide: VykortAjaxOptions.Dialog.Hide
                                     , show: VykortAjaxOptions.Dialog.Show
                                     , close: function (event, ui) {
                                         var content = $(this);
                                         var contentParent = content.parent();
                                         content.remove();
                                         contentParent.remove();
                                         if (jQuery.validator && jQuery.validator.unobtrusive) {
                                             jQuery.validator.unobtrusive.parse(document);
                                         }
                                         if (options.dialog.closed) {
                                             options.dialog.closed();
                                         }
                                     }
                                     , open: function (event, ui) {
                                         $(".dialog-window-content", this).css({ 'max-width': maxWidth, 'min-width': minWidth, 'max-height': maxHeight, "min-height": minHeight, 'overflow-y': 'auto' });
                                     }
                                     , position: "center"
                                     , autoOpen: true
                                     , stack: true
                                     , height: "auto"
                                     , width: "auto"
                                     //, maxHeight: maxHeight
                                     , dialogClass: "mvc-dialog"
                                 }
                                 , options.dialog);
                             var div = $("<div class='ajax-dialog'></div>");
                             div.appendTo("body");
                             div.html(response.Content);
                             var dialogTitle = div.find(".dialog-ontainer:first").attr("dialog-title");
                             dialogOptions.title = dialogOptions.title || dialogTitle;

                             div.dialog(dialogOptions);
                         }
                         else if (options.container) {
                             $(options.container).html(data);
                             if (options.container == ".pane-east .content .right-panel") {
                                 setTimeout(function () { $(window).trigger("RightPanelLoaded"); }, 200);
                             }
                         }
                     }
                     if (options.success) {
                         options.success(response);
                     }
                 }
                 , complete: function (XMLHttpRequest, textStatus) {
                     if (options.complete) {
                         options.complete(new AjaxResponse(XMLHttpRequest));
                     }
                     if (options.loader) {
                         //$(window).ProgressEnd(loaderOptions);
                         $(loaderOptions.loader).hideLoading();
                     }
                 }
                 , error: function (XMLHttpRequest, textStatus, errorThrown) {
                     if (options.error) {
                         options.error(XMLHttpRequest.responseText);
                     }
                 }
            });
            return ajaxRequest;
        }
    });
    jQuery.extend({
        Abort: function (ajaxRequest) {
            if (ajaxRequest && ajaxRequest.readyState != 4) {
                ajaxRequest.abort();
            }
        }
    });

    $.fn.SerializeObject = function () {
        var form = $(this);
        form.find("input:checked").removeAttr("disabled");
        var data = form.serializeArray();
        return data;
    };

    $.fn.SerializeData = function () {
        var form = $(this);
        form.find("input:checked").removeAttr("disabled");
        var data = form.serialize();
        return data;
    };

    $.fn.Post = function (options) {
        var form = $(this);
        if (typeof (options.ignoreValidation) == "undefined") {
            if (jQuery.validator && jQuery.validator.unobtrusive) {
                form.validate();
                if (!form.valid()) {
                    return null;
                }
            }
        }
        var action = form.attr("action");
        if (typeof (options.url) == "undefined") {
            options.url = action;
        }

        options = jQuery.ajaxSetup(options);

        options.type = "POST";
        options.data = form.SerializeData();
        var request = jQuery.Ajax(options);
        return request;
    };

})(jQuery);