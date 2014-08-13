/// <reference path="jquery-1.10.2.js" />
/// <reference path="knockout-3.1.0.js" />

//For todays date;
Date.prototype.today = function () {
    return ((this.getDate() < 10) ? "0" : "") + this.getDate() + "/" + (((this.getMonth() + 1) < 10) ? "0" : "") + (this.getMonth() + 1) + "/" + this.getFullYear()
};
//For the time now
Date.prototype.timeNow = function () {
    return ((this.getHours() < 10) ? "0" : "") + this.getHours() + ":" + ((this.getMinutes() < 10) ? "0" : "") + this.getMinutes() + ":" + ((this.getSeconds() < 10) ? "0" : "") + this.getSeconds();
};

function NorthboundViewModel() {
    var self = this;

    //we need this only in case we directly point to another machine using CORS
    self.defaultUrl = "http://localhost:8080/";

    //setup ajax global settings
    $.ajaxSetup({
        xhrFields: { withCredentials: true }, //this is needed for authorization/CORS
        beforeSend: function (xhr, settings) {
            settings.url = "http://localhost:8080/" + settings.url;
        }
    });

    //enable CORS
    $.ajax.cors = true;

    self.eventsResult = ko.observable();
    self.sendPing = function () {
        var url = "api/authorized";
        $.ajax({
            url: url,
            type: "GET",
            contentType: 'application/json', //important
            statusCode: {
                200: function (data) {
                    document.open();
                    document.write(data);
                    document.close();
                }
            }
        });
    };

    //diagnostics

    self.lastPing = ko.observable();

    //ping
    self.checkServer = function () {
        self.lastPing("ping... please wait");
        $.ajax({
            url: "api/unauthorized/",
            type: "GET",
            success: function (response) {
                var newDate = new Date();
                var datetime = "Last ping: " + newDate.today() + " @ " + newDate.timeNow();
                self.lastPing(datetime);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                self.lastPing("Error: " + thrownError);
            }
        });
    }
};

$(function () {
    var viewModel = new NorthboundViewModel();
    ko.applyBindings(viewModel);
});