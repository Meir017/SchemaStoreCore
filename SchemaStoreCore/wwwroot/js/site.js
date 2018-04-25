/* global ga, get */

(function (global) {

    global.get = function (url, asJson, callback) {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', url, true);
        xhr.onload = function () {
            if (asJson)
                callback(JSON.parse(xhr.responseText), url);
            else
                callback(xhr.responseText, url);
        };

        xhr.send();
    };

    var ul = document.querySelector("#schemalist ul");
    var p = document.getElementById("count");
    var schemas = document.getElementById("schemas");

    if (!ul || !p)
        return;

    if (schemas !== null) {
        var api = schemas.getAttribute("data-api");

        get(api, true, function (catalog) {

            p.innerHTML = p.innerHTML.replace("{0}", catalog.schemas.length);

            for (var i = 0; i < catalog.schemas.length; i++) {

                var schema = catalog.schemas[i];
                var li = document.createElement("li");
                var a = document.createElement("a");
                a.href = schema.url;
                a.title = schema.description;
                a.innerHTML = schema.name;

                li.appendChild(a);
                ul.appendChild(li);
            }

            ul.parentNode.style.maxHeight = "9999px";
        });
    }

}(typeof window !== undefined ? window : this));

ga('create', 'UA-51110136-1', 'auto');
ga('send', 'pageview');
